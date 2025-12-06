using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class WeatherService
    {
        private readonly string _apiKey;
        private readonly HttpClient client = new HttpClient();

        public WeatherService(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task<WeatherResponse?> GetWeatherAsync(string city)
        {
            string url =
                $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}&units=metric&lang=tr";

            HttpResponseMessage response;

            try
            {
                response = await client.GetAsync(url);
            }
            catch
            {
                Console.WriteLine("\n❌ İnternet bağlantısı yok veya sunucuya ulaşılamıyor.");
                return null;
            }

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Console.WriteLine("\n❌ Böyle bir şehir bulunamadı.");
                return null;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                Console.WriteLine("\n❌ API anahtarı hatalı.");
                return null;
            }
            else if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"\n❌ API hatası: {response.StatusCode}");
                return null;
            }

            string json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<WeatherResponse>(json);
        }
    }
}
