using System;
using System.Drawing;
using System.Linq;
using System.Text;
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
        }

        private void Form2_Load(object sender, EventArgs e)
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