using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMvc_FinalProject.Models
{
    public class ResetPasswordModel
    {
        [Key]
        [Required]
        public string UserId { get; set; }

        [Required]
        public string SubmittedToken { get; set; }

        [Required(ErrorMessage = "Password field cant be empty.")]
        [RegularExpression(@"[A-Za-z0-9@_.-]{5,}", ErrorMessage = "Password can have only alphabets and numbers and minimum 5 characters length and NO spaces")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "ConfirmPassword")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and confirm password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
