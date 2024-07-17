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

        private void label12_Click(object sender, EventArgs e)
        {

        }

        string APIKey = "4359ef1cd11b4c97b0da50cce76d01e7";
        private void btn_search_Click(object sender, EventArgs e)
        {
            getWeather();
        }

        private void getWeather()
        {
            using (WebClient web = new WebClient())
            {
                string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}", tbCity.Text, APIKey);
                var json = web.DownloadString(url);
                WeatherInfo.root Info = JsonConvert.DeserializeObject<WeatherInfo.root>(json);
                pic_icon.ImageLocation = "https://openweathermap.org/img/w/" + Info.weather[0].icon + ".png";
                lab_condtion.Text = Info.weather[0].main;
                lab_detail.Text = Info.weather[0].description;
                lab_sunset.Text = Info.sys.sunset.ToString();
                lab_sunrise.Text = Info.sys.sunrise.ToString();
                lab_windspeed.Text = Info.wind.speed.ToString();
                lab_pressure.Text = Info.main.pressure.ToString();

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
