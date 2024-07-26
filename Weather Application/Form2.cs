
using AppWeather.Api;
using AppWeather.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppWeather
{
    public partial class Form2 : Form
    {
        private ForecastModel.RootObject data;
        private string cityName;
        public Form2(string City)
        {
            InitializeComponent();
            this.cityName = City;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            prepareForecastToDisplay(cityName);
            displayWeather();
        }

        public void prepareForecastToDisplay(string City)
        {
            data = WeatherApi.getHoursForecast(City);
        }

        public void displayWeather()
        {

            dateLabel1.Text = data.list[0].dt_txt;
            temperatureLabel1.Text = data.list[0].main.temp.ToString() + " °C";
            string imgUrl = "http://openweathermap.org/img/w/" + data.list[0].weather[0].icon + ".png";
            weatherIconBox1.Load(imgUrl);

            dateLabel2.Text = data.list[1].dt_txt;
            temperatureLabel2.Text = data.list[1].main.temp.ToString() + " °C"; ;
            string imgUrl2 = "http://openweathermap.org/img/w/" + data.list[1].weather[0].icon + ".png";
            weatherIconBox2.Load(imgUrl2);

            dateLabel3.Text = data.list[2].dt_txt;
            TemperatureLabel3.Text = data.list[2].main.temp.ToString() + " °C"; ;
            string imgUrl3 = "http://openweathermap.org/img/w/" + data.list[2].weather[0].icon + ".png";
            weatherIconBox3.Load(imgUrl3);
        }

        private void detalisBtn1_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3(data.list[0].dt_txt, data.list[0].main.temp_min.ToString(), data.list[0].main.temp_max.ToString(),
                data.list[0].main.pressure.ToString(), data.list[0].wind.speed.ToString(), data.list[0].main.humidity.ToString(),
                data.list[0].weather[0].description, data.list[0].weather[0].icon);
            form.Show();
        }

        private void detalisBtn2_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3(data.list[1].dt_txt, data.list[1].main.temp_min.ToString(), data.list[1].main.temp_max.ToString(),
     data.list[1].main.pressure.ToString(), data.list[1].wind.speed.ToString(), data.list[1].main.humidity.ToString(),
     data.list[1].weather[0].description, data.list[1].weather[0].icon);
            form.Show();
        }

        private void detalisBtn3_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3(data.list[2].dt_txt, data.list[2].main.temp_min.ToString(), data.list[2].main.temp_max.ToString(),
     data.list[2].main.pressure.ToString(), data.list[2].wind.speed.ToString(), data.list[2].main.humidity.ToString(),
     data.list[2].weather[0].description, data.list[2].weather[0].icon);
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
