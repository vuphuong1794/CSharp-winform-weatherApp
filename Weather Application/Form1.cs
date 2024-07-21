using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;

namespace WeatherApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            getWeather();
        }

        // Thay thế lat, lon bằng giá trị thực tế
        double lat = 33.44; // Ví dụ giá trị latitude
        double lon = -94.04; // Ví dụ giá trị longitude
        string APIKey = "4359ef1cd11b4c97b0da50cce76d01e7"; // Thay thế bằng API key của bạn
        string exclude = "hourly,daily"; // Các phần bạn muốn loại trừ (minutely, hourly, daily)

        private void getWeather()
        {
            try
            {
                using (WebClient web = new WebClient())
                {
                    string url = string.Format("https://api.openweathermap.org/data/3.0/onecall?lat={0}&lon={1}&exclude={2}&appid={3}", lat, lon, exclude, APIKey);

                    var json = web.DownloadString(url);
                    WeatherInfo.Root info = JsonConvert.DeserializeObject<WeatherInfo.Root>(json);

                    // Kiểm tra dữ liệu trước khi sử dụng để tránh lỗi null
                    if (info?.Current?.Weather != null && info.Current.Weather.Count > 0)
                    {
                        // Tính toán nhiệt độ
                        double temperatureKelvin = info.Current.Temperature;
                        double temperatureCelsius = temperatureKelvin - 273.15;
                        double temperatureFahrenheit = (temperatureCelsius * 9 / 5) + 32;

                        // Cập nhật giao diện người dùng
                        pic_icon.ImageLocation = "https://openweathermap.org/img/w/" + info.Current.Weather[0].Icon + ".png";
                        lab_tinhtrang.Text = WeatherTranslator.Translate(info.Current.Weather[0].Main); // Dịch tình trạng thời tiết
                        lab_chitiet.Text = info.Current.Weather[0].Description;

                        // Hiển thị nhiệt độ
                        lab_nhietdo.Text = $"{temperatureCelsius.ToString("0.0")} °C | {temperatureFahrenheit.ToString("0.0")} °F";

                        // Hiển thị các thông tin khác
                        //lab_sunset.Text = ConvertDateTime(info.Current.Sunset).ToString("HH:mm");
                        //lab_sunrise.Text = ConvertDateTime(info.Current.Sunrise).ToString("HH:mm");
                        //lab_windspeed.Text = info.Current.WindSpeed.ToString("0.0") + " m/s";
                       // lab_pressure.Text = info.Current.Pressure.ToString() + " hPa";
                    }
                    else
                    {
                        MessageBox.Show("Weather data is not available.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving weather data: " + ex.Message);
            }
        }

        DateTime ConvertDateTime(long seconds)
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(seconds).ToLocalTime();
        }
    }

    public static class WeatherTranslator
    {
        private static readonly Dictionary<string, string> WeatherTranslations = new Dictionary<string, string>
        {
            { "Clear", "Trời quang" },
            { "Clouds", "Có mây" },
            { "Rain", "Mưa" },
            { "Drizzle", "Mưa phùn" },
            { "Thunderstorm", "Dông bão" },
            { "Snow", "Tuyết" },
            { "Mist", "Sương mù" },
            { "Fog", "Sương mù dày" },
            { "Ash", "Tro" },
            { "Squall", "Gió mạnh" },
            { "Tornado", "Lốc xoáy" },
            { "Haze", "Sương khói" },
            { "Smoke", "Khói" },
            { "Dust", "Bụi" },
            { "Sand", "Cát" },
            { "Volcanic Ash", "Tro núi lửa" },
            { "Spray", "Tia nước" },
            { "Freezing Rain", "Mưa đá" },
            { "Heavy Rain", "Mưa lớn" },
            { "Light Rain", "Mưa nhỏ" },
            { "Moderate Rain", "Mưa vừa" },
            { "Heavy Snow", "Tuyết lớn" },
            { "Light Snow", "Tuyết nhẹ" },
            { "Moderate Snow", "Tuyết vừa" },
            { "Ice Pellets", "Mưa đá viên" },
            { "Sleet", "Mưa tuyết" },
            { "Hail", "Mưa đá" },
            { "Shower Rain", "Mưa rào" },
            { "Light Shower Rain", "Mưa rào nhẹ" },
            { "Heavy Shower Rain", "Mưa rào lớn" },
            { "Thunderstorm with Light Rain", "Dông bão với mưa nhẹ" },
            { "Thunderstorm with Heavy Rain", "Dông bão với mưa lớn" },
            { "Thunderstorm with Snow", "Dông bão với tuyết" }
        };

        public static string Translate(string weatherCondition)
        {
            return WeatherTranslations.TryGetValue(weatherCondition, out string translation) ? translation : weatherCondition;
        }
    }
}
