using Microsoft.AspNetCore.Mvc;
using Views.Services;
using Views.ViewModels;

namespace Views.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService _productService;
        private readonly CategoryService _categoryService;

        public ProductsController(ProductService productService, CategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Products";

            
            return View();
        }

        public IActionResult ProductDetails(int id)
        {
            ViewData["Title"] = "Product Details";


            return View(id);
        }


        public async Task<IActionResult> AddProduct()
        {
            ViewData["Title"] = "Add Products";
            ViewBag.Categories = await _categoryService.GetCategoryAsync();
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> AddProduct(ProductRegistrationViewModel productRegistrationViewModel, string[] categories)
        {
            if(ModelState.IsValid)
            {
                var productId = await _productService.CreateAsync(productRegistrationViewModel);
                if (productId > 0)
                {
                    await _productService.AddProductCategoryAsync(productId, categories);

                    return RedirectToAction("Index", "Products");
                } else
                {
                    ModelState.AddModelError("", "Something went wrong");
                }
            }
            ViewBag.Categories = await _categoryService.GetCategoryAsync(categories);
            return View(productRegistrationViewModel);
        }
    }
}
