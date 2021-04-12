using Newtonsoft.Json;
using System;

namespace WeatherExam
{
//{
    //"rh": 46,
    //"pod": "d",
    //"lon": 34.78057,
    //"pres": 1013.2,
    //"timezone": "Asia/Jerusalem",
    //"ob_time": "2021-01-10 13:50",
    //"country_code": "IL",
    //"clouds": 0,
    //"ts": 1610286600,
    //"solar_rad": 116.5,
    //"state_code": "05",
    //"city_name": "Tel Aviv",
    //"wind_spd": 3.1,
    //"wind_cdir_full": "northwest",
    //"wind_cdir": "NW",
    //"slp": 1019,
    //"vis": 5,
    //"h_angle": 90,
    //"sunset": "14:54",
    //"dni": 464.7,
    //"dewpt": 9.8,
    //"snow": 0,
    //"uv": 2.41139,
    //"precip": 0,
    //"wind_dir": 320,
    //"sunrise": "04:41",
    //"ghi": 116.49,
    //"dhi": 51.86,
    //"aqi": 130,
    //"lat": 32.08088,
    //"weather": {
    //"icon": "c01d",
    //"code": 800,
    //"description": "Clear sky"
    //},
    //"datetime": "2021-01-10:14",
    //"temp": 22,
    //"station": "LLBG",
    //"elev_angle": 9.11,
    //"app_temp": 21.5
//}

    [Serializable]
    public class WeatherBoundary
    {
        [JsonProperty("city_name")]
        public string CityName { get; set; }
        [JsonProperty("temp")]
        public double Temperature { get; set; }
        [JsonProperty("weather")]
        public Weather WeatherDescription { get; set; }
        [JsonProperty("sunset")]
        public string SunsetTime { get; set; }
        [JsonProperty("wind_dir")]
        public string WindDirection { get; set; }

        public override string ToString()
        {
            return $"CityName = {CityName}\n Temperature = {Temperature}\n WeatherDescription = {WeatherDescription}\n SunsetTime = {SunsetTime}\n WindDirection = {WindDirection}";
        }
    }

    [Serializable]
    public class Weather
    {
        [JsonProperty("icon")]
        public string Icon { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }

        public override string ToString()
        {
            return $"Icon = {Icon}\n Description = {Description}";
        }
    }
}