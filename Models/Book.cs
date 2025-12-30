using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fahasa.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Thuộc tính này là bắt buộc")]
        [MaxLength(500, ErrorMessage = "Giá trị phải nhỏ hơn 500 ký tự")]
        [Display(Name = "Tên sách")]
        public string Name { get; set; }

        [Display(Name = "Mô tả")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Thuộc tính này là bắt buộc")]
        [ForeignKey("Category")]
        [Display(Name = "Danh mục")]
        public int CategoryId { get; set; }
        [ValidateNever]
        public Category? Category { get; set; }

        [Required(ErrorMessage = "Thuộc tính này là bắt buộc")]
        [ForeignKey("Publisher")]
        [Display(Name = "Nhà xuất bản")]
        public int PublisherId { get; set; }
        [ValidateNever]
        public Publisher? Publisher { get; set; }

        [Required(ErrorMessage = "Thuộc tính này là bắt buộc")]
        [ForeignKey("Author")]
        [Display(Name = "Tác giả")]
        public int AuthorId { get; set; }
        [ValidateNever]
        public Author? Author { get; set; }

        [Required(ErrorMessage = "Thuộc tính này là bắt buộc")]
        [Display(Name = "Năm xuất bản")]
        [Range(1900, 2100, ErrorMessage = "Giá trị phải nằm trong khoảng từ 1900 đến 2100")]
        public int? PublicationYear { get; set; }

        [Required(ErrorMessage = "Thuộc tính này là bắt buộc")]
        [Display(Name = "Ngôn ngữ")]
        public int Language { get; set; } = 0;

        [Required(ErrorMessage = "Thuộc tính này là bắt buộc")]
        [Range(1, int.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0")]
        [Display(Name = "Số trang")]
        public int? Pages { get; set; }

        [Required(ErrorMessage = "Thuộc tính này là bắt buộc")]
        [Range(1, int.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0")]
        [Display(Name = "Khối lượng")]
        public int? Weight { get; set; }

        [Required(ErrorMessage = "Thuộc tính này là bắt buộc")]
        [Range(1, 1000, ErrorMessage = "Giá trị phải lớn hơn 0")]
        [Display(Name = "Rộng (cm)")]
        public decimal? Width { get; set; }

        [Required(ErrorMessage = "Thuộc tính này là bắt buộc")]
        [Range(1, 1000, ErrorMessage = "Giá trị phải lớn hơn 0")]
        [Display(Name = "Cao (cm)")]
        public decimal? Height { get; set; }

        [Required(ErrorMessage = "Thuộc tính này là bắt buộc")]
        [Range(1, 1000, ErrorMessage = "Giá trị phải lớn hơn 0")]
        [Display(Name = "Dày (cm)")]
        public decimal? Depth { get; set; }

        [Required(ErrorMessage = "Thuộc tính này là bắt buộc")]
        [Display(Name = "Loại bìa")]
        public int CoverType { get; set; } = 0;

        [Required(ErrorMessage = "Thuộc tính này là bắt buộc")]
        [Range(1, 1000000000, ErrorMessage = "Giá trị phải lớn hơn 0")]
        [Display(Name = "Giá")]
        public int Price { get; set; }


        [Display(Name = "Phần trăm giảm giá")]
        [Range(1, int.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0")]
        public int DiscountPercent { get; set; } = 0;

        [Required(ErrorMessage = "Thuộc tính này là bắt buộc")]
        [Display(Name = "Số lượng tồn")]
        [Range(1, int.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0")]
        public int StockQuantity { get; set; } = 0;

        [Display(Name = "Đã bán")]
        public int SoldCount { get; set; } = 0;

        [Display(Name = "Lượt xem")]
        public int ViewCount { get; set; } = 0;

        [Display(Name = "Điểm đánh giá trung bình")]
        public decimal RatingAverage { get; set; } = 0;

        [Display(Name = "Lượt đánh giá")]
        public int RatingCount { get; set; } = 0;

        // public int? FeatureId { get; set; }

        [Display(Name = "Ảnh bìa")]
        public string? ImageUrl { get; set; }

        [Display(Name = "Trạng thái")]
        public bool IsActive { get; set; } = true;

        public bool IsFeatured { get; set; } = false;

        public bool IsBestseller { get; set; } = false;

        public bool IsNewRelease { get; set; } = false;

        [Display(Name = "Ngày tạo")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "Ngày cập nhật")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}
