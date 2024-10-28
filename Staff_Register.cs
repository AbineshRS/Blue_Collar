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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Blue_Collared
{
    public partial class Staff_Register : Form
    {
        public Staff_Register()
        {
            InitializeComponent();
            Sid();
            Uid();
            addjob();
        }
        SqlConnection con = new SqlConnection("server=HP;database=Blue_Collared;uid=sa;password=User123");

        public void Sid()
        {
            con.Open();
            string query = "SELECT ISNULL(MAX(Sid), 100) + 1 AS NewCid FROM Staff_Reg";
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
                textBox7.Text = dr[0].ToString();
            }
            con.Close();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(open.FileName);
                textBox4.Text = open.FileName;

            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            bool error = false;
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                label7.Text = "name is required";
                label7.ForeColor = Color.Red;
                error = true;
            }
            else
            {
                label7.Text = "";
            }
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                label15.Text = "Age is required";
                label15.ForeColor = Color.Red;
                error = true;
            }
            else if (textBox3.Text.Length != 2 || !textBox3.Text.All(char.IsDigit))
            {
                label15.Text = "Age must be 2 digits ";
                label15.ForeColor = Color.Red;  
                error = true;
            }
            else
            {
                label15.Text = "";
            }
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                label16.Text = "select Gender";
                label16.ForeColor = Color.Red;
                error = true;
            }
            else
            {
                label16.Text = "";
            }
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                label17.Text = "image is required";
                label17.ForeColor = Color.Red;
                error = true;
            }
            else
            {
                label17.Text = "";
            }
            if (string.IsNullOrEmpty(comboBox2.Text))
            {
                label18.Text = "job type is required";
                label18.ForeColor = Color.Red;
                error = true;
            }
            else
            {
                label18.Text = "";
            }
            if (string.IsNullOrEmpty(textBox10.Text))
            {
                label19.Text = "Experiance required";
                label19.ForeColor = Color.Red;
                error = true;
            }
            else
            {
                label19.Text = "";
            }
            if (string.IsNullOrEmpty(textBox11.Text))
            {
                label20.Text = "required";
                label20.ForeColor = Color.Red;
                error = true;
            }
            else
            {
                label20.Text = "";
            }
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                label21.Text = "required";
                label21.ForeColor = Color.Red;
                error = true;
            }
            else
            {
                label21.Text = "";
            }
            if (string.IsNullOrEmpty(textBox8.Text))
            {
                label22.Text="required";
                label22.ForeColor = Color.Red;
                error = true;
            }
            else
            {
                label22.Text = "";
            }
            if (string.IsNullOrEmpty(textBox9.Text))
            {
                label23.Text = "required";
                label23.ForeColor = Color.Red;  
                error = true;
            }
            else if (textBox9.Text.Length < 8)
            {
                label23.Text = "Password must be at least 8 characters long";
                label23.ForeColor = Color.Red;
                error = true;
            }
            else if (!textBox9.Text.Any(char.IsLetter) || !textBox9.Text.Any(char.IsDigit))
            {
                label23.Text = "Password must contain both letters and numbers";
                label23.ForeColor = Color.Red;
                error = true;
            }
            else
            {
                label23.Text = "";
            }


            con.Open();
            string query = "select * from Login where(Username='" + textBox8.Text + "' or Password='" + textBox9.Text + "') and Usertype='Staff'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd .ExecuteReader();
            if(dr.Read())
            {
                if (string.IsNullOrEmpty(textBox8.Text))
                {
                    label22.Text = "required";
                    label22.ForeColor = Color.Red;
                    error = true;
                }
                else if (textBox8.Text == dr[1].ToString())
                {
                    label22.Text = "username is already exisit";
                    label22.ForeColor= Color.Red;
                    error = true;
                }
                else
                {
                    label22.Text = "";
                }

                if(string.IsNullOrEmpty(textBox9.Text))
                {
                    label23.Text = "required";
                    label23.ForeColor = Color.Red;
                    error = true;
                }else if(textBox9.Text == dr[2].ToString())
                {
                    label23.Text = "password already taken";
                    label23.ForeColor= Color.Red;
                    error = true;
                }
                else
                {
                    label23.Text = "";
                }
            }
            dr.Close();


            if (!error)
            {
                //Image

                string profile = Path.Combine(Application.StartupPath, "profile", comboBox2.Text);
                if (!Directory.Exists(profile))
                {
                    Directory.CreateDirectory(profile);
                }
                string folder = Path.Combine(profile, textBox1.Text + Path.GetExtension(textBox4.Text));
                File.Copy(textBox4.Text, folder, true);
                string profdb = Path.Combine("profile", comboBox2.Text, textBox1.Text + Path.GetExtension(textBox4.Text));


               
                string query2 = "insert into Staff_Reg values (" + textBox1.Text + "," + textBox7.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "','" + profdb + "','" + comboBox2.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + textBox6.Text + "')";
                SqlCommand cmd2 = new SqlCommand(query2, con);
                if (cmd2.ExecuteNonQuery() > 0)
                {
                    string query3 = "insert into Login values(" + textBox7.Text + ",'" + textBox8.Text + "','" + textBox9.Text + "','Staff','InActive')";
                    SqlCommand cmd3 = new SqlCommand(query3, con);
                    if (cmd3.ExecuteNonQuery() > 0)
                    {
                        Login obj = new Login();
                        obj.Show();
                    }
                }
                
            }
            con.Close();

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
        public void addjob()
        {
            con.Open();
            string query = "select * from Add_Jobs";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr[1].ToString());
            }
            con.Close();
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}


