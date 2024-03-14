namespace WeatherApp.Data.Models
{
    public class Weather
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
    }
}
