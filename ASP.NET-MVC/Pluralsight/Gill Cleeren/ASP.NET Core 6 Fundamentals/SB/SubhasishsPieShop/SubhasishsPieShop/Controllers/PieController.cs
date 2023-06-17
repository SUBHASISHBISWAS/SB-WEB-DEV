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

        public IActionResult PieList()
        {
            ViewBag.CurrentCategory = "";

            var pieListViewModel = new PieListViewModel(_pieRepository.AllPies, "Cheese Cake");
            return View(pieListViewModel);
        }

        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie == null)
            {
                return NotFound();
            }
            return View(pie);
        }
    }
}
