using Microsoft.AspNetCore.Mvc;

namespace Views.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() //a route/action called Index
        {
            ViewData["Title"] = "Home";
            return View();
        }
    }
}
