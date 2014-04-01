using System;

namespace imaterialise.Models
{
    [Serializable]
    public class ModelPricingRequestDto : ModelPricingRequestDtoBase
    {
        public string ModelReference { get; set; }

        public string ToolID { get; set; }

        public string XDimMm { get; set; }

        public string YDimMm { get; set; }

        public string ZDimMm { get; set; }

        public string VolumeCm3 { get; set; }

        public string SurfaceCm2 { get; set; }
    }
}
