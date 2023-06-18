using Microsoft.AspNetCore.Mvc;
using SubhasishsPieShop.Models;

namespace SubhasishsPieShop.Components
{
    public class CategoryMenu :ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryMenu(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new System.ArgumentNullException(nameof(categoryRepository));
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryRepository.AllCategories.OrderBy(c=>c.CategoryName);
            return View(categories);
        }


    }
}
