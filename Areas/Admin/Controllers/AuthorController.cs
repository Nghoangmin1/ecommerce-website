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
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostEnvironment _hostEnvironment;
        public AuthorController(ApplicationDbContext context, IHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index(string search = "", int page = 1)
        {
            int pageSize = 10;
            
            // Build query with IQueryable
            IQueryable<Author> query = _context.Authors;
            
            // Apply filters
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(a => a.Name.Contains(search));
            }
            
            // Get total count
            int totalItems = query.Count();
            int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            
            // Apply pagination and execute query
            var paginatedAuthors = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            
            ViewBag.search = search;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(paginatedAuthors);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Details(int id, string search = "", int IsActive = 0, int categoryId = 0, int? priceFrom = null, int? priceTo = null, int page = 1)
        {
            var author = _context.Authors.Find(id);
            IQueryable<Book> query = _context.Books
                .Include(b => b.Category)
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .Where(b => b.AuthorId == id);

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
            return View(author);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Author author)
        {
            // Chuẩn hóa dữ liệu đầu vào - Trim các string properties
            if (author.Name != null) author.Name = author.Name.Trim();
            if (author.Biography != null) author.Biography = author.Biography.Trim();
            if (author.Nationality != null) author.Nationality = author.Nationality.Trim();
            
            if (ModelState.IsValid)
            {
                // Set timestamps
                author.CreatedAt = DateTime.Now;
                
                _context.Authors.Add(author);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"Đã tạo tác giả '{author.Name}' thành công.";
                return RedirectToAction("Index");
            }
            return View(author);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var author = _context.Authors.Find(id);
            return View(author);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Author author)
        {
            // Chuẩn hóa dữ liệu đầu vào - Trim các string properties
            if (author.Name != null) author.Name = author.Name.Trim();
            if (author.Biography != null) author.Biography = author.Biography.Trim();
            if (author.Nationality != null) author.Nationality = author.Nationality.Trim();
            
            if (ModelState.IsValid)
            {
                _context.Authors.Update(author);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"Đã cập nhật tác giả '{author.Name}' thành công.";
                return RedirectToAction("Index");
            }
            return View(author);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var author = _context.Authors.Find(id);
            return View(author);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Author author)
        {
            // Kiểm tra xem có sách nào đang tham chiếu đến tác giả này không
            var booksWithAuthor = _context.Books.Where(b => b.AuthorId == author.Id).ToList();
            
            if (booksWithAuthor.Any())
            {
                TempData["ErrorMessage"] = $"Không thể xóa tác giả '{author.Name}' vì vẫn còn {booksWithAuthor.Count} cuốn sách đang tham chiếu đến tác giả này. Vui lòng xóa hoặc cập nhật các cuốn sách liên quan trước.";
                return RedirectToAction("Index");
            }
            
            _context.Authors.Remove(author);
            _context.SaveChanges();
            TempData["SuccessMessage"] = $"Đã xóa tác giả '{author.Name}' thành công.";
            return RedirectToAction("Index");
        }
    }
}
