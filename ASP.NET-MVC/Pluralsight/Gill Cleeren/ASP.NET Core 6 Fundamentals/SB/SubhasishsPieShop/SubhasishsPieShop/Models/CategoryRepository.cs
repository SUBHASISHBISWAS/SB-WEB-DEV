namespace SubhasishsPieShop.Models
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly SubhasishPieShopDbContext _subhasishPieShopDbContext;

        public CategoryRepository(SubhasishPieShopDbContext subhasishPieShopDbContext)
        {
            _subhasishPieShopDbContext = subhasishPieShopDbContext ?? throw new ArgumentNullException(nameof(subhasishPieShopDbContext));
        }

        public IEnumerable<Category> AllCategories
        {
            get
            {
                return _subhasishPieShopDbContext.Categories.OrderBy(p=>p.CategoryName);
            }
        }
    }
}
