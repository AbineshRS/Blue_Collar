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
    public partial class Customer_View_Status : Form
    {
        public Customer_View_Status()
        {
            InitializeComponent();
            combo();
        }
        SqlConnection con = new SqlConnection("server=HP;database=Blue_Collared;uid=sa;password=User123");
        public void combo()
        {
            con.Open();
            string query = "select * from Book_Jobs where Cid='" + Program.Cid + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[4].ToString());
            }
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            string query = "select * from Book_Jobs where Jobtype='" + comboBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                if (dr[5].ToString()== "Approve")
                {
                    MessageBox.Show("on the way");
                }
                else if(dr[5].ToString()== "UnApprove")
                {
                    MessageBox.Show("On Processing");
                }
            }
            con.Close();
            
        }
    }
}
