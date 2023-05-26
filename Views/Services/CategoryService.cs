using Microsoft.AspNetCore.Mvc.Rendering;
using Views.Repos;

namespace Views.Services
{
    public class CategoryService
    {
        private readonly CategoryRepository _categoryRepo;

        public CategoryService(CategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<List<SelectListItem>> GetCategoryAsync()
        {
            var categories = new List<SelectListItem>();

            foreach (var category in await _categoryRepo.GetAllAsync())
            {
                categories.Add(new SelectListItem
                {
                    Value = category.Id.ToString(),
                    Text = category.Name
            });
            }
            return categories;
        }

        public async Task<List<SelectListItem>> GetCategoryAsync(string[] selectedCategories)
        {
            var categories = new List<SelectListItem>();

            foreach (var category in await _categoryRepo.GetAllAsync())
            {
                categories.Add(new SelectListItem
                {
                    Value = category.Id.ToString(),
                    Text = category.Name,
                    Selected = selectedCategories!.Contains(category.Id.ToString())
                });
            }
            return categories;
        }
    }
}
