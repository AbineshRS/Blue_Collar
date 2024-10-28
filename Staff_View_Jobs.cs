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
    public partial class Staff_View_Jobs : Form
    {
        public Staff_View_Jobs()
        {
            InitializeComponent();
            fillcombo();
            fillcombo2();
            fillgrid();
            fillgrid2();
        }
        SqlConnection con = new SqlConnection("server=HP;database=Blue_Collared;uid=sa;password=User123");


        public void fillgrid()
        {
            con.Open();
            string query = "select * from Book_Jobs where Uid='" + Program.sid + "' and Status='UnApprove'  ";
            DataSet ds = new DataSet();
            SqlDataAdapter sqlda = new SqlDataAdapter(query, con);
            sqlda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            con.Close();
        }
        public void fillgrid2()
        {
            con.Open();
            string query = "select * from Book_Jobs where Uid='" + Program.sid + "' and Status='Approve' ";
            DataSet ds = new DataSet();
            SqlDataAdapter sqlda = new SqlDataAdapter(query, con);
            sqlda.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0].DefaultView;
            con.Close();
        }
        public void fillcombo()
        {
            con.Open();
            string query = "select * from Book_Jobs where Uid='" + Program.sid + "'  and Status='UnApprove' ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());
            }
            con.Close();
        }
        public void fillcombo2()
        {
            con.Open();
            string query = "select * from Book_Jobs where Uid='" + Program.sid + "'  and Status='Approve' ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr[0].ToString());
            }
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "update Book_Jobs set Status='Approve' where Uid='" + Program.sid + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Approved");
                comboBox1.Items.Clear();
                comboBox1.Text = "";
            }
            con.Close();
            fillgrid();
            fillgrid2();
            fillcombo();
            fillcombo2();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "update Book_Jobs set Status='UnApprove' where Uid='" + Program.sid + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("UnApproved");
                comboBox2.Items.Clear();
                comboBox2.Text = "";
            }
            con.Close();
            fillgrid();
            fillgrid2();
            fillcombo();
            fillcombo2();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
