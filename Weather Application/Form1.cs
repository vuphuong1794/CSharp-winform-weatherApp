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

        string APIKey = "3ad3bbc4ae8ad572fc1b8252553aeb26";

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
                    string cityName = Uri.EscapeDataString(tbCity.Text);
                    string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}", cityName, APIKey);

                    var json = web.DownloadString(url);

                    MessageBox.Show("JSON result: " + json);

                    WeatherInfo.Root info = JsonConvert.DeserializeObject<WeatherInfo.Root>(json);

                    if (info != null && info.Weather != null && info.Weather.Count > 0)
                    {
                        string iconUrl = "https://openweathermap.org/img/w/" + info.Weather[0].Icon + ".png";
                        LoadAndResizeImage(iconUrl);

                        // Dịch mô tả thời tiết sang tiếng Việt và hiển thị
                        lab_tinhtrang.Text = WeatherTranslator.TranslateMain(info.Weather[0].Main);
                        lab_chitiet.Text = WeatherTranslator.TranslateDescription(info.Weather[0].Description);
                        // Hiển thị nhiệt độ
                        lab_nhietdo.Text = $"{(info.Main.Temp - 273.15).ToString("0.0")} °C";

                        // Hiển thị độ ẩm
                        lab_doam.Text = $"{info.Main.Humidity} %";

                        // Hiển thị áp suất
                        lab_apsuat.Text = $"{info.Main.Pressure} hPa";

                        // Hiển thị gió giật
                        lab_giogiat.Text = $"{info.Wind.Gust?.ToString("0.00") ?? "N/A"} m/s";

                        // Hiển thị tốc độ gió  
                        lab_tdgio.Text = $"{info.Wind.Speed:0.00} m/s";

                        // Hiển thị lượng mưa (nếu có)
                        lab_luongmua.Text = $"{info.Rain?.Rain1h?.ToString("0.0") ?? "0.0"} mm";
                    }
                    else
                    {
                        MessageBox.Show("Weather data is not available or is incomplete.");
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
            private static readonly Dictionary<string, string> WeatherMainDescriptions = new Dictionary<string, string>
    {
        { "Thunderstorm", "Dông bão" },
        { "Drizzle", "Mưa phùn" },
        { "Rain", "Mưa" },
        { "Snow", "Tuyết" },
        { "Mist", "Sương mù" },
        { "Smoke", "Khói" },
        { "Haze", "Sương mù" },
        { "Dust", "Bụi" },
        { "Fog", "Sương mù" },
        { "Sand", "Cát" },
        { "Ash", "Tro" },
        { "Squall", "Gió mạnh" },
        { "Tornado", "Lốc xoáy" },
        { "Clear", "Trời quang" },
        { "Clouds", "Mây" }
    };

            private static readonly Dictionary<string, string> WeatherDetailDescriptions = new Dictionary<string, string>
    {
        { "light rain", "mưa nhẹ" },
        { "moderate rain", "mưa vừa" },
        { "heavy intensity rain", "mưa lớn" },
        { "very heavy rain", "mưa rất lớn" },
        { "extreme rain", "mưa cực lớn" },
        { "freezing rain", "mưa đá" },
        { "light intensity shower rain", "mưa rào nhẹ" },
        { "shower rain", "mưa rào" },
        { "heavy intensity shower rain", "mưa rào lớn" },
        { "ragged shower rain", "mưa rào không đều" },
        { "light snow", "tuyết nhẹ" },
        { "Snow", "tuyết" },
        { "Heavy snow", "tuyết lớn" },
        { "Sleet", "mưa tuyết" },
        { "Light shower sleet", "mưa tuyết nhẹ" },
        { "Shower sleet", "mưa tuyết" },
        { "Light rain and snow", "mưa và tuyết nhẹ" },
        { "Rain and snow", "mưa và tuyết" },
        { "Light shower snow", "tuyết rơi nhẹ" },
        { "Shower snow", "tuyết rơi" },
        { "Heavy shower snow", "tuyết rơi lớn" },
        { "mist", "sương mù" },
        { "smoke", "khói" },
        { "haze", "sương mù" },
        { "sand/ dust whirls", "bụi cát" },
        { "fog", "sương mù" },
        { "sand", "cát" },
        { "dust", "bụi" },
        { "volcanic ash", "tro núi lửa" },
        { "squalls", "gió mạnh" },
        { "tornado", "lốc xoáy" },
        { "clear sky", "bầu trời quang đãng" },
        { "few clouds", "ít mây" },
        { "scattered clouds", "mây rải rác" },
        { "broken clouds", "mây đứt đoạn" },
        { "overcast clouds", "mây bao phủ" }
    };

            public static string TranslateMain(string main)
            {
                if (WeatherMainDescriptions.TryGetValue(main, out string description))
                {
                    return description;
                }
                return "Không xác định";
            }

            public static string TranslateDescription(string description)
            {
                if (WeatherDetailDescriptions.TryGetValue(description, out string translatedDescription))
                {
                    return translatedDescription;
                }
                return "Không xác định";
            }
        }

    }
}