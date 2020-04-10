using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.OleDb;

namespace car_rental
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        public static OleDbConnection com = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Ammar\Car Rental\Vehicle Databse.accdb");

        private void button2_Click(object sender, EventArgs e)
        {
            startupPage st = new startupPage();
            st.Show();
            this.Hide();

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'vehicle_DatabseDataSet.Table2' table. You can move, or remove it, as needed.
            //this.table2TableAdapter.Fill(this.vehicle_DatabseDataSet.Table2);
            // TODO: This line of code loads data into the 'vehicle_DatabseDataSet.Table1' table. You can move, or remove it, as needed.
            //this.table1TableAdapter.Fill(this.vehicle_DatabseDataSet.Table1);
            // TODO: This line of code loads data into the 'vehicle_DatabseDataSet.Table1' table. You can move, or remove it, as needed.
            //this.table1TableAdapter.Fill(this.vehicle_DatabseDataSet.Table1);

/*            string[] data = new string[7];
            data[0] = "Plate number";
            data[1] = "Car name";
            data[2] = "Model";
            data[3] = "Colour";
            data[4] = "Engine cc";
            data[5] = "Company";
            data[6] = "Type";
            comboBox1.Items.AddRange(data);

            if (radioButton1.Checked)
            {
                string[] data1 = new string[2];
                data1[0] = "Rent";
                data1[1] = "Status";
                comboBox1.Items.AddRange(data1);
            }
            if (radioButton2.Checked)
            {
                string[] data2 = new string[1];
                data2[0] = "Milage";
                comboBox1.Items.AddRange(data2);
            }
            if (radioButton3.Checked)
            {
                string[] data3 = new string[1];
                data3[0] = "Distance";
                comboBox1.Items.AddRange(data3);
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            com.Open();
            OleDbCommand cmd = com.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select ID,CarName,Model,Colour from Table1";
            cmd.ExecuteNonQuery();
            OleDbDataAdapter adap = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            com.Close();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (Convert.ToString(comboBox1.SelectedItem) == "Car name")
                {
                    comboBox3.Items.Clear();
                    //comboBox3.Items.Add("Hamza");
                    com.Open();
                    OleDbCommand cd = new OleDbCommand();
                    cd.Connection = com;
                    string query = "Select Table1.CarName from Table1,Table3 where Table1.ID=Table3.ID";
                    cd.CommandText = query;
                    OleDbDataReader reader = cd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox3.Items.Add(reader[0].ToString());
                    }
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Plate number")
                {
                    comboBox3.Items.Clear();
                    //comboBox2.Text = "Enter car plate number";
                    com.Open();
                    OleDbCommand cd = new OleDbCommand();
                    cd.Connection = com;
                    string query = "Select Table1.ID from Table1,Table3 where Table1.ID=Table3.ID";
                    cd.CommandText = query;
                    OleDbDataReader reader = cd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox3.Items.Add(reader[0].ToString());
                    }
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Model")
                {
                    comboBox3.Items.Clear();
                    com.Open();
                    OleDbCommand cd = new OleDbCommand();
                    cd.Connection = com;
                    string query = "Select Table1.Model from Table1,Table3 where Table1.ID=Table3.ID";
                    cd.CommandText = query;
                    OleDbDataReader reader = cd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox3.Items.Add(reader[0].ToString());
                    }
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Type")
                {
                    comboBox3.Items.Clear();
                    com.Open();
                    OleDbCommand cd = new OleDbCommand();
                    cd.Connection = com;
                    string query = "Select Type from Table3";
                    cd.CommandText = query;
                    OleDbDataReader reader = cd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox3.Items.Add(reader[0].ToString());
                    }
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Engine cc")
                {
                    comboBox3.Items.Clear();
                    com.Open();
                    OleDbCommand cd = new OleDbCommand();
                    cd.Connection = com;
                    string query = "Select Enginecc from Table3";
                    cd.CommandText = query;
                    OleDbDataReader reader = cd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox3.Items.Add(reader[0].ToString());
                    }
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Company")
                {
                    comboBox3.Items.Clear();
                    com.Open();
                    OleDbCommand cd = new OleDbCommand();
                    cd.Connection = com;
                    string query = "Select Company from Table3";
                    cd.CommandText = query;
                    OleDbDataReader reader = cd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox3.Items.Add(reader[0].ToString());
                    }
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Colour")
                {
                    comboBox3.Items.Clear();
                    com.Open();
                    OleDbCommand cd = new OleDbCommand();
                    cd.Connection = com;
                    string query = "Select Table1.Colour from Table1,Table3 where Table1.ID=Table3.ID";
                    cd.CommandText = query;
                    OleDbDataReader reader = cd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox3.Items.Add(reader[0].ToString());
                    }
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Rent")
                {
                    comboBox3.Items.Clear();
                    com.Open();
                    OleDbCommand cd = new OleDbCommand();
                    cd.Connection = com;
                    string query = "Select Rent from Table3";
                    cd.CommandText = query;
                    OleDbDataReader reader = cd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox3.Items.Add(reader[0].ToString());
                    }
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Status")
                {
                    comboBox3.Items.Clear();
                    com.Open();
                    OleDbCommand cd = new OleDbCommand();
                    cd.Connection = com;
                    string query = "Select Status from Table3";
                    cd.CommandText = query;
                    OleDbDataReader reader = cd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox3.Items.Add(reader[0].ToString());
                    }
                    com.Close();
                }
            }

            if(radioButton2.Checked)
            {
                if (Convert.ToString(comboBox1.SelectedItem) == "Car name")
                {
                    comboBox3.Items.Clear();
                    //comboBox3.Items.Add("Hamza");
                    com.Open();
                    OleDbCommand cd = new OleDbCommand();
                    cd.Connection = com;
                    string query = "Select Table1.CarName from Table1,Table4 where Table1.ID=Table4.ID";
                    cd.CommandText = query;
                    OleDbDataReader reader = cd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox3.Items.Add(reader[0].ToString());
                    }
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Plate number")
                {
                    comboBox3.Items.Clear();
                    //comboBox2.Text = "Enter car plate number";
                    com.Open();
                    OleDbCommand cd = new OleDbCommand();
                    cd.Connection = com;
                    string query = "Select Table1.ID from Table1,Table4 where Table1.ID=Table4.ID";
                    cd.CommandText = query;
                    OleDbDataReader reader = cd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox3.Items.Add(reader[0].ToString());
                    }
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Model")
                {
                    comboBox3.Items.Clear();
                    com.Open();
                    OleDbCommand cd = new OleDbCommand();
                    cd.Connection = com;
                    string query = "Select Table1.Model from Table1,Table4 where Table1.ID=Table4.ID";
                    cd.CommandText = query;
                    OleDbDataReader reader = cd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox3.Items.Add(reader[0].ToString());
                    }
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Type")
                {
                    comboBox3.Items.Clear();
                    com.Open();
                    OleDbCommand cd = new OleDbCommand();
                    cd.Connection = com;
                    string query = "Select Type from Table4";
                    cd.CommandText = query;
                    OleDbDataReader reader = cd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox3.Items.Add(reader[0].ToString());
                    }
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Engine cc")
                {
                    comboBox3.Items.Clear();
                    com.Open();
                    OleDbCommand cd = new OleDbCommand();
                    cd.Connection = com;
                    string query = "Select Enginecc from Table4";
                    cd.CommandText = query;
                    OleDbDataReader reader = cd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox3.Items.Add(reader[0].ToString());
                    }
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Company")
                {
                    comboBox3.Items.Clear();
                    com.Open();
                    OleDbCommand cd = new OleDbCommand();
                    cd.Connection = com;
                    string query = "Select Company from Table4";
                    cd.CommandText = query;
                    OleDbDataReader reader = cd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox3.Items.Add(reader[0].ToString());
                    }
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Colour")
                {
                    comboBox3.Items.Clear();
                    com.Open();
                    OleDbCommand cd = new OleDbCommand();
                    cd.Connection = com;
                    string query = "Select Table1.Colour from Table1,Table4 where Table1.ID=Table4.ID";
                    cd.CommandText = query;
                    OleDbDataReader reader = cd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox3.Items.Add(reader[0].ToString());
                    }
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Milage")
                {
                    comboBox3.Items.Clear();
                    com.Open();
                    OleDbCommand cd = new OleDbCommand();
                    cd.Connection = com;
                    string query = "Select Milage from Table4";
                    cd.CommandText = query;
                    OleDbDataReader reader = cd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox3.Items.Add(reader[0].ToString());
                    }
                    com.Close();
                }
            }

            if (radioButton3.Checked)
            {
                if (Convert.ToString(comboBox1.SelectedItem) == "Car name")
                {
                    comboBox3.Items.Clear();
                    //comboBox3.Items.Add("Hamza");
                    com.Open();
                    OleDbCommand cd = new OleDbCommand();
                    cd.Connection = com;
                    string query = "Select Table1.CarName from Table1,Table5 where Table1.ID=Table5.ID";
                    cd.CommandText = query;
                    OleDbDataReader reader = cd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox3.Items.Add(reader[0].ToString());
                    }
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Plate number")
                {
                    comboBox3.Items.Clear();
                    //comboBox2.Text = "Enter car plate number";
                    com.Open();
                    OleDbCommand cd = new OleDbCommand();
                    cd.Connection = com;
                    string query = "Select Table1.ID from Table1,Table5 where Table1.ID=Table5.ID";
                    cd.CommandText = query;
                    OleDbDataReader reader = cd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox3.Items.Add(reader[0].ToString());
                    }
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Model")
                {
                    comboBox3.Items.Clear();
                    com.Open();
                    OleDbCommand cd = new OleDbCommand();
                    cd.Connection = com;
                    string query = "Select Table1.Model from Table1,Table5 where Table1.ID=Table5.ID";
                    cd.CommandText = query;
                    OleDbDataReader reader = cd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox3.Items.Add(reader[0].ToString());
                    }
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Type")
                {
                    comboBox3.Items.Clear();
                    com.Open();
                    OleDbCommand cd = new OleDbCommand();
                    cd.Connection = com;
                    string query = "Select Type from Table5";
                    cd.CommandText = query;
                    OleDbDataReader reader = cd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox3.Items.Add(reader[0].ToString());
                    }
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Engine cc")
                {
                    comboBox3.Items.Clear();
                    com.Open();
                    OleDbCommand cd = new OleDbCommand();
                    cd.Connection = com;
                    string query = "Select Enginecc from Table5";
                    cd.CommandText = query;
                    OleDbDataReader reader = cd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox3.Items.Add(reader[0].ToString());
                    }
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Company")
                {
                    comboBox3.Items.Clear();
                    com.Open();
                    OleDbCommand cd = new OleDbCommand();
                    cd.Connection = com;
                    string query = "Select Company from Table5";
                    cd.CommandText = query;
                    OleDbDataReader reader = cd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox3.Items.Add(reader[0].ToString());
                    }
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Colour")
                {
                    comboBox3.Items.Clear();
                    com.Open();
                    OleDbCommand cd = new OleDbCommand();
                    cd.Connection = com;
                    string query = "Select Table1.Colour from Table1,Table5 where Table1.ID=Table5.ID";
                    cd.CommandText = query;
                    OleDbDataReader reader = cd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox3.Items.Add(reader[0].ToString());
                    }
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Distance")
                {
                    comboBox3.Items.Clear();
                    com.Open();
                    OleDbCommand cd = new OleDbCommand();
                    cd.Connection = com;
                    string query = "Select Distance from Table5";
                    cd.CommandText = query;
                    OleDbDataReader reader = cd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox3.Items.Add(reader[0].ToString());
                    }
                    com.Close();
                }
            }
        }



        private void search_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (Convert.ToString(comboBox1.SelectedItem) == "Car name")
                {
                    com.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter("Select Table1.ID,Table1.CarName,Table1.Model,Table1.Colour,Table3.Company,Table3.Enginecc,Table3.Type,Table3.Rent,Table3.Status from Table1,Table3 where Table1.ID = Table3.ID AND Table1.CarName like '" + comboBox3.Text + "%'", com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Plate number")
                {


                    com.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter("Select Table1.ID,Table1.CarName,Table1.Model,Table1.Colour,Table3.Company,Table3.Enginecc,Table3.Type,Table3.Rent,Table3.Status from Table1,Table3 where Table1.ID = Table3.ID AND Table1.ID like '" + comboBox3.Text + "%'", com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Model")
                {
                    com.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter("Select Table1.ID,Table1.CarName,Table1.Model,Table1.Colour,Table3.Company,Table3.Enginecc,Table3.Type,Table3.Rent,Table3.Status from Table1,Table3 where Table1.ID = Table3.ID AND Table1.Model like '" + Convert.ToDecimal(comboBox3.Text) + "%'", com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Type")
                {
                    com.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter("Select Table1.ID,Table1.CarName,Table1.Model,Table1.Colour,Table3.Company,Table3.Enginecc,Table3.Type,Table3.Rent,Table3.Status from Table1,Table3 where Table1.ID = Table3.ID AND Table3.Type like '" + comboBox3.Text + "%'", com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Engine cc")
                {
                    com.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter("Select Table1.ID,Table1.CarName,Table1.Model,Table1.Colour,Table3.Company,Table3.Enginecc,Table3.Type,Table3.Rent,Table3.Status from Table1,Table3 where Table1.ID = Table3.ID AND Table3.Enginecc like '" + Convert.ToDecimal(comboBox3.Text) + "%'", com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Company")
                {
                    com.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter("Select Table1.ID,Table1.CarName,Table1.Model,Table1.Colour,Table3.Company,Table3.Enginecc,Table3.Type,Table3.Rent,Table3.Status from Table1,Table3 where Table1.ID = Table3.ID AND Table3.Company like '" + comboBox3.Text + "%'", com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Rent")
                {
                    com.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter("Select Table1.ID,Table1.CarName,Table1.Model,Table1.Colour,Table3.Company,Table3.Enginecc,Table3.Type,Table3.Rent,Table3.Status from Table1,Table3 where Table1.ID = Table3.ID AND Table3.Rent like '" + comboBox3.Text + "%'", com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Status")
                {
                    com.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter("Select Table1.ID,Table1.CarName,Table1.Model,Table1.Colour,Table3.Company,Table3.Enginecc,Table3.Type,Table3.Rent,Table3.Status from Table1,Table3 where Table1.ID = Table3.ID AND Table3.Status like '" + comboBox3.Text + "%'", com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Colour")
                {
                    com.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter("Select Table1.ID,Table1.CarName,Table1.Model,Table1.Colour,Table3.Company,Table3.Enginecc,Table3.Type,Table3.Rent,Table3.Status from Table1,Table3 where Table1.ID = Table3.ID AND Table1.Colour like '" + comboBox3.Text + "%'", com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    com.Close();
                }
            }

            if (radioButton2.Checked)
            {
                if (Convert.ToString(comboBox1.SelectedItem) == "Car name")
                {
                    com.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter("Select Table1.ID,Table1.CarName,Table1.Model,Table1.Colour,Table4.Company,Table4.Enginecc,Table4.Type,Table4.Milage,Table4.Cost from Table1,Table4 where Table1.ID = Table4.ID AND Table1.CarName like '" + comboBox3.Text + "%'", com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Plate number")
                {


                    com.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter("Select Table1.ID,Table1.CarName,Table1.Model,Table1.Colour,Table4.Company,Table4.Enginecc,Table4.Type,Table4.Milage,Table4.Cost from Table1,Table4 where Table1.ID = Table4.ID AND Table1.ID like '" + comboBox3.Text + "%'", com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Model")
                {
                    com.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter("Select Table1.ID,Table1.CarName,Table1.Model,Table1.Colour,Table4.Company,Table4.Enginecc,Table4.Type,Table4.Milage,Table4.Cost from Table1,Table4 where Table1.ID = Table4.ID AND Table1.Model like '" + Convert.ToDecimal(comboBox3.Text) + "%'", com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Type")
                {
                    com.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter("Select Table1.ID,Table1.CarName,Table1.Model,Table1.Colour,Table4.Company,Table4.Enginecc,Table4.Type,Table4.Milage,Table4.Cost from Table1,Table4 where Table1.ID = Table4.ID AND Table4.Type like '" + comboBox3.Text + "%'", com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Engine cc")
                {
                    com.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter("Select Table1.ID,Table1.CarName,Table1.Model,Table1.Colour,Table4.Company,Table4.Enginecc,Table4.Type,Table4.Milage,Table4.Cost from Table1,Table4 where Table1.ID = Table4.ID AND Table4.Enginecc like '" + Convert.ToDecimal(comboBox3.Text) + "%'", com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Company")
                {
                    com.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter("Select Table1.ID,Table1.CarName,Table1.Model,Table1.Colour,Table4.Company,Table4.Enginecc,Table4.Type,Table4.Milage,Table4.Cost from Table1,Table4 where Table1.ID = Table4.ID AND Table4.Company like '" + comboBox3.Text + "%'", com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Milage")
                {
                    com.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter("Select Table1.ID,Table1.CarName,Table1.Model,Table1.Colour,Table4.Company,Table4.Enginecc,Table4.Type,Table4.Milage,Table4.Cost from Table1,Table4 where Table1.ID = Table4.ID AND Table4.Milage like '" + Convert.ToDecimal(comboBox3.Text) + "%'", com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Colour")
                {
                    com.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter("Select Table1.ID,Table1.CarName,Table1.Model,Table1.Colour,Table4.Company,Table4.Enginecc,Table4.Type,Table4.Milage,Table4.Cost from Table1,Table4 where Table1.ID = Table4.ID AND Table1.Colour like '" + Convert.ToDecimal(comboBox3.Text) + "%'", com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    com.Close();
                }
            }

            else if (radioButton3.Checked)
            {
                if (Convert.ToString(comboBox1.SelectedItem) == "Car name")
                {
                    com.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter("Select Table1.ID,Table1.CarName,Table1.Model,Table1.Colour,Table5.Company,Table5.Enginecc,Table5.Type,Table5.Distance,Table5.Cost from Table1,Table5 where Table1.ID = Table5.ID AND Table1.CarName like '" + comboBox3.Text + "%'", com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Plate number")
                {
                    com.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter("Select Table1.ID,Table1.CarName,Table1.Model,Table1.Colour,Table5.Company,Table5.Enginecc,Table5.Type,Table5.Distance,Table5.Cost from Table1,Table5 where Table1.ID = Table5.ID AND ID like '" + comboBox3.Text + "%'", com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Model")
                {
                    com.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter("Select Table1.ID,Table1.CarName,Table1.Model,Table1.Colour,Table5.Company,Table5.Enginecc,Table5.Type,Table5.Distance,Table5.Cost from Table1,Table5 where Table1.ID = Table5.ID AND Table1.Model like '" + Convert.ToDecimal(comboBox3.Text) + "%'", com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Type")
                {
                    com.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter("Select Table1.ID,Table1.CarName,Table1.Model,Table1.Colour,Table5.Company,Table5.Enginecc,Table5.Type,Table5.Distance,Table5.Cost from Table1,Table5 where Table1.ID = Table5.ID AND Table5.Type like '" + comboBox3.Text + "%'", com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Engine cc")
                {
                    com.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter("Select Table1.ID,Table1.CarName,Table1.Model,Table1.Colour,Table5.Company,Table5.Enginecc,Table5.Type,Table5.Distance,Table5.Cost from Table1,Table5 where Table1.ID = Table5.ID AND Table5.Enginecc like '" + Convert.ToDecimal(comboBox3.Text) + "%'", com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Company")
                {
                    com.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter("Select Table1.ID,Table1.CarName,Table1.Model,Table1.Colour,Table5.Company,Table5.Enginecc,Table5.Type,Table5.Distance,Table5.Cost from Table1,Table5 where Table1.ID = Table5.ID AND Table5.Company like '" + comboBox3.Text + "%'", com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Distance")
                {
                    com.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter("Select Table1.ID,Table1.CarName,Table1.Model,Table1.Colour,Table5.Company,Table5.Enginecc,Table5.Type,Table5.Distance,Table5.Cost from Table1,Table5 where Table1.ID = Table5.ID AND Table5.Distance like '" + Convert.ToDecimal(comboBox3.Text) + "%'", com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    com.Close();
                }
                if (Convert.ToString(comboBox1.SelectedItem) == "Colour")
                {
                    com.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter("Select Table1.ID,Table1.CarName,Table1.Model,Table1.Colour,Table5.Company,Table5.Enginecc,Table5.Type,Table5.Distance,Table5.Cost from Table1,Table5 where Table1.ID = Table5.ID AND Table1.Colour like '" + comboBox3.Text + "%'", com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    com.Close();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            string[] data = new string[9];
            data[0] = "Plate number";
            data[1] = "Car name";
            data[2] = "Model";
            data[3] = "Colour";
            data[4] = "Engine cc";
            data[5] = "Company";
            data[6] = "Type";
            data[7] = "Rent";
            data[8] = "Status";
            comboBox1.Items.AddRange(data);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            string[] data1 = new string[8];
            data1[0] = "Plate number";
            data1[1] = "Car name";
            data1[2] = "Model";
            data1[3] = "Colour";
            data1[4] = "Engine cc";
            data1[5] = "Company";
            data1[6] = "Type";
            data1[7] = "Milage";
            comboBox1.Items.AddRange(data1);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            string[] data2 = new string[8];
            data2[0] = "Plate number";
            data2[1] = "Car name";
            data2[2] = "Model";
            data2[3] = "Colour";
            data2[4] = "Engine cc";
            data2[5] = "Company";
            data2[6] = "Type";
            data2[7] = "Distance";
            comboBox1.Items.AddRange(data2);
        }
    }
}
