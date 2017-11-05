using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using RestSharp;
using Newtonsoft.Json;

namespace RESTClient
{
    public class DBAccess
    {
        public async Task<List<Marker>> RetrieveMarkerList()
        {
            var client = new RestClient("http://avoidaticketapi20171104033218.azurewebsites.net/");

            var request = new RestRequest("api/marker", Method.GET);

            var asyncQueryResult = await client.ExecuteTaskAsync<List<Marker>>(request);

            var markers = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<Marker>>(asyncQueryResult.Content));

            return markers;
        }

        public void SaveMarker(Marker marker)
        {
            var client = new RestClient("http://avoidaticketapi20171104033218.azurewebsites.net/");

            var request = new RestRequest("api/marker", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };
            request.AddBody(marker);
            request.AddHeader("content-type", "application/json");

            client.Execute(request);
        }
    }
}
