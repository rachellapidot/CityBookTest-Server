using System.Net.Http.Headers;
using Newtonsoft.Json;
using Weather.App.Domain.Cotext;
using Weather.App.Domain.Model;
using Weather.App.Interfaces;
using Weather.App.Model;
using System.Linq;

namespace Weather.App.Implementations
{
    public class WeatherService : IWeatherService
    {
        private readonly string apiKey = "wVm14SlR9plziUb38spyIfMfDF9SosW2";

        private readonly string baseUrl = "http://dataservice.accuweather.com/";

        private readonly ICacheService cacheService;

        private readonly IRepository repository;

        static HttpClient client = new HttpClient();

        public WeatherService(ICacheService _cacheService, IRepository _repository)
        {
            cacheService = _cacheService;
            repository = _repository;
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


        public async Task<int>  AddFavorite(Favorite f)
        {
            FavoriteCities favorite = new FavoriteCities();
            favorite.CityKey = f.CityKey;
            favorite.CityName = f.CityName;

             return await repository.Insert(favorite);
        }

        public Task<List<Favorite>> GetFavorites()
        {
            List<FavoriteCities> favorites = repository.GetAll();
            List<Favorite> favoriteList = new List<Favorite>();
            favorites.ForEach(favorite =>
            {
                Favorite c = new Favorite();
                c.Id = favorite.Id;
                c.CityName = favorite.CityName;
                c.CityKey = favorite.CityKey;
                favoriteList.Add(c);
            });
            return Task.FromResult(favoriteList);

        }


    }
}
