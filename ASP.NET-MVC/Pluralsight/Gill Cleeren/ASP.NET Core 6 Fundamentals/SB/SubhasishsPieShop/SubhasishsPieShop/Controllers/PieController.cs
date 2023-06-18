using Microsoft.AspNetCore.Mvc;

using SubhasishsPieShop.Models;
using SubhasishsPieShop.ViewModels;

namespace SubhasishsPieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository ?? throw new ArgumentNullException(nameof(pieRepository));
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        //public IActionResult PieList()
        //{
        //    ViewBag.CurrentCategory = "";

        //    var pieListViewModel = new PieListViewModel(_pieRepository.AllPies, "Cheese Cake");
        //    return View(pieListViewModel);
        //}

        public IActionResult PieList(string category)
        {
            IEnumerable<Pie> pies;
            string? currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                pies = _pieRepository.AllPies.OrderBy(p => p.PieId);
                currentCategory = "All Pies";
            }
            else
            {
                pies = _pieRepository.AllPies.Where(p => p.Category.CategoryName == category)
                    .OrderBy(p => p.PieId);
                currentCategory = _categoryRepository.AllCategories.
                    FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }
            return View(new PieListViewModel(pies, currentCategory));
        }

        public IActionResult Details(int pieId)
        {
            var pie = _pieRepository.GetPieById(pieId);
            if (pie == null)
            {
                return NotFound();
            }
            return View(pie);
        }
    }
}
