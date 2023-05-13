using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Views.Contexts;
using Views.Models.Entities;
using Views.ViewModels;

namespace Views.Controllers
{
    public class LoginController : Controller
    {

        private readonly DataContext _context;

        public LoginController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult AccountPage()
        {
            return View();
        }

        //Egentligen ska vi ha en Service som hanterar databas-sökningar osv och inte göra det här. se föreläsning 4, från 2h30min

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    if (!await _context.Users.AnyAsync(x => x.Email == registerViewModel.Email))
                    {
                        UserEntity userEntity = registerViewModel;
                        ProfileEntity profileEntity = registerViewModel;


                        _context.Users.Add(userEntity);
                        await _context.SaveChangesAsync();

                        profileEntity.UserId = userEntity.Id;

                        _context.Profiles.Add(profileEntity);
                        await _context.SaveChangesAsync();

                        return RedirectToAction("Index", "Home");
                    } else
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
        }


        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var userEntity = await _context.Users.FirstOrDefaultAsync(x => x.Email == loginViewModel.Email);
                if(userEntity != null)
                {
                    if(userEntity.VerifySecurePassword(loginViewModel.Password))
                    {
                       return RedirectToAction("AccountPage", "Login");
                    }
                }

            ModelState.AddModelError("", "Wrong email och password");
            } 
            return View(loginViewModel);
        }






    }
}
