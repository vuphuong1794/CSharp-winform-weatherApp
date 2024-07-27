using System;
using System.Drawing;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using AppWeather;
using System.Collections.Generic;

namespace WeatherApp
{
    public partial class Form2 : Form
    {
        private WeatherForecast data;
        private string cityName;

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
                data = await WeatherInfo.getHoursForecast(City);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving weather data: {ex.Message}");
            }
        }

        public void displayWeather()
        {
            if (data != null && data.list.Count >= 3)
            {
                dateLabel1.Text = data.list[0].dt_txt;
                temperatureLabel1.Text = data.list[0].main.temp.ToString() + " °C";
                string imgUrl = "http://openweathermap.org/img/w/" + data.list[0].weather[0].icon + ".png";
                weatherIconBox1.Load(imgUrl);

                dateLabel2.Text = data.list[1].dt_txt;
                temperatureLabel2.Text = data.list[1].main.temp.ToString() + " °C";
                string imgUrl2 = "http://openweathermap.org/img/w/" + data.list[1].weather[0].icon + ".png";
                weatherIconBox2.Load(imgUrl2);

                dateLabel3.Text = data.list[2].dt_txt;
                TemperatureLabel3.Text = data.list[2].main.temp.ToString() + " °C";
                string imgUrl3 = "http://openweathermap.org/img/w/" + data.list[2].weather[0].icon + ".png";
                weatherIconBox3.Load(imgUrl3);
            }
            else
            {
                MessageBox.Show("Weather data is not available.");
            }
        }

        private void detalisBtn1_Click(object sender, EventArgs e)
        {
            ShowDetails(0);
        }

        private void detalisBtn2_Click(object sender, EventArgs e)
        {
            ShowDetails(1);
        }

        private void detalisBtn3_Click(object sender, EventArgs e)
        {
            ShowDetails(2);
        }

        private void ShowDetails(int index)
        {
            if (data != null && data.list.Count > index)
            {
                var weather = data.list[index];
                Form3 form = new Form3(
                    weather.dt_txt,
                    weather.main.temp_min.ToString(),
                    weather.main.temp_max.ToString(),
                    weather.main.pressure.ToString(),
                    weather.wind.speed.ToString(),
                    weather.main.humidity.ToString(),
                    weather.weather[0].description,
                    weather.weather[0].icon
                );
                form.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void temperatureL_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }

    public static class WeatherInfo
    {
        private static readonly string APIKey = "3ad3bbc4ae8ad572fc1b8252553aeb26";

        public static async Task<WeatherForecast> getHoursForecast(string cityName)
        {
            string url = $"https://api.openweathermap.org/data/2.5/forecast?q={Uri.EscapeDataString(cityName)}&appid={APIKey}&units=metric";

            using (WebClient client = new WebClient())
            {
                string json = await client.DownloadStringTaskAsync(url);
                return JsonConvert.DeserializeObject<WeatherForecast>(json);
            }
        }
    }

    public class WeatherForecast
    {
        public List<WeatherDetails> list { get; set; }
    }

    public class WeatherDetails
    {
        public string dt_txt { get; set; }
        public Main main { get; set; }
        public List<Weather> weather { get; set; }
        public Wind wind { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
    }

    public class Weather
    {
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
    }
}
