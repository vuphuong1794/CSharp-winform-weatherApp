﻿namespace AppWeather
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.trangthai = new System.Windows.Forms.Label();
            this.weatherIconBox1 = new System.Windows.Forms.PictureBox();
            this.ttchitiet = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.thoigian = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.weatherIconBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // trangthai
            // 
            this.trangthai.AutoSize = true;
            this.trangthai.BackColor = System.Drawing.Color.Transparent;
            this.trangthai.Font = new System.Drawing.Font("Arial Rounded MT Bold", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trangthai.ForeColor = System.Drawing.Color.MidnightBlue;
            this.trangthai.Location = new System.Drawing.Point(142, 371);
            this.trangthai.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.trangthai.Name = "trangthai";
            this.trangthai.Size = new System.Drawing.Size(200, 43);
            this.trangthai.TabIndex = 11;
            this.trangthai.Text = "Trạng thái";
            // 
            // weatherIconBox1
            // 
            this.weatherIconBox1.BackColor = System.Drawing.Color.Transparent;
            this.weatherIconBox1.Location = new System.Drawing.Point(97, 103);
            this.weatherIconBox1.Margin = new System.Windows.Forms.Padding(4);
            this.weatherIconBox1.Name = "weatherIconBox1";
            this.weatherIconBox1.Size = new System.Drawing.Size(343, 246);
            this.weatherIconBox1.TabIndex = 10;
            this.weatherIconBox1.TabStop = false;
            // 
            // ttchitiet
            // 
            this.ttchitiet.AutoSize = true;
            this.ttchitiet.BackColor = System.Drawing.Color.Transparent;
            this.ttchitiet.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ttchitiet.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ttchitiet.Location = new System.Drawing.Point(607, 103);
            this.ttchitiet.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ttchitiet.Name = "ttchitiet";
            this.ttchitiet.Size = new System.Drawing.Size(143, 32);
            this.ttchitiet.TabIndex = 9;
            this.ttchitiet.Text = "Thông tin";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightCoral;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(521, 462);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 51);
            this.button1.TabIndex = 37;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // thoigian
            // 
            this.thoigian.AutoSize = true;
            this.thoigian.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.thoigian.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.thoigian.Cursor = System.Windows.Forms.Cursors.Hand;
            this.thoigian.Font = new System.Drawing.Font("Arial", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thoigian.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.thoigian.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.thoigian.Location = new System.Drawing.Point(375, 23);
            this.thoigian.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.thoigian.Name = "thoigian";
            this.thoigian.Size = new System.Drawing.Size(168, 40);
            this.thoigian.TabIndex = 57;
            this.thoigian.Text = "Thời gian";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1221, 526);
            this.Controls.Add(this.thoigian);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.trangthai);
            this.Controls.Add(this.weatherIconBox1);
            this.Controls.Add(this.ttchitiet);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form4";
            this.Text = "Các thông số khác dự báo";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.weatherIconBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label trangthai;
        private System.Windows.Forms.PictureBox weatherIconBox1;
        private System.Windows.Forms.Label ttchitiet;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label thoigian;
    }
}