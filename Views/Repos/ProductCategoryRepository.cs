using Views.Contexts;
using Views.Models.Entities;

namespace Views.Repos
{
    public class ProductCategoryRepository : Repository<ProductsCategory>
    {
        public ProductCategoryRepository(IdentityContext context) : base(context)
        {
        }
    }
}
