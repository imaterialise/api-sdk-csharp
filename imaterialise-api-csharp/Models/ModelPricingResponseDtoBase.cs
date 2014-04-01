namespace imaterialise.Models
{
    public abstract class ModelPricingResponseDtoBase
    {
        public string ToolID { get; set; }

        public string MaterialID { get; set; }

        public string MaterialName { get; set; }

        public string FinishID { get; set; }

        public string FinishingName { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal XDimMm { get; set; }

        public decimal YDimMm { get; set; }

        public decimal ZDimMm { get; set; }

        public decimal VolumeCm3 { get; set; }

        public decimal SurfaceCm2 { get; set; }

        public bool IsToolIDPrice { get; set; }

        public ErrorDto PricingError { get; set; }
    }
}