using System.Text.Json.Serialization;

namespace Fahasa.Models
{
    public class CartItem
    {
        [JsonPropertyName("bookId")]
        public int BookId { get; set; }
        
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        public CartItem()
        {
        }

        public CartItem(int bookId, int quantity)
        {
            if (bookId <= 0)
                throw new ArgumentException("BookId must be greater than 0", nameof(bookId));
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than 0", nameof(quantity));

            BookId = bookId;
            Quantity = quantity;
        }
    }
}

