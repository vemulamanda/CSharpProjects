using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCDataAnnotations.Models
{
	public class User
	{
		[Display(Name = "User Name: ")]
		[Required(ErrorMessage = "User Name field cant be left empty.")]
		[RegularExpression(@"[A-Za-z\s]{3,}", ErrorMessage = "Name can have alphabets, spaces and minimum 3 characters length" )]
		public string Name { get; set; }

		[DataType(DataType.Password)]
        [Required(ErrorMessage = "Password field cant be left empty.")]
		[RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&\-+=()])(?=\S+$).{8,20}$", ErrorMessage = "Password should have one upper and lower alphabets and one special character and numbers..")]
        public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Confirm Password: ")]
        [Required(ErrorMessage = "Confirm Password field cant be left empty.")]
		[Compare("Password", ErrorMessage = "Confirm password should match with password.")]
        public string ConfirmPassword { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = "Date of Birth")]
		[Required(ErrorMessage = "Date cannot be left empty.")]
		[System.Web.Mvc.Remote("IsDateValid", "User", ErrorMessage = "You should be above 18 years of age to register.")]
		public DateTime DOB { get; set; }

        [Display(Name = "Mobile No")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"[6-9]\d{9}", ErrorMessage = "Mobile No. should start with 6, 7, 8, and 9 only and can be having a length of 10 digits (both Max & Min).")]
		public string Mobile { get; set; }

        [Display(Name = "Email ID:")]
		[DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Address:")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

	}
}