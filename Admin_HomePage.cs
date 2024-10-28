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
    public partial class Admin_HomePage : Form
    {
        public Admin_HomePage()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Admin_ViewCustomers obj = new Admin_ViewCustomers();
            obj.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Admin_ViewStaff obj = new Admin_ViewStaff();
            obj.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Admin_Staff_Aprove obj = new Admin_Staff_Aprove();
            obj.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Admin_Add_job_types obj = new Admin_Add_job_types();
            obj.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Admin_view_Job_Details obj = new Admin_view_Job_Details();
            obj.Show();
        }
    }
}
