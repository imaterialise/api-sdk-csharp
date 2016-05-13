using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace imaterialise
{
    [TestClass]
    public class _3DLabConnectionAPITest
    {
        private string apiUrl = null;
        private string filePath = null;
        private string toolID = null;

        [TestInitialize]
        public void TestInitialize()
        {
            apiUrl = "https://imatsandbox.materialise.net/Upload";

            // specify tool ID / product template ID / plugin ID
            toolID = Guid.Empty.ToString();

            // configure path to the model to upload.
            filePath = @"D:\full_path_to_the_file\car.stl";
        }

        [TestMethod]
        public void TestAdvanced3DPrintLabConnection()
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            var cookies = new CookieContainer();
            var handler = new HttpClientHandler { CookieContainer = cookies };
            
            var content = BuildRequestContent(filePath, toolID);
            using (content)
            {
                using (var client = new HttpClient(handler))
                {
                    // wait for response.
                    var result = client.PostAsync(apiUrl, content).Result;

                    var uri = new Uri(apiUrl);

                    // in case you need cookies
                    var responseCookies = cookies.GetCookies(uri).Cast<Cookie>();
                    Assert.IsTrue(responseCookies.Any(c => c.Name == "imata"));
                }
            }
        }

        private MultipartFormDataContent BuildRequestContent(string pathToTheFile, string toolID)
        {
            var content = new MultipartFormDataContent("Upload----" + DateTime.Now.ToString(CultureInfo.InvariantCulture));

            var fileInfo = new FileInfo(pathToTheFile);
            content.Add(new StreamContent(new MemoryStream(File.ReadAllBytes(pathToTheFile))), "file", fileInfo.Name);
            var values = new[]
            {
                        new KeyValuePair<string, string>("forceEmbedding", "true"),
                        new KeyValuePair<string, string>("plugin", toolID),
                        new KeyValuePair<string, string>("file", fileInfo.Name),
                        new KeyValuePair<string, string>("MATERIAL", "ÿÿ"),
                        new KeyValuePair<string, string>("COLOR", "ÀÀÀÿ")
                    };

            var formContent = new FormUrlEncodedContent(values);

            content.Add(formContent);

            foreach (var keyValuePair in values)
            {
                content.Add(new StringContent(keyValuePair.Value),
                    String.Format("\"{0}\"", keyValuePair.Key));
            }

            return content;
        }
    }
}
