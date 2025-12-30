using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fahasa.Data;
using Fahasa.Models;
using Fahasa.Services;

namespace Fahasa.Areas.Customer.Controllers
{
    public class CartItemViewModel
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }
        public decimal FinalPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }

    [Area("Customer")]
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly CartService _cartService;

        public CartController(ApplicationDbContext context, CartService cartService)
        {
            _context = context;
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            var cartItems = _cartService.GetCartItems();
            
            if (cartItems == null || !cartItems.Any())
            {
                ViewBag.CartItems = new List<CartItemViewModel>();
                ViewBag.TotalPrice = 0;
                ViewBag.TotalItems = 0;
                return View();
            }

            var bookIds = cartItems.Select(x => x.BookId).ToList();
            
            var books = _context.Books
                .Include(b => b.Category)
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .Where(b => bookIds.Contains(b.Id) && b.IsActive)
                .ToList();

            var cartViewModels = new List<CartItemViewModel>();
            foreach (var item in cartItems)
            {
                var book = books.FirstOrDefault(b => b.Id == item.BookId);
                if (book == null) continue;

                var finalPrice = book.Price * (1 - book.DiscountPercent / 100m);
                cartViewModels.Add(new CartItemViewModel
                {
                    Book = book,
                    Quantity = item.Quantity,
                    FinalPrice = finalPrice,
                    TotalPrice = finalPrice * item.Quantity
                });
            }

            ViewBag.CartItems = cartViewModels;
            ViewBag.TotalPrice = _cartService.GetTotalPrice(_context);
            ViewBag.TotalItems = _cartService.GetTotalItems();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddToCart(int bookId, int quantity = 1)
        {
            if (quantity <= 0)
            {
                // TempData["ErrorMessage"] = "Số lượng phải lớn hơn 0.";
                return RedirectToAction("Index", "Category");
            }

            var book = _context.Books.FirstOrDefault(b => b.Id == bookId && b.IsActive);
            if (book == null)
            {
                // TempData["ErrorMessage"] = "Sản phẩm không tồn tại hoặc đã ngừng kinh doanh.";
                return RedirectToAction("Index", "Category");
            }

            var existingCartItems = _cartService.GetCartItems();
            var existingItem = existingCartItems.FirstOrDefault(x => x.BookId == bookId);
            var currentQuantity = existingItem?.Quantity ?? 0;
            var newQuantity = currentQuantity + quantity;

            if (newQuantity > book.StockQuantity)
            {
                TempData["Error"] = $"Số lượng vượt quá tồn kho. Hiện có {book.StockQuantity} sản phẩm.";
                return RedirectToAction("Index", "Category");
            }

            _cartService.AddToCart(bookId, quantity);
            
            // Verify cart was saved
            var verifyItems = _cartService.GetCartItems();
            if (!verifyItems.Any(x => x.BookId == bookId))
            {
                TempData["Error"] = "Có lỗi xảy ra khi thêm sản phẩm vào giỏ hàng. Vui lòng thử lại.";
                return RedirectToAction("Index", "Category");
            }
            
            TempData["Success"] = "Đã thêm sản phẩm vào giỏ hàng thành công";
            return RedirectToAction("Index", "Category");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveFromCart(int bookId)
        {
            _cartService.RemoveFromCart(bookId);
            TempData["Success"] = "Đã xóa sản phẩm khỏi giỏ hàng.";

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateQuantity(int bookId, int quantity)
        {
            if (quantity <= 0)
            {
                return RemoveFromCart(bookId);
            }

            var book = _context.Books.FirstOrDefault(b => b.Id == bookId && b.IsActive);
            if (book == null)
            {
                TempData["Error"] = "Sản phẩm không tồn tại hoặc đã ngừng kinh doanh.";
                return RedirectToAction(nameof(Index));
            }

            if (quantity > book.StockQuantity)
            {
                TempData["Error"] = $"Số lượng vượt quá tồn kho. Hiện có {book.StockQuantity} sản phẩm.";
                return RedirectToAction(nameof(Index));
            }

            _cartService.UpdateQuantity(bookId, quantity);
            TempData["Success"] = "Đã cập nhật số lượng sản phẩm.";

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ClearCart()
        {
            _cartService.ClearCart();
            TempData["Success"] = "Đã xóa toàn bộ giỏ hàng.";

            return RedirectToAction(nameof(Index));
        }
    }
}

