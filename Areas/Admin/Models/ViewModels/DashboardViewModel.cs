using Fahasa.Models;

namespace Fahasa.Areas.Admin.Models.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public int TotalBooks { get; set; }
        public int TotalUsers { get; set; }
        public List<Order> RecentOrders { get; set; } = new List<Order>();

        // Monthly Report (Current Year)
        public List<decimal> MonthlyRevenue { get; set; } = new List<decimal>();
        public List<int> MonthlyOrders { get; set; } = new List<int>();

        // Yearly Report (Last 5 Years)
        public List<decimal> YearlyRevenue { get; set; } = new List<decimal>();
        public List<int> YearlyOrders { get; set; } = new List<int>();
        public List<int> Years { get; set; } = new List<int>();
    }
}
