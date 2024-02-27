using Microsoft.EntityFrameworkCore;
using RecipeCostCalculation.DAL;
using RecipeCostCalculation.DAL.Interfaces;
using RecipeCostCalculation.DAL.Repositories;
using RecipeCostCalculation.Domain.Entities;
using RecipeCostCalculation.Service.Implementations;
using RecipeCostCalculation.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services
    .AddScoped<IBaseRepositories<ProductEntity>, ProductRepositories>()
    .AddScoped<IProductService, ProductService>()
    .AddDbContext<AppDbContext>(options =>
    {
        var connectionString = builder.Configuration.GetConnectionString("postgres");
        options.UseNpgsql(connectionString);
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "Product",
    pattern: "{controller=Product}/{action=Product}/{id?}"
    );

app.Run();
