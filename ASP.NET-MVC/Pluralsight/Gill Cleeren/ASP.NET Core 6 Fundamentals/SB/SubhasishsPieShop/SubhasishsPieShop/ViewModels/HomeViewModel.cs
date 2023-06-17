using SubhasishsPieShop.Models;

namespace SubhasishsPieShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Pie> PiesOfTheWeek { get; }

        public HomeViewModel(IEnumerable<Pie> piesOfTheWeek)
        {
            PiesOfTheWeek = piesOfTheWeek ?? throw new ArgumentNullException(nameof(piesOfTheWeek));
        }
    }
}
