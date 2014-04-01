using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace imaterialise.Models
{
    [XmlRoot(ElementName = "PriceResponse")]
    public class PricingResponseDto
    {
        [XmlArrayItem(ElementName = "Model")]
        public List<ModelPricingResponseDto> Models { get; set; }

        public string Disclaimer { get; set; }

        public ShipmentCostDto ShipmentCost { get; set; }

        public string Currency { get; set; }

        public string RequestError { get; set; }

        public ErrorDto Error { get; set; }
    }
}