using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using WeatherApp;

namespace AppWeather
{
    public partial class Form3 : Form
    {
        private List<WeatherInfo.Forecast> hourlyForecasts;

        public Form3(string date, List<WeatherInfo.Forecast> hourlyForecasts)
        {
            InitializeComponent();
            this.Text = $"Chi tiết thời tiết cho {date}";
            this.hourlyForecasts = hourlyForecasts;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if (hourlyForecasts == null || !hourlyForecasts.Any())
            {
                MessageBox.Show("Không có dự báo theo giờ.");
                return;
            }

            DisplayHourlyForecasts();
        }

        private void DisplayHourlyForecasts()
        {
            // Create a TableLayoutPanel with 4 columns
            var tableLayoutPanel = new TableLayoutPanel
            {
                AutoSize = true,
                ColumnCount = 4,
                Dock = DockStyle.Fill,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                Padding = new Padding(10)
            };

            // Set equal width for each column
            for (int i = 0; i < 4; i++)
            {
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            }

            int row = 0;
            int col = 0;

            foreach (var forecast in hourlyForecasts)
            {
                if (col == 4)
                {
                    col = 0;
                    row++;
                }

                var time = DateTime.Parse(forecast.DtTxt).ToString("HH:mm");
                var temp = forecast.Main.Temp.ToString("F1") + " °C";
                //lab_chitiet.Text = WeatherTranslator.TranslateDescription(forecast.Weather[0].Description);
                var description = WeatherTranslator.TranslateDescription(forecast.Weather[0].Description);

                var icon = forecast.Weather[0].Icon;

                var timeLabel = new Label
                {
                    Text = $"Thời gian: {time}",
                    AutoSize = true,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    Margin = new Padding(3)
                };

                var tempLabel = new Label
                {
                    Text = $"Nhiệt độ: {temp}",
                    AutoSize = true,
                    Font = new Font("Arial", 10),
                    Margin = new Padding(3)
                };

                var descriptionLabel = new Label
                {
                    Text = $"Mô tả: {description}",
                    AutoSize = true,
                    Font = new Font("Arial", 10),
                    Margin = new Padding(3)
                };

                var pictureBox = new PictureBox
                {
                    ImageLocation = $"http://openweathermap.org/img/w/{icon}.png",
                    SizeMode = PictureBoxSizeMode.AutoSize,
                    Margin = new Padding(3)
                };

                var detailsButton = new Button
                {
                    Text = "Thông số khác",
                    AutoSize = true,
                    Tag = forecast,
                    Font = new Font("Arial", 10),
                    Margin = new Padding(3)
                };
                detailsButton.Click += DetailsButton_Click;

                var panel = new FlowLayoutPanel
                {
                    AutoSize = true,
                    FlowDirection = FlowDirection.TopDown
                };

                panel.Controls.Add(timeLabel);
                panel.Controls.Add(tempLabel);
                panel.Controls.Add(descriptionLabel);
                panel.Controls.Add(pictureBox);
                panel.Controls.Add(detailsButton);

                tableLayoutPanel.Controls.Add(panel, col, row);

                col++;
            }

            Controls.Add(tableLayoutPanel);
        }

        private void DetailsButton_Click(object sender, EventArgs e)
        {
            if (sender is Button button && button.Tag is WeatherInfo.Forecast forecast)
            {
                var tg = DateTime.Parse(forecast.DtTxt).ToString("HH:mm");
                var icon = forecast.Weather[0].Icon;
                var details = $"Cảm giác nhiệt độ: {forecast.Main.FeelsLike} °C\n" +
                              $"Nhiệt độ tối thiểu: {forecast.Main.TempMin} °C\n" +
                              $"Nhiệt độ tối đa: {forecast.Main.TempMax} °C\n" +
                              $"Áp suất: {forecast.Main.Pressure} hPa\n" +
                              $"Độ ẩm: {forecast.Main.Humidity}%\n" +
                              $"Tốc độ gió: {forecast.Wind.Speed} m/s\n" +
                              $"Gió giật: {forecast.Wind.Gust} m/s\n" +
                              $"Lượng mưa: {(forecast.Rain?.Rain3h.HasValue ?? false ? forecast.Rain.Rain3h.Value.ToString() : "0")} mm";


                    Form4 form = new Form4(details, forecast.Weather[0].Icon, DateTime.Parse(forecast.DtTxt).ToString("HH:mm"), WeatherTranslator.TranslateDescription(forecast.Weather[0].Description));
                    form.Show();
                
                //MessageBox.Show(details, "Chi tiết dự báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public static class WeatherTranslator
        {
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