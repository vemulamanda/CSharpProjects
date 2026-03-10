using System.ComponentModel.DataAnnotations;

namespace SudApi.Models
{
    public class LoginModel
    {
        [Key]
        [Required(ErrorMessage = "Username field cant be empty.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password field cant be empty.")]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
