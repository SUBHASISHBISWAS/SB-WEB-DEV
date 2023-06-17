using Microsoft.EntityFrameworkCore;

namespace SubhasishsPieShop.Models
{
    public class SubhasishPieShopDbContext:DbContext
    {
        public SubhasishPieShopDbContext(DbContextOptions<SubhasishPieShopDbContext> options):base(options)
        {
                
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Chinook");
        //    }
        //}


        public DbSet<Pie> Pies { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
