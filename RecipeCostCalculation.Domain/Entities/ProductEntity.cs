namespace RecipeCostCalculation.Domain.Entities
{
    /// <summary>
    /// The ProductEntity class represents a product in the domain.
    /// </summary>
    public class ProductEntity
    {
        /// <summary>
        /// Gets or sets the ID of the product.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the count of the product.
        /// </summary>
        public required string Count { get; set; }

        /// <summary>
        /// Gets or sets the price of the product.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Gets or sets the energy value of the product.
        /// </summary>
        public double EnergyValue { get; set; }

        /// <summary>
        /// Gets or sets the date of manufacture of the product.
        /// </summary>
        public DateTime DateOfManufacture { get; set; }

        /// <summary>
        /// Gets or sets the expiration date of the product.
        /// </summary>
        public DateTime ExpirationDate { get; set; }
    }
}
