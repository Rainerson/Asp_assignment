using Views.Contexts;
using Views.Models.Identity;

namespace Views.Repos
{
    public class ProfileRepository : Repository<ProfileData>
    {
        public ProfileRepository(IdentityContext context) : base(context)
        {
        }
    }
}
