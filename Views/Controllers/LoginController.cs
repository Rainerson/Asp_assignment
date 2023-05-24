using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Views.Contexts;
using Views.Models.Entities;
using Views.Models.Identity;
using Views.Services;
using Views.ViewModels;

namespace Views.Controllers
{
    public class LoginController : Controller
    {

        private readonly IdentityContext _context;
        private readonly AuthenticationService _auth;

        public LoginController(IdentityContext context, AuthenticationService auth)
        {
            _context = context;
            _auth = auth;
        }


        public IActionResult Index(string ReturnUrl = null!)
        {
            var loginViewModel = new LoginViewModel();
            if(ReturnUrl !=null) { loginViewModel.ReturnUrl = ReturnUrl; }
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }


        /*        [HttpPost]
                public async Task<IActionResult> Register(RegisterViewModel2 registerViewModel)
                {
                    if (ModelState.IsValid)
                    {

                        try
                        {
                            if (!await _context.Users.AnyAsync(x => x.Email == registerViewModel.Email))
                            {
                                AppUser appUser = registerViewModel;
                                ProfileData profileData = registerViewModel;


                                _context.Users.Add(appUser);
                                await _context.SaveChangesAsync();

                                profileData.IdentityUser = appUser.Id;

                                _context.Profiles.Add(profileData);
                                await _context.SaveChangesAsync();

                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                ModelState.AddModelError("", "Email already in use");
                            }


                        }
                        catch
                        {
                            ModelState.AddModelError("", "Something went wrong");
                        }
                    }
                    return View(registerViewModel);
                }*/

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel2 registerViewModel)
        {
            {
                if (ModelState.IsValid)
                {
                    if (await _auth.UserAlreadyExistsAsync(registerViewModel))
                    {
                        ModelState.AddModelError("", "There already exists a user with this email");
                    }
                    if (await _auth.RegisterUserAsync(registerViewModel))
                    {
                        return RedirectToAction("Index", "Login");
                    }

                }

                return View(registerViewModel);

            }
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel loginViewModel)
        {

            if (ModelState.IsValid)
            {
                if (await _auth.LoginAsync(loginViewModel))
                {
                    return LocalRedirect(loginViewModel.ReturnUrl);
                }
                ModelState.AddModelError("", "Incorrect email or password");
            }

            return View(loginViewModel);
        }
    } 
}