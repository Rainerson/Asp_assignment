using Microsoft.AspNetCore.Mvc;

namespace Views.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Contact";
            return View();
        }
    }
}
