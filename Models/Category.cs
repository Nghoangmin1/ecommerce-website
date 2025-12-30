using System.ComponentModel.DataAnnotations;

namespace Fahasa.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Thuộc tính này là bắt buộc")]
        [StringLength(50, ErrorMessage = "Giá trị phải nhỏ hơn 50 ký tự")]
        [Display(Name = "Tên danh mục")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "Giá trị phải nhỏ hơn 500 ký tự")]
        [Display(Name = "Mô tả")]
        public string? Description { get; set; }

        [Display(Name = "Thứ tự hiển thị")]
        public int DisplayOrder { get; set; } = 0;

        [Display(Name = "Hoạt động")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "Ngày tạo")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "Ngày cập nhật")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
