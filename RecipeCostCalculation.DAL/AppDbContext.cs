using Microsoft.EntityFrameworkCore;
using RecipeCostCalculation.Domain.Entities;
using RecipeCostCalculation.Domain.Models;

namespace RecipeCostCalculation.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<RecipeEntity> Recipe { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }
    }
}
