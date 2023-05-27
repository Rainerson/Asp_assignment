using System.ComponentModel.DataAnnotations;
using Views.Models.Entities;

namespace Views.ViewModels
{
    public class ContactFormModel
    {
        [Required(ErrorMessage = "Enter a name")]
        [Display(Name = "Name*")]
        public string Name { get; set; } = null!;


        [Required(ErrorMessage = "Enter an email")]
        [Display(Name = "Email*")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Display(Name = "Phone")]
        public string? Phone { get; set; }

        [Display(Name = "Company")]
        public string? Company { get; set; }


        [Required(ErrorMessage = "Enter a message")]
        [Display(Name = "Message*")]
        public string Message { get; set; } = null!;

        public static implicit operator ContactFormEntity(ContactFormModel viewModel)
        {
            return new ContactFormEntity
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Company = viewModel.Company,
                Message = viewModel.Message,

            };
        }
    }
}
