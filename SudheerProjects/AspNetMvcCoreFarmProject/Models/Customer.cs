using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetMvcCoreFarmProject.Models
{
    public class Customer
    {
        [Key]
        public int Custid { get; set; }
        //------------------------------------------------------
        [Display(Name = "Farmer Name ")]
        [Required(ErrorMessage = "Username field cant be left empty")]
        [RegularExpression(@"[A-Za-z\s]{3,}", ErrorMessage = "Name should have alphabets, spaces and minimum 3 characters length")]
        [MaxLength(50)]
        [Column(TypeName = "Varchar")]
        public string Name { get; set; }
        //------------------------------------------------------    
        //[Display(Name = "Email ")]
        //[DataType(DataType.EmailAddress)]
        //[EmailAddress(ErrorMessage = "Please enter a valid email Address")]
        //public string Email { get; set; }
        ////------------------------------------------------------
        //[Display(Name = "Mobile ")]
        //[DataType(DataType.PhoneNumber)]
        //[Phone(ErrorMessage = "Please enter a valid phone number")]
        //public string MobileNumber { get; set; }


        //------------------------------------------------------
        [Display(Name = "Name of First Breed")]
        [Required(ErrorMessage = "Please select the first breed")]
        public string FirstBreed { get; set; }
        //------------------------------------------------------
        [Display(Name = "Price of single piece each..")]
        [Required(ErrorMessage = "Please enter the price of each piece (first breed).")]
        public double FB_Price { get; set; }
        //------------------------------------------------------
        [Display(Name = "Number of pieces available.")]
        [Required(ErrorMessage = "Please enter number of pieces available (first breed).")]
        public double FB_Pieces { get; set; }
        //------------------------------------------------------


        [Display(Name = "Name of Second Breed")]
        public string? SecondBreed { get; set; }
        //------------------------------------------------------
        [Display(Name = "Price of single piece each.")]
        public double? SB_Price { get; set; }
        //------------------------------------------------------
        [Display(Name = "Number of pieces available.")]
        public double? SB_Pieces { get; set; }
        //------------------------------------------------------



        [Display(Name = "Name of Third Breed")]
        public string? ThirdBreed { get; set; }
        //------------------------------------------------------
        [Display(Name = "Price of single piece each.")]
        public double? TB_Price { get; set; }
        //------------------------------------------------------
        [Display(Name = "Number of pieces available.")]
        public double? TB_Pieces { get; set; }
        //------------------------------------------------------

        [Display(Name = "Farm Address ")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        //------------------------------------------------------

        [Display(Name = "Upload Images ")]
        public List<string>? ImagePath { get; set; }
        //------------------------------------------------------

        public string? Identity_Phone { get; set; }

        public string? Identity_Email { get; set; }

        [ForeignKey("IdentityUser")]
        public string? Identity_userId { get; set; }

        public IdentityUser? IdentityUser { get; set; }
    }
}
