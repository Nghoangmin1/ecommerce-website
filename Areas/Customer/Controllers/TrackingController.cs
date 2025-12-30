using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Fahasa.Data;
using System.Security.Claims;
using Fahasa.Models;

namespace Fahasa.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class TrackingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrackingController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(System.Security.Claims.ClaimTypes.NameIdentifier);
            
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            var orders = await _context.Orders
                .Include(o => o.OrderItems)
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();

            return View(orders);
        }

        public async Task<IActionResult> Details(int id)
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

        [HttpPost]
        public async Task<IActionResult> CancelOrder(int id, string cancelReason)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems) // Include items to restore stock
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            // Only allow cancellation if status is Pending
            if (order.Status != OrderStatus.Pending)
            {
                TempData["ErrorMessage"] = "Đơn hàng chỉ có thể hủy khi đang chờ xác nhận.";
                return RedirectToAction("Details", new { id = id });
            }

            order.Status = OrderStatus.Cancelled;
            order.CancelReason = cancelReason ?? "Khách hàng hủy";
            order.CancelledAt = DateTime.Now;
            order.UpdatedAt = DateTime.Now;

            // Restore Stock
            foreach (var item in order.OrderItems)
            {
                var book = await _context.Books.FindAsync(item.BookId);
                if (book != null)
                {
                    book.StockQuantity += item.Quantity;
                    book.SoldCount -= item.Quantity;
                    _context.Books.Update(book);
                }
            }

            _context.Orders.Update(order);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Đơn hàng đã được hủy thành công.";
            return RedirectToAction("Details", new { id = id });
        }
    }
}
