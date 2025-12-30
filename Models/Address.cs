using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Fahasa.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ValidateNever]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        [ValidateNever]
        public ApplicationUser? User { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên người nhận")]
        [Display(Name = "Tên người nhận")]
        public string ReceiverName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [Display(Name = "Số điện thoại")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ cụ thể")]
        [Display(Name = "Địa chỉ")]
        public string StreetAddress { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Tỉnh/Thành phố")]
        [Display(Name = "Tỉnh/Thành phố")]
        public string City { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Quận/Huyện")]
        [Display(Name = "Quận/Huyện")]
        public string District { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Phường/Xã")]
        [Display(Name = "Phường/Xã")]
        public string Ward { get; set; }

        [Display(Name = "Đặt làm mặc định")]
        public bool IsDefault { get; set; } = false;
    }
}
