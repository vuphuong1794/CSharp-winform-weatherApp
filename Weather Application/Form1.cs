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
        private Size originalSize;

        public Form1()
        {
            InitializeComponent();
            originalSize = this.Size; // Lưu kích thước ban đầu của form
            HideControls();
        }



        // Trong tệp Form1.cs
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form hiện tại
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

                    //MessageBox.Show("JSON result: " + json);

                    WeatherInfo.Root info = JsonConvert.DeserializeObject<WeatherInfo.Root>(json);

                    if (info != null && info.Weather != null && info.Weather.Count > 0)
                    {
                        string iconUrl = "https://openweathermap.org/img/w/" + info.Weather[0].Icon + ".png";
                        LoadAndResizeImage(iconUrl);

                        lab_ngay01.Text = DateTime.Now.ToString("dd MMMM yyyy");
                        lab_thoigian.Text = DateTime.Now.ToString("dddd HH:mm:ss");

                        // Dịch mô tả thời tiết sang tiếng Việt và hiển thị
                        lab_tinhtrang.Text = WeatherTranslator.TranslateMain(info.Weather[0].Main);
                        lab_chitiet.Text = WeatherTranslator.TranslateDescription(info.Weather[0].Description);

                        ShowControls();

                        // Chuyển đổi nhiệt độ từ Kelvin sang Celsius và Fahrenheit
                        double tempCelsius = info.Main.Temp - 273.15;
                        // Hiển thị nhiệt độ cả bằng độ C 
                        lab_nhietdo.Text = $"{tempCelsius.ToString("0.0")} °C ";
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

                        // Mở rộng form
                        this.Size = originalSize;
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu thời tiết không có sẵn hoặc không đầy đủ.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving weather data: " + ex.Message);
            }
        }

        //ẩn data khi chưa có request
        private void HideControls()
        {
            lab_nhietdo.Visible = false;
            lab_luongmua.Visible = false;
            lab_tdgio.Visible = false;
            lab_doam.Visible = false;
            lab_apsuat.Visible = false;
            lab_giogiat.Visible = false;

            lb02.Visible = false;
            lab_chitiet.Visible = false;
            lb03.Visible = false;
            lb04.Visible = false;
            lb05.Visible = false;
            lb06.Visible = false;
            lb07.Visible = false;
            btn_chitiet02.Visible = false;
            rank_thu02.Visible = false;
            lab_nhietdo02.Visible = false;
            pic02_icon.Visible = false;
            btn_chitiet04.Visible = false;
            rank_thu04.Visible = false;
            pic04_icon.Visible = false;
            lab_nhietdo4.Visible = false;
            btn_chitiet03.Visible = false;
            rank_thu03.Visible = false;
            pic03_icon.Visible = false;
            lab_nhietdo03.Visible = false;
            btn_chitiet06.Visible = false;
            rank_thu06.Visible = false;
            pic06_icon.Visible = false;
            lab_nhietdo06.Visible = false;
            btn_chitiet05.Visible = false;
            rank_thu05.Visible = false;
            lab_nhietdo05.Visible = false;
            pic05_icon.Visible = false;

            lab_ngay02.Visible = false;
            lab_tinhtrang.Visible = false;
            lab_giogiat.Visible = false;
            lab_luongmua.Visible = false;
            lab_apsuat.Visible = false;
            lab_doam.Visible = false;
            lab_tdgio.Visible = false;
            lab_nhietdo.Visible = false;
            lab_chitiet02.Visible = false;
            lab_chitiet04.Visible = false;
            lab_chitiet03.Visible = false;
            lab_chitiet06.Visible = false;
            lab_chitiet05.Visible = false;
            pic01_icon.Visible = false;
            rank_thu01.Visible = false;
            lab_nhietdo01.Visible = false;
            btn_chitiet01.Visible = false;
            lab_chitiet01.Visible = false;

            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;

            pic_icon.Visible = false;
        }

        //show data
        private void ShowControls()
        {
            lab_nhietdo.Visible = true;
            lab_luongmua.Visible = true;
            lab_tdgio.Visible = true;
            lab_doam.Visible = true;
            lab_apsuat.Visible = true;
            lab_giogiat.Visible = true;

            lb02.Visible = true;
            lab_chitiet.Visible = true;
            lb03.Visible = true;
            lb04.Visible = true;
            lb05.Visible = true;
            lb06.Visible = true;
            lb07.Visible = true;
            btn_chitiet02.Visible = true;
            rank_thu02.Visible = true;
            lab_nhietdo02.Visible = true;
            pic02_icon.Visible = true;
            btn_chitiet04.Visible = true;
            rank_thu04.Visible = true;
            pic04_icon.Visible = true;
            lab_nhietdo4.Visible = true;
            btn_chitiet03.Visible = true;
            rank_thu03.Visible = true;
            pic03_icon.Visible = true;
            lab_nhietdo03.Visible = true;
            btn_chitiet06.Visible = true;
            rank_thu06.Visible = true;
            pic06_icon.Visible = true;
            lab_nhietdo06.Visible = true;
            btn_chitiet05.Visible = true;
            rank_thu05.Visible = true;
            lab_nhietdo05.Visible = true;
            pic05_icon.Visible = true;

            lab_ngay02.Visible = true;
            lab_tinhtrang.Visible = true;
            lab_giogiat.Visible = true;
            lab_luongmua.Visible = true;
            lab_apsuat.Visible = true;
            lab_doam.Visible = true;
            lab_tdgio.Visible = true;
            lab_nhietdo.Visible = true;
            lab_chitiet02.Visible = true;
            lab_chitiet04.Visible = true;
            lab_chitiet03.Visible = true;
            lab_chitiet06.Visible = true;
            lab_chitiet05.Visible = true;
            pic01_icon.Visible = true;
            rank_thu01.Visible = true;
            lab_nhietdo01.Visible = true;
            btn_chitiet01.Visible = true;
            lab_chitiet01.Visible = true;

            panel2.Visible = true;
            panel3.Visible = true;
            panel4.Visible = true;
            panel5.Visible = true;
            panel6.Visible = true;
            panel7.Visible = true;

            pic_icon.Visible = true;
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
            //tình hình thời tiết
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

            //chi tiết tình hình thời tiết hiện tại 
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

        private void Form1_Load(object sender, EventArgs e)
        {
            HideControls();
            this.Size = new Size(791, 140); // Thiết lập kích thước nhỏ ban đầu
        }

        private void tbCity_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_chitiet01_Click(object sender, EventArgs e)
        {

        }
    }
}