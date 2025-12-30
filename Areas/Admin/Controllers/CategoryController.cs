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
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostEnvironment _hostEnvironment;
        public CategoryController(ApplicationDbContext context, IHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index(string search = "", int IsActive = 0, int page = 1)
        {
            int pageSize = 10;
            
            // Build query with IQueryable
            IQueryable<Category> query = _context.Categories;
            
            // Apply filters
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(c => c.Name.Contains(search));
            }
            
            if (IsActive == 1)
            {
                query = query.Where(c => c.IsActive == true);
            }
            else if (IsActive == 2)
            {
                query = query.Where(c => c.IsActive == false);
            }
            
            // Get total count
            int totalItems = query.Count();
            int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            
            // Apply pagination and execute query
            var paginatedCategories = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            
            ViewBag.search = search;
            ViewBag.IsActive = IsActive;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(paginatedCategories);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Details(int id, string search = "", int IsActive = 0, int? priceFrom = null, int? priceTo = null, int page = 1)
        {
            var category = _context.Categories.Find(id);
            IQueryable<Book> query = _context.Books
                .Include(b => b.Category)
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .Where(b => b.CategoryId == id);

            int pageSize = 10;
            
            // Apply filters
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(b => b.Name.Contains(search));
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
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.books = paginatedBooks;
            return View(category);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            // Chuẩn hóa dữ liệu đầu vào - Trim các string properties
            if (category.Name != null) category.Name = category.Name.Trim();
            if (category.Description != null) category.Description = category.Description.Trim();
            
            if (ModelState.IsValid)
            {
                // Set timestamps
                category.CreatedAt = DateTime.Now;
                category.UpdatedAt = DateTime.Now;

                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"Đã tạo danh mục '{category.Name}' thành công.";
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var category = _context.Categories.Find(id);
            return View(category);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category)
        {
            // Chuẩn hóa dữ liệu đầu vào - Trim các string properties
            if (category.Name != null) category.Name = category.Name.Trim();
            if (category.Description != null) category.Description = category.Description.Trim();
            
            if (ModelState.IsValid)
            {
                category.UpdatedAt = DateTime.Now;
                _context.Categories.Update(category);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"Đã cập nhật danh mục '{category.Name}' thành công.";
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.Find(id);
            return View(category);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category category)
        {
            // Kiểm tra xem có sách nào đang tham chiếu đến danh mục này không
            var booksWithCategory = _context.Books.Where(b => b.CategoryId == category.Id).ToList();
            
            if (booksWithCategory.Any())
            {
                TempData["ErrorMessage"] = $"Không thể xóa danh mục '{category.Name}' vì vẫn còn {booksWithCategory.Count} cuốn sách đang tham chiếu đến danh mục này. Vui lòng xóa hoặc cập nhật các cuốn sách liên quan trước.";
                return RedirectToAction("Index");
            }
            
            _context.Categories.Remove(category);
            _context.SaveChanges();
            TempData["SuccessMessage"] = $"Đã xóa danh mục '{category.Name}' thành công.";
            return RedirectToAction("Index");
        }
    }
}
