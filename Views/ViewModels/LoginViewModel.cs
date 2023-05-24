using System.ComponentModel.DataAnnotations;

namespace Views.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Enter an email")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Enter a password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name = "Keep me logged in")]
        public bool KeepLoggedIn { get; set; } = false;

        public string ReturnUrl { get; set; } = "/";

    }
}
