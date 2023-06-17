using SubhasishsPieShop.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPieRepository, PieRepository>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddControllersWithViews();

var app = builder.Build();



app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapDefaultControllerRoute();

app.Run();
