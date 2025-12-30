using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Fahasa.Models;
using Fahasa.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace Fahasa.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public BookController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index(string search = "", int IsActive = 0, int categoryId = 0, int? priceFrom = null, int? priceTo = null, int page = 1)
        {
            int pageSize = 10;
            
            // Build query with IQueryable
            IQueryable<Book> query = _context.Books
                .Include(b => b.Category)
                .Include(b => b.Author)
                .Include(b => b.Publisher);
            
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
            
            if (categoryId > 0)
            {
                query = query.Where(b => b.CategoryId == categoryId);
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

            return View(paginatedBooks);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Details(int id)
        {
            var book = _context.Books
                .Include(b => b.Category)
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .FirstOrDefault(b => b.Id == id);
            return View(book);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories.Where(c => c.IsActive), "Id", "Name");
            ViewBag.Authors = new SelectList(_context.Authors, "Id", "Name");
            ViewBag.Publishers = new SelectList(_context.Publishers, "Id", "Name");
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book, IFormFile? cover)
        {
            // Chuẩn hóa dữ liệu đầu vào - Trim các string properties
            if (book.Name != null) book.Name = book.Name.Trim();
            if (book.Description != null) book.Description = book.Description.Trim();
            
            if (cover != null && cover.Length > 0)
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
                var allowedContentTypes = new[] { "image/jpeg", "image/jpg", "image/png", "image/gif", "image/bmp" };
                var extension = Path.GetExtension(cover.FileName).ToLowerInvariant();
                var contentType = cover.ContentType.ToLowerInvariant();
                
                if (!allowedExtensions.Contains(extension) || !allowedContentTypes.Contains(contentType))
                {
                    ModelState.AddModelError("cover", "Chỉ chấp nhận file ảnh có định dạng: jpg, jpeg, png, gif, bmp.");
                    ViewBag.Categories = new SelectList(_context.Categories.Where(c => c.IsActive), "Id", "Name", book.CategoryId);
                    ViewBag.Authors = new SelectList(_context.Authors, "Id", "Name", book.AuthorId);
                    ViewBag.Publishers = new SelectList(_context.Publishers, "Id", "Name", book.PublisherId);
                    return View(book);
                }
            }
            if (ModelState.IsValid)
            {
                book.CreatedAt = DateTime.Now;
                book.UpdatedAt = DateTime.Now;
                // Handle cover upload
                if (cover != null)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(cover.FileName);
                    var uploadsFolder = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot", "images", "books");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }
                    var filePath = Path.Combine(uploadsFolder, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        cover.CopyTo(stream);
                    }
                    book.ImageUrl = "/images/books/" + fileName;
                }
                
                _context.Books.Add(book);
                _context.SaveChanges();
                TempData["SuccessMessage"] = $"Đã tạo sách '{book.Name}' thành công.";
                return RedirectToAction("Index");
            }
            
            ViewBag.Categories = new SelectList(_context.Categories.Where(c => c.IsActive), "Id", "Name", book.CategoryId);
            ViewBag.Authors = new SelectList(_context.Authors, "Id", "Name", book.AuthorId);
            ViewBag.Publishers = new SelectList(_context.Publishers, "Id", "Name", book.PublisherId);
            return View(book);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            
            ViewBag.Categories = new SelectList(_context.Categories.Where(c => c.IsActive), "Id", "Name", book.CategoryId);
            ViewBag.Authors = new SelectList(_context.Authors, "Id", "Name", book.AuthorId);
            ViewBag.Publishers = new SelectList(_context.Publishers, "Id", "Name", book.PublisherId);
            return View(book);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book, IFormFile? cover)
        {
            // Chuẩn hóa dữ liệu đầu vào - Trim các string properties
            if (book.Name != null) book.Name = book.Name.Trim();
            if (book.Description != null) book.Description = book.Description.Trim();
            
            if (cover != null && cover.Length > 0)
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
                var allowedContentTypes = new[] { "image/jpeg", "image/jpg", "image/png", "image/gif", "image/bmp" };
                var extension = Path.GetExtension(cover.FileName).ToLowerInvariant();
                var contentType = cover.ContentType.ToLowerInvariant();
                
                if (!allowedExtensions.Contains(extension) || !allowedContentTypes.Contains(contentType))
                {
                    ModelState.AddModelError("cover", "Chỉ chấp nhận file ảnh có định dạng: jpg, jpeg, png, gif, bmp.");
                    ViewBag.Categories = new SelectList(_context.Categories.Where(c => c.IsActive), "Id", "Name", book.CategoryId);
                    ViewBag.Authors = new SelectList(_context.Authors, "Id", "Name", book.AuthorId);
                    ViewBag.Publishers = new SelectList(_context.Publishers, "Id", "Name", book.PublisherId);
                    return View(book);
                }
            }
            if (ModelState.IsValid)
            {
                // Get the existing book from database
                var existingBook = _context.Books.Find(book.Id);
                if (existingBook == null)
                {
                    return NotFound();
                }
                
                // Update only the fields that should be changed
                existingBook.Name = book.Name;
                existingBook.Description = book.Description;
                existingBook.CategoryId = book.CategoryId;
                existingBook.AuthorId = book.AuthorId;
                existingBook.PublisherId = book.PublisherId;
                existingBook.PublicationYear = book.PublicationYear;
                existingBook.Language = book.Language;
                existingBook.Pages = book.Pages;
                existingBook.Weight = book.Weight;
                existingBook.Width = book.Width;
                existingBook.Height = book.Height;
                existingBook.Depth = book.Depth;
                existingBook.CoverType = book.CoverType;
                existingBook.Price = book.Price;
                existingBook.DiscountPercent = book.DiscountPercent;
                existingBook.StockQuantity = book.StockQuantity;
                existingBook.IsActive = book.IsActive;
                existingBook.IsFeatured = book.IsFeatured;
                existingBook.IsBestseller = book.IsBestseller;
                existingBook.IsNewRelease = book.IsNewRelease;
                existingBook.UpdatedAt = DateTime.Now;
                // Handle cover upload (replace if provided)
                if (cover != null)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(cover.FileName);
                    var uploadsFolder = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot", "images", "books");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }
                    var filePath = Path.Combine(uploadsFolder, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        cover.CopyTo(stream);
                    }
                    existingBook.ImageUrl = "/images/books/" + fileName;
                }
                
                _context.SaveChanges();
                TempData["SuccessMessage"] = $"Đã cập nhật sách '{existingBook.Name}' thành công.";
                return RedirectToAction("Index");
            }
            
            ViewBag.Categories = new SelectList(_context.Categories.Where(c => c.IsActive), "Id", "Name", book.CategoryId);
            ViewBag.Authors = new SelectList(_context.Authors, "Id", "Name", book.AuthorId);
            ViewBag.Publishers = new SelectList(_context.Publishers, "Id", "Name", book.PublisherId);
            return View(book);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var book = _context.Books
                .Include(b => b.Category)
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .FirstOrDefault(b => b.Id == id);
            return View(book);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Book book)
        {
            // Check if there are any orders for this book
            bool hasOrders = _context.OrderItems.Any(oi => oi.BookId == book.Id);

            if (hasOrders)
            {
                // Soft delete: Disable the book
                var bookToDisable = _context.Books.Find(book.Id);
                if (bookToDisable != null)
                {
                    bookToDisable.IsActive = false;
                    bookToDisable.UpdatedAt = DateTime.Now;
                    _context.Books.Update(bookToDisable);
                    _context.SaveChanges();
                    TempData["SuccessMessage"] = $"Sản phẩm '{bookToDisable.Name}' đã chuyển sang trạng thái ngưng kinh doanh do đã có đơn hàng.";
                }
            }
            else
            {
                // Hard delete
                _context.Books.Remove(book);
                _context.SaveChanges();
                TempData["SuccessMessage"] = $"Đã xóa sách '{book.Name}' thành công.";
            }

            return RedirectToAction("Index");
        }
    }
}
