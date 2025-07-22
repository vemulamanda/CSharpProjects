using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCAppWithFormsAuth.Models
{
    public class LoginModel
    {
        [Display(Name = "User Id")]
        [Required(ErrorMessage = "Cant leave the field empty.")]
        [RegularExpression("[A-Za-z0-9]{6,20}", ErrorMessage = "User Id value cant be empty or Invalid.")]
        public string UserId { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Can't leave the field empty.")]
        [RegularExpression("[A-Z]{1}[a-z0-9@#$%_-]{7,15}", ErrorMessage = "Password cant be empty or invalid..")]
        public string Password { get; set; }
    }
}