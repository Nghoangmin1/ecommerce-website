using System.ComponentModel.DataAnnotations;

namespace Fahasa.Models
{
    public class Publisher
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Thuộc tính này là bắt buộc")]
        [MaxLength(255, ErrorMessage = "Giá trị phải nhỏ hơn 255 ký tự")]
        [Display(Name = "Tên nhà xuất bản")]
        public string Name { get; set; }
        
        [Display(Name = "Mô tả")]
        public string? Description { get; set; }

        
        [MaxLength(255, ErrorMessage = "Giá trị phải nhỏ hơn 255 ký tự")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string? Email { get; set; }
        
        [MaxLength(20, ErrorMessage = "Giá trị phải nhỏ hơn 20 ký tự")]
        [Phone]
        [Display(Name = "Số điện thoại")]
        public string? Phone { get; set; }
        
        [Display(Name = "Địa chỉ")]
        public string? Address { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "Ngày cập nhật")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
