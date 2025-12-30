using Fahasa.Models;

namespace Fahasa.ViewModels
{
    public class CheckoutViewModel
    {
        public Order Order { get; set; }
        public List<CheckoutItemViewModel> Icon { get; set; } = new List<CheckoutItemViewModel>();
        public decimal TotalAmount { get; set; }
    }

    public class CheckoutItemViewModel
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }
        public decimal FinalPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
