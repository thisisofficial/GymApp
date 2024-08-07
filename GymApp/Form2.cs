using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymApp
{
    public partial class Form2 : Form
    {
        private DataTable table;
        private DataTable table2;
        string mysqlcon = "server=127.0.0.1;user=root;database=gimnasio;password=; convert zero datetime=True";


        private void Inicializar()
        {
            table = new DataTable();

            table.Columns.Add("Nombre");
            table.Columns.Add("Apellido");
            table.Columns.Add("Telefono");
            table.Columns.Add("Numero de cuenta");
            dataGridView_Clients.DataSource = table;


        }

        private void InicializarPay()
        {
            table2 = new DataTable();

            table2.Columns.Add("Numero de cuenta");
            table2.Columns.Add("Fecha limite");
            table2.Columns.Add("Precio");
            table2.Columns.Add("Pagado");
            table2.Columns.Add("Tipo de subscripcion");
            table2.Columns.Add("Activo");
            table2.Columns.Add("Recurrent");
            dataGridView_Pagos.DataSource = table2;
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void OnlyNumbersCheck(object sender, KeyPressEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox10.Text == "")
            {
                ConsultarPayment();
            }
            else
            {
                ConsultarPayment(textBox10.Text);
            }

        }

        private void ConsultarPayment(string text = "")
        {
            string sql;
            if (text == "")
            {
                sql = "SELECT * FROM pagos ORDER BY FechaFin ASC LIMIT 30";
            }
            else
            {
                sql = "SELECT * FROM pagos WHERE AccNum LIKE '%" + text + "%' ORDER BY FechaFin ASC LIMIT 30";
            }
            MySqlConnection mySqlConnection = new MySqlConnection(mysqlcon);
            List<Payment> values = new List<Payment>();
            try
            {


                mySqlConnection.Open();
                MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Payment payment = new Payment();
                    payment.AccNum = reader["AccNum"].ToString();
                    payment.LastDate = DateTime.Parse(reader["FechaFin"].ToString());
                    payment.Price = reader["Owed"].ToString();
                    payment.Owed = reader["Payed"].ToString();
                    payment.Active = reader["Active"].ToString();
                    payment.Recurrent = reader["Recurrent"].ToString();
                    string type = "";
                    switch (reader["TimeFrame"].ToString())
                    {
                        case "1":
                            type = "Semanal";
                            break;
                        case "2":
                            type = "Quincena";
                            break;
                        case "3":
                            type = "Mensual";
                            break;
                    }
                    payment.Type = type;
                    values.Add(payment);
                }
            }
            catch
            {

            }
            finally
            {
                mySqlConnection.Close();
            }
            InicializarPay();
            Console.Write(values.ToString());
            Console.Write("aaaa");
            foreach (var item in values)
            {
                DataRow row = table2.NewRow();
                row["Numero de cuenta"] = item.AccNum;
                row["Fecha limite"] = item.LastDate.ToString();
                row["Precio"] = item.Price;
                row["Pagado"] = item.Owed;
                row["Tipo de subscripcion"] = item.Type;
                row["Activo"] = item.Active;
                row["Recurrent"] = item.Recurrent;
                table2.Rows.Add(row);


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dateTime_paid.Value = DateTime.Now;
        }

        private void btnSaveClient_Click(object sender, EventArgs e)
        {
            {
                bool check = false;

                if (txtName.Text == "")
                {
                    check = true;
                }
                if (txtLastName.Text == "")
                {
                    check = true;
                }
                if (textBox1.Text == "")
                {
                    check = true;
                }

                if (UserPagePayToogle.Checked)
                {
                    if (UserPage_Payed.Text == "")
                    {
                        check = true;
                    }

                    if (UsePage_Due.Text == "")
                    {
                        check = true;
                    }
                }

                if (!check)
                {
                    Guardar();
                    Clean();
                }
                else
                {
                    MessageBox.Show("Rellena todos los campos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void Clean()
        {
            txtLastName.Text = "";
            txtName.Text = "";
            textBox1.Text = "";
        }

        private void Guardar()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(mysqlcon);
            int newid = 0;
            try
            {
                mySqlConnection.Open();
                string sql = "SELECT MAX(Id) FROM Clientes";
                MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader[0]);
                    newid = Int32.Parse(reader[0].ToString());
                }
                Console.WriteLine("Nuevo id: " + newid);
            }
            catch
            {

            }
            finally
            {
                mySqlConnection.Close();
            }
            DateTime rn = DateTime.Now;
            string numAcc = (rn.Year - 2000).ToString() + rn.Month.ToString() + rn.Day.ToString() + (newid + 1);
            Console.WriteLine(numAcc);
            Cliente model = new Cliente()
            {
                Name = txtName.Text,
                LastName = txtLastName.Text,
                AccNum = numAcc.ToString(),
                Tel = textBox1.Text,
            };

            try
            {
                mySqlConnection.Open();
                /*if (model.FechaInicio.Month < 10)
                    monthini = "0" + model.FechaInicio.Month.ToString();
                else
                    monthini = model.FechaInicio.Month.ToString();
                if (model.FechaFin.Month < 10)
                    monthfin = "0" + model.FechaFin.Month.ToString();
                else
                    monthfin = model.FechaFin.Month.ToString();
                if (model.FechaInicio.Day < 10)
                    dayini = "0" + model.FechaInicio.Day.ToString();
                else
                    dayini = model.FechaInicio.Day.ToString();
                if (model.FechaFin.Day < 10)
                    dayfin = "0" + model.FechaInicio.Day.ToString();
                else
                    dayfin = model.FechaInicio.Month.ToString();

                string fechini = model.FechaInicio.Year.ToString() + "-" + monthini + "-" + dayini;
                string fechfin = model.FechaFin.Year.ToString() + "-" + monthfin + "-" + dayfin;*/
                string sql = "INSERT INTO clientes (`Id`, `Name`, `LastName`, `Activo`, `Imagen`, `Tel`, `AccNum`) VALUES (NULL,'" + model.Name + "', '" + model.LastName + "','1', NULL,'" + model.Tel.ToString() + "', '" + model.AccNum + "');";
                MySqlCommand cmd2 = new MySqlCommand(sql, mySqlConnection);
                cmd2.ExecuteNonQuery();
                Zen.Barcode.CodeQrBarcodeDraw qrcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
                pictureBox3.Image = qrcode.Draw(model.AccNum.ToString(), 150);
                lblResultName.Text = "Cliente: " + model.Name.ToString() + " " + model.LastName.ToString();
                lblResultAcc.Text = "Numero de cuenta: " + model.AccNum.ToString();
                var await = TriggerCooldownRegister(30000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                mySqlConnection.Close();
                if (UserPagePayToogle.Checked)
                {
                    int modelpayment = 0;

                    if (radioButton3.Checked)
                    {
                        modelpayment = 3;
                    }
                    else if (radioButton2.Checked)
                    {
                        modelpayment = 2;
                    }
                    else if (radioButton1.Checked)
                    {
                        modelpayment = 1;
                    }

                    GuardarPago(model.AccNum, Recurrent.Checked, modelpayment, dateTime_paid.Value, dateTime_toPay.Value, float.Parse(UsePage_Due.Text), float.Parse(UserPage_Payed.Text));
                }
            }

            FirstConsultAcc();
        }

        /// <summary>
        /// Saca todos los datos necesarios en cuanto se abre la app
        /// Inicializa la tabla de usuarios.
        ///
        /// </summary>
        private void FirstConsultAcc()
        {
            List<Cliente> values = new List<Cliente>();
            MySqlConnection mySqlConnection = new MySqlConnection(mysqlcon);
            try
            {
                string sql = "";
                mySqlConnection.Open();
                Console.WriteLine("Connection added");
                sql = "SELECT * FROM clientes WHERE Activo = 1 ORDER BY Id DESC LIMIT 30";
                string secondsql = "SELECT COUNT(Id) As COUTED FROM clientes WHERE Activo = 1";
                MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("11");
                    Cliente cliente = new Cliente();
                    cliente.AccNum = reader["AccNum"].ToString();
                    cliente.Name = reader["Name"].ToString();
                    cliente.LastName = reader["LastName"].ToString();
                    cliente.Tel = reader["Tel"].ToString();
                    values.Add(cliente);
                }
                mySqlConnection.Close();
                mySqlConnection.Open();
                cmd = new MySqlCommand(secondsql, mySqlConnection);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ClientCount.Text = "Clientes registrados: " + reader[0].ToString();
                    Console.Write("AAAH" + reader[0].ToString());
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
                    label27.Text = "Ingresados hoy: " + reader[0].ToString();
                }
                mySqlConnection.Close();
            }
            Inicializar();
            Console.Write(values.ToString());
            Console.Write("aaaa");
            foreach (var item in values)
            {
                DataRow row = table.NewRow();
                row["Nombre"] = item.Name;
                row["Apellido"] = item.LastName;
                row["Telefono"] = item.Tel;
                row["Numero de cuenta"] = item.AccNum.ToString();
                table.Rows.Add(row);

            }
            dateTime_toPay.Value = DateTime.Now.AddMonths(1);
            Payment_End.Value = DateTime.Now.AddMonths(1);
        }

        private void GuardarPago(string AccNum, bool Recurrent, int Model, DateTime start, DateTime end, float Due, float Payed)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(mysqlcon);
            bool check = true;
            try
            {
                mySqlConnection.Open();
                string sql = "SELECT * FROM clientes WHERE AccNum = '" + AccNum + "';";
                MySqlCommand cmd2 = new MySqlCommand(sql, mySqlConnection);
                var reader = cmd2.ExecuteReader();
                if (!reader.Read())
                {
                    check = false;
                }
            }
            catch
            {

            }
            finally
            {
                mySqlConnection.Close();
            }
            if (check)
            {
                try
                {
                    int recurringvalue = 1;
                    if (!Recurrent)
                    {
                        recurringvalue = 0;
                    }
                    string monthini, monthfin, dayini, dayfin = "";
                    if (start.Month < 10)
                        monthini = "0" + start.Month.ToString();
                    else
                        monthini = start.Month.ToString();
                    if (end.Month < 10)
                        monthfin = "0" + end.Month.ToString();
                    else
                        monthfin = end.Month.ToString();
                    if (start.Day < 10)
                        dayini = "0" + start.Day.ToString();
                    else
                        dayini = start.Day.ToString();
                    if (end.Day < 10)
                        dayfin = "0" + end.Day.ToString();
                    else
                        dayfin = end.Day.ToString();
                    Console.WriteLine(start.Day);
                    string fechini = start.Year.ToString() + "-" + monthini + "-" + dayini;
                    Console.WriteLine(start.Day);
                    string fechfin = end.Year.ToString() + "-" + monthfin + "-" + dayfin;
                    Console.WriteLine(start.Day);
                    string sql = "INSERT INTO pagos (`AccNum`, `FechaFin`, `TimeFrame`, `Recurrent`, `Owed`, `Payed`, `Id` ,`FechaInicio`, `RecurrentTimes`, `Active`) VALUES ('" + AccNum + "', '" + fechfin + "','" + Model + "','" + recurringvalue + "','" + Due + "','" + Payed + "'," + "NULL,'" + fechini + "','1','1');";
                    Console.Write(sql);
                    mySqlConnection.Open();
                    MySqlCommand cmd2 = new MySqlCommand(sql, mySqlConnection);
                    cmd2.ExecuteNonQuery();
                }
                catch
                {

                }
                finally
                {
                    mySqlConnection.Close();
                    MessageBox.Show("Se agrego la subscripcion correctamente.", "Tarea completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No se encontro ningun usuario asociado al número de cuenta", "No se completo la tarea", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        async Task TriggerCooldownRegister(int milisecond)
        {
            await Task.Delay(milisecond);
            lblResultName.Text = "";
            lblResultFecha.Text = "";
            lblResultAcc.Text = "";
            pictureBox3.Image = null;
            if (UserPagePayToogle.Checked)
            {
                UsePage_Due.Text = "";
                UserPage_Payed.Text = "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (textBox6.Text == "")
                check = true;
            if (textBox5.Text == "")
                check = true;
            if (textBox4.Text == "")
                check = true;
            if (check)
            {
                MessageBox.Show("Por favor rellene todos los campos antes de continuar", "Error en la tarea", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var confirmation = MessageBox.Show("¿Está seguro que quiere editar este elemento?", "Esta acción no puede revertirse", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmation == DialogResult.Yes)
                {
                    try
                    {
                        MySqlConnection mySqlConnection = new MySqlConnection(mysqlcon);
                        mySqlConnection.Open();
                        string recurrent = "0";
                        string active = "0";
                        if (checkBox1.Checked == true)
                            recurrent = "1";
                        if (checkBox2.Checked == true)
                            active = "1";
                        Console.WriteLine("Connection added");
                        string ender = "";
                        string sql = "";
                        if (textBox4.Text == textBox5.Text || checkBox2.Checked == false)
                        {
                            MySqlConnection mysqlConnection2 = new MySqlConnection(mysqlcon);
                            List<Payment> listings = new List<Payment>();
                            try
                            {
                                Console.WriteLine("Lets start");
                                mysqlConnection2.Open();
                                string sql2 = "SELECT * from Pagos where AccNum = '" + textBox6.Text + "';";
                                Console.WriteLine("Lets start");
                                MySqlCommand cmd2 = new MySqlCommand(sql2, mysqlConnection2);
                                var reader = cmd2.ExecuteReader();
                                Console.WriteLine("Lets start");
                                while (reader.Read())
                                {
                                    Console.WriteLine("aaa");
                                    Payment payment = new Payment();
                                    payment.LastDate = DateTime.Parse(reader["FechaFin"].ToString());
                                    Console.WriteLine("Lets start6");
                                    payment.Recurrance = reader["RecurrentTimes"].ToString();
                                    Console.WriteLine("Lets start7");
                                    payment.StartDate = DateTime.Parse(reader["FechaInicio"].ToString());
                                    Console.WriteLine("Lets start8");
                                    Console.WriteLine("Entered");

                                    payment.Type = reader["TimeFrame"].ToString();

                                    listings.Add(payment);
                                }

                                if (checkBox1.Checked == true)
                                {

                                    DateTime newdate = listings[0].StartDate;
                                    Console.WriteLine(listings[0].Type);
                                    switch (Int32.Parse(listings[0].Type))
                                    {
                                        case 1:
                                            newdate = newdate.AddDays(7 * (1 + Int32.Parse(listings[0].Recurrance)));
                                            break;
                                        case 2:
                                            newdate = newdate.AddDays(14 * (1 + Int32.Parse(listings[0].Recurrance)));
                                            break;
                                        case 3:
                                            newdate = newdate.AddMonths(1 * (1 + Int32.Parse(listings[0].Recurrance)));
                                            break;
                                    }
                                    Console.WriteLine(newdate);
                                    string month, day = "";
                                    if (newdate.Month < 10)
                                        month = "0" + newdate.Month.ToString();
                                    else
                                        month = newdate.Month.ToString();
                                    if (newdate.Day < 10)
                                        day = "0" + newdate.Day.ToString();
                                    else
                                        day = newdate.Day.ToString();
                                    string fecha = newdate.Year.ToString() + "-" + month + "-" + day;
                                    ender = ", FechaFin = '" + fecha + "', RecurrentTimes = '" + (1 + Int32.Parse(listings[0].Recurrance));
                                    sql = "UPDATE pagos SET Payed = '" + (float.Parse(textBox4.Text) - float.Parse(textBox5.Text)) + "', Owed = '" + textBox5.Text + "', Recurrent = '" + recurrent + "', Active = '" + "1" + "' " + ender + "' where AccNum = " + textBox6.Text + ";";
                                }
                                else
                                {
                                    sql = "DELETE from Pagos where AccNum = '" + textBox6.Text + "';";
                                }
                            }
                            catch
                            {

                            }
                            finally
                            {
                                mysqlConnection2.Close();
                            }
                        }
                        else
                        {
                            sql = "UPDATE pagos SET Payed = '" + textBox4.Text + "', Owed = '" + textBox5.Text + "', Recurrent = '" + recurrent + "', Active = '" + active + "'" + " where AccNum = " + textBox6.Text + ";";
                        }
                        MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {

                    }
                    finally
                    {
                        MessageBox.Show("Elemento editado correctamente", "Tarea completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        button9_Click(sender, e);
                        ConsultarPayment();
                    }
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox6.Text = "";
            textBox5.Text = "";
            textBox4.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            textBox5.Enabled = false;
            textBox4.Enabled = false;
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            button9.Enabled = false;
            button4.Enabled = false;
            button3.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (textBox6.Text == "")
                check = true;
            if (check)
            {
                MessageBox.Show("Por favor rellene todos los campos antes de continuar", "Error en la tarea", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var confirmation = MessageBox.Show("¿Está seguro que quiere eliminar este elemento?", "Esta acción no puede revertirse", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmation == DialogResult.Yes)
                {
                    try
                    {
                        MySqlConnection mySqlConnection = new MySqlConnection(mysqlcon);
                        mySqlConnection.Open();
                        Console.WriteLine("Connection added");
                        string sql = "DELETE from pagos where AccNum = " + textBox6.Text;
                        MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {

                    }
                    finally
                    {
                        MessageBox.Show("Elemento eliminado correctamente", "Tarea completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        button9_Click(sender, e);
                        ConsultarPayment();
                    }

                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ConsultarTabla();
        }


        /// <summary>
        /// Esta hace la consulta para la tabla de cuentas registradas
        /// </summary>
        private void ConsultarTabla()
        {
            List<Cliente> values = new List<Cliente>();
            MySqlConnection mySqlConnection = new MySqlConnection(mysqlcon);
            try
            {
                string sql = "";
                mySqlConnection.Open();
                Console.WriteLine("Connection added");
                if (txtSearch.Text.Length == 0)
                {
                    sql = "SELECT * FROM clientes WHERE Activo = 1 ORDER BY Id DESC";
                }
                else
                {
                    string selected = "";
                    string finisher = "";
                    switch (comboBox1.SelectedIndex)
                    {
                        case 0:
                            if (!checkBox4.Checked)
                            {
                                selected = "AccNum LIKE '%";
                                finisher = "%'";
                            }
                            else
                                selected = "AccNum = ";
                            break;
                        case 1:
                            if (!checkBox4.Checked)
                            {
                                selected = "Name LIKE '%";
                                finisher = "%'";
                            }
                            else
                            {
                                selected = "Name = '";
                                finisher = "'";
                            }
                            break;
                        case 2:
                            if (!checkBox4.Checked)
                            {
                                selected = "LastName LIKE '%";
                                finisher = "%'";
                            }
                            else
                            {
                                selected = "LastName = '";
                                finisher = "'";
                            }
                            break;
                        case 3:
                            if (!checkBox4.Checked)
                            {
                                selected = "Tel LIKE '%";
                                finisher = "%'";
                            }
                            else
                                selected = "Tel = ";
                            break;
                        default:
                            if (!checkBox4.Checked)
                            {
                                selected = "AccNum LIKE '%";
                                finisher = "%'";
                            }
                            else
                                selected = "AccNum = ";
                            break;
                    }
                    sql = "SELECT * FROM clientes WHERE Activo = 1";
                    sql = sql + " AND " + selected + txtSearch.Text + finisher + " ORDER BY Id DESC";
                    Console.WriteLine(sql);
                }
                MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("11");
                    Cliente cliente = new Cliente();
                    cliente.AccNum = reader["AccNum"].ToString();
                    cliente.Name = reader["Name"].ToString();
                    cliente.LastName = reader["LastName"].ToString();
                    cliente.Tel = reader["Tel"].ToString();
                    //cliente.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                    //cliente.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                    values.Add(cliente);
                }


            }
            catch (Exception ex)
            {

            }
            finally
            {
                mySqlConnection.Close();
            }
            Inicializar();
            Console.Write(values.ToString());
            Console.Write("aaaa");
            foreach (var item in values)
            {
                DataRow row = table.NewRow();
                row["Nombre"] = item.Name;
                row["Apellido"] = item.LastName;
                row["Telefono"] = item.Tel;
                row["Numero de cuenta"] = item.AccNum.ToString();
                table.Rows.Add(row);


            }

        }
    }
}
