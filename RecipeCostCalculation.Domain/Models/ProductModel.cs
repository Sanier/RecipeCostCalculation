namespace RecipeCostCalculation.Domain.Models
{
    public class ProductModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Count { get; set; }
        public double Price { get; set; }
        public double EnergyValue { get; set; }
        public string DateOfManufacture { get; set; }
        public string ExpirationDate { get; set; }
    }
}
