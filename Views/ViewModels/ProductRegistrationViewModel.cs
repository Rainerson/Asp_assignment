using System.ComponentModel.DataAnnotations;
using Views.Models.Entities;

namespace Views.ViewModels
{
    public class ProductRegistrationViewModel
    {

        [Display(Name = "Product name")]
        public string Name { get; set; } = null!;


        [Display(Name = "Description")]
        public string Description { get; set; } = null!;


        [Display(Name = "Price")]
        public decimal Price { get; set; }


        [Display(Name = "Rating")]
        public int Rating { get; set; }

        public static implicit operator ProductEntity(ProductRegistrationViewModel productRegistrationViewModel)
        {
            return new ProductEntity
            {
                Name = productRegistrationViewModel.Name,
                Description = productRegistrationViewModel.Description,
                Price = productRegistrationViewModel.Price,
                Rating = productRegistrationViewModel.Rating
            };
        }
    }
}
