using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace WeatherApp
{
    internal class WeatherInfo
    {
        // Lớp đại diện cho tọa độ
        public class Coord
        {
            [JsonProperty("lon")]
            public double Longitude { get; set; }

            [JsonProperty("lat")]
            public double Latitude { get; set; }
        }

        // Lớp đại diện cho điều kiện thời tiết
        public class Weather
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("main")]
            public string Main { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("icon")]
            public string Icon { get; set; }
        }

        // Lớp đại diện cho thông tin chính
        public class Main
        {
            [JsonProperty("temp")]
            public double Temperature { get; set; }

            [JsonProperty("feels_like")]
            public double FeelsLike { get; set; }

            [JsonProperty("temp_min")]
            public double TempMin { get; set; }

            [JsonProperty("temp_max")]
            public double TempMax { get; set; }

            [JsonProperty("pressure")]
            public double Pressure { get; set; }

            [JsonProperty("humidity")]
            public double Humidity { get; set; }

            [JsonProperty("dew_point")]
            public double DewPoint { get; set; }

            [JsonProperty("sea_level")]
            public double SeaLevel { get; set; }

            [JsonProperty("grnd_level")]
            public double GroundLevel { get; set; }
        }

        // Lớp đại diện cho thông tin gió
        public class Wind
        {
            [JsonProperty("speed")]
            public double Speed { get; set; }

            [JsonProperty("deg")]
            public double Degree { get; set; }

            [JsonProperty("gust")]
            public double Gust { get; set; }
        }

        // Lớp đại diện cho thông tin hệ thống
        public class Sys
        {
            [JsonProperty("sunrise")]
            public long Sunrise { get; set; }

            [JsonProperty("sunset")]
            public long Sunset { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }
        }

        // Lớp đại diện cho thông tin hiện tại
        public class CurrentWeather
        {
            [JsonProperty("dt")]
            public long DateTime { get; set; }

            [JsonProperty("sunrise")]
            public long Sunrise { get; set; }

            [JsonProperty("sunset")]
            public long Sunset { get; set; }

            [JsonProperty("temp")]
            public double Temperature { get; set; }

            [JsonProperty("feels_like")]
            public double FeelsLike { get; set; }

            [JsonProperty("pressure")]
            public double Pressure { get; set; }

            [JsonProperty("humidity")]
            public double Humidity { get; set; }

            [JsonProperty("dew_point")]
            public double DewPoint { get; set; }

            [JsonProperty("uvi")]
            public double Uvi { get; set; }

            [JsonProperty("clouds")]
            public int Clouds { get; set; }

            [JsonProperty("visibility")]
            public int Visibility { get; set; }

            [JsonProperty("wind_speed")]
            public double WindSpeed { get; set; }

            [JsonProperty("wind_deg")]
            public int WindDegree { get; set; }

            [JsonProperty("wind_gust")]
            public double WindGust { get; set; }

            [JsonProperty("weather")]
            public List<Weather> Weather { get; set; }
        }

        // Lớp đại diện cho thông tin hàng giờ
        public class HourlyWeather
        {
            [JsonProperty("dt")]
            public long DateTime { get; set; }

            [JsonProperty("temp")]
            public double Temperature { get; set; }

            [JsonProperty("feels_like")]
            public double FeelsLike { get; set; }

            [JsonProperty("pressure")]
            public double Pressure { get; set; }

            [JsonProperty("humidity")]
            public double Humidity { get; set; }

            [JsonProperty("dew_point")]
            public double DewPoint { get; set; }

            [JsonProperty("uvi")]
            public double Uvi { get; set; }

            [JsonProperty("clouds")]
            public int Clouds { get; set; }

            [JsonProperty("visibility")]
            public int Visibility { get; set; }

            [JsonProperty("wind_speed")]
            public double WindSpeed { get; set; }

            [JsonProperty("wind_deg")]
            public int WindDegree { get; set; }

            [JsonProperty("wind_gust")]
            public double WindGust { get; set; }

            [JsonProperty("weather")]
            public List<Weather> Weather { get; set; }

            [JsonProperty("pop")]
            public double Pop { get; set; }
        }

        // Lớp đại diện cho thông tin hàng ngày
        public class DailyWeather
        {
            [JsonProperty("dt")]
            public long DateTime { get; set; }

            [JsonProperty("sunrise")]
            public long Sunrise { get; set; }

            [JsonProperty("sunset")]
            public long Sunset { get; set; }

            [JsonProperty("moonrise")]
            public long Moonrise { get; set; }

            [JsonProperty("moonset")]
            public long Moonset { get; set; }

            [JsonProperty("moon_phase")]
            public double MoonPhase { get; set; }

            [JsonProperty("summary")]
            public string Summary { get; set; }

            [JsonProperty("temp")]
            public Temperature Temp { get; set; }

            [JsonProperty("feels_like")]
            public FeelsLike FeelsLike { get; set; }

            [JsonProperty("pressure")]
            public double Pressure { get; set; }

            [JsonProperty("humidity")]
            public double Humidity { get; set; }

            [JsonProperty("dew_point")]
            public double DewPoint { get; set; }

            [JsonProperty("wind_speed")]
            public double WindSpeed { get; set; }

            [JsonProperty("wind_deg")]
            public int WindDegree { get; set; }

            [JsonProperty("wind_gust")]
            public double WindGust { get; set; }

            [JsonProperty("weather")]
            public List<Weather> Weather { get; set; }

            [JsonProperty("clouds")]
            public int Clouds { get; set; }

            [JsonProperty("pop")]
            public double Pop { get; set; }

            [JsonProperty("rain")]
            public double Rain { get; set; }

            [JsonProperty("uvi")]
            public double Uvi { get; set; }
        }

        // Lớp đại diện cho thông tin cảnh báo thời tiết
        public class WeatherAlert
        {
            [JsonProperty("sender_name")]
            public string SenderName { get; set; }

            [JsonProperty("event")]
            public string Event { get; set; }

            [JsonProperty("start")]
            public long Start { get; set; }

            [JsonProperty("end")]
            public long End { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("tags")]
            public List<string> Tags { get; set; }
        }

        // Lớp root đại diện cho thông tin thời tiết toàn diện
        public class Root
        {
            [JsonProperty("lat")]
            public double Latitude { get; set; }

            [JsonProperty("lon")]
            public double Longitude { get; set; }

            [JsonProperty("timezone")]
            public string TimeZone { get; set; }

            [JsonProperty("timezone_offset")]
            public int TimeZoneOffset { get; set; }

            [JsonProperty("current")]
            public CurrentWeather Current { get; set; }

            [JsonProperty("minutely")]
            public List<MinutelyWeather> Minutely { get; set; }

            [JsonProperty("hourly")]
            public List<HourlyWeather> Hourly { get; set; }

            [JsonProperty("daily")]
            public List<DailyWeather> Daily { get; set; }

            [JsonProperty("alerts")]
            public List<WeatherAlert> Alerts { get; set; }
        }

        // Lớp đại diện cho thông tin lượng mưa hàng phút
        public class MinutelyWeather
        {
            [JsonProperty("dt")]
            public long DateTime { get; set; }

            [JsonProperty("precipitation")]
            public double Precipitation { get; set; }
        }

        // Lớp đại diện cho nhiệt độ trong lớp DailyWeather
        public class Temperature
        {
            [JsonProperty("day")]
            public double Day { get; set; }

            [JsonProperty("min")]
            public double Min { get; set; }

            [JsonProperty("max")]
            public double Max { get; set; }

            [JsonProperty("night")]
            public double Night { get; set; }

            [JsonProperty("eve")]
            public double Eve { get; set; }

            [JsonProperty("morn")]
            public double Morn { get; set; }
        }

        // Lớp đại diện cho cảm giác nhiệt độ trong lớp DailyWeather
        public class FeelsLike
        {
            [JsonProperty("day")]
            public double Day { get; set; }

            [JsonProperty("night")]
            public double Night { get; set; }

            [JsonProperty("eve")]
            public double Eve { get; set; }

            [JsonProperty("morn")]
            public double Morn { get; set; }
        }
    }
}
