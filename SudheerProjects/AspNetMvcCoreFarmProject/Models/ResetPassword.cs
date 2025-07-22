using System.ComponentModel.DataAnnotations;

namespace AspNetMvcCoreFarmProject.Models
{
    public class ResetPassword
    {
        [Key]
        [Required]
        public string UserId { get; set; }

        //[Required]
        //public string Token { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm password should match the password")]
        public string ConfirmPassword { get; set; }
    }
}
