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
    public partial class Admin_ViewCustomers : Form
    {
        public Admin_ViewCustomers()
        {
            InitializeComponent();
            fillgrid();
        }
        SqlConnection con = new SqlConnection("server=HP;database=Blue_Collared;uid=sa;password=User123");

        public void fillgrid()
        {
            con.Open();
            string query = "select * from Customer_Reg";
            DataSet ds = new DataSet();
            SqlDataAdapter sqlda = new SqlDataAdapter(query, con);
            sqlda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            con.Close();
        }
    }
}
