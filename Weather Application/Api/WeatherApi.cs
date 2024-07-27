using AppWeather.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppWeather.Api
{
    class WeatherApi
    {
        static string APPID = "3ad3bbc4ae8ad572fc1b8252553aeb26";
        
        public  static WeatherModel.RootObject getOneDayWeather(string cityName)
        {
            string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&APPID={1}&units=metric", cityName, APPID);
            WebClient client = new WebClient();
            try
            {
                var json = client.DownloadString(url);
                var result = JsonConvert.DeserializeObject<WeatherModel.RootObject>(json);
                WeatherModel.RootObject weatherData = result;
                return weatherData;
            }
            catch(WebException e)
            {
                return null;
            }
            
            
        }

        public static ForecastModel.RootObject getHoursForecast(string cityName)
        {
            string url = string.Format("http://api.openweathermap.org/data/2.5/forecast?q={0}&APPID={1}&units=metric&cnt=5", cityName, APPID);
            WebClient client = new WebClient();
            var json = client.DownloadString(url);
            var result = JsonConvert.DeserializeObject<ForecastModel.RootObject>(json);
            ForecastModel.RootObject forecastData = result;
            return forecastData;
        }
        
    }
}
