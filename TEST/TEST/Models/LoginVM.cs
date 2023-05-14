using System.ComponentModel.DataAnnotations;

namespace TEST.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage = "UserName is required.")]
        [StringLength(30, ErrorMessage = "使用者名稱最多三十個字")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "密碼不可小於6碼")]
        [MaxLength(16, ErrorMessage = "密碼不可以大於16碼")]
        public string Password { get; set; }


    }
}
