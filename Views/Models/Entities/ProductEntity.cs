using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Views.Models.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public int Rating { get; set; }

        public static implicit operator ProductModel(ProductEntity entity)
        {
            return new ProductModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price,
                Rating = entity.Rating
            };
        }

        public ICollection<ProductsCategory> Categories { get; set; } = new HashSet<ProductsCategory>();
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<ProductsCategory> Products { get; set; } = new HashSet<ProductsCategory>();
    }



    [PrimaryKey(nameof(ProductId), nameof(CategoryId))]
    public class ProductsCategory
    {  
        public int ProductId { get; set; }
        public ProductEntity Product { get; set; } = null!;

        public int CategoryId { get; set; } 
        public Category Category { get; set; } = null!;
    }
}
