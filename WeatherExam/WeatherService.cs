using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherExam
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _client;

        public WeatherService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://api.weatherbit.io/v2.0/");
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        //citiy=tel%20aviv
        public async Task<WeatherBoundary> GetWeather(string cityName)
        {
            if (String.IsNullOrEmpty(cityName))
            {
                throw new Exception("Please provide a city to get weather for.");
            }
            try
            {
                var response = await _client.GetAsync($"current?key=e65ef8948538477fabe19b9ac4e7d029&city={cityName}");

                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    throw new Exception($"The provided city {cityName} to get weather for was not found.");
                }
                if (response.IsSuccessStatusCode)
                {
                    var serializedString = await response.Content.ReadAsStringAsync();
                    var items = JsonConvert.DeserializeObject<Dictionary<string, object>>(serializedString);

                    var serializedItem = JsonConvert.DeserializeObject<WeatherBoundary[]>(items["data"].ToString());
                    return serializedItem[0];
                }
                else
                {
                    throw new Exception($"No weather found for {cityName}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<WeatherBoundary>> GetWeathers(string[] cities)
        {
            if (cities == null)
            {
                throw new Exception("Please provide cities to get weather for.");
            }
            else
            {
                if (cities.Length == 0)
                    throw new Exception("Please provide cities to get weather for.");
            }
            var weathers = new List<WeatherBoundary>();
            foreach (var city in cities)
            {
                try
                {
                    var result = await GetWeather(city);
                    if (result != null)
                        weathers.Add(result);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return weathers;
        }
    }
}
