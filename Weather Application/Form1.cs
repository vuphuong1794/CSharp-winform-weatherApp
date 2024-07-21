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
using System.IO;
using static WeatherApp.WeatherInfo;

namespace WeatherApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string APIKey = "4359ef1cd11b4c97b0da50cce76d01e7";

        private void btn_search_Click(object sender, EventArgs e)
        {
            getWeather();
        }

        private void getWeather()
        {
            try
            {
                using (WebClient web = new WebClient())
                {
                    string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}", tbCity.Text, APIKey);
                    var json = web.DownloadString(url);
                    WeatherInfo.Root info = JsonConvert.DeserializeObject<WeatherInfo.Root>(json);

                    // Kiểm tra dữ liệu trước khi sử dụng để tránh lỗi null
                    if (info?.Weather != null && info.Weather.Count > 0)
                    {
                        string iconUrl = "https://openweathermap.org/img/w/" + info.Weather[0].Icon + ".png";
                        LoadAndResizeImage(iconUrl);

                        lab_tinhtrang.Text = WeatherTranslator.Translate(info.Weather[0].Main);
                        lab_chitiet.Text = WeatherTranslator.Translate(info.Weather[0].Description);

                        // Hiển thị nhiệt độ
                        double tempCelsius = info.Main.Temperature - 273.15;
                        double tempFahrenheit = tempCelsius * 9 / 5 + 32;
                        lab_nhietdo.Text = $"{tempCelsius:0.0} °C | {tempFahrenheit:0.0} °F";

                        // Hiển thị độ ẩm
                        lab_doam.Text = $"{info.Main.Humidity:0.0} %";

                        // Hiển thị áp suất
                        lab_apsuat.Text = $"{info.Main.Pressure:0.0} hPa";

                        // Hiển thị gió giật
                        lab_giogiat.Text = $"{info.Wind.Gust:0.0} m/s";

                        // Hiển thị tốc độ gió
                        lab_tdgio.Text = $"{info.Wind.Speed:0.0} m/s";
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

        private void LoadAndResizeImage(string url)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    byte[] imageBytes = webClient.DownloadData(url);
                    using (MemoryStream stream = new MemoryStream(imageBytes))
                    {
                        using (Image originalImage = Image.FromStream(stream))
                        {
                            // Điều chỉnh kích thước hình ảnh cho phù hợp với PictureBox
                            pic_icon.Image = ResizeImage(originalImage, pic_icon.Width, pic_icon.Height);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading image: " + ex.Message);
            }
        }

        private Image ResizeImage(Image image, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, 0, 0, width, height);
            }
            return resizedImage;
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
}
