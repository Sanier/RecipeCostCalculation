namespace RecipeCostCalculation.Domain.Models
{
    public class CreateProductModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Count { get; set; }
        public double Price { get; set; }
        public double EnergyValue { get; set; }
        public string ExpirationDate { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentNullException(Name, "");

            if (string.IsNullOrWhiteSpace(Count))
                throw new ArgumentNullException(Count, "");

            //if (string.IsNullOrWhiteSpace(ExpirationDate))
            //    throw new ArgumentNullException(ExpirationDate, "");
        }
    }
}
