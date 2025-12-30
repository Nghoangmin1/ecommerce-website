using Fahasa.Data;
using Fahasa.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace Fahasa.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PublisherController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostEnvironment _hostEnvironment;
        public PublisherController(ApplicationDbContext context, IHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }


        [Authorize(Roles = "Admin")]
        public IActionResult Index(string search = "", int page = 1)
        {
            int pageSize = 10;
            
            // Build query with IQueryable
            IQueryable<Publisher> query = _context.Publishers;
            
            // Apply filters
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Name.Contains(search));
            }
            
            // Get total count
            int totalItems = query.Count();
            int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            
            // Apply pagination and execute query
            var paginatedPublishers = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            
            ViewBag.search = search;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(paginatedPublishers);
        }


        [Authorize(Roles = "Admin")]
        public IActionResult Details(int id, string search = "", int IsActive = 0, int categoryId = 0, int? priceFrom = null, int? priceTo = null, int page = 1)
        {
            var publisher = _context.Publishers.Find(id);

            IQueryable<Book> query = _context.Books
                .Include(b => b.Category)
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .Where(b => b.PublisherId == id);

            int pageSize = 10;

            // Apply filters
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(b => b.Name.Contains(search));
            }

            if (categoryId > 0)
            {
                query = query.Where(b => b.CategoryId == categoryId);
            }

            if (IsActive == 1)
            {
                query = query.Where(b => b.IsActive == true);
            }
            else if (IsActive == 2)
            {
                query = query.Where(b => b.IsActive == false);
            }

            if (priceFrom.HasValue)
            {
                if (priceFrom.Value < 0)
                {
                    query = query.Where(b => b.Price >= 0);
                    ViewBag.priceFrom = 0;
                }
                else
                {
                    query = query.Where(b => b.Price >= priceFrom.Value);
                    ViewBag.priceFrom = priceFrom;
                }

            }

            if (priceTo.HasValue)
            {
                if (priceTo.Value > 0 && priceTo.Value <= 1000000000)
                {
                    query = query.Where(b => b.Price <= priceTo.Value);
                    ViewBag.priceTo = priceTo;
                }
                else
                {
                    query = query.Where(b => b.Price <= 1000000000);
                    ViewBag.priceTo = 1000000000;
                }

            }

            // Get total count
            int totalItems = query.Count();
            int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            // Apply pagination and execute query
            var paginatedBooks = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.search = search;
            ViewBag.IsActive = IsActive;
            ViewBag.categoryId = categoryId;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
            ViewBag.books = paginatedBooks;
            return View(publisher);
        }


        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Publisher publisher)
        {
            // Chuẩn hóa dữ liệu đầu vào - Trim các string properties
            if (publisher.Name != null) publisher.Name = publisher.Name.Trim();
            if (publisher.Description != null) publisher.Description = publisher.Description.Trim();
            if (publisher.Email != null) publisher.Email = publisher.Email.Trim();
            if (publisher.Phone != null) publisher.Phone = publisher.Phone.Trim();
            if (publisher.Address != null) publisher.Address = publisher.Address.Trim();
            
            if (ModelState.IsValid)
            {
                // Set timestamps
                publisher.CreatedAt = DateTime.Now;
                
                _context.Publishers.Add(publisher);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"Đã tạo nhà xuất bản '{publisher.Name}' thành công.";
                return RedirectToAction("Index");
            }
            return View(publisher);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var publisher = _context.Publishers.Find(id);
            return View(publisher);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Publisher publisher)
        {
            // Chuẩn hóa dữ liệu đầu vào - Trim các string properties
            if (publisher.Name != null) publisher.Name = publisher.Name.Trim();
            if (publisher.Description != null) publisher.Description = publisher.Description.Trim();
            if (publisher.Email != null) publisher.Email = publisher.Email.Trim();
            if (publisher.Phone != null) publisher.Phone = publisher.Phone.Trim();
            if (publisher.Address != null) publisher.Address = publisher.Address.Trim();
            
            if (ModelState.IsValid)
            {
                _context.Publishers.Update(publisher);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"Đã cập nhật nhà xuất bản '{publisher.Name}' thành công.";
                return RedirectToAction("Index");
            }
            return View(publisher);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var publisher = _context.Publishers.Find(id);
            return View(publisher);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Publisher publisher)
        {
            // Kiểm tra xem có sách nào đang tham chiếu đến nhà xuất bản này không
            var booksWithPublisher = _context.Books.Where(b => b.PublisherId == publisher.Id).ToList();
            
            if (booksWithPublisher.Any())
            {
                TempData["ErrorMessage"] = $"Không thể xóa nhà xuất bản '{publisher.Name}' vì vẫn còn {booksWithPublisher.Count} cuốn sách đang tham chiếu đến nhà xuất bản này. Vui lòng xóa hoặc cập nhật các cuốn sách liên quan trước.";
                return RedirectToAction("Index");
            }
            
            _context.Publishers.Remove(publisher);
            _context.SaveChanges();
            TempData["SuccessMessage"] = $"Đã xóa nhà xuất bản '{publisher.Name}' thành công.";
            return RedirectToAction("Index");
        }
    }
}
