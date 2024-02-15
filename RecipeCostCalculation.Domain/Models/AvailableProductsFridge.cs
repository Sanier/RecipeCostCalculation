using System;

namespace RecipeCostCalculation.Domain.Models
{
    public class AvailableProductsFridge
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Count { get; set; }
        public double Price { get; set; }
        public double EnergyValue { get; set; }
        public string RemainingShelfLife { get; set; }
    }
}
