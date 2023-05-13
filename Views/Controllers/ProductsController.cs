using Microsoft.AspNetCore.Mvc;
using Views.Services;
using Views.ViewModels;

namespace Views.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Products";
            return View();
        }

        public IActionResult AddProduct()
        {
            ViewData["Title"] = "Add Products";
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> AddProduct(ProductRegistrationViewModel productRegistrationViewModel)
        {
            if(ModelState.IsValid)
            {
                if (await _productService.CreateAsync(productRegistrationViewModel))
                {
                    return RedirectToAction("Index", "Products");
                } else
                {
                    ModelState.AddModelError("", "Something went wrong");
                }
            }
            return View();
        }
    }
}
