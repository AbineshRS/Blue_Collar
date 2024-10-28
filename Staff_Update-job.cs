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
    public partial class Staff_Update_job : Form
    {
        public Staff_Update_job()
        {
            InitializeComponent();
            combox();
        }
        SqlConnection con = new SqlConnection("server=HP;database=Blue_Collared;uid=sa;password=User123");
        public void combox()
        {
            con.Open();
            string query = "select * from Staff_reg where Uid='"+Program.sid+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());
            }
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            string query = "select * from Staff_reg where Sid='" + comboBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr[2].ToString();
                textBox2.Text = dr[7].ToString();
                textBox3.Text = dr[8].ToString();
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool error=false;
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                label4.Text = "required";
                label4.ForeColor= Color.Red;
                error= true;
            }
            else
            {
                label4.Text = "";
            }
            if(string.IsNullOrEmpty(textBox2.Text))
            {
                label7.Text= "required";
                label7.ForeColor= Color.Red;
                error= true;
            }
            else
            {
                label7.Text = "";
            }
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                label8.Text= "required";
                label8.ForeColor= Color.Red;
                error= true;
            }
            else
            {
                label8.Text = "";
            }
            if (!error)
            {
                con.Open();
                string qury = "update Staff_reg set Name='" + textBox1.Text + "' ,Experience='" + textBox2.Text + "',Salery='" + textBox3.Text + "'";
                SqlCommand cmd = new SqlCommand(qury, con);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Updated");
                }
                con.Close();
            }
            
        }
    }
}
