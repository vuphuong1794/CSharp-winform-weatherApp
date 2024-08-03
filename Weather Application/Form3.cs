using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeatherApp;
using static WeatherApp.WeatherInfo;

namespace AppWeather
{
    public partial class Form3 : Form
    {
        string date, mintemp, maxtemp, pressure, wind, humidity, message, picture, gust, rain;
        //long sunrise, sunset;

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pic_icon_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void temperatureL_Click(object sender, EventArgs e)
        {

        }

        private void minTemperatureLabel_Click(object sender, EventArgs e)
        {

        }

        public Form3(string date, string mintemp, string maxtemp, string pressure, string wind, string humidity
            , string message, string picture, string gust, string rain
            )
        {
            InitializeComponent();
            this.date = date;
            this.mintemp = mintemp;
            this.maxtemp = maxtemp;
            this.pressure = pressure;
            this.wind = wind;
            this.humidity = humidity;
            this.message = message;
            this.picture = picture;
            //this.sunrise = sunrise;
            //this.sunset = sunset;
            this.gust = gust;
            this.rain = rain;

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            displayData();
        }

        private void displayData()
        {
            dateLabel.Text = date;
            minnhiet.Text = mintemp + " °C";
            maxnhiet.Text = maxtemp + " °C";
            khiquyen.Text = pressure + " hPa";
            windSpeed.Text = wind + " m/s";
            doam.Text = humidity + " %";

            // Translation 
            descriptionLabel.Text = WeatherTranslator.TranslateDescription(message.ToUpper());


            string img = "http://openweathermap.org/img/w/" + picture + ".png";

            // Set the size of the PictureBox (increase size as needed)
            pic_icon.Size = new System.Drawing.Size(200, 200); // Example size: 200x200 pixels

            // Set the SizeMode to stretch the image to fit the PictureBox
            pic_icon.SizeMode = PictureBoxSizeMode.StretchImage;

            // Load the image into the PictureBox
            pic_icon.Load(img);

            //sunrisetext.Text = DateTimeOffset.FromUnixTimeSeconds(sunrise).ToString("yyyy-MM-dd HH:mm");
            //sunsettext.Text = DateTimeOffset.FromUnixTimeSeconds(sunset).ToString("yyyy-MM-dd HH:mm");
            windGust.Text = gust + " m/s";
            luongmua.Text = rain + " mm";
        }
        // Translation Vietnam
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
                { "snow", "Tuyết" },
                { "heavy snow", "Tuyết lớn" },
                { "sleet", "Mưa tuyết" },
                { "light shower sleet", "Mưa tuyết nhẹ" },
                { "shower sleet", "Mưa tuyết" },
                { "light rain and snow", "Mưa và tuyết nhẹ" },
                { "rain and snow", "Mưa và tuyết" },
                { "light shower snow", "Tuyết rơi nhẹ" },
                { "shower snow", "Tuyết rơi" },
                { "heavy shower snow", "Tuyết rơi lớn" },
                { "mist", "Sương mù" },
                { "smoke", "Khói" },
                { "haze", "Sương mù" },
                { "sand/dust whirls", "Bụi cát" },
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
                string lowerDescription = description.Trim().ToLower();

                if (WeatherDetailDescriptions.TryGetValue(lowerDescription, out string translatedDescription))
                {
                    return translatedDescription;
                }
                return "Không xác định";
            }
        }
    }
}