using Microsoft.EntityFrameworkCore;
using SubhasishsPieShop.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPieRepository, PieRepository>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<SubhasishPieShopDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("SubhasishPieShopDbContextConnection")));
var app = builder.Build();



app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapDefaultControllerRoute();

app.Run();
