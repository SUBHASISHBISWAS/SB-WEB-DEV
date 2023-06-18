using Microsoft.AspNetCore.Mvc;
using SubhasishsPieShop.Models;
using SubhasishsPieShop.ViewModels;

namespace SubhasishsPieShop.Components
{
    public class ShoppingCartSummary:ViewComponent
    {
        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartSummary(IShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart ?? throw new System.ArgumentNullException(nameof(shoppingCart));
        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var _shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart, 
                _shoppingCart.GetShoppingCartTotal());
            return View(_shoppingCartViewModel);
        }

    }   
}
