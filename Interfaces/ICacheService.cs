using Weather.App.Model;

namespace Weather.App.Interfaces
{
    public interface ICacheService
    {
        CurrentWeatherModel OnGet(string key);

        void SetEntry(string key, CurrentWeatherModel weather);
    }
}
