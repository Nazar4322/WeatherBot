using Newtonsoft.Json;
using System.Net;
using static System.Net.WebRequestMethods;

namespace WeatherProgramm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string url = "http://api.openweathermap.org/geo/1.0/direct?q=Odesa&appid=6b2728f4ef9b1d4baa8e54394d176f4b";
            WebRequest webRequest = WebRequest.Create(url);
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            Stream stream = webResponse.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string data = reader.ReadToEnd();

            List<City>citys = JsonConvert.DeserializeObject<List<City>>(data);
            foreach ( var city in citys)
            {
                Console.WriteLine(city.Country);

                webRequest = WebRequest.Create($"https://api.openweathermap.org/data/2.5/weather?lat={city.Lat}&lon={city.Lon}&appid=6b2728f4ef9b1d4baa8e54394d176f4b");
                webResponse = (HttpWebResponse)webRequest.GetResponse();
                stream = webResponse.GetResponseStream();
                reader = new StreamReader(stream);
                data = reader.ReadToEnd();
                WeatherInfo weatherInfo = JsonConvert.DeserializeObject<WeatherInfo>(data);
                Console.WriteLine($"Температура: {(double.Parse(weatherInfo.Main.Temp.Split(".")[0]) - 273.15)}");
                Console.WriteLine($"Хмарнiсть: {weatherInfo.Clouds.All}");
                Console.WriteLine($"Погода: {weatherInfo.Weather[0].Main}");
                Console.WriteLine($"Хмарнiсть:  {weatherInfo.Clouds.All}");
            }
        }

    }
}
