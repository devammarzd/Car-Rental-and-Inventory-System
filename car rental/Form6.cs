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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            AutoCompletetxt();
        }

        public static OleDbConnection com = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Ammar\Car Rental\Vehicle Databse.accdb");

        private void button1_Click(object sender, EventArgs e)
        {
            Customer cusf = new Customer();
            cusf.Show();
            this.Hide();
        }

        void AutoCompletetxt()
        {
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            com.Open();
            OleDbCommand cd = new OleDbCommand();
            cd.Connection = com;
            string query = "Select name from Table2 where Rent_OR_Owned='Rent'";
            cd.CommandText = query;
            OleDbDataReader reader = cd.ExecuteReader();
            while (reader.Read())
            {
                string name=reader[0].ToString();
                coll.Add(name);
            }
            textBox1.AutoCompleteCustomSource = coll;
            com.Close();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
                com.Open();
                OleDbCommand cd = new OleDbCommand();
                cd.Connection = com;
                string query = "Select ID from Table2 where name='" + textBox1.Text + "'";
                cd.CommandText = query;
                OleDbDataReader reader = cd.ExecuteReader();
                while (reader.Read())
                {
                    textBox2.Text=reader[0].ToString();
                }
                com.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            com.Open();
            OleDbCommand com1 = new OleDbCommand("Delete from Table2 where name='" + textBox1.Text + "'", com);
            com1.ExecuteNonQuery();

            OleDbCommand up = com.CreateCommand();
            up.CommandType = CommandType.Text;
            string u = "update Table3 set Status = 'Available' where ID='" + textBox2.Text + "'";
            up.CommandText = u;
            up.ExecuteNonQuery();
            MessageBox.Show("Customer Deleted!");
            com.Close();
        }
    }
}
