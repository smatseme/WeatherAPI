using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WeatherApp.Data.Models
{
    public class WeatherDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        public double Temperature { get; set; }
        [Required]
        public double FeelLikeTemp { get; set; }
        [Required]
        public string Conditions { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Humidity { get; set; }
        [Required]
        public DateTime TimeStamp { get; set; }
    }
}
