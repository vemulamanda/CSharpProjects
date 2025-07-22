using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMvc_FinalProject.Models
{
    public class UserModel
    {
        [Required]
        [Key]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name="ConfirmPassword")]
        [Compare("Password", ErrorMessage = "Passwords didnt match")]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression("[6-9]\\d{9}", ErrorMessage = "Please enter correct mobile number.")]
        public string Mobile { get; set; }
    }
}
