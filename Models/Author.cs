
using System.ComponentModel.DataAnnotations;
namespace Fahasa.Models
{
    public class Author
    {
        [Key]    
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Thuộc tính này là bắt buộc")]
        [MaxLength(255, ErrorMessage = "Giá trị phải nhỏ hơn 255 ký tự")]
        [Display(Name = "Tên tác giả")]
        public string Name { get; set; }
        
        [Display(Name = "Tiểu sử")]
        public string? Biography { get; set; }
        
        [Display(Name = "Ảnh đại diện")]
        public string? AvatarUrl { get; set; }

        [Display(Name = "Năm sinh")]
        [Range(1, int.MaxValue, ErrorMessage = "Giá trị phải lớn hơn 0")]
        public int? BirthYear { get; set; }
        
        [MaxLength(100, ErrorMessage = "Giá trị phải nhỏ hơn 100 ký tự")]
        [Display(Name = "Quốc tịch")]
        public string? Nationality { get; set; }

        [Display(Name = "Ngày tạo")]        
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "Ngày cập nhật")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
