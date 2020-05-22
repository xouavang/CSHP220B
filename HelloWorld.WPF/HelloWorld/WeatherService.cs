using HelloWorld.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace HelloWorld
{
    public class WeatherService
    {
        private const string appId = "ba13addf5aea5b7a6ecd077819fc3cf0";

        public WeatherModel GetWeather()
        {
            //HttpClient is the class you use to call a web service.
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/"); // Do not forget the last forward slash after 2.5

            var result = client.GetAsync(string.Format("weather?appId={0}&q={1}", appId, "seattle")).Result; // .Result waits for the result

            var json = result.Content.ReadAsStringAsync().Result;

            var weatherModel = JsonConvert.DeserializeObject<WeatherModel>(json); // Convert from JSON to your object model. In this case 'WeatherModel'

            return weatherModel;
        }
    }
}
