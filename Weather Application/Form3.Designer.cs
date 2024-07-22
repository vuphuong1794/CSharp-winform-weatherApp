namespace AppWeather
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.dateLabel = new System.Windows.Forms.Label();
            this.WindSpeedL = new System.Windows.Forms.Label();
            this.pressureL = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_close = new System.Windows.Forms.Button();
            this.lab_tieude = new System.Windows.Forms.Label();
            this.icon_logo = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.temperatureL = new System.Windows.Forms.Label();
            this.minTemperatureLabel = new System.Windows.Forms.Label();
            this.pressureLabel = new System.Windows.Forms.Label();
            this.WindSpeedLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.humidityLabel = new System.Windows.Forms.Label();
            this.maxTempLabel = new System.Windows.Forms.Label();
            this.pic_icon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.icon_logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_icon)).BeginInit();
            this.SuspendLayout();
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.BackColor = System.Drawing.Color.Transparent;
            this.dateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.dateLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.dateLabel.Location = new System.Drawing.Point(28, 39);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(85, 24);
            this.dateLabel.TabIndex = 0;
            this.dateLabel.Text = "Ngày/giờ";
            // 
            // WindSpeedL
            // 
            this.WindSpeedL.AutoSize = true;
            this.WindSpeedL.BackColor = System.Drawing.Color.Transparent;
            this.WindSpeedL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.WindSpeedL.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.WindSpeedL.Location = new System.Drawing.Point(35, 148);
            this.WindSpeedL.Name = "WindSpeedL";
            this.WindSpeedL.Size = new System.Drawing.Size(107, 24);
            this.WindSpeedL.TabIndex = 11;
            this.WindSpeedL.Text = "Tốc độ gió:";
            // 
            // pressureL
            // 
            this.pressureL.AutoSize = true;
            this.pressureL.BackColor = System.Drawing.Color.Transparent;
            this.pressureL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.pressureL.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.pressureL.Location = new System.Drawing.Point(35, 114);
            this.pressureL.Name = "pressureL";
            this.pressureL.Size = new System.Drawing.Size(165, 24);
            this.pressureL.TabIndex = 10;
            this.pressureL.Text = "Áp suất khí quyển:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(38, 254);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 24);
            this.label2.TabIndex = 16;
            this.label2.Text = "Nhiệt độ cao nhất:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(35, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 24);
            this.label3.TabIndex = 18;
            this.label3.Text = "Độ ẩm:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Gray;
            this.button5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(287, 371);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(117, 36);
            this.button5.TabIndex = 62;
            this.button5.Tag = "";
            this.button5.Text = "quay lại";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(539, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 24);
            this.label1.TabIndex = 63;
            this.label1.Text = "Nhiệt độ cao nhất:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(35, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 24);
            this.label4.TabIndex = 64;
            this.label4.Text = "Lượng mưa:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Location = new System.Drawing.Point(539, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 24);
            this.label5.TabIndex = 66;
            this.label5.Text = "Sunrise:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label6.Location = new System.Drawing.Point(539, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 24);
            this.label6.TabIndex = 67;
            this.label6.Text = "Sunset:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label7.Location = new System.Drawing.Point(539, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 24);
            this.label7.TabIndex = 68;
            this.label7.Text = "Gió giật:";
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btn_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_close.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.btn_close.ForeColor = System.Drawing.Color.White;
            this.btn_close.Location = new System.Drawing.Point(724, 0);
            this.btn_close.Margin = new System.Windows.Forms.Padding(2);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(46, 30);
            this.btn_close.TabIndex = 69;
            this.btn_close.Text = "X";
            this.btn_close.UseVisualStyleBackColor = false;
            // 
            // lab_tieude
            // 
            this.lab_tieude.AutoSize = true;
            this.lab_tieude.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lab_tieude.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lab_tieude.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lab_tieude.Location = new System.Drawing.Point(39, 0);
            this.lab_tieude.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lab_tieude.Name = "lab_tieude";
            this.lab_tieude.Size = new System.Drawing.Size(153, 22);
            this.lab_tieude.TabIndex = 2;
            this.lab_tieude.Text = "Dự báo thời tiết";
            // 
            // icon_logo
            // 
            this.icon_logo.BackColor = System.Drawing.Color.Transparent;
            this.icon_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.icon_logo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.icon_logo.Image = ((System.Drawing.Image)(resources.GetObject("icon_logo.Image")));
            this.icon_logo.InitialImage = null;
            this.icon_logo.Location = new System.Drawing.Point(3, 0);
            this.icon_logo.Name = "icon_logo";
            this.icon_logo.Size = new System.Drawing.Size(31, 22);
            this.icon_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.icon_logo.TabIndex = 70;
            this.icon_logo.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label8.Location = new System.Drawing.Point(539, 254);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 24);
            this.label8.TabIndex = 71;
            this.label8.Text = "Tầm nhìn:";
            // 
            // temperatureL
            // 
            this.temperatureL.AutoSize = true;
            this.temperatureL.BackColor = System.Drawing.Color.Transparent;
            this.temperatureL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.temperatureL.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.temperatureL.Location = new System.Drawing.Point(444, 160);
            this.temperatureL.Name = "temperatureL";
            this.temperatureL.Size = new System.Drawing.Size(40, 24);
            this.temperatureL.TabIndex = 9;
            this.temperatureL.Text = "25c";
            this.temperatureL.Click += new System.EventHandler(this.temperatureL_Click);
            // 
            // minTemperatureLabel
            // 
            this.minTemperatureLabel.AutoSize = true;
            this.minTemperatureLabel.Font = new System.Drawing.Font("Book Antiqua", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minTemperatureLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.minTemperatureLabel.Location = new System.Drawing.Point(375, 67);
            this.minTemperatureLabel.Name = "minTemperatureLabel";
            this.minTemperatureLabel.Size = new System.Drawing.Size(0, 27);
            this.minTemperatureLabel.TabIndex = 12;
            this.minTemperatureLabel.Click += new System.EventHandler(this.minTemperatureLabel_Click);
            // 
            // pressureLabel
            // 
            this.pressureLabel.AutoSize = true;
            this.pressureLabel.Font = new System.Drawing.Font("Book Antiqua", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pressureLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.pressureLabel.Location = new System.Drawing.Point(365, 90);
            this.pressureLabel.Name = "pressureLabel";
            this.pressureLabel.Size = new System.Drawing.Size(0, 27);
            this.pressureLabel.TabIndex = 13;
            // 
            // WindSpeedLabel
            // 
            this.WindSpeedLabel.AutoSize = true;
            this.WindSpeedLabel.Font = new System.Drawing.Font("Book Antiqua", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WindSpeedLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.WindSpeedLabel.Location = new System.Drawing.Point(365, 124);
            this.WindSpeedLabel.Name = "WindSpeedLabel";
            this.WindSpeedLabel.Size = new System.Drawing.Size(0, 27);
            this.WindSpeedLabel.TabIndex = 14;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.BackColor = System.Drawing.Color.Transparent;
            this.descriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.descriptionLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.descriptionLabel.Location = new System.Drawing.Point(316, 284);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(68, 24);
            this.descriptionLabel.TabIndex = 15;
            this.descriptionLabel.Text = "thời tiết";
            // 
            // humidityLabel
            // 
            this.humidityLabel.AutoSize = true;
            this.humidityLabel.Font = new System.Drawing.Font("Book Antiqua", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.humidityLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.humidityLabel.Location = new System.Drawing.Point(365, 157);
            this.humidityLabel.Name = "humidityLabel";
            this.humidityLabel.Size = new System.Drawing.Size(0, 27);
            this.humidityLabel.TabIndex = 19;
            // 
            // maxTempLabel
            // 
            this.maxTempLabel.AutoSize = true;
            this.maxTempLabel.Font = new System.Drawing.Font("Book Antiqua", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxTempLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.maxTempLabel.Location = new System.Drawing.Point(400, 61);
            this.maxTempLabel.Name = "maxTempLabel";
            this.maxTempLabel.Size = new System.Drawing.Size(0, 27);
            this.maxTempLabel.TabIndex = 17;
            // 
            // pic_icon
            // 
            this.pic_icon.BackColor = System.Drawing.Color.Transparent;
            this.pic_icon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic_icon.Location = new System.Drawing.Point(284, 124);
            this.pic_icon.Margin = new System.Windows.Forms.Padding(2);
            this.pic_icon.Name = "pic_icon";
            this.pic_icon.Size = new System.Drawing.Size(155, 140);
            this.pic_icon.TabIndex = 72;
            this.pic_icon.TabStop = false;
            this.pic_icon.Click += new System.EventHandler(this.pic_icon_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(770, 418);
            this.Controls.Add(this.pic_icon);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.icon_logo);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.lab_tieude);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.humidityLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.maxTempLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.WindSpeedLabel);
            this.Controls.Add(this.pressureLabel);
            this.Controls.Add(this.minTemperatureLabel);
            this.Controls.Add(this.WindSpeedL);
            this.Controls.Add(this.pressureL);
            this.Controls.Add(this.temperatureL);
            this.Controls.Add(this.dateLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form3";
            this.Text = "Detail";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.icon_logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_icon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label WindSpeedL;
        private System.Windows.Forms.Label pressureL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Label lab_tieude;
        private System.Windows.Forms.PictureBox icon_logo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label temperatureL;
        private System.Windows.Forms.Label minTemperatureLabel;
        private System.Windows.Forms.Label pressureLabel;
        private System.Windows.Forms.Label WindSpeedLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label humidityLabel;
        private System.Windows.Forms.Label maxTempLabel;
        private System.Windows.Forms.PictureBox pic_icon;
    }
}