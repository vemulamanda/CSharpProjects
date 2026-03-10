using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMvc_FinalProject.Models
{
    public class ChangePasswordModel
    {
        //[Key]
        //[Display(Name = "User Name")]
        //[RegularExpression("[A-Za-z0-9-._@+]*")]
        //public string Username { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email Address")]
        public string Email { get; set; }
    }
}
