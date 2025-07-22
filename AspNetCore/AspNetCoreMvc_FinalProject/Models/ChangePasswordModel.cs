using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMvc_FinalProject.Models
{
    public class ChangePasswordModel
    {
        [Key]
        [Required]
        [Display(Name = "User Name")]
        [RegularExpression("[A-Za-z0-9-._@+]*")]
        public string Name { get; set; }
    }
}
