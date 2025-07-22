
using System.ComponentModel.DataAnnotations;

namespace AspNetMvcCoreFarmProject.Models
{
    public class UserModel
    {        
        [Key]
        [Display(Name = "Username")]
        [Required(ErrorMessage = "User Name field cant be left empty.")]
        [RegularExpression(@"[A-Za-z\s]{3,}", ErrorMessage = "Name can have alphabets, spaces and should be minimum 3 characters length")]
        public string Name { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password field cant be left empty.")]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&\-+=()])(?=\S+$).{8,20}$", ErrorMessage = "Password should have one upper and lower alphabets and one special character and numbers..")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "ConfirmPassword")]
        [Compare("Password", ErrorMessage = "Passwords didnt match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression("[0-9]\\d{9}", ErrorMessage = "Please enter correct mobile number.")]
        public string Mobile {  get; set; }
    }
}
