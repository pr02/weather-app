using System;
using System.Text.Json.Serialization;

namespace WeatherApp
{

    // public partial class Temperatures
    // {
    //     [JsonPropertyName("location")]
    //     public Location location { get; set; }

    //     [JsonPropertyName("current")]
    //     public Current Current { get; set; }
    // }

    public class Current
    {
        // [JsonPropertyName("last_updated_epoch")]
        // public long LastUpdatedEpoch { get; set; }

        // [JsonPropertyName("last_updated")]
        // public string LastUpdated { get; set; }

        // [JsonPropertyName("temp_c")]
        // public long TempC { get; set; }

        [JsonPropertyName("wind_kph")]
        public double WindKph { get; set; }


    }
}