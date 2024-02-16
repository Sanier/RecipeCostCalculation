namespace RecipeCostCalculation.Domain.Entities
{
    public class ProductEntity
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public required string Count { get; set; }
        public double Price { get; set; }
        public double EnergyValue { get; set; }
        public DateTime DateOfManufacture { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
