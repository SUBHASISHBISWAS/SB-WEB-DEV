using Microsoft.EntityFrameworkCore;
using SubhasishsPieShop.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPieRepository, PieRepository>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<SubhasishPieShopDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("SubhasishPieShopDbContextConnection")));
var app = builder.Build();



app.UseStaticFiles();
app.UseSession();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

//app.MapDefaultControllerRoute();
app.MapControllerRoute(
    name:"default", 
    pattern:"{controller=Home}/{action=Index}/{id?}");

DbInitializer.Seed(app);

app.Run();
