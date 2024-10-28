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
    public partial class Admin_Staff_Aprove : Form
    {
        public Admin_Staff_Aprove()
        {
            InitializeComponent();
            fillgrid();
            fillcombo();
        }
        SqlConnection con = new SqlConnection("server=HP;database=Blue_Collared;uid=sa;password=User123");

        public void fillgrid()
        {
            con.Open();
            string query = "select * from Login where Usertype='Staff'";
            DataSet ds = new DataSet();
            SqlDataAdapter sqlda = new SqlDataAdapter(query, con);
            sqlda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            con.Close();
        }
        public void fillcombo()
        {
            con.Open();
            string query = "select * from Login where  Usertype='Staff'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "update Login set Status='Active' where Uid='" + comboBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Staff Approved");
            }
            con.Close();
            fillgrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "update Login set Status='InActive' where Uid='" + comboBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Staff not Approved");
            }
            con.Close();
            fillgrid();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            string query = "select * from Staff_reg where Uid='" + comboBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                string imagePath = dr[5].ToString();
                if (File.Exists(imagePath))
                {
                    pictureBox1.Image = new Bitmap(imagePath);
                }
                string imagePath2 = dr[6].ToString();
                if (File.Exists(imagePath2))
                {
                    pictureBox2.Image = new Bitmap(imagePath2);
                }
            }
            con.Close();
            
        }
    }
}
