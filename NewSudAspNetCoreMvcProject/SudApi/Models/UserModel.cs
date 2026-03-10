using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SudApi.Models
{
    public class UserModel
    {
        [Key]
        [Required(ErrorMessage = "Username field cant be empty.")]
        [RegularExpression(@"[A-Za-z0-9]{3,}", ErrorMessage = "Name can have only alphabets, numbers and minimum 3 characters length and NO spaces")]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password field cant be empty.")]
        [RegularExpression(@"[A-Za-z0-9@_.-]{5,}", ErrorMessage = "Password can have only alphabets and numbers and minimum 5 characters length and NO spaces")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name="ConfirmPassword")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and confirm password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email Address")]
        public string? Email { get; set; }

        [Required]
        [Phone(ErrorMessage = "Please enter a valid phone number")]
        [RegularExpression("[6-9]\\d{9}", ErrorMessage = "Please enter correct mobile number.")]
        public string Mobile { get; set; }
    }
}
