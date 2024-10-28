using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blue_Collared
{
    public partial class Customer_HomePage : Form
    {
        public Customer_HomePage()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Customer_Search obj = new Customer_Search();
            obj.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Customer_View_Status obj = new Customer_View_Status();
            obj.Show();
        }
    }
}
