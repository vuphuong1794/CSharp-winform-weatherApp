using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Collections.Generic;
using AppWeather;

namespace WeatherApp
{
    public partial class Form2 : Form
    {
        private WeatherInfo.Root data;
        private string cityName;
        private const string APIKey = "4359ef1cd11b4c97b0da50cce76d01e7";

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
                    string url = string.Format("https://api.openweathermap.org/data/2.5/forecast?q={0}&units=metric&appid={1}", Uri.EscapeDataString(City), APIKey);
                    var json = await web.DownloadStringTaskAsync(url);
                    data = JsonConvert.DeserializeObject<WeatherInfo.Root>(json);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy dữ liệu thời tiết: {ex.Message}");
            }
        }

        public void displayWeather()
        {
            if (data != null && data.List != null && data.List.Count > 0)
            {
                var forecasts = data.List
                    .GroupBy(x => DateTime.Parse(x.DtTxt).Date)
                    .Select(g => g.First())
                    .Skip(1)
                    .Take(5)
                    .ToList();

                DisplayForecast(forecasts[0], dateLabel1, temperatureLabel1, weatherIconBox1, detalisBtn1);
                if (forecasts.Count > 1) DisplayForecast(forecasts[1], dateLabel2, temperatureLabel2, weatherIconBox2, detalisBtn2);
                if (forecasts.Count > 2) DisplayForecast(forecasts[2], dateLabel3, TemperatureLabel3, weatherIconBox3, detalisBtn3);
                if (forecasts.Count > 3) DisplayForecast(forecasts[3], dateLabel4, TemperatureLabel4, weatherIconBox4, detalisBtn4);
                if (forecasts.Count > 4) DisplayForecast(forecasts[4], dateLabel5, TemperatureLabel5, weatherIconBox5, detalisBtn5);
            }
            else
            {
                MessageBox.Show("Dữ liệu thời tiết không khả dụng.");
            }
        }

        private void DisplayForecast(WeatherInfo.Forecast forecast, Label dateLabel, Label tempLabel, PictureBox iconBox, Button detailsButton)
        {
            dateLabel.Text = DateTime.Parse(forecast.DtTxt).ToString("dd/MM/yyyy");
            tempLabel.Text = forecast.Main.Temp.ToString("F1") + " °C";
            string img = "http://openweathermap.org/img/w/" + forecast.Weather[0].Icon + ".png";

            iconBox.Size = new System.Drawing.Size(150, 150); // Example size: 200x200 pixels

            iconBox.SizeMode = PictureBoxSizeMode.StretchImage;

            iconBox.Load(img);
            dateLabel.Visible = tempLabel.Visible = iconBox.Visible = detailsButton.Visible = true;
        }

        private void detalisBtn1_Click(object sender, EventArgs e) => ShowDetails(0);
        private void detalisBtn2_Click(object sender, EventArgs e) => ShowDetails(1);
        private void detalisBtn3_Click(object sender, EventArgs e) => ShowDetails(2);
        private void detalisBtn4_Click(object sender, EventArgs e) => ShowDetails(3);
        private void detalisBtn5_Click(object sender, EventArgs e) => ShowDetails(4);

        private void ShowDetails(int index)
        {
            if (data != null && data.List != null && data.List.Count > 0)
            {
                var selectedDay = DateTime.Parse(data.List[0].DtTxt).Date.AddDays(index + 1);
                var hourlyForecasts = data.List
                    .Where(x => DateTime.Parse(x.DtTxt).Date == selectedDay)
                    .ToList();

                Form3 form = new Form3(selectedDay.ToString("dd/MM/yyyy"), hourlyForecasts);
                form.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}