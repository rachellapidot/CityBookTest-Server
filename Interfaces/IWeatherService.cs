
using Microsoft.AspNetCore.Mvc;
using Weather.App.DTOs;
using Weather.App.Model;

namespace Weather.App.Interfaces
{
    public interface IWeatherService
    {
        Task<List<SearchResultModel>> Search(string query);

        Task<CurrentWeatherModel> GetCurrentWeather(string cityKey);

        Task<int> AddFavorite(Favorite f);

        Task<List<Favorite>> GetFavorites();
    }
}
