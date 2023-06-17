using Microsoft.EntityFrameworkCore;

namespace SubhasishsPieShop.Models;

public class PieRepository : IPieRepository
{
    private readonly SubhasishPieShopDbContext _subhasishPieShopDbContext;

    public PieRepository(SubhasishPieShopDbContext subhasishPieShopDbContext)
    {
        _subhasishPieShopDbContext = subhasishPieShopDbContext ?? throw new ArgumentNullException(nameof(subhasishPieShopDbContext));
    }

    public IEnumerable<Pie> AllPies 
    { 
        get
        {
            return _subhasishPieShopDbContext.Pies.Include(c=>c.Category);
        }
    }

    public IEnumerable<Pie> PiesOfTheWeek
    {
        get
        {
            return _subhasishPieShopDbContext.Pies.Include(c => c.Category).Where(p=>p.IsPieOfTheWeek);
        }
    }

    public Pie? GetPieById(int pieId)
    {
        return _subhasishPieShopDbContext.Pies.Include(c => c.Category).FirstOrDefault(p=>p.PieId==pieId);
    }

    public IEnumerable<Pie> SearchPies(string searchQuery)
    {
        throw new NotImplementedException();
    }
}
