using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

using MySql.Data.MySqlClient;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Threading;

namespace GymApp
{
    public partial class MainForm : Form
    {

        private FilterInfoCollection CaptureDevice;
        private VideoCaptureDevice FinalFrame;
        bool cooldown;

        string mysqlcon = "server=127.0.0.1;user=root;database=gimnasio;password=; convert zero datetime=True";


        private string VersionString = "1.0.5";
        public MainForm()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string decode = textBox2.Text.Trim();
            if (decode != "" && IsDigitsOnly(decode))
            {

                textBox2.Text = decode;
                AddVisit(decode);
                cooldown = true;
                var wait = TriggerCooldown(500);

            }
            else
            {

            }
        }

        private void AddVisit(string AccNum, string Name = null)
        {
            List<Cliente> values = new List<Cliente>();
            List<Payment> subs = new List<Payment>();
            MySqlConnection mySqlConnection = new MySqlConnection(mysqlcon);
            try
            {
                string sql = "SELECT * FROM clientes WHERE AccNum = " + AccNum;
                mySqlConnection.Open();
                Console.WriteLine("1");
                MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Cliente cliente = new Cliente();

                    cliente.Name = reader["Name"].ToString();
                    if (Name == null)
                        Name = cliente.Name;
                    values.Add(cliente);
                }
                Console.WriteLine("2");
                if (values.Count > 0)
                {
                    Console.WriteLine("3");
                    if (AccNum == "00000000")
                    {
                        Console.WriteLine("4");
                        mySqlConnection.Close();
                        mySqlConnection.Open();
                        sql = "INSERT INTO entradas (Id,FechaHora,AccNum,Nombre) VALUES (NULL, current_timestamp(), '" + AccNum + "', '" + Name + "');";
                        MySqlCommand cmd2 = new MySqlCommand(sql, mySqlConnection);
                        cmd2.ExecuteNonQuery();
                        lblName.Text = "Bienvenid@ " + Name;
                        lblTime.Text = "Pase de día";
                        lblDay.Text = "Feliz entrenamiento";
                        var wait = TriggerCooldownLogin(5000);
                    }
                    else
                    {
                        Console.WriteLine("4");
                        sql = "SELECT * FROM pagos WHERE AccNum = " + AccNum + " ORDER BY FechaFin DESC LIMIT 1;";
                        mySqlConnection.Close();
                        mySqlConnection.Open();
                        MySqlCommand cmd2 = new MySqlCommand(sql, mySqlConnection);
                        var reader2 = cmd2.ExecuteReader();
                        while (reader2.Read())
                        {
                            Payment payed = new Payment();
                            Console.WriteLine("5.5");
                            Console.WriteLine(reader2["FechaFin"]);
                            payed.LastDate = DateTime.Parse(reader2["FechaFin"].ToString());
                            Console.WriteLine("5.5");
                            payed.Active = reader2["Active"].ToString();
                            Console.Write(reader2["Active"]);
                            subs.Add(payed);
                            Console.WriteLine("6");
                        }
                        if (subs.Count > 0)
                        {
                            Console.WriteLine("7");
                            int DaysLeft = (subs[0].LastDate - DateTime.Now).Days;
                            Console.WriteLine(DaysLeft);
                            Console.WriteLine(DaysLeft);
                            if (subs[0].Active == "True")
                            {
                                lblName.Text = "Bienvenid@ " + values[0].Name;
                                if (DaysLeft >= 0)
                                {
                                    string Date = subs[0].LastDate.Date.ToString();

                                    lblTime.Text = "Fecha final de la subscripcion: " + Date;
                                    if (DaysLeft > 7)
                                    {
                                        lblDay.Text = "Feliz Entrenamiento";
                                    }
                                    else
                                        lblDay.Text = "Quedan " + DaysLeft.ToString() + " días restantes";
                                    mySqlConnection.Close();
                                    mySqlConnection.Open();
                                    sql = "INSERT INTO entradas (Id,FechaHora,AccNum,Nombre) VALUES (NULL, current_timestamp(), '" + AccNum + "', '" + Name + "');";
                                    MySqlCommand cmd3 = new MySqlCommand(sql, mySqlConnection);
                                    cmd3.ExecuteNonQuery();
                                    var wait = TriggerCooldownLogin(5000);
                                }
                                else
                                {
                                    lblTime.Text = "La subscrtipcion a acabado";
                                    DaysLeft = (DateTime.Now - subs[0].LastDate).Days;
                                    lblDay.Text = "Subscripcion con " + DaysLeft.ToString() + " días tardios";
                                    mySqlConnection.Close();
                                    mySqlConnection.Open();
                                    sql = "INSERT INTO entradas (Id,FechaHora,AccNum,Nombre) VALUES (NULL, current_timestamp(), '" + AccNum + "', '" + Name + "');";
                                    MySqlCommand cmd3 = new MySqlCommand(sql, mySqlConnection);
                                    cmd3.ExecuteNonQuery();
                                    var wait = TriggerCooldownLogin(5000);
                                }
                            }
                            else
                            {
                                MessageBox.Show("La subscripción se a acabado, favor de renovar", "Error al ingresar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se encontro una subscripción asociada a esta cuenta", "Error al ingresar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }

                }
                else
                {
                    MessageBox.Show("No se encontro el número de cuenta", "Error al ingresar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                mySqlConnection.Close();
                string sql = "SELECT COUNT(Id) FROM entradas WHERE DATE(FechaHora) = CURDATE();";
                mySqlConnection.Open();
                MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    logged_count.Text = "Ingresados hoy: " + reader[0].ToString();
                }
                mySqlConnection.Close();
            }
        }

        private bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        async Task TriggerCooldown(int milisecond)
        {
            textBox2.Text = "";
            await Task.Delay(milisecond);
        

        }

        async Task TriggerCooldownLogin(int milisecond)
        {
            ActiveForm.BackColor = Color.DarkSlateGray;
            await Task.Delay(milisecond);
            ActiveForm.BackColor = Color.DimGray;
            lblName.Text = "Bienvenid@ a JL Fit";
            lblTime.Text = "Muestra tu QR o ingresa tu número de cuenta";
            lblDay.Text = "O consigue un acceso por día";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ZXing.Windows.Compatibility.BarcodeReader reader = new ZXing.Windows.Compatibility.BarcodeReader();
            ZXing.Result result = reader.Decode((Bitmap)pictureBox2.Image);
            if (result != null)
            {
                try
                {
                    string decode = result.ToString().Trim();
                    if (decode != "" && IsDigitsOnly(decode))
                    {
                        textBox2.Text = decode;
                        AddVisit(decode);
                        cooldown = true;
                        var wait = TriggerCooldown(5000);

                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in CaptureDevice)
            {
                comboBox2.Items.Add(Device.Name);
            }

            comboBox2.SelectedIndex = 0;
            FinalFrame = new VideoCaptureDevice();
            FinalFrame = new VideoCaptureDevice(CaptureDevice[comboBox2.SelectedIndex].MonikerString);
            FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
            FinalFrame.Start();
            Thread.Sleep(1000);
            timer1.Start();
        }

        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs e)
        {
            try
            {
                pictureBox2.Image = (Bitmap)e.Frame.Clone();
            }
            catch
            {

            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            FinalFrame.Stop();
            timer1.Stop();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            FinalFrame = new VideoCaptureDevice(CaptureDevice[comboBox2.SelectedIndex].MonikerString);
            FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
            FinalFrame.Start();
        }
    }
}
