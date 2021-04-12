using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherExam
{
    public interface IWeatherService
    {
        Task<WeatherBoundary> GetWeather(string cityName);
        Task<IEnumerable<WeatherBoundary>> GetWeathers(string[] cities);
    }
}