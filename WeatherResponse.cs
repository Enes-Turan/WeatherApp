using System.Text.Json.Serialization;

namespace WeatherApp
{
    public class WeatherResponse
    {
        [JsonPropertyName("main")]
        public WeatherMain Main { get; set; }

        [JsonPropertyName("weather")]
        public WeatherDescription[] Weather { get; set; }
    }

    public class WeatherMain
    {
        [JsonPropertyName("temp")]
        public float Temp { get; set; }

        [JsonPropertyName("feels_like")]
        public float FeelsLike { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }
    }

    public class WeatherDescription
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
