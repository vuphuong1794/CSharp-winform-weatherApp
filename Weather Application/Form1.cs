using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using AppWeather;
using Newtonsoft.Json;

namespace WeatherApp
{
    public partial class Form1 : Form
    {
        private Size originalSize;
        private string APIKey = "3ad3bbc4ae8ad572fc1b8252553aeb26";

        public Form1()
        {
            InitializeComponent();
            originalSize = this.Size; // Store the initial size of the form
            HideControls();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the current form
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            getWeather();
        }

        private void getWeather()
        {
            try
            {
                string cityName = Uri.EscapeDataString(tbCity.Text);
                string url = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={APIKey}";

                using (WebClient web = new WebClient())
                {
                    string json = web.DownloadString(url);
                    WeatherInfo.Root info = JsonConvert.DeserializeObject<WeatherInfo.Root>(json);

                    if (info?.Weather?.Count > 0)
                    {
                        string iconUrl = $"https://openweathermap.org/img/w/{info.Weather[0].Icon}.png";
                        LoadAndResizeImage(iconUrl);

                        lab_ngay01.Text = DateTime.Now.ToString("dd MMMM yyyy");
                        lab_thoigian.Text = DateTime.Now.ToString("dddd HH:mm:ss");

                        lab_tinhtrang.Text = WeatherTranslator.TranslateMain(info.Weather[0].Main);
                        lab_chitiet.Text = WeatherTranslator.TranslateDescription(info.Weather[0].Description);

                        ShowWeatherInfo(info);
                        ShowControls();
                    }
                    else
                    {
                        MessageBox.Show("Weather data is not available or incomplete.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving weather data: {ex.Message}");
            }
        }

        private void ShowWeatherInfo(WeatherInfo.Root info)
        {
            double tempCelsius = info.Main.Temp - 273.15;

            lab_nhietdo.Text = $"{tempCelsius:0.0} °C";
            lab_doam.Text = $"{info.Main.Humidity} %";
            lab_apsuat.Text = $"{info.Main.Pressure} hPa";
            lab_giogiat.Text = $"{info.Wind.Gust?.ToString("0.00") ?? "N/A"} m/s";
            lab_tdgio.Text = $"{info.Wind.Speed:0.00} m/s";
            lab_luongmua.Text = $"{info.Rain?.Rain1h?.ToString("0.0") ?? "0.0"} mm";

            // Expand form to fit content
            this.Size = originalSize;
        }

        private void HideControls()
        {
            foreach (Control control in Controls)
            {
                if (control is Label || control is Button || control is PictureBox || control is Panel)
                {
                    control.Visible = false;
                }
            }
        }

        private void ShowControls()
        {
            foreach (Control control in Controls)
            {
                if (control is Label || control is Button || control is PictureBox || control is Panel)
                {
                    control.Visible = true;
                }
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
                            pic_icon.Image = ResizeImage(originalImage, pic_icon.Width, pic_icon.Height);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}");
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
                { "light rain", "Mưa nhẹ" },
                { "moderate rain", "Mưa vừa" },
                { "heavy intensity rain", "Mưa lớn" },
                { "very heavy rain", "Mưa rất lớn" },
                { "extreme rain", "Mưa cực lớn" },
                { "freezing rain", "Mưa đá" },
                { "light intensity shower rain", "Mưa rào nhẹ" },
                { "shower rain", "Mưa rào" },
                { "heavy intensity shower rain", "Mưa rào lớn" },
                { "ragged shower rain", "Mưa rào không đều" },
                { "light snow", "Tuyết nhẹ" },
                { "Snow", "Tuyết" },
                { "Heavy snow", "Tuyết lớn" },
                { "Sleet", "Mưa tuyết" },
                { "Light shower sleet", "Mưa tuyết nhẹ" },
                { "Shower sleet", "Mưa tuyết" },
                { "Light rain and snow", "Mưa và tuyết nhẹ" },
                { "Rain and snow", "Mưa và tuyết" },
                { "Light shower snow", "Tuyết rơi nhẹ" },
                { "Shower snow", "Tuyết rơi" },
                { "Heavy shower snow", "Tuyết rơi lớn" },
                { "mist", "Sương mù" },
                { "smoke", "Khói" },
                { "haze", "Sương mù" },
                { "sand/ dust whirls", "Bụi cát" },
                { "fog", "Sương mù" },
                { "sand", "Cát" },
                { "dust", "Bụi" },
                { "volcanic ash", "Tro núi lửa" },
                { "squalls", "Gió mạnh" },
                { "tornado", "Lốc xoáy" },
                { "clear sky", "Bầu trời quang đãng" },
                { "few clouds", "Ít mây" },
                { "scattered clouds", "Mây rải rác" },
                { "broken clouds", "Mây đứt đoạn" },
                { "overcast clouds", "Mây bao phủ" }
            };

            public static string TranslateMain(string main)
            {
                return WeatherMainDescriptions.TryGetValue(main, out string description) ? description : "Không xác định";
            }

            public static string TranslateDescription(string description)
            {
                return WeatherDetailDescriptions.TryGetValue(description, out string translatedDescription) ? translatedDescription : "Không xác định";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HideControls();
            this.Size = new Size(791, 140); // Set initial small size
        }

        private void tbCity_TextChanged(object sender, EventArgs e)
        {
            // Add any desired functionality for when text changes
        }

        private void btn_chitiet01_Click(object sender, EventArgs e)
        {
            string city = tbCity.Text;
            Form2 form2 = new Form2(city);
            form2.Show();
        }

        private void btn_chitiet02_Click(object sender, EventArgs e)
        {
 
        }

        private void lb03_Click(object sender, EventArgs e)
        {
            // Add functionality for lb03 if needed
        }
    }
}
