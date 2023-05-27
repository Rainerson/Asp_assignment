using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Views.Models.Identity;

namespace Views.Services
{
    public class UserAdminService
    {

        private readonly UserManager<AppUser> _userManager;

        public UserAdminService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var users = new List<User>();
            foreach (var user in await _userManager.Users.ToListAsync())
            {
                var _user = new User
                {
                    Id = user.Id,
                    Email = user.Email!,
                };

                foreach(var role in await _userManager.GetRolesAsync(user))
                {
                    _user.Roles.Add(role);
                }
                users.Add(_user);
            }

            return users;
        }
    }
}

public class User
{
    public string Id { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public List<string> Roles { get; set; } = new List<string>();
}
