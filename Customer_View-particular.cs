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
using static System.Net.Mime.MediaTypeNames;

namespace Blue_Collared
{
    public partial class Customer_View_particular : Form
    {
        public string imgid;
      
        public Customer_View_particular(string imageId)
        {
            InitializeComponent();
            imgid = imageId;
            fill();

        }
        SqlConnection con = new SqlConnection("server=HP;database=Blue_Collared;uid=sa;password=User123");

        public void fill()
        {
            con.Open();
            string query = "select * from Staff_reg where Sid='" + imgid + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr[2].ToString();
                textBox2.Text = dr[3].ToString();
                textBox3.Text = dr[4].ToString();
                textBox4.Text = dr[7].ToString();
                textBox5.Text = dr[8].ToString();
            }
            con.Close();
        }
        


        private void button1_Click(object sender, EventArgs e)
        {
            Customer_Book obj = new Customer_Book(imgid);
            obj.Show();
        }
    }
}
