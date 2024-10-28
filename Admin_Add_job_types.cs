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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Blue_Collared
{
    public partial class Admin_Add_job_types : Form
    {
        public Admin_Add_job_types()
        {
            InitializeComponent();
            Jid();
        }
        SqlConnection con = new SqlConnection("server=HP;database=Blue_Collared;uid=sa;password=User123");

        public void Jid()
        {
            con.Open();
            string query = "SELECT ISNULL(MAX(Jid), 100) + 1 AS NewJid FROM Add_Jobs";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr[0].ToString();
            }
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bool error=false;
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                label6.Text = "Fill the job type";
                label6.ForeColor = Color.Red;
                error = true;
            }
            else
            {
                label6.Text = "";
            }            
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                label7.Text = "Fill the job description";
                label7.ForeColor = Color.Red;
                error = true;
            }
            else
            {
                label7.Text = "";
            }
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                label8.Text = "select the picture";
                label8.ForeColor = Color.Red;
                error= true;
            }
            else
            {
                try
                {
                    label8.Text = "";
                    con.Open();
                    string query = "select count(*) from Add_Jobs";
                    SqlCommand cmd = new SqlCommand(query, con);
                    int count = (int)cmd.ExecuteScalar();
                    if (count == 0)
                    {
                        string profile = Path.Combine("job pics", textBox1.Text + Path.GetExtension(textBox4.Text));
                        File.Copy(textBox4.Text, Path.Combine(Application.StartupPath, profile), true);


                        string query2 = "insert into Add_Jobs values(" + textBox1.Text + ",'" + textBox3.Text + "','" + textBox2.Text + "','" + profile + "')";
                        SqlCommand cmd2 = new SqlCommand(query2, con);
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Job Inserted");
                        }
                    }
                    else
                    {
                        MessageBox.Show("You have alraedy Added job");
                    }
                }catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();

                }

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {

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
    }
}
