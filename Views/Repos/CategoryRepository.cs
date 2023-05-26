using Views.Contexts;
using Views.Models.Entities;

namespace Views.Repos
{
    public class CategoryRepository : Repository<Category>
    {
        public CategoryRepository(IdentityContext context) : base(context)
        {
        }
    }
}
