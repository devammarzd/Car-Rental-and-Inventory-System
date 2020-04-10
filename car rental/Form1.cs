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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static OleDbConnection com = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C: \Users\AMMAR\source\repos\car rental\car rental\Vehicle Databse.accdb");
        //OleDbDataAdapter adap = new OleDbDataAdapter("Select * from Table1", con);
        //DataSet d1 = new DataSet("Table1");
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'vehicle_DatabseDataSet.Table1' table. You can move, or remove it, as needed.
            //this.table1TableAdapter.Fill(this.vehicle_DatabseDataSet.Table1);
       
            string[] data = new string[6];
            data[0] = "Plate number";
            data[1] = "Car name";
            data[2] = "Model";
            data[3] = "Category";
            data[4] = "Seats";
            data[5] = "Colour";
            comboBox1.Items.AddRange(data);
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            com.Open();
            OleDbCommand cmd = com.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select ID,CarName,Model,Category,Colour,Seats,Aircondition,Driver from Table1";
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
            //string selected_id = dataGridView1.CurrentRow.Cells["iDDataGridViewTextBoxColumn"].Value.ToString();
            //string selected_cname = dataGridView1.CurrentRow.Cells["carNameDataGridViewTextBoxColumn"].Value.ToString();
            // string selected_model = dataGridView1.CurrentRow.Cells["modelDataGridViewTextBoxColumn"].Value.ToString();
            //string selected_cat = dataGridView1.CurrentRow.Cells["categoryDataGridViewTextBoxColumn"].Value.ToString();
            // string selected_col = dataGridView1.CurrentRow.Cells["colourDataGridViewTextBoxColumn"].Value.ToString();
            // string selected_sts = dataGridView1.CurrentRow.Cells["seatsDataGridViewTextBoxColumn"].Value.ToString();
            // string selected_ac = dataGridView1.CurrentRow.Cells["airconditionDataGridViewTextBoxColumn"].Value.ToString();
            //string selected_driver = dataGridView1.CurrentRow.Cells["driverDataGridViewTextBoxColumn"].Value.ToString();
            //string delete_row= "delete * from Table1 where ID ='"+ selected_id + "' AND CarName = '"+ selected_cname + "' AND Model = '"+ selected_model + "' AND Category = '"+ selected_cat + "' AND Colour = '"+ selected_col+ "' AND Seats = '"+ selected_sts + "' AND Aircondition = '"+ selected_ac + "' AND Driver = '" + selected_driver + "'";
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(comboBox1.SelectedItem) == "Car name")
            {
                comboBox3.Items.Add("Hamza");
                com.Open();
                OleDbCommand cd = new OleDbCommand();
                cd.Connection = com;
                string query = "Select CarName from Table1";
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
                //comboBox2.Items.Clear();
                //comboBox2.Text = "Enter car plate number";
                com.Open();
                OleDbCommand cd = new OleDbCommand();
                cd.Connection = com;
                string query = "Select Plate number from Table1 ";
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
                //comboBox2.Items.Clear();
                com.Open();
                OleDbCommand cd = new OleDbCommand();
                cd.Connection = com;
                string query = "Select Model from Table1 ";
                cd.CommandText = query;
                OleDbDataReader reader = cd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox3.Items.Add(reader[0].ToString());
                }
                com.Close();
            }
            if (Convert.ToString(comboBox1.SelectedItem) == "Category")
            {
                //comboBox2.Items.Clear();
                com.Open();
                OleDbCommand cd = new OleDbCommand();
                cd.Connection = com;
                string query = "Select Category from Table1";
                cd.CommandText = query;
                OleDbDataReader reader = cd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox3.Items.Add(reader[0].ToString());
                }
                com.Close();
            }
            if (Convert.ToString(comboBox1.SelectedItem) == "Seats")
            {
                //comboBox2.Items.Clear();
                com.Open();
                OleDbCommand cd = new OleDbCommand();
                cd.Connection = com;
                string query = "Select Seats from Table1";
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
                //comboBox2.Items.Clear();
                com.Open();
                OleDbCommand cd = new OleDbCommand();
                cd.Connection = com;
                string query = "Select * from Table1";
                cd.CommandText = query;
                OleDbDataReader reader = cd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox3.Items.Add(reader[0].ToString());
                }
                com.Close();
            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(comboBox1.SelectedItem) == "Car name")
            {
                com.Open();
                OleDbDataAdapter da = new OleDbDataAdapter("Select ID,CarName,Model,Category,Colour,Seats,Aircondition,Driver from Table1 where CarName like '" + comboBox3.Text + "%'", com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                com.Close();
            }
            if (Convert.ToString(comboBox1.SelectedItem) == "Plate number")
            {


                com.Open();
                OleDbDataAdapter da = new OleDbDataAdapter("Select ID,CarName,Model,Category,Colour,Seats,Aircondition,Driver from Table1 where ID like '" + comboBox3.Text + "%'", com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                com.Close();
            }
            if (Convert.ToString(comboBox1.SelectedItem) == "Model")
            {
                com.Open();
                OleDbDataAdapter da = new OleDbDataAdapter("Select ID,CarName,Model,Category,Colour,Seats,Aircondition,Driver from Table1 where Model like '" + comboBox3.Text + "%'", com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                com.Close();
            }
            if (Convert.ToString(comboBox1.SelectedItem) == "Category")
            {
                com.Open();
                OleDbDataAdapter da = new OleDbDataAdapter("Select ID,CarName,Model,Category,Colour,Seats,Aircondition,Driver from Table1 where Category like '" + comboBox3.Text + "%'", com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                com.Close();
            }
            if (Convert.ToString(comboBox1.SelectedItem) == "Seats")
            {
                com.Open();
                OleDbDataAdapter da = new OleDbDataAdapter("Select ID,CarName,Model,Category,Colour,Seats,Aircondition,Driver from Table1 where Seats like '" + comboBox3.Text + "%'", com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                com.Close();
            }
            if (Convert.ToString(comboBox1.SelectedItem) == "Colour")
            {
                com.Open();
                OleDbDataAdapter da = new OleDbDataAdapter("Select ID,CarName,Model,Category,Colour,Seats,Aircondition,Driver from Table1 where Colour like '" + comboBox3.Text + "%'", com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                com.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
    
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           // com.Open();
           // OleDbCommand com1 = new OleDbCommand("Delete  from [userinfo] where ID=" & dataGridView1.Select(0).Cells(0).Value.ToString());

        }

        private void MainMenu_Click(object sender, EventArgs e)
        {
            startupPage st = new startupPage();
            st.Show();
            this.Hide();


        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}