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
    public partial class Staff_HomePage : Form
    {
        public Staff_HomePage()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Staff_View_Jobs obj = new Staff_View_Jobs();
            obj.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Staff_Update_job obj = new Staff_Update_job();
            obj.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
        }
    }
}
