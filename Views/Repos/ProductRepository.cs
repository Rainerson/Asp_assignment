using Views.Contexts;
using Views.Models.Entities;

namespace Views.Repos
{
    public class ProductRepository : Repository<ProductEntity>
    {
        public ProductRepository(IdentityContext context) : base(context)
        {
        }
    }
}
