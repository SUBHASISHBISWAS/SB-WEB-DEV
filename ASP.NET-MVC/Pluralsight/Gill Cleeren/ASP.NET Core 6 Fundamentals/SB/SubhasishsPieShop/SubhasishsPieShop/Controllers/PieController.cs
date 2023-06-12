using Microsoft.AspNetCore.Mvc;

namespace SubhasishsPieShop.Controllers
{
    public class PieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
