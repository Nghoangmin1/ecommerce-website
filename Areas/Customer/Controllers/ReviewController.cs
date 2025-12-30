using Fahasa.Data;
using Fahasa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fahasa.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ReviewController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReviewController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit(int bookId, string phone, int rating, string comment)
        {
            if (string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(comment) || rating < 1 || rating > 5)
            {
                return Json(new { success = false, message = "Vui lòng nhập đầy đủ thông tin và đánh giá hợp lệ." });
            }

            // Trim inputs
            phone = phone.Trim();
            comment = comment.Trim();

            // 1. Verify that the user has purchased this book and the order is delivered
            var hasPurchased = await _context.Orders
                .Include(o => o.OrderItems)
                .AnyAsync(o => o.Phone == phone && 
                               o.Status == OrderStatus.Delivered && 
                               o.OrderItems.Any(oi => oi.BookId == bookId));

            if (!hasPurchased)
            {
                return Json(new { success = false, message = "Bạn chỉ có thể đánh giá sản phẩm đã mua và đơn hàng đã được giao thành công." });
            }

            // 2. Check if the user has already reviewed this book
            var existingReview = await _context.Reviews
                .FirstOrDefaultAsync(r => r.BookId == bookId && r.Phone == phone);

            if (existingReview != null)
            {
                // Update existing review
                existingReview.Rating = rating;
                existingReview.Comment = comment;
                existingReview.UpdatedAt = DateTime.Now;
                _context.Reviews.Update(existingReview);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Đã cập nhật đánh giá của bạn." });
            }
            else
            {
                // Create new review
                var review = new Review
                {
                    BookId = bookId,
                    Phone = phone,
                    Rating = rating,
                    Comment = comment,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                _context.Reviews.Add(review);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Cảm ơn bạn đã đánh giá sản phẩm!" });
            }
        }
    }
}
