using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Umbraco.Core.Cache;
using Weather.App.Interfaces;
using Weather.App.Model;

namespace Weather.App.Implementations
{
    public class CacheService : PageModel, ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        public DateTime CurrentDateTime { get; private set; }

        public CacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public CurrentWeatherModel OnGet(string key)
        {
            return _memoryCache.Get<CurrentWeatherModel>(key);
        }

        public void SetEntry(string key, CurrentWeatherModel weather)
        {
            weather.Temperature.Metric.Value = weather.Temperature.Metric.Value + 10;
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromHours(3));

            _memoryCache.Set(key, weather, cacheEntryOptions);
        }



    }
}
