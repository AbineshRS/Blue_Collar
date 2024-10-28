using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blue_Collared
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("server=HP;database=Blue_Collared;uid=sa;password=User123");

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Admin" && textBox2.Text == "pwd")
            {
                Admin_HomePage obj = new Admin_HomePage();
                obj.Show();
            }
            else
            {
                con.Open();
                string query = "select * from Login where Username='" + textBox1.Text + "' and Password='" + textBox2.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr[3].ToString() == "Customer" && dr[4].ToString() == "Active")
                    {
                        Program.Cid = dr[0].ToString();
                        Customer_HomePage obj = new Customer_HomePage();
                        obj.Show();
                    }
                    else if (dr[3].ToString() == "Staff" && dr[4].ToString() == "InActive")
                    {
                        MessageBox.Show("You Are Not Approved by admin");
                    }
                    else if (dr[3].ToString() == "Staff" && dr[4].ToString() == "Active")
                    {
                        Program.sid = dr[0].ToString();
                        Staff_HomePage obj = new Staff_HomePage();
                        obj.Show();
                    }
                }
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void label3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you Staff ?", "Registrtion Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Staff_Register obj = new Staff_Register();
                obj.Show();
            }
            else
            {
                Customer_Register obj = new Customer_Register();
                obj.Show();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
