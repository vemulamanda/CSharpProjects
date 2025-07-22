using System.ComponentModel.DataAnnotations;

namespace AspNetMvcCoreFarmProject.Models
{
    public class ChangePassword
    {
        [Key]
        [Required]
        [Display(Name = "User Name")]
        [RegularExpression("[A-Za-z0-9-._@+]*")]
        public string Name { get; set; }
    }
}
