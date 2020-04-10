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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public static OleDbConnection com = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Ammar\Car Rental\Vehicle Databse.accdb");
        private void delete_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                com.Open();
                OleDbCommand com1 = new OleDbCommand("Delete from Table1 where ID='" + textBox1.Text + "'", com);
                com1.ExecuteNonQuery();

                OleDbCommand com2 = new OleDbCommand("Delete from Table3 where ID='" + textBox1.Text + "'", com);
                com2.ExecuteNonQuery();
                MessageBox.Show("Deleted");
                com.Close();
            }

            if (radioButton2.Checked)
            {
                com.Open();
                OleDbCommand com3 = new OleDbCommand("Delete from Table1 where ID='" + textBox1.Text + "'", com);
                com3.ExecuteNonQuery();

                OleDbCommand com4 = new OleDbCommand("Delete from Table4 where ID='" + textBox1.Text + "'", com);
                com4.ExecuteNonQuery();
                MessageBox.Show("Deleted");
                com.Close();
            }

            if (radioButton3.Checked)
            {
                com.Open();
                OleDbCommand com5 = new OleDbCommand("Delete from Table1 where ID='" + textBox1.Text + "'", com);
                com5.ExecuteNonQuery();

                OleDbCommand com6 = new OleDbCommand("Delete from Table5 where ID='" + textBox1.Text + "'", com);
                com6.ExecuteNonQuery();
                MessageBox.Show("Deleted");
                com.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
