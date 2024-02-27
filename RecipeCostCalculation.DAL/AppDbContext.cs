using Microsoft.EntityFrameworkCore;
using RecipeCostCalculation.Domain.Entities;

namespace RecipeCostCalculation.DAL
{
    /// <summary>
    /// The AppDbContext class represents a session with the database and can be used to query and save instances of your entities.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Gets or sets the DbSet of ProductEntity.
        /// </summary>
        public DbSet<ProductEntity> Products { get; set; }

        /// <summary>
        /// Gets or sets the DbSet of RecipeEntity.
        /// </summary>
        public DbSet<RecipeEntity> Recipe { get; set; }

        /// <summary>
        /// Constructor for the AppDbContext class.
        /// </summary>
        /// <param name="options">The options to be used by a DbContext.</param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }
    }
}
