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
    public partial class Customer : Form
    {
        string b;
        public Customer()
        {
            InitializeComponent();
        }

        public static OleDbConnection com = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Ammar\Car Rental\Vehicle Databse.accdb");

        private void Customer_Load(object sender, EventArgs e)
        {

        }

        public void pass(string plate,string amount,string disamount)
        {
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            textBox6.Text = plate;
            textBox7.Text = "Rent";
            if (disamount == "No Discount")
            {
                textBox8.Text = amount;
            }
            else
            {
                textBox8.Text = disamount;
            }
        }


        public void Buy()
        {
            textBox7.Text = "Owned";

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            com.Open();
            OleDbCommand cd = new OleDbCommand();
            cd.Connection = com;
            string query = "select Cost from Table4 where ID='" + textBox6.Text + "'";
            cd.CommandText = query;
            OleDbDataReader reader = cd.ExecuteReader();
            while (reader.Read())
            {
                textBox8.Text = reader[0].ToString();
            }
            com.Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            com.Open();
            OleDbCommand cd = new OleDbCommand();
            cd.Connection = com;
            string query = "select Cost from Table5 where ID='" + textBox6.Text + "'";
            cd.CommandText = query;
            OleDbDataReader reader = cd.ExecuteReader();
            while (reader.Read())
            {
                textBox8.Text = reader[0].ToString();
            }
            com.Close();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Close();
            startupPage fm = new startupPage();
            fm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            com.Open();

            if (textBox7.Text == "Rent")
            {
                OleDbCommand up = com.CreateCommand();
                up.CommandType = CommandType.Text;

                string u = "update Table3 set Status = 'NOT Available' where ID='" + textBox6.Text + "'";
                up.CommandText = u;
                up.ExecuteNonQuery();
            }

            OleDbCommand han = com.CreateCommand();
            han.CommandType = CommandType.Text;

            string q = "Insert into Table2(Name,Phone,Address,Occupation,Email,ID,Rent_OR_Owned) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')";
            han.CommandText = q;
            han.ExecuteNonQuery();
            MessageBox.Show("Thankyou for shopping!");
            com.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
            this.Hide();
        }
    }
}
