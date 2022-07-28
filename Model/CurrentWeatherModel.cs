namespace Weather.App.Model
{
    public class CurrentWeatherModel
    {
        public CurrentWeatherModel(string weatherText, Temperature temperature)
        {
            WeatherText = weatherText;
            Temperature = temperature;
        }

        public string WeatherText { get; set; }

        public Temperature Temperature { get; set; }
  
    }
}
