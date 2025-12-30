using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Fahasa.Data;
using Fahasa.Models;
using Fahasa.Areas.Admin.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Fahasa.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var viewModel = new DashboardViewModel();

            // 1. General Stats
            viewModel.TotalOrders = _context.Orders.Count();
            viewModel.TotalRevenue = _context.Orders.Sum(o => o.TotalAmount);
            viewModel.TotalBooks = _context.Books.Count();
            viewModel.TotalUsers = _context.Users.Count();

            // 2. Recent Orders (Top 5)
            viewModel.RecentOrders = _context.Orders
                .Include(o => o.User)
                .OrderByDescending(o => o.CreatedAt)
                .Take(5)
                .ToList();

            // 3. Monthly Report (Current Year 1-12)
            var currentYear = DateTime.Now.Year;
            var monthlyData = _context.Orders
                .Where(o => o.CreatedAt.Year == currentYear)
                .GroupBy(o => o.CreatedAt.Month)
                .Select(g => new
                {
                    Month = g.Key,
                    Revenue = g.Sum(o => o.TotalAmount),
                    Count = g.Count()
                })
                .ToList();

            for (int i = 1; i <= 12; i++)
            {
                var monthStat = monthlyData.FirstOrDefault(m => m.Month == i);
                viewModel.MonthlyRevenue.Add(monthStat?.Revenue ?? 0);
                viewModel.MonthlyOrders.Add(monthStat?.Count ?? 0);
            }

            // 4. Yearly Report (Last 5 Years)
            var startYear = currentYear - 4;
            var yearlyData = _context.Orders
                .Where(o => o.CreatedAt.Year >= startYear)
                .GroupBy(o => o.CreatedAt.Year)
                .Select(g => new
                {
                    Year = g.Key,
                    Revenue = g.Sum(o => o.TotalAmount),
                    Count = g.Count()
                })
                .ToList();

            for (int year = startYear; year <= currentYear; year++)
            {
                var yearStat = yearlyData.FirstOrDefault(y => y.Year == year);
                viewModel.Years.Add(year);
                viewModel.YearlyRevenue.Add(yearStat?.Revenue ?? 0);
                viewModel.YearlyOrders.Add(yearStat?.Count ?? 0);
            }

            return View(viewModel);
        }
    }
}
