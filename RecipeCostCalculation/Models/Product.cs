using System.ComponentModel.DataAnnotations;

namespace RecipeCostCalculation.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Count { get; set; }
        public decimal Price { get; set; }
        public int? EnergyValue { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfManufacture { get; set; }

        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }
    }
}
