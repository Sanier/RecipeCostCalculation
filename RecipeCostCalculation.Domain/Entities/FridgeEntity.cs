namespace RecipeCostCalculation.Domain.Entities
{
    public class FridgeEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Count { get; set; }
        public double Price { get; set; }
        public double EnergyValue { get; set; }
        public DateTime DateOfManufacture { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
