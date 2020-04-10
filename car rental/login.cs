using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace car_rental
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "admin")
            {
                this.Hide();
                startupPage start = new startupPage();
                start.Show();
            }
           else
            {
                MessageBox.Show("Incorrect Username or Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Clear();
            }
            
        }
    }
}
