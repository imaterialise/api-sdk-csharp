using System.Collections.Generic;
using System.Xml.Serialization;

namespace imaterialise.Models
{
    [XmlRoot(ElementName = "PricingRequest")]
    public class PricingRequestDto
    {
        [XmlArrayItem(ElementName = "Model")]
        public List<ModelPricingRequestDto> Models { get; set; }

        public ShipmentInfoDto ShipmentInfo { get; set; }

        public string Currency { get; set; }
    }
}