using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Collections.Generic;
using AppWeather;

namespace AppWeather
{
    public partial class Form4 : Form
    {
        private string thongtin, icon, tg, tt;

        public Form4(string thongtin, string icon, string tg, string tt)
        {
            InitializeComponent();
            this.thongtin = thongtin;
            this.icon = icon;
            this.tg = tg;
            this.tt = tt;

        }

        private void ttchitiet_Click(object sender, EventArgs e)
        {

        }

        private async void Form4_Load(object sender, EventArgs e)
        {
            displayWeather();
        }


        public void displayWeather()
        {
            ttchitiet.Text = thongtin;
            //weatherIconBox1.Text = icon;
            trangthai.Text = tt;
            thoigian.Text = "Các thông số vào lúc " + tg;
            string img = "http://openweathermap.org/img/w/" + icon + ".png";

            // Set the size of the PictureBox (increase size as needed)
            weatherIconBox1.Size = new System.Drawing.Size(300, 300); // Example size: 200x200 pixels

            // Set the SizeMode to stretch the image to fit the PictureBox
            weatherIconBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            // Load the image into the PictureBox
            weatherIconBox1.Load(img);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}