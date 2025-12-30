using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Fahasa.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(255)]
        [Display(Name = "Họ và tên")]
        public string? FullName { get; set; }

        [Display(Name = "Ngày sinh")]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Giới tính")]
        public int Gender { get; set; }

        [Display(Name = "Điểm tích lũy")]
        public int LoyaltyPoints { get; set; } = 0;

        [Display(Name = "Hạng thành viên")]
        public int MemberTier { get; set; } = 0;

        [Display(Name = "Trạng thái")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "Ngày tạo")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "Ngày cập nhật")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;


    }
}
