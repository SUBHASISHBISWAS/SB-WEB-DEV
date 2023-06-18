using Microsoft.AspNetCore.Mvc;
using SubhasishsPieShop.Models;
using SubhasishsPieShop.ViewModels;

namespace SubhasishsPieShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCart _shoppingCart;
        private readonly IPieRepository _pieRepository;

        public ShoppingCartController(IShoppingCart shoppingCart, IPieRepository pieRepository)
        {
            _shoppingCart = shoppingCart ?? throw new ArgumentNullException(nameof(shoppingCart));
            _pieRepository = pieRepository ?? throw new ArgumentNullException(nameof(pieRepository));
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart, 
                _shoppingCart.GetShoppingCartTotal());

            return View(shoppingCartViewModel);
        }

        public IActionResult RemoveFromShoppingCart(int pieId)
        {
            var pie = _pieRepository.GetPieById(pieId);

            if (pie != null)
            {
                _shoppingCart.RemoveFromCart(pie);
            }

            return RedirectToAction("Index");
        }

        public IActionResult AddToShoppingCart(int pieId)
        {
            var pie = _pieRepository.GetPieById(pieId);

            if (pie != null)
            {
                _shoppingCart.AddToCart(pie);
            }

            return RedirectToAction("Index");
        }
       
    }
}
