using Fahasa.Data;
using Fahasa.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Security.Claims;

namespace Fahasa.Services
{
    public class CartService
    {
        private const string CartSessionKey = "Cart";
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDbContext _context;

        public CartService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        private ISession GetSession()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext == null)
                return null;

            return httpContext.Session;
        }

        private string GetUserId()
        {
            return _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        private bool IsAuthenticated()
        {
            return _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated == true;
        }

        private List<CartItem> GetCartItemsFromSession()
        {
            var session = GetSession();
            if (session == null)
                return new List<CartItem>();

            try
            {
                var cartJson = session.GetString(CartSessionKey);
                if (string.IsNullOrEmpty(cartJson))
                    return new List<CartItem>();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                return JsonSerializer.Deserialize<List<CartItem>>(cartJson, options) ?? new List<CartItem>();
            }
            catch (Exception)
            {
                return new List<CartItem>();
            }
        }

        private void SaveCartItemsToSession(List<CartItem> items)
        {
            var session = GetSession();
            if (session == null)
                return;

            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = false
                };
                var cartJson = JsonSerializer.Serialize(items, options);
                session.SetString(CartSessionKey, cartJson);
            }
            catch (Exception)
            {
                // Simple throw or log
                throw;
            }
        }

        public List<CartItem> GetCartItems()
        {
            if (IsAuthenticated())
            {
                var userId = GetUserId();
                if (string.IsNullOrEmpty(userId)) return new List<CartItem>();

                return _context.Carts
                    .Where(c => c.UserId == userId)
                    .Select(c => new CartItem(c.BookId, c.Quantity))
                    .ToList();
            }

            return GetCartItemsFromSession();
        }

        public void AddToCart(int bookId, int quantity)
        {
            if (IsAuthenticated())
            {
                var userId = GetUserId();
                if (string.IsNullOrEmpty(userId)) return;

                var existingItem = _context.Carts.FirstOrDefault(c => c.UserId == userId && c.BookId == bookId);
                if (existingItem != null)
                {
                    existingItem.Quantity += quantity;
                }
                else
                {
                    _context.Carts.Add(new Cart
                    {
                        UserId = userId,
                        BookId = bookId,
                        Quantity = quantity
                    });
                }
                _context.SaveChanges();
            }
            else
            {
                var items = GetCartItemsFromSession();
                var existingItem = items.FirstOrDefault(x => x.BookId == bookId);

                if (existingItem != null)
                {
                    existingItem.Quantity += quantity;
                }
                else
                {
                    items.Add(new CartItem(bookId, quantity));
                }

                SaveCartItemsToSession(items);
            }
        }

        public void RemoveFromCart(int bookId)
        {
            if (IsAuthenticated())
            {
                var userId = GetUserId();
                if (string.IsNullOrEmpty(userId)) return;

                var item = _context.Carts.FirstOrDefault(c => c.UserId == userId && c.BookId == bookId);
                if (item != null)
                {
                    _context.Carts.Remove(item);
                    _context.SaveChanges();
                }
            }
            else
            {
                var items = GetCartItemsFromSession();
                items.RemoveAll(x => x.BookId == bookId);
                SaveCartItemsToSession(items);
            }
        }

        public void UpdateQuantity(int bookId, int quantity)
        {
            if (quantity <= 0)
            {
                RemoveFromCart(bookId);
                return;
            }

            if (IsAuthenticated())
            {
                var userId = GetUserId();
                if (string.IsNullOrEmpty(userId)) return;

                var item = _context.Carts.FirstOrDefault(c => c.UserId == userId && c.BookId == bookId);
                if (item != null)
                {
                    item.Quantity = quantity;
                    _context.SaveChanges();
                }
            }
            else
            {
                var items = GetCartItemsFromSession();
                var existingItem = items.FirstOrDefault(x => x.BookId == bookId);

                if (existingItem != null)
                {
                    existingItem.Quantity = quantity;
                    SaveCartItemsToSession(items);
                }
            }
        }

        public void ClearCart()
        {
            if (IsAuthenticated())
            {
                var userId = GetUserId();
                if (string.IsNullOrEmpty(userId)) return;

                var items = _context.Carts.Where(c => c.UserId == userId);
                _context.Carts.RemoveRange(items);
                _context.SaveChanges();
            }
            else
            {
                SaveCartItemsToSession(new List<CartItem>());
            }
        }

        public int GetTotalItems()
        {
            return GetCartItems().Sum(x => x.Quantity);
        }

        public decimal GetTotalPrice(ApplicationDbContext context)
        {
            var items = GetCartItems();
            if (!items.Any())
                return 0;

            var bookIds = items.Select(x => x.BookId).ToList();
            var books = context.Books
                .Where(b => bookIds.Contains(b.Id) && b.IsActive)
                .ToList();

            decimal total = 0;
            foreach (var item in items)
            {
                var book = books.FirstOrDefault(b => b.Id == item.BookId);
                if (book != null)
                {
                    var finalPrice = book.Price * (1 - book.DiscountPercent / 100m);
                    total += finalPrice * item.Quantity;
                }
            }

            return total;
        }

        public void MergeSessionToDatabase(string userId)
        {
            var sessionItems = GetCartItemsFromSession();
            if (!sessionItems.Any()) return;

            var dbItems = _context.Carts.Where(c => c.UserId == userId).ToList();

            foreach (var item in sessionItems)
            {
                var existing = dbItems.FirstOrDefault(c => c.BookId == item.BookId);
                if (existing != null)
                {
                    existing.Quantity += item.Quantity;
                }
                else
                {
                    _context.Carts.Add(new Cart
                    {
                        UserId = userId,
                        BookId = item.BookId,
                        Quantity = item.Quantity
                    });
                }
            }
            
            _context.SaveChanges();
            
            // Clear session cart after merge
            SaveCartItemsToSession(new List<CartItem>());
        }
    }
}
