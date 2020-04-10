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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public static OleDbConnection com = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Ammar\Car Rental\Vehicle Databse.accdb");
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void done_Click(object sender, EventArgs e)
        {

            if (radioButton1.Checked){ 
            com.Open();
            OleDbCommand han = com.CreateCommand();
            han.CommandType = CommandType.Text;
          
            string q= "insert into Table1(ID,CarName,Model,Colour) values('" + ID.Text + "','" + carname.Text +"','"+modelbox.Text+"','"+colour.Text+"')";
            han.CommandText = q;
            han.ExecuteNonQuery();

            OleDbCommand han1 = com.CreateCommand();
            han1.CommandType = CommandType.Text;

            string i = "insert into Table3(ID,Rent,Status,Enginecc,Company,Type) values('" + ID.Text + "','" + textBox2.Text + "','Available','" + engine.Text + "','" + comboBox1.Text + "','" + catbox.Text + "')";
            han1.CommandText = i;
            han1.ExecuteNonQuery();
            MessageBox.Show("Inserted");
            com.Close();
            }

            if (radioButton2.Checked)
            {
                com.Open();
                OleDbCommand han2 = com.CreateCommand();
                han2.CommandType = CommandType.Text;

                string i1 = "insert into Table1(ID,CarName,Model,Colour) values('" + ID.Text + "','" + carname.Text + "','" + modelbox.Text + "','" + colour.Text + "')";
                han2.CommandText = i1;
                han2.ExecuteNonQuery();

                OleDbCommand han3 = com.CreateCommand();
                han3.CommandType = CommandType.Text;

                string i2 = "insert into Table4(ID,Enginecc,Company,Type,Milage,Cost) values('" + ID.Text + "','" + engine.Text + "','" + comboBox1.Text + "','" + catbox.Text + "','" + textBox1.Text + "','" + textBox3.Text + "')";
                han3.CommandText = i2;
                han3.ExecuteNonQuery();
                MessageBox.Show("Inserted");
                com.Close();
            }

            if (radioButton3.Checked)
            {
                com.Open();
                OleDbCommand han4 = com.CreateCommand();
                han4.CommandType = CommandType.Text;

                string i3 = "insert into Table1(ID,CarName,Model,Colour) values('" + ID.Text + "','" + carname.Text + "','" + modelbox.Text + "','" + colour.Text + "')";
                han4.CommandText = i3;
                han4.ExecuteNonQuery();

                OleDbCommand han5 = com.CreateCommand();
                han5.CommandType = CommandType.Text;

                string i4 = "insert into Table5(ID,Enginecc,Company,Type,Distance,Cost) values('" + ID.Text + "','" + engine.Text + "','" + comboBox1.Text + "','" + catbox.Text + "','" + textBox4.Text + "','" + textBox3.Text + "')";
                han5.CommandText = i4;
                han5.ExecuteNonQuery();
                MessageBox.Show("Inserted");
                com.Close();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string[] data = new string[7];
            data[0] = "Toyota";
            data[1] = "Honda";
            data[2] = "Suzuki";
            data[3] = "Mercedes";
            data[4] = "BMW";
            data[5] = "Daihatsu";
            data[6] = "Nissan";
            comboBox1.Items.AddRange(data);
            string[] data2 = new string[10];
            data2[0] = "2010";
            data2[1] = "2011";
            data2[2] = "2012";
            data2[3] = "2013";
            data2[4] = "2014";
            data2[5] = "2015";
            data2[6] = "2016";
            data2[7] = "2017";
            data2[8] = "2018";
            data2[9] = "2019";
            modelbox.Items.AddRange(data2);
            string[] data3 = new string[4];
            data3[0] = "Sedan";
            data3[1] = "SUV";
            data3[2] = "Mini";
            data3[3] = "4WD";
            catbox.Items.AddRange(data3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 fq = new Form5();
            fq.Show();
            this.Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void modelbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox2.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox4.Enabled = false;
            textBox3.Enabled = true;
            textBox2.Enabled = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox4.Enabled = true;
            textBox3.Enabled = true;
            textBox2.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ID.Text = "";
            carname.Text = "";
            modelbox.Text = "";
            catbox.Text = "";
            colour.Text = "";
            engine.Text = "";
            comboBox1.Text = "";
            textBox1.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            textBox2.Text = "";
        }
    }
}
