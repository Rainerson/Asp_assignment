using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Views.Contexts;
using Views.Models;
using Views.Models.Entities;
using Views.Repos;
using Views.ViewModels;

namespace Views.Services
{
    public class ProductService
    {
        private readonly IdentityContext _context;
        private readonly ProductCategoryRepository _productCategoryRepo;

        public ProductService(IdentityContext context, ProductCategoryRepository productCategoryRepo)
        {
            _context = context;
            _productCategoryRepo = productCategoryRepo;
        }

        public async Task<int> CreateAsync(ProductRegistrationViewModel productRegistrationViewModel)
        {

                ProductEntity productEntity = productRegistrationViewModel;

                _context.Products.Add(productEntity);
                await _context.SaveChangesAsync();

                return productEntity.Id;

        }

        public async Task AddProductCategoryAsync(int productId, string[] categories)
        {

            foreach (var category in categories)
             {
                 await _productCategoryRepo.AddAsync(new ProductsCategory
                 {
                     ProductId = productId,
                     CategoryId = int.Parse(category)
                 });
             }
        }

        public async Task<IEnumerable<ProductModel>> GetAllAsync()
        {
            var products = new List<ProductModel>();
            var items = await _context.Products.ToListAsync();
            foreach (var item in items)
            {
                ProductModel productModel = item;
                products.Add(productModel);
            }

            return products;
        }
    }
}
