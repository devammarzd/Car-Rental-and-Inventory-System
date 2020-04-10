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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        public static OleDbConnection com = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Ammar\Car Rental\Vehicle Databse.accdb");

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            com.Open();
            OleDbCommand cmd = com.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select Table1.ID,Table1.CarName,Table1.Model,Table1.Colour,Table3.Company,Table3.Enginecc,Table3.Type,Table3.Rent,Table3.Status from Table1,Table3 where Table1.ID = Table3.ID AND Table1.ID='" + plateno.Text+"'";
            cmd.ExecuteNonQuery();
            OleDbDataAdapter adap = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            com.Close();
        }
       int z, x,y;

        private void back_Click(object sender, EventArgs e)
        {
            startupPage s = new startupPage();
            s.Show();
            this.Hide();
        }

        private void submit_Click(object sender, EventArgs e)
        {
            Customer frm = new Customer();
            frm.pass(plateno.Text,textBox1.Text,textBox2.Text);
            frm.Show();
            this.Hide();
        }

        private void plateno_TextChanged(object sender, EventArgs e)
        {

        }

        private void calculate_Click(object sender, EventArgs e)
        {
            com.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = com;
            string query = "select * from Table3 where ID='" + plateno.Text + "'";
            cmd.CommandText = query;

            OleDbDataReader reader = cmd.ExecuteReader();
            if ((Convert.ToInt16(days.Text)) < 30)
            {
                //OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    z = (Convert.ToInt16(reader["Rent"]));
                    x = (Convert.ToInt16(reader["Rent"])) * (Convert.ToInt16(days.Text));

                    textBox2.Text = "No Discount";
                    textBox1.Text = x.ToString();//hamza
                }
                
            }
            else if ((Convert.ToInt16(days.Text)) >= 30)
            {
                while (reader.Read())
                { 
                    z = (Convert.ToInt16(reader["Rent"]));
                x = (Convert.ToInt16(reader["Rent"])) * (Convert.ToInt16(days.Text));
                y = x* 90/100;

                textBox1.Text = x.ToString();
                textBox2.Text = y.ToString();
                }
            }
            com.Close();
        }
    }
}
