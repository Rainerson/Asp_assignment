using Microsoft.EntityFrameworkCore;
using Views.Models.Identity;
using Views.Repos;

namespace Views.Services
{
    public class ProfileService
    {
        private readonly ProfileRepository _profileRepo;

        public ProfileService(ProfileRepository profileRepo)
        {
            _profileRepo = profileRepo;
        }

        public async Task<ProfileData> CreateAsync(AppUser user, ProfileData profileData)
        {
            profileData.IdentityUser = user.Id;
            var profile = await _profileRepo.AddAsync(profileData);
            return profile;
        }

      
    }
}

