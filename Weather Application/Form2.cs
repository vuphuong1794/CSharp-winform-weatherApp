using System;
using System.Drawing;
using System.Net;
using System.Reflection.Emit;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppWeather;
using Newtonsoft.Json;
using WeatherApp;

namespace WeatherApp
{
    public partial class Form2 : Form
    {
        private WeatherInfo.Root data;
        private string cityName;
        private const string APIKey = "3ad3bbc4ae8ad572fc1b8252553aeb26";

        public Form2(string City)
        {
            InitializeComponent();
            this.cityName = City;
        }

        private async void Form2_Load(object sender, EventArgs e)
        {
            await prepareForecastToDisplay(cityName);
            displayWeather();
        }

        public async Task prepareForecastToDisplay(string City)
        {
            try
            {
                using (WebClient web = new WebClient())
                {
                    string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units=metric", Uri.EscapeDataString(City), APIKey);
                    var json = await web.DownloadStringTaskAsync(url);
                    data = JsonConvert.DeserializeObject<WeatherInfo.Root>(json);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving weather data: {ex.Message}");
            }
        }

        public void displayWeather()
        {
            if (data != null && data.Weather != null && data.Weather.Count > 0)
            {
                // Hiển thị thông tin thời tiết hiện tại
                dateLabel1.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                temperatureLabel1.Text = data.Main.Temp.ToString("F1") + " °C";
                string imgUrl = "http://openweathermap.org/img/w/" + data.Weather[0].Icon + ".png";
                LoadImage(weatherIconBox1, imgUrl);

                // Ẩn thông tin cho các khoảng thời gian khác
                dateLabel2.Visible = false;
                temperatureLabel2.Visible = false;
                weatherIconBox2.Visible = false;
                detalisBtn2.Visible = false;

                dateLabel3.Visible = false;
                TemperatureLabel3.Visible = false;
                weatherIconBox3.Visible = false;
                detalisBtn3.Visible = false;

                // Hiển thị tên thành phố
                label1.Text = data.Name;
            }
            else
            {
                MessageBox.Show("Weather data is not available.");
            }
        }

        private void LoadImage(PictureBox pictureBox, string url)
        {
            using (WebClient client = new WebClient())
            {
                byte[] imageData = client.DownloadData(url);
                using (var ms = new System.IO.MemoryStream(imageData))
                {
                    pictureBox.Image = Image.FromStream(ms);
                }
            }
        }

        private void detalisBtn1_Click(object sender, EventArgs e)
        {
            ShowDetails();
        }

        private void ShowDetails()
        {
            if (data != null && data.Weather != null && data.Weather.Count > 0)
            {
                Form3 form = new Form3(
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    data.Main.TempMin.ToString("F1"),
                    data.Main.TempMax.ToString("F1"),
                    data.Main.Pressure.ToString(),
                    data.Wind.Speed.ToString(),
                    data.Main.Humidity.ToString(),
                    data.Weather[0].Description,
                    data.Weather[0].Icon
                );
                form.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Các phương thức xử lý sự kiện khác
        private void temperatureL_Click(object sender, EventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void label15_Click(object sender, EventArgs e)
        {
        }

        // Các phương thức này có thể được xóa hoặc để trống vì chúng không cần thiết cho dự báo một ngày
        private void detalisBtn2_Click(object sender, EventArgs e)
        {
        }

        private void detalisBtn3_Click(object sender, EventArgs e)
        {
        }
    }
}