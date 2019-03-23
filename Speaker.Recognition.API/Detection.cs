using System;
using System.Net.Http.Headers;
using System.Text;
using System.Net.Http;
using System.Web;

namespace Speaker.Recognition.API
{
    public class Detection
    {
        public static string _endPoint = "https://westus.api.cognitive.microsoft.com/spid/v1.0/identificationProfiles?";
        public async void GetResponse(string key,string request )
        {
            HttpClient httpClient = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);           
            string uri = _endPoint + "?" + queryString;
            HttpResponseMessage response;
          
            byte[] byteData = Encoding.UTF8.GetBytes(request);

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("< your content type, i.e. application/json >"); //application/octet-stream
                response = await httpClient.PostAsync(uri, content);
            }

        }
    }
}
