using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WeatherApp.Data.Models;
using WeatherApp.Data;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.Services.Implementations
{
    public class WeatherService :IWeather
    {
        private readonly ApplicationDbContext _context;
        private HttpClient _client;
        private ILogger<WeatherService> _logger;

        public WeatherService(ApplicationDbContext context, ILogger<WeatherService> logger)
        {
            _context = context;
            _logger = logger;
            _client = new HttpClient();
        }

        public async Task AddWeatherInfo(WeatherDTO weatherApiDto)
        {
            await _context.AddAsync(weatherApiDto);
            await SaveChanges();
        }

        public async Task<WeatherApiDTO> GetLocationWeatherInfo(double? lat, double? lon)
        {
            try
            {
                if (lat.HasValue && lon.HasValue)
                {
                    HttpResponseMessage response = await _client.GetAsync(
                        $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid=2f65f2b2d61e10bd5c793afc0c705538&units=metric");
                    response.EnsureSuccessStatusCode();
                    var responseBody = await response
                        .Content
                        .ReadAsStringAsync();
                    return JsonConvert
                        .DeserializeObject<WeatherApiDTO>(responseBody);
                }
                else
                {
                    _logger.LogInformation("No latitude and longitude value passed");
                    return null;
                }
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                throw;
            }

        }

        public async Task<IEnumerable<WeatherDTO>> GetAllWeatherInfoUser()
        {
            return await _context
                .WeatherRecords
                .ToListAsync();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
