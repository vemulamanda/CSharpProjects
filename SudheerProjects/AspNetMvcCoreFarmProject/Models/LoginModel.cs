using System.ComponentModel.DataAnnotations;

namespace AspNetMvcCoreFarmProject.Models
{
    public class LoginModel
    {
        [Key]
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
