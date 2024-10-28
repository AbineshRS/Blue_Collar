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
    public partial class Admin_view_Job_Details : Form
    {
        public Admin_view_Job_Details()
        {
            InitializeComponent();
            fillgrid();
            fillcombo();
        }
        SqlConnection con = new SqlConnection("server=HP;database=Blue_Collared;uid=sa;password=User123");

        public void fillgrid()
        {

            con.Open();
            string query = "select JobType,JobDetails from Add_Jobs ";
            DataSet ds = new DataSet();
            SqlDataAdapter sqlda = new SqlDataAdapter(query, con);
            sqlda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            con.Close();
        }
        public void fillcombo()
        {
            con.Open();
            string query = "select JobType from Add_Jobs";
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
            string query = "select JobType,JobDetails from Add_Jobs where JobType='" + comboBox1.Text + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter sqlda = new SqlDataAdapter(query, con);
            sqlda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            con.Close();

            con.Open();
            string query2 = "select * from Add_Jobs where JobType='" + comboBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(query2, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string imagePath = dr[3].ToString();
                if (File.Exists(imagePath))
                {
                    pictureBox1.Image = new Bitmap(imagePath);
                }

            }
            con.Close();

        }
    }
}
