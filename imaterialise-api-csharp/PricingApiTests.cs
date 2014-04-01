using System.Collections.Generic;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using imaterialise.Models;

namespace imaterialise
{
    [TestClass]
    public class PricingTests
    {
        private HttpClient client = null;

        private PricingRequestDto requestDto = null;

        private ModelPricingRequestDto model = null;

        private string apiUrl = null;

        [TestInitialize]
        public void Setup()
        {
            apiUrl = "https://imatsandbox.materialise.net/web-api/pricing";

            client = new HttpClient();
            client.DefaultRequestHeaders.Add("ApiCode", "1E0C64D0-AEA9-490D-BA5E-7B02387EA968");
            
            model = new ModelPricingRequestDto()
            {
                ToolID = null,
                ModelReference = "some model.xml",
                MaterialID = "035f4772-da8a-400b-8be4-2dd344b28ddb",
                FinishID = "bba2bebb-8895-4049-aeb0-ab651cee2597",
                Quantity = "2",
                XDimMm = "10",
                YDimMm = "10",
                ZDimMm = "10",
                VolumeCm3 = "1.0",
                SurfaceCm2 = "6"
            };

            requestDto = new PricingRequestDto()
            {
                Models = new List<ModelPricingRequestDto>() 
                { 
                    model
                },
                Currency = "EUR"
            };
        }

        [TestMethod]
        public void should_return_price_for_specified_parameters()
        {
            var result = client.PostXml<PricingRequestDto, PricingResponseDto>(apiUrl, requestDto);
            
            //check the result
        }
    }
}
