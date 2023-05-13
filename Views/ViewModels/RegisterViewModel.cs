using System.ComponentModel.DataAnnotations;
using Views.Models.Entities;

namespace Views.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "First Name*")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Last Name*")]
        public string LastName { get; set; } = null!;

        [Display(Name = "Email*")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage ="Enter a valid email")]
        public string Email { get; set; } = null!;

        [Display(Name = "Street*")]
        public string StreetName { get; set; } = null!;

        [Display(Name = "City*")]
        public string City { get; set; } = null!;

        [Display(Name = "Postal Code*")]
        public string PostalCode { get; set; } = null!;

        [Display(Name = "Password*")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name = "Confirm Password*")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage ="Passwords must match")]
        public string ConfirmPassword { get; set; } = null!;


        [Display(Name = "Mobile")]
        public string? Mobile { get; set; }

        [Display(Name = "Company")]
        public string? Company { get; set; }

        [Display(Name = "Image")]
        public string? Image { get; set; }


        public static implicit operator UserEntity(RegisterViewModel registerViewModel)
        {
            var userEntity = new UserEntity { Email = registerViewModel.Email };
            userEntity.GenerateSecurePassword(registerViewModel.Password);
            return userEntity;
        }

        public static implicit operator ProfileEntity(RegisterViewModel registerViewModel)
        {
            return new ProfileEntity
            {
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
                Mobile = registerViewModel.Mobile,
                Company = registerViewModel.Company,
                Image = registerViewModel.Image,
                StreetName = registerViewModel.StreetName,
                City = registerViewModel.City,
                PostalCode = registerViewModel.PostalCode,
            };

        }
    }
}
