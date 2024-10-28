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
    public partial class Customer_Book : Form
    {
        private string uid;

        public Customer_Book(string uid)
        {
            InitializeComponent();
            this.uid = uid;
            combo();

        }

        SqlConnection con = new SqlConnection("server=HP;database=Blue_Collared;uid=sa;password=User123");

        public void combo()
        {
            con.Open();
            string query = "select * from Staff_reg where Sid='" + uid + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox2.Text = dr[1].ToString();
                textBox3.Text = dr[6].ToString();
            }
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bool b = true;
            if(string.IsNullOrEmpty(textBox1.Text))
            {
                label6.Text = "Give your Address";
                label6.ForeColor=Color.Red;
                b= false;
            }
            else
            {
                label6.Text = "";
                
            }
            if (!b)
            {
                con.Open();
                string query2 = "select * from Book_Jobs where Status='UnApprove' and (Uid='" + textBox2.Text + "' and  Cid='" + Program.Cid + "') ";
                SqlCommand cmd2 = new SqlCommand(query2, con);
                SqlDataReader dr2 = cmd2.ExecuteReader();
                if (dr2.Read())
                {
                    MessageBox.Show("You have already booked");
                    dr2.Close();
                }
                else
                {
                    dr2.Close();
                    string query = "insert into Book_Jobs values('" + textBox2.Text + "','" + Program.Cid + "','" + dateTimePicker1.Text + "','" + textBox1.Text + "','" + textBox3.Text + "','UnApprove')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("You have booked");
                    }
                }
                con.Close();
            }
            

           

        }
    }
}
