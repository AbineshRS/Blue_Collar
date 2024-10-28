using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blue_Collared
{
    public partial class Customer_Register : Form
    {
        public Customer_Register()
        {
            InitializeComponent();
            Cid();
            Uid();
        }
        SqlConnection con = new SqlConnection("server=HP;database=Blue_Collared;uid=sa;password=User123");

        public void Cid()
        {
            con.Open();
            string query = "SELECT ISNULL(MAX(Cid), 100) + 1 AS NewCid FROM Customer_Reg";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr[0].ToString();
            }
            con.Close();
        }
        public void Uid()
        {
            con.Open();
            string query = "SELECT ISNULL (MAX(Uid),1000)+ 1 AS NewUid FROM Login";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox6.Text = dr[0].ToString();
            }
            con.Close();
        }

        private void Customer_Register_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool error = false;


            if (string.IsNullOrEmpty(textBox2.Text))
            {
                label11.Text = "Name must be entered";
                label11.ForeColor = Color.Red;
                error = true;
            }
            else
            {
                label11.Text = "";
            }


            if (string.IsNullOrEmpty(textBox3.Text))
            {
                label12.Text = "Age is required";
                label12.ForeColor = Color.Red;
                error = true;
            }
            else if (textBox3.Text.Length != 2 || !textBox3.Text.All(char.IsDigit))
            {
                label12.Text = "Age must be 2 digits";
                label12.ForeColor = Color.Red;
                error = true;
            }
            else
            {
                label12.Text = "";
            }


            if (string.IsNullOrEmpty(textBox4.Text))
            {
                label13.Text = "Mobile number is required";
                label13.ForeColor = Color.Red;
                error = true;
            }
            else if (textBox4.Text.Length != 11 || !textBox4.Text.All(char.IsDigit))
            {
                label13.Text = "Mobile number must be 11 digits";
                label13.ForeColor = Color.Red;
                error = true;
            }
            else
            {
                label13.Text = "";
            }


            if (string.IsNullOrEmpty(textBox5.Text))
            {
                label14.Text = "Address is required";
                label14.ForeColor = Color.Red;
                error = true;
            }
            else
            {
                label14.Text = "";
            }
            if (string.IsNullOrEmpty(textBox7.Text))
            {
                label16.Text = "Username is required";
                label16.ForeColor = Color.Red;
                error = true;
            }
            else
            {
                label16.Text = "";
            }
            if (string.IsNullOrEmpty(textBox8.Text))
            {
                label15.Text = "Password is required";
                label15.ForeColor = Color.Red;
                error = true;
            }
            else if (textBox8.Text.Length < 8)
            {
                label15.Text = "Password must be at least 8 characters long";
                label15.ForeColor = Color.Red;
                error = true;
            }
            else if (!textBox8.Text.Any(char.IsLetter) || textBox8.Text.Any(char.IsDigit))
            {
                label15.Text = "Password must contain both letters and numbers";
                label15.ForeColor = Color.Red;
                error = true;
            }
            else
            {
                label15.Text = "";
            }
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                label17.Text = "select gender";
                label17.ForeColor = Color.Red;
                error = true;
            }
            else
            {
                label17.Text = "";
            }


            con.Open();


            string query2 = "SELECT * FROM Login WHERE (Username = '" + textBox7.Text + "' OR Password = '" + textBox8.Text + "') AND Usertype = 'Customer'";
            SqlCommand cmd2 = new SqlCommand(query2, con);

            SqlDataReader dr = cmd2.ExecuteReader();

            if (dr.Read())
            {

                if (string.IsNullOrEmpty(textBox7.Text))
                {
                    label16.Text = "Username is required";
                    label16.ForeColor = Color.Red;
                    error = true;
                }
                else if (textBox7.Text == dr["Username"].ToString())
                {
                    label16.Text = "Username already taken";
                    label16.ForeColor = Color.Red;
                    error = true;
                }
                else
                {
                    label16.Text = "";
                }


                if (string.IsNullOrEmpty(textBox8.Text))
                {
                    label15.Text = "Password is required";
                    label15.ForeColor = Color.Red;
                    error = true;
                }
                else if (textBox8.Text == dr["Password"].ToString())
                {
                    label15.Text = "Password already taken";
                    label15.ForeColor = Color.Red;
                    error = true;
                }
                else
                {
                    label15.Text = "";
                }
            }
            dr.Close();


            if (!error)
            {

                string queryCustomer = "INSERT INTO Customer_Reg VALUES ('" + textBox1.Text + "', '" + textBox6.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + comboBox1.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "')";
                SqlCommand cmdCustomer = new SqlCommand(queryCustomer, con);


                if (cmdCustomer.ExecuteNonQuery() > 0)
                {

                    string queryLogin = "INSERT INTO Login VALUES ('" + textBox6.Text + "', '" + textBox7.Text + "', '" + textBox8.Text + "', 'Customer', 'Active')";
                    SqlCommand cmdLogin = new SqlCommand(queryLogin, con);


                    if (cmdLogin.ExecuteNonQuery() > 0)
                    {

                        Login ob = new Login();
                        ob.Show();
                    }
                }
            }


            con.Close();
        }


        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            label15.Text = "";
        }
    }
}
