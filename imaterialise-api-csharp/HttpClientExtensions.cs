using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Xml.Serialization;

namespace imaterialise
{
    public static class HttpClientExtensions
    {
        public static TReturn PostXml<T, TReturn>(this HttpClient client, string url, T obj)
        {
            using (var stream = new MemoryStream())
            {
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(stream, obj);
                stream.Position = 0;

                var sr = new StreamReader(stream);

                var xml = sr.ReadToEnd();

                var content = new StringContent(xml, Encoding.UTF8, "application/xml");
                var result = client.PostAsync(url, content).Result;

                if((int)result.StatusCode >= 400)
                    throw new InvalidOperationException("Server returned status code:" + result.StatusCode);

                var serializerResult = new XmlSerializer(typeof(TReturn));
                return (TReturn)serializerResult.Deserialize(result.Content.ReadAsStreamAsync().Result);
            }
        }
    }
}
