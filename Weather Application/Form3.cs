using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
            this.Text = $"Weather Details for {date}";
            this.hourlyForecasts = hourlyForecasts;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if (hourlyForecasts == null || !hourlyForecasts.Any())
            {
                MessageBox.Show("No hourly forecasts available.");
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
                var description = forecast.Weather[0].Description;
                var icon = forecast.Weather[0].Icon;

                var timeLabel = new Label
                {
                    Text = $"Time: {time}",
                    AutoSize = true,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    Margin = new Padding(3)
                };

                var tempLabel = new Label
                {
                    Text = $"Temperature: {temp}",
                    AutoSize = true,
                    Font = new Font("Arial", 10),
                    Margin = new Padding(3)
                };

                var descriptionLabel = new Label
                {
                    Text = $"Description: {description}",
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
                    Text = "Details",
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
                var details = $"Feels Like: {forecast.Main.FeelsLike} °C\n" +
                              $"Min Temp: {forecast.Main.TempMin} °C\n" +
                              $"Max Temp: {forecast.Main.TempMax} °C\n" +
                              $"Pressure: {forecast.Main.Pressure} hPa\n" +
                              $"Humidity: {forecast.Main.Humidity}%\n" +
                              $"Wind Speed: {forecast.Wind.Speed} m/s\n" +
                              $"Wind Gust: {forecast.Wind.Gust} m/s\n" +
                              $"Rain: {(forecast.Rain?.Rain3h.HasValue ?? false ? forecast.Rain.Rain3h.Value.ToString() : "0")} mm";

                MessageBox.Show(details, "Forecast Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}