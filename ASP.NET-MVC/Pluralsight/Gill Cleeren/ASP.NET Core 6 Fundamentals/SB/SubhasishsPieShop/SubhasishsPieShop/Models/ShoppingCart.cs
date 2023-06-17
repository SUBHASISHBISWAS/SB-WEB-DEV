using Microsoft.EntityFrameworkCore;

namespace SubhasishsPieShop.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly SubhasishPieShopDbContext _subhasishPieShopDbContext;

        public string? ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;

        public ShoppingCart(SubhasishPieShopDbContext subhasishPieShopDbContext)
        {
            _subhasishPieShopDbContext = subhasishPieShopDbContext ?? throw new ArgumentNullException(nameof(subhasishPieShopDbContext));
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

            SubhasishPieShopDbContext context = services.GetService<SubhasishPieShopDbContext>() ?? throw new Exception("Error initializing");

            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

            session?.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Pie pie)
        {
            var shoppingCartItem =
                    _subhasishPieShopDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Pie.PieId == pie.PieId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Pie = pie,
                    Amount = 1
                };

                _subhasishPieShopDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _subhasishPieShopDbContext.SaveChanges();
        }

        public int RemoveFromCart(Pie pie)
        {
            var shoppingCartItem =
                    _subhasishPieShopDbContext.ShoppingCartItems.SingleOrDefault(
                                               s => s.Pie.PieId == pie.PieId 
                                               && s.ShoppingCartId == ShoppingCartId);

            int localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _subhasishPieShopDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _subhasishPieShopDbContext.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??=
                       _subhasishPieShopDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.Pie)
                           .ToList();
        }

        public void ClearCart()
        {
            var cartItems = _subhasishPieShopDbContext
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _subhasishPieShopDbContext.ShoppingCartItems.RemoveRange(cartItems);

            _subhasishPieShopDbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _subhasishPieShopDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Pie.Price * c.Amount).Sum();
            return total;
        }

    }
}
