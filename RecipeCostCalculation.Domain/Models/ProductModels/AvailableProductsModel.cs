namespace RecipeCostCalculation.Domain.Models.ProductModels
{
    public class AvailableProductsModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Count { get; set; }
        public double Price { get; set; }
        public double EnergyValue { get; set; }
        public int RemainingShelfLife { get; set; }
    }
}
