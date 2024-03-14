using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherApp.Data.Models
{
    [NotMapped]
    public class WeatherApiDTO
    {
        public Weather[] weather { get; set; }

        public Main main { get; set; }
    }
}
