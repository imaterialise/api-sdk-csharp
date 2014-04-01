namespace imaterialise.Models
{
    public abstract class ModelPricingRequestDtoBase
    {
        public string MaterialID { get; set; }

        public string FinishID { get; set; }

        public string Quantity { get; set; }
    }
}