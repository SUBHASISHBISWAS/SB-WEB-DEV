using SubhasishsPieShop.Models;

namespace SubhasishsPieShop.ViewModels
{
    public class PieListViewModel
    {
        public IEnumerable<Pie> Pies { get; }

        public string? CurrentCategory { get; }

        public PieListViewModel(IEnumerable<Pie> pies, string? currentCategory)
        {
            Pies = pies ?? throw new ArgumentNullException(nameof(pies));
            CurrentCategory = currentCategory;
        }
    }
}
