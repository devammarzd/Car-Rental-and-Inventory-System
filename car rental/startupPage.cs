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
    public partial class startupPage : Form
    {
        public startupPage()
        {
            InitializeComponent();
        }

        private void startupPage_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f4 = new Form4();
            f4.Show();
           
        }

        private void Custom_Click(object sender, EventArgs e)
        {
            Customer form = new Customer();
            form.Show();
            form.Buy();
            this.Hide();
        }
    }
}
