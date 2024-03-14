using WeatherApp.Data.Models;

namespace WeatherApp.Services.Interfaces
{
    public interface IWeather
    {
        Task AddWeatherInfo(WeatherDTO weather);
        Task<WeatherApiDTO> GetLocationWeatherInfo(double? lat, double? lon);
        Task<IEnumerable<WeatherDTO>> GetAllWeatherInfoUser();
        Task SaveChanges();
    }
}
