using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fahasa.Data;
using Fahasa.Models;

namespace Fahasa.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")] // Uncomment when Roles are set up
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string search, string fromDate, string toDate, OrderStatus? status)
        {
            var query = _context.Orders
                .Include(o => o.User)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                search = search.Trim();
                query = query.Where(o => o.Phone.Contains(search));
            }

            if (status.HasValue)
            {
                query = query.Where(o => o.Status == status);
            }

            if (!string.IsNullOrEmpty(fromDate))
            {
                if (DateTime.TryParse(fromDate, out DateTime from))
                {
                     query = query.Where(o => o.CreatedAt >= from.Date);
                }
            }

            if (!string.IsNullOrEmpty(toDate))
            {
                if (DateTime.TryParse(toDate, out DateTime to))
                {
                    // Include the whole day of 'to' date
                     query = query.Where(o => o.CreatedAt < to.Date.AddDays(1));
                }
            }

            var orders = await query
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();

            ViewBag.Search = search;
            ViewBag.FromDate = fromDate;
            ViewBag.ToDate = toDate;
            ViewBag.Status = status;

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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatus(int id, OrderStatus status)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems) // Include items to restore stock
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            // Restore stock if cancelling
            if (status == OrderStatus.Cancelled && order.Status != OrderStatus.Cancelled)
            {
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
            }

            order.Status = status;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
