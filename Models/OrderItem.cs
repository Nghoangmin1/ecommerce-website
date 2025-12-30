using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fahasa.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order? Order { get; set; }

        [Required]
        [ForeignKey("Book")] // Mapping product_id to Book
        public int BookId { get; set; }
        public Book? Book { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Tên sách")]
        public string ProductName { get; set; } = null!;

        [Required]
        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        [Display(Name = "Đơn giá")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "Phần trăm giảm giá")]
        public int DiscountPercent { get; set; } = 0;

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        [Display(Name = "Thành tiền")]
        public decimal TotalPrice { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
