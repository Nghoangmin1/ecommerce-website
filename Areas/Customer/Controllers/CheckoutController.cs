using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Fahasa.Data;
using Fahasa.Models;
using Fahasa.Services;
using Fahasa.ViewModels;
using System.Security.Claims;

namespace Fahasa.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly CartService _cartService;

        public CheckoutController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, CartService cartService)
        {
            _context = context;
            _userManager = userManager;
            _cartService = cartService;
        }

        public async Task<IActionResult> Index(int? bookId, int? quantity)
        {
            var viewModel = new CheckoutViewModel
            {
                Order = new Order(),
                Icon = new List<CheckoutItemViewModel>()
            };

            List<CartItem> cartItems = new List<CartItem>();

            // 1. Determine Source (One-click Buy vs Cart)
            if (bookId.HasValue && quantity.HasValue && quantity.Value > 0)
            {
                // Buy Now mode
                var book = await _context.Books
                    .Include(b => b.Category)
                    .Include(b => b.Author)
                    .FirstOrDefaultAsync(b => b.Id == bookId.Value && b.IsActive);

                if (book != null)
                {
                    cartItems.Add(new CartItem { BookId = book.Id, Quantity = quantity.Value });
                    
                    // Pass these to View so they can be posted back to PlaceOrder
                    ViewBag.BuyNowBookId = bookId.Value;
                    ViewBag.BuyNowQuantity = quantity.Value;
                }
            }
            else
            {
                // Normal Cart mode
                cartItems = _cartService.GetCartItems();
                if (cartItems == null || !cartItems.Any())
                {
                    return RedirectToAction("Index", "Cart");
                }
            }

            var bookIds = cartItems.Select(x => x.BookId).ToList();
            // Fetch books again to be sure (if came from cart service, books list might be needed)
            // Note: In Buy Now mode, we already fetched the book above, but re-fetching here for code simplicity and bulk handling is fine.
            var books = await _context.Books
                .Include(b => b.Category)
                .Include(b => b.Author)
                .Where(b => bookIds.Contains(b.Id) && b.IsActive)
                .ToListAsync();

            decimal totalAmount = 0;

            foreach (var item in cartItems)
            {
                var book = books.FirstOrDefault(b => b.Id == item.BookId);
                if (book != null)
                {
                    decimal finalPrice = book.Price * (1 - book.DiscountPercent / 100m);
                    decimal itemTotal = finalPrice * item.Quantity;

                    viewModel.Icon.Add(new CheckoutItemViewModel
                    {
                        Book = book,
                        Quantity = item.Quantity,
                        FinalPrice = finalPrice,
                        TotalPrice = itemTotal
                    });

                    totalAmount += itemTotal;
                }
            }
            viewModel.TotalAmount = totalAmount;
            viewModel.Order.Subtotal = totalAmount;
            viewModel.Order.TotalAmount = totalAmount;

            // 2. Handle User Info (Guest vs Logged In)
            if (User.Identity.IsAuthenticated)
            {
                var userId = _userManager.GetUserId(User);
                var user = await _userManager.FindByIdAsync(userId);
                
                if (user != null)
                {
                    viewModel.Order.UserId = userId;
                    viewModel.Order.RecipientName = user.FullName ?? "";
                    viewModel.Order.Phone = user.PhoneNumber ?? "";

                    // Auto-fill address
                    var existingAddress = await _context.Addresses
                        .Where(a => a.UserId == userId)
                        .OrderByDescending(a => a.IsDefault) // Default first, then others
                        .FirstOrDefaultAsync();

                    if (existingAddress != null)
                    {
                        viewModel.Order.RecipientName = existingAddress.ReceiverName;
                        viewModel.Order.Phone = existingAddress.PhoneNumber;
                        viewModel.Order.Province = existingAddress.City;
                        viewModel.Order.District = existingAddress.District;
                        viewModel.Order.Ward = existingAddress.Ward;
                        viewModel.Order.AddressDetail = existingAddress.StreetAddress;
                    }
                }
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder(CheckoutViewModel viewModel, int? buyNowBookId, int? buyNowQuantity)
        {
            List<CartItem> cartItems = new List<CartItem>();

            // 1. Determine Source
            if (buyNowBookId.HasValue && buyNowQuantity.HasValue && buyNowQuantity.Value > 0)
            {
                 // Buy Now mode
                 cartItems.Add(new CartItem { BookId = buyNowBookId.Value, Quantity = buyNowQuantity.Value });
            }
            else
            {
                // Normal Cart mode
                cartItems = _cartService.GetCartItems();
                if (cartItems == null || !cartItems.Any())
                {
                    return RedirectToAction("Index", "Cart");
                }
            }

            // Recalculate totals from DB (security)
            var bookIds = cartItems.Select(x => x.BookId).ToList();
            var books = await _context.Books.Where(b => bookIds.Contains(b.Id)).ToListAsync();

            decimal totalAmount = 0;
            var orderItems = new List<OrderItem>();

            foreach (var item in cartItems)
            {
                var book = books.FirstOrDefault(b => b.Id == item.BookId);
                if (book != null)
                {
                    // Check stock again here if needed, but for now assuming valid
                    decimal finalPrice = book.Price * (1 - book.DiscountPercent / 100m);
                    decimal itemTotal = finalPrice * item.Quantity;

                    orderItems.Add(new OrderItem
                    {
                        BookId = book.Id,
                        ProductName = book.Name,
                        Quantity = item.Quantity,
                        UnitPrice = finalPrice,
                        DiscountPercent = book.DiscountPercent,
                        TotalPrice = itemTotal
                    });

                    totalAmount += itemTotal;
                }
            }

            // Create Order
            // Create Order
            var order = viewModel.Order;

            // Trim string properties
            if (order.RecipientName != null) order.RecipientName = order.RecipientName.Trim();
            if (order.Phone != null) order.Phone = order.Phone.Trim();
            if (order.Province != null) order.Province = order.Province.Trim();
            if (order.District != null) order.District = order.District.Trim();
            if (order.Ward != null) order.Ward = order.Ward.Trim();
            if (order.AddressDetail != null) order.AddressDetail = order.AddressDetail.Trim();

            order.CreatedAt = DateTime.Now;
            order.UpdatedAt = DateTime.Now;
            order.Status = OrderStatus.Pending;
            order.OrderNumber = DateTime.Now.ToString("yyyyMMddHHmmss") + new Random().Next(1000, 9999);
            order.Subtotal = totalAmount;
            order.TotalAmount = totalAmount; // + ShippingFee if any

            if (User.Identity.IsAuthenticated)
            {
                var userId = _userManager.GetUserId(User);
                order.UserId = userId;

                // Auto-save address if user has no addresses
                var hasAddress = await _context.Addresses.AnyAsync(a => a.UserId == userId);
                if (!hasAddress)
                {
                    var newAddress = new Address
                    {
                        UserId = userId,
                        ReceiverName = order.RecipientName,
                        PhoneNumber = order.Phone,
                        City = order.Province,
                        District = order.District,
                        Ward = order.Ward,
                        StreetAddress = order.AddressDetail,
                        IsDefault = true
                    };
                    _context.Addresses.Add(newAddress);
                    // Don't need separate SaveChanges here, transaction commit will handle it
                }
            }

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Orders.Add(order);
                    await _context.SaveChangesAsync();

                    foreach (var orderItem in orderItems)
                    {
                        // VALIDATE AND DEDUCT STOCK
                        var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == orderItem.BookId);
                        if (book == null)
                        {
                            throw new Exception($"Sách '{orderItem.ProductName}' không còn tồn tại.");
                        }

                        if (book.StockQuantity < orderItem.Quantity)
                        {
                            throw new Exception($"Sách '{book.Name}' không đủ số lượng tồn kho (Còn lại: {book.StockQuantity}).");
                        }

                        book.StockQuantity -= orderItem.Quantity;
                        book.SoldCount += orderItem.Quantity;
                        _context.Books.Update(book);

                        orderItem.OrderId = order.Id;
                        _context.OrderItems.Add(orderItem);
                    }
                    await _context.SaveChangesAsync();
                    
                    // Save new address if added above (EF tracks it in the context)
                    // Note: If we added it to _context.Addresses above, SaveChangesAsync here will persist it.

                    // ONLY clear cart if it was a normal cart checkout
                    if (!buyNowBookId.HasValue)
                    {
                        _cartService.ClearCart();
                    }

                    transaction.Commit();
                    
                    return RedirectToAction("PlaceOrder", new { id = order.Id });
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    // Log error
                    ModelState.AddModelError("", ex.Message); // Show specific error message (e.g., Out of stock)
                    // Re-populate view model for redisplay
                     viewModel.Icon = new List<CheckoutItemViewModel>(); 
                     // TODO: Re-populate viewModel.Icon properly if we want to show items on error page
                     // For now just returning View
                    return View("Index", viewModel);
                }
            }
        }

        public async Task<IActionResult> PlaceOrder(int id)
        {
            var order = await _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Book)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }
    }
}
