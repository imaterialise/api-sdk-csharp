namespace imaterialise.Models
{
    public class ShipmentServiceDto
    {
        public string Name { get; set; }

        public decimal Value { get; set; }

        public int? DaysInTransit { get; set; }
    }
}