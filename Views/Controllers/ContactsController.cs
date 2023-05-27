using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Views.Services;
using Views.ViewModels;
using Microsoft.AspNetCore.Http;

namespace Views.Controllers
{
    public class ContactsController : Controller
    {

        private readonly ContactFormService _formService;

        public ContactsController(ContactFormService formService)
        {
            _formService = formService;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Contact";

            string cookieValue = Request.Cookies["FormDataCookie"];
            if (cookieValue != null)
            {
                string[] values = cookieValue.Split(':');
                string name = values[0];
                string email = values[1];

                ViewBag.Name = name;
                ViewBag.Email = email;
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactFormModel viewModel, bool rememberMe)
        {
            //For the cookie, brought to you by ChatGPT
            if (rememberMe)
            {
                CookieOptions options = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(30)
                };

                string cookieValue = $"{viewModel.Name}:{viewModel.Email}";

                Response.Cookies.Append("FormDataCookie", cookieValue, options);
            }

            if (ModelState.IsValid)
            {
               if(await _formService.CreateAsync(viewModel))
                {
                    ViewBag.SuccessMessage = "Thank you for you message!";
                    return View("Index", viewModel);
                }  else
                {
                    ModelState.AddModelError("", "Something went wrong");
                }
            }
            return View();
        }
    }
}
