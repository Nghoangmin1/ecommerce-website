using Fahasa.Models;

namespace Fahasa.Models.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Book> NewArrivals { get; set; }
        public IEnumerable<Book> Bestsellers { get; set; }
        public IEnumerable<Book> Featured { get; set; }
    }
}
