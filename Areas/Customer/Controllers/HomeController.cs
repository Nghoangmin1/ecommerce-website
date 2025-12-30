using Microsoft.AspNetCore.Mvc;
using Fahasa.Data;
using Fahasa.Models;
using Fahasa.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Fahasa.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var homeVM = new HomeVM
            {
                NewArrivals = await _context.Books.Include(b => b.Author).Where(b => b.IsActive && b.IsNewRelease).Take(8).ToListAsync(),
                Bestsellers = await _context.Books.Include(b => b.Author).Where(b => b.IsActive && b.IsBestseller).Take(8).ToListAsync(),
                Featured = await _context.Books.Include(b => b.Author).Where(b => b.IsActive && b.IsFeatured).Take(5).ToListAsync()
            };

            // Fallback if no specific flags are set, just to show something
            if (!homeVM.NewArrivals.Any())
            {
                homeVM.NewArrivals = await _context.Books.Include(b => b.Author).Where(b => b.IsActive).OrderByDescending(b => b.CreatedAt).Take(8).ToListAsync();
            }
             if (!homeVM.Bestsellers.Any())
            {
                homeVM.Bestsellers = await _context.Books.Include(b => b.Author).Where(b => b.IsActive).OrderByDescending(b => b.SoldCount).Take(8).ToListAsync();
            }

            return View(homeVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
