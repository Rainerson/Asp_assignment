﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Views.Models.Identity;
using Views.ViewModels;

namespace Views.Services
{
    public class AuthenticationService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ProfileService _profileService;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthenticationService(UserManager<AppUser> userManager, ProfileService profileService, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _profileService = profileService;
            _signInManager = signInManager;
        }

        public async Task<bool> UserAlreadyExistsAsync(RegisterViewModel2 registerViewModel2)
        {
            return await _userManager.Users.AnyAsync(x => x.Email == registerViewModel2.Email);
        }


        public async Task<bool> RegisterUserAsync(RegisterViewModel2 registerViewModel2)
        {
            AppUser appUser = registerViewModel2;
            var result = await _userManager.CreateAsync(appUser, registerViewModel2.Password);

            if(result.Succeeded)
            {
                var IdentityUserId = await _userManager.FindByEmailAsync(registerViewModel2.Email);
                var profile = await _profileService.CreateAsync(IdentityUserId,registerViewModel2);
                if(profile != null)
                {
                    return true;
                }  
            }
            return false;
        }

        public async Task<bool> LoginAsync(LoginViewModel loginViewModel)
        {
            var appUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == loginViewModel.Email);
            if(appUser != null)
            {
                var result = await _signInManager.PasswordSignInAsync(appUser, loginViewModel.Password, loginViewModel.KeepLoggedIn, false);
                return result.Succeeded;
            }

           return false;
        }
    }
}
