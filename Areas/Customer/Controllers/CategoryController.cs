using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fahasa.Data;
using Fahasa.Models;

namespace Fahasa.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? categoryId, string search = "", string sortBy = "default", 
            int[]? authorIds = null, int[]? publisherIds = null, int? priceFrom = null, int? priceTo = null, int page = 1)
        {
            int pageSize = 12;
            search = search.Trim();

            // Lấy danh sách categories đang hoạt động
            var categories = _context.Categories
                .Where(c => c.IsActive)
                .OrderBy(c => c.DisplayOrder)
                .ThenBy(c => c.Name)
                .ToList();

            // Lấy danh sách authors và publishers
            var authors = _context.Authors
                .OrderBy(a => a.Name)
                .ToList();

            var publishers = _context.Publishers
                .OrderBy(p => p.Name)
                .ToList();

            // Đếm số lượng sách cho mỗi author và publisher
            var authorBookCounts = _context.Books
                .Where(b => b.IsActive)
                .GroupBy(b => b.AuthorId)
                .Select(g => new { AuthorId = g.Key, Count = g.Count() })
                .ToDictionary(x => x.AuthorId, x => x.Count);

            var publisherBookCounts = _context.Books
                .Where(b => b.IsActive)
                .GroupBy(b => b.PublisherId)
                .Select(g => new { PublisherId = g.Key, Count = g.Count() })
                .ToDictionary(x => x.PublisherId, x => x.Count);

            ViewBag.AuthorBookCounts = authorBookCounts;
            ViewBag.PublisherBookCounts = publisherBookCounts;

            // Đếm số lượng sách cho mỗi category
            var categoryBookCounts = _context.Books
                .Where(b => b.IsActive)
                .GroupBy(b => b.CategoryId)
                .Select(g => new { CategoryId = g.Key, Count = g.Count() })
                .ToDictionary(x => x.CategoryId, x => x.Count);

            ViewBag.Categories = categories;
            ViewBag.CategoryBookCounts = categoryBookCounts;
            ViewBag.Authors = authors;
            ViewBag.Publishers = publishers;
            ViewBag.SelectedCategoryId = categoryId;
            ViewBag.SelectedAuthorIds = authorIds ?? Array.Empty<int>();
            ViewBag.SelectedPublisherIds = publisherIds ?? Array.Empty<int>();
            ViewBag.PriceFrom = priceFrom;
            ViewBag.PriceTo = priceTo;

            // Query books
            IQueryable<Book> query = _context.Books
                .Include(b => b.Category)
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .Where(b => b.IsActive);

            // Lọc theo category
            if (categoryId.HasValue && categoryId.Value > 0)
            {
                query = query.Where(b => b.CategoryId == categoryId.Value);
            }

            // Tìm kiếm
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(b => b.Name.Contains(search) || 
                                        (b.Description != null && b.Description.Contains(search)));
            }

            // Lọc theo tác giả
            if (authorIds != null && authorIds.Length > 0)
            {
                query = query.Where(b => authorIds.Contains(b.AuthorId));
            }

            // Lọc theo nhà xuất bản
            if (publisherIds != null && publisherIds.Length > 0)
            {
                query = query.Where(b => publisherIds.Contains(b.PublisherId));
            }

            // Lọc theo giá
            if (priceFrom.HasValue && priceFrom.Value > 0)
            {
                query = query.Where(b => b.Price >= priceFrom.Value);
            }

            if (priceTo.HasValue && priceTo.Value > 0)
            {
                query = query.Where(b => b.Price <= priceTo.Value);
            }

            // Sắp xếp
            switch (sortBy.ToLower())
            {
                case "price_asc":
                    query = query.OrderBy(b => b.Price);
                    break;
                case "price_desc":
                    query = query.OrderByDescending(b => b.Price);
                    break;
                case "name_asc":
                    query = query.OrderBy(b => b.Name);
                    break;
                case "name_desc":
                    query = query.OrderByDescending(b => b.Name);
                    break;
                case "newest":
                    query = query.OrderByDescending(b => b.CreatedAt);
                    break;
                case "popular":
                    query = query.OrderByDescending(b => b.SoldCount);
                    break;
                default:
                    query = query.OrderBy(b => b.Name);
                    break;
            }

            // Pagination
            int totalItems = query.Count();
            int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var books = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Lấy giá min và max từ tất cả sách đang hoạt động
            var allActiveBooks = _context.Books.Where(b => b.IsActive);
            var minPrice = allActiveBooks.Any() ? allActiveBooks.Min(b => b.Price) : 0;
            var maxPrice = allActiveBooks.Any() ? allActiveBooks.Max(b => b.Price) : 1000000;

            ViewBag.Books = books;
            ViewBag.Search = search;
            ViewBag.SortBy = sortBy;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.TotalItems = totalItems;
            ViewBag.MinPrice = minPrice;
            ViewBag.MaxPrice = maxPrice;

            return View();
        }

        public IActionResult Details(int id)
        {
            var book = _context.Books
                .Include(b => b.Category)
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .AsNoTracking()
                .FirstOrDefault(b => b.Id == id); // Removed && b.IsActive check to allow viewing inactive items from order history

            if (book == null)
            {
                return NotFound();
            }

            // Flag if the product is inactive
            if (!book.IsActive)
            {
                ViewBag.IsInactive = true;
            }

            // Tăng lượt xem (update riêng để tránh conflict với AsNoTracking)
            var bookToUpdate = _context.Books.Find(id);
            if (bookToUpdate != null)
            {
                bookToUpdate.ViewCount++;
                _context.SaveChanges();
            }

            // Lấy các sách liên quan (cùng category)
            var relatedBooks = _context.Books
                .Include(b => b.Category)
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .Where(b => b.IsActive && b.CategoryId == book.CategoryId && b.Id != book.Id)
                .OrderByDescending(b => b.CreatedAt)
                .Take(4)
                .ToList();

            ViewBag.Book = book;
            ViewBag.RelatedBooks = relatedBooks;

            // Load Reviews
            var reviews = _context.Reviews
                .Where(r => r.BookId == id)
                .OrderByDescending(r => r.CreatedAt)
                .ToList();
            ViewBag.Reviews = reviews;

            return View();
        }
    }
}
