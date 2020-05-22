using HelloWorld.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace HelloWorld
{
    public class ImageService
    {
        public ImageModel GetImage()
        {
            //HttpClient is the class you use to call a web service.
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Client-ID 2280591526449b5");
            client.BaseAddress = new Uri("http://api.imgur.com/3/gallery/t/kitten"); // Do not forget the last forward slash after 2.5

            var result = client.GetAsync("").Result; // .Result waits for the result

            var json = result.Content.ReadAsStringAsync().Result;

            var imageModel = JsonConvert.DeserializeObject<ImageModel>(json); // Convert from JSON to your object model. In this case 'WeatherModel'

            return imageModel;
        }
    }
}
