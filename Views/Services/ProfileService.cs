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

        /*        public async Task<ProfileData> GetOrCreateAsync(AppUser user, ProfileData profileData)
                {

                    var profile = await _profileRepo.GetAsync(x => 
                    x.FirstName == profileData.FirstName &&
                    x.LastName == profileData.LastName &&
                    x.Company == profileData.Company &&
                    x.ImageFile == profileData.ImageFile &&
                    x.StreetName == profileData.StreetName &&
                    x.City == profileData.City &&
                    x.PostalCode == profileData.PostalCode &&
                    x.IdentityUser == user.Id
                    );

                        profile ??= await _profileRepo.AddAsync(profileData);
                        return profile!;

                }*/

        /*        public async Task AddProfileAsync(AppUser user, ProfileData profileData)
                {
                    profileData.IdentityUser = user.Id;
                    await _profileRepo.AddAsync(profileData);
                }*/

    }
}

