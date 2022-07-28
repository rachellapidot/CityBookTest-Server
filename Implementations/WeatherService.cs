using System.Net.Http.Headers;
using Newtonsoft.Json;
using Weather.App.Interfaces;
using Weather.App.Model;

namespace Weather.App.Implementations
{
    public class WeatherService : IWeatherService
    {
        private readonly string apiKey = "l0fm4Em4HNhpAWXCmRpAeYK6MycjAflD";

        private readonly string baseUrl = "http://dataservice.accuweather.com/";

        private readonly ICacheService cacheService;

        static HttpClient client = new HttpClient();

        public WeatherService(ICacheService _cacheService)
        {
            cacheService = _cacheService;
        }
        public async Task<List<SearchResultModel>> Search(string query)
        {
            List<SearchResultModel> searchResultList = new List<SearchResultModel>();
            HttpResponseMessage response = await client.GetAsync(baseUrl + "locations/v1/cities/autocomplete?apikey="+apiKey+ "&q=" +query+"&language=he");
            if(response.IsSuccessStatusCode == false)
            {
                throw new Exception();
            }

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                searchResultList = JsonConvert.DeserializeObject<List<SearchResultModel>>(apiResponse);
             }
             return searchResultList;
         }

        public async Task<CurrentWeatherModel> GetCurrentWeather(string cityKey)
        {
            CurrentWeatherModel cityWeather = cacheService.OnGet(cityKey);

            if (cityWeather == null) {
                CurrentWeatherModel currentWeatherModel = null;
                HttpResponseMessage response = await client.GetAsync(baseUrl +"currentconditions/v1/" + cityKey + "?apikey=" + apiKey);
                if (response.IsSuccessStatusCode == false)
                {
                    throw new Exception();
                }
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    currentWeatherModel = JsonConvert.DeserializeObject<List<CurrentWeatherModel>>(apiResponse).First();
                    cacheService.SetEntry(cityKey, currentWeatherModel);
                }
                
                return currentWeatherModel;
            }

            return cityWeather;
        }


    }
}
