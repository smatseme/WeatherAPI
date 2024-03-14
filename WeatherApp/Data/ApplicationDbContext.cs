using Microsoft.EntityFrameworkCore;
using WeatherApp.Data.Models;

namespace WeatherApp.Data
{
    public class ApplicationDbContext :DbContext
    {
        public DbSet<WeatherDTO> WeatherRecords { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
