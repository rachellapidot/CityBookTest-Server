using Weather.App.Interfaces;
using Weather.App.Model;
using Microsoft.AspNetCore.Mvc;

namespace Weather.App.Controllers
{
    [Route("[controller]")]
    public class WeatherForecastController : Controller
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private IWeatherService _weatherService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        [HttpGet]
        public async Task<ActionResult<SearchResultModel>> Search(string query)
        {
            try
            {
                return Ok(await _weatherService.Search(query));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Not able to search: " + ex.Message });
            }
        }

        [HttpGet]
        [Route("currentWeather")]
        public async Task<ActionResult<CurrentWeatherModel>> GetCurrentWeather(string cityKey)
        {
            try
            {
                return Ok(await _weatherService.GetCurrentWeather(cityKey));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error getting city weather: " + ex.Message });
            }
        }

        [HttpPost]
        [Route("favorite")]
        public async Task<ActionResult<int>> AddFavorite([FromBody]Favorite f)
        {
            try
            {
                return Ok(await _weatherService.AddFavorite(f));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error saving favorite: " + ex.Message });
            }
        }

        [HttpGet]
        [Route("favorite")]
        public async Task<ActionResult<int>> GetFavorites()
        {
            try
            {
                return Ok(await _weatherService.GetFavorites());
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error getting favorites: " + ex.Message });
            }
        }
    }
}