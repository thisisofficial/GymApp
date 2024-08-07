using System;
using System.Windows.Forms;

namespace GymApp
{
    partial class MainForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                
            }
            base.Dispose(disposing);
            Environment.Exit(0);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.logged_count = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblDay = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // logged_count
            // 
            this.logged_count.AutoSize = true;
            this.logged_count.Font = new System.Drawing.Font("Myanmar Text", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logged_count.ForeColor = System.Drawing.Color.Gold;
            this.logged_count.Location = new System.Drawing.Point(1159, 58);
            this.logged_count.Name = "logged_count";
            this.logged_count.Size = new System.Drawing.Size(164, 32);
            this.logged_count.TabIndex = 26;
            this.logged_count.Text = "Ingresados hoy: 0";
            this.logged_count.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Linen;
            this.label10.Location = new System.Drawing.Point(1164, 542);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(146, 20);
            this.label10.TabIndex = 25;
            this.label10.Text = "Número de cuenta";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Linen;
            this.label9.Location = new System.Drawing.Point(1164, 488);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 20);
            this.label9.TabIndex = 24;
            this.label9.Text = "Camara";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Linen;
            this.label7.Location = new System.Drawing.Point(1164, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(309, 20);
            this.label7.TabIndex = 23;
            this.label7.Text = "Acceso por QR o número de cuenta";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Myanmar Text", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblTime.Location = new System.Drawing.Point(45, 658);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(592, 50);
            this.lblTime.TabIndex = 22;
            this.lblTime.Text = "Muestra tu QR o ingresa tu número de cuenta";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Myanmar Text", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Gold;
            this.lblName.Location = new System.Drawing.Point(30, 553);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(808, 142);
            this.lblName.TabIndex = 21;
            this.lblName.Text = "Bienvenid@ a JL FIT";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button5
            // 
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.button5.Location = new System.Drawing.Point(1165, 590);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(491, 45);
            this.button5.TabIndex = 20;
            this.button5.Text = "Accesar";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(1165, 562);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(491, 22);
            this.textBox2.TabIndex = 19;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(1165, 508);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(491, 24);
            this.comboBox2.TabIndex = 18;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(1165, 154);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(491, 320);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::GymApp.Properties.Resources.logo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(242, 141);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(433, 391);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Font = new System.Drawing.Font("Myanmar Text", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDay.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblDay.Location = new System.Drawing.Point(45, 708);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(378, 50);
            this.lblDay.TabIndex = 27;
            this.lblDay.Text = "O consigue el acceso por dia";
            this.lblDay.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1682, 853);
            this.Controls.Add(this.lblDay);
            this.Controls.Add(this.logged_count);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MainForm";
            this.Text = " ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label logged_count;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Timer timer1;
    }
}

