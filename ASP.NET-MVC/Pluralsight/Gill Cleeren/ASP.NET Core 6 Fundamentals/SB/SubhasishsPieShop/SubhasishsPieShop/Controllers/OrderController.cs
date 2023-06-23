using Microsoft.AspNetCore.Mvc;
using SubhasishsPieShop.Models;

namespace SubhasishsPieShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IShoppingCart _shoppingCart;

        // Injecting IOrderRepository and IShoppingCart
        public OrderController(IOrderRepository orderRepository, IShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }
        public IActionResult Checkout()
        {
            return View();
        }
    }
}
