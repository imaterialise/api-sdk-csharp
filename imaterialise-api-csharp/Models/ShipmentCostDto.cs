using System.Xml.Serialization;

namespace imaterialise.Models
{
    public class ShipmentCostDto
    {
        [XmlArrayItem(ElementName = "Service")]
        public ShipmentServiceDto[] Services { get; set; }

        public string ShipmentError { get; set; }
    }
}