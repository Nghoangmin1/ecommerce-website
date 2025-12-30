using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fahasa.Data;
using Fahasa.Models;

namespace Fahasa.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Shipper")]
    public class ShipperController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShipperController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchOrderNumber)
        {
            if (string.IsNullOrEmpty(searchOrderNumber))
            {
                return View();
            }

            // Clean input
            searchOrderNumber = searchOrderNumber.Trim();

            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .Include(o => o.User)
                .FirstOrDefaultAsync(o => o.OrderNumber == searchOrderNumber);

            if (order == null)
            {
                ViewBag.Error = "Không tìm thấy đơn hàng với mã này.";
                return View();
            }

            // Strictly allow only Shipping orders
            if (order.Status != OrderStatus.Shipping)
            {
                ViewBag.Error = "Không tìm thấy đơn hàng với mã này.";
                return View();
            }

            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus(int orderId, string status)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == orderId);
            if (order == null)
            {
                return NotFound();
            }

            // Backend validation: Only allow updates if current status is Shipping
            if (order.Status != OrderStatus.Shipping)
            {
                TempData["Error"] = "Chỉ có thể cập nhật đơn hàng đang giao.";
                return RedirectToAction("Index");
            }

            if (status == "Delivered")
            {
                order.Status = OrderStatus.Delivered;
                order.DeliveredAt = DateTime.Now;
                order.PaymentStatus = PaymentStatus.Paid; // Assume payment collected if COD, or already paid
                TempData["Success"] = $"Đơn hàng {order.OrderNumber} đã giao thành công.";
            }
            else if (status == "Cancelled")
            {
                order.Status = OrderStatus.Cancelled;
                order.CancelledAt = DateTime.Now;
                order.CancelReason = "Khách hàng hủy";
                
                // Restore Stock
                foreach (var item in order.OrderItems) // Order is already included with OrderItems in Index? No, wait. UpdateStatus fetches it. 
                                                       // We need to fetch it here or modify UpdateStatus to include it.
                                                       // Wait, previous code in ShipperController.UpdateStatus did NOT include OrderItems.
                                                       // I need to update the fetch logic first.
                {
                    var book = await _context.Books.FindAsync(item.BookId);
                    if (book != null)
                    {
                        book.StockQuantity += item.Quantity;
                        book.SoldCount -= item.Quantity;
                        _context.Books.Update(book);
                    }
                }

                TempData["Success"] = $"Đơn hàng {order.OrderNumber} đã bị hủy.";
            }

            order.UpdatedAt = DateTime.Now;
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();

            // Redirect back to Index with empty search to clear view or keep it? 
            // Better to clear or show updated. Let's redirect to Index.
            return RedirectToAction("Index");
        }
    }
}
