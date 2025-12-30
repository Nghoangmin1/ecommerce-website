using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Fahasa.Models;

namespace Fahasa.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string OrderNumber { get; set; } = null!;

        [ForeignKey("User")]
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        // Shipping information
        [Required]
        [StringLength(255)]
        [Display(Name = "Tên người nhận")]
        public string RecipientName { get; set; } = null!;

        [Required]
        [StringLength(20)]
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; } = null!;

        [Required]
        [StringLength(100)]
        [Display(Name = "Tỉnh/Thành phố")]
        public string Province { get; set; } = null!;

        [Required]
        [StringLength(100)]
        [Display(Name = "Quận/Huyện")]
        public string District { get; set; } = null!;

        [Required]
        [StringLength(100)]
        [Display(Name = "Phường/Xã")]
        public string Ward { get; set; } = null!;

        [Required]
        [Display(Name = "Địa chỉ chi tiết")]
        public string AddressDetail { get; set; } = null!;

        // Price information
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        [Display(Name = "Tạm tính")]
        public decimal Subtotal { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        [Display(Name = "Phí vận chuyển")]
        public decimal ShippingFee { get; set; } = 0;

        [Column(TypeName = "decimal(10,2)")]
        [Display(Name = "Giảm giá")]
        public decimal DiscountAmount { get; set; } = 0;

        [Display(Name = "Điểm tích lũy sử dụng")]
        public int LoyaltyPointsUsed { get; set; } = 0;

        [Column(TypeName = "decimal(10,2)")]
        [Display(Name = "Giảm giá điểm tích lũy")]
        public decimal LoyaltyDiscount { get; set; } = 0;

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        [Display(Name = "Tổng tiền")]
        public decimal TotalAmount { get; set; }

        // Payment
        [Required]
        [Display(Name = "Phương thức thanh toán")]
        public PaymentMethod PaymentMethod { get; set; }

        [Display(Name = "Trạng thái thanh toán")]
        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;

        // Order status
        [Display(Name = "Trạng thái đơn hàng")]
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        [Display(Name = "Ghi chú")]
        public string? Note { get; set; }

        [Display(Name = "Lý do hủy")]
        public string? CancelReason { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "Ngày cập nhật")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [Display(Name = "Ngày xác nhận")]
        public DateTime? ConfirmedAt { get; set; }

        [Display(Name = "Ngày giao hàng")]
        public DateTime? ShippedAt { get; set; }

        [Display(Name = "Ngày nhận hàng")]
        public DateTime? DeliveredAt { get; set; }

        [Display(Name = "Ngày hủy")]
        public DateTime? CancelledAt { get; set; }
    }

    public enum PaymentMethod
    {
        [Display(Name = "Thanh toán khi nhận hàng (COD)")]
        Cod,
        [Display(Name = "Chuyển khoản ngân hàng")]
        BankTransfer
    }

    public enum PaymentStatus
    {
        [Display(Name = "Chờ thanh toán")]
        Pending,
        [Display(Name = "Đã thanh toán")]
        Paid,
        [Display(Name = "Thanh toán thất bại")]
        Failed,
        [Display(Name = "Đã hoàn tiền")]
        Refunded
    }

    public enum OrderStatus
    {
        [Display(Name = "Chờ xác nhận")]
        Pending,
        [Display(Name = "Đang xử lý")]
        Processing,
        [Display(Name = "Đang giao hàng")]
        Shipping,
        [Display(Name = "Đã giao hàng")]
        Delivered,
        [Display(Name = "Đã hủy")]
        Cancelled
    }
}
