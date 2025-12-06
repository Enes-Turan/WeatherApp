using System;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.Extensions.Configuration;

namespace WeatherApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            string apiKey = config["OpenWeatherApiKey"];

            Console.Write("Şehir adı girin: ");
            string city = Console.ReadLine();

            city = NormalizeCityName(city);

            WeatherService weatherService = new WeatherService(apiKey);
            var result = await weatherService.GetWeatherAsync(city);

            if (result != null)
            {
                Console.WriteLine($"\n🌤️ {city.ToUpper()} Hava Durumu:");
                Console.WriteLine($"Sıcaklık     : {result.Main.Temp}°C");
                Console.WriteLine($"Hissedilen   : {result.Main.FeelsLike}°C");
                Console.WriteLine($"Nem          : {result.Main.Humidity}%");
                Console.WriteLine($"Durum        : {result.Weather[0].Description}");
            }
            else
            {
                Console.WriteLine("\n❌ Hava durumu bilgisi alınamadı.");
            }
        }

        static string NormalizeCityName(string text)
        {
            text = text.Trim();

            return text
                .Replace("İ", "I")
                .Replace("ı", "i")
                .Replace("Ş", "S")
                .Replace("ş", "s")
                .Replace("Ğ", "G")
                .Replace("ğ", "g")
                .Replace("Ü", "U")
                .Replace("ü", "u")
                .Replace("Ö", "O")
                .Replace("ö", "o")
                .Replace("Ç", "C")
                .Replace("ç", "c")
                .ToLower(new CultureInfo("en-US"));
        }
    }
}
