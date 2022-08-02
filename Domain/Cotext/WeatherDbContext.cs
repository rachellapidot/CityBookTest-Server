using Microsoft.EntityFrameworkCore;
using Weather.App.Domain.Model;

namespace Weather.App.Domain.Cotext
{
    public class WeatherDbContext: DbContext
    {
        public DbSet<FavoriteCities> Favorites { get; set; }

        private static string _connectionString;

        private static string ConnectionString
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_connectionString))
                {
                    var config = new ConfigurationBuilder()
                        .AddJsonFile(Path.Combine(Environment.CurrentDirectory, "appsettings.json"))
                        .Build();
                    _connectionString = config.GetSection("ConnectionStrings")["WeatherDbConnection"];
                }
                return _connectionString;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
        
    }
}
