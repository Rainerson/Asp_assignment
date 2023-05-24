using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Views.Models.Entities;
using Views.Models.Identity;

namespace Views.ViewModels
{
    public class RegisterViewModel2
    {
        [Display(Name = "First Name*")]
        [Required(ErrorMessage = "You must provide a first name")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Last Name*")]
        [Required(ErrorMessage = "You must provide a last name")]
        public string LastName { get; set; } = null!;


        [Display(Name = "Street*")]
        [Required(ErrorMessage = "You must provide a street")]
        public string StreetName { get; set; } = null!;

        [Display(Name = "Postal Code*")]
        [Required(ErrorMessage = "You must provide a postalcode")]
        public string PostalCode { get; set; } = null!;
        
        [Display(Name = "City*")]
        [Required(ErrorMessage = "You must provide a city")]
        public string City { get; set; } = null!;

        [Display(Name = "Company")]
        public string? Company { get; set; }

    /*    [Display(Name = "Image")]
        [DataType(DataType.Upload)]
        public IFormFile? ImageFile { get; set; }*/


        [Display(Name = "Image")]
        [DataType(DataType.Upload)]
        public string? ImageFile { get; set; }



    [Display(Name = "Email*")]
    [DataType(DataType.EmailAddress)]
    [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Enter a valid email")]
    public string Email { get; set; } = null!;

    [Display(Name = "Password*")]
    [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$", ErrorMessage = "Passwords must contain minimum eight characters, at least one uppercase letter, one lowercase letter, one number and one special character")]

    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;


    [Display(Name = "Confirm Password*")]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Passwords must match")]
    public string ConfirmPassword { get; set; } = null!;


    [Display(Name = "Mobile")]
    public virtual string? Mobile { get; set; }

    [Display(Name = "Terms and conditions")]
    [Required(ErrorMessage = "You must agree to the terms and conditions")]
    public bool TermsAndAgreement { get; set; } = false;




    public static implicit operator AppUser(RegisterViewModel2 registerViewModel2)
    {
        return new AppUser {
            UserName = registerViewModel2.Email,
            Email = registerViewModel2.Email,
            PhoneNumber = registerViewModel2.Mobile
        };
    }

    public static implicit operator ProfileData(RegisterViewModel2 registerViewModel2)
    {
        return new ProfileData
        {
            FirstName = registerViewModel2.FirstName,
            LastName = registerViewModel2.LastName,
            Company = registerViewModel2.Company,
            ImageFile = registerViewModel2.ImageFile,
            StreetName = registerViewModel2.StreetName,
            City = registerViewModel2.City,
            PostalCode = registerViewModel2.PostalCode,
        };

    }


}
}
