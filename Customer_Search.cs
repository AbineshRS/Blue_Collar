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
    public partial class Customer_Search : Form
    {
        public Customer_Search()
        {
            InitializeComponent();
            combo();
            AllUsers();
        }
        SqlConnection con = new SqlConnection("server=HP;database=Blue_Collared;uid=sa;password=User123");
        public void combo()
        {
            con.Open();
            string query = "select * from Add_Jobs";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[1].ToString());
            }
            con.Close();
        }
        public void AllUsers()
        {
            listView1.Items.Clear();
            imageList1.Images.Clear(); // Clear existing images in the ImageList

            // Open the database connection
            con.Open();
            string quer = "SELECT Profile FROM Staff_reg"; // Use parameterized queries for security
            SqlCommand cmd = new SqlCommand(quer, con);

            SqlDataReader dr = cmd.ExecuteReader();

            int imageIndex = 0; // To keep track of the image index

            // Set ListView properties
            listView1.View = View.LargeIcon; // Set the view to LargeIcon
            listView1.LargeImageList = imageList1; // Assign the ImageList to the ListView

            // Add images and names to the ListView items
            while (dr.Read())
            {
                string imagePath = dr[0].ToString(); // Assuming the image path is in the first column
                if (File.Exists(imagePath))
                {
                    // Load the image and add it to the ImageList
                    Bitmap image = new Bitmap(imagePath);
                    imageList1.Images.Add(image);

                    // Get the filename without the extension
                    string imageNameWithoutExtension = Path.GetFileNameWithoutExtension(imagePath);

                    // Create a new ListViewItem with the image index
                    ListViewItem item = new ListViewItem
                    {
                        ImageIndex = imageIndex, // Set the index of the image in the ImageList
                        Text = imageNameWithoutExtension // Set the text to the filename without extension
                    };

                    listView1.Items.Add(item); // Add the ListViewItem to the ListView
                    imageIndex++; // Increment the image index for the next item
                }
            }
            con.Close();

            // Attach the DoubleClick event handler for the ListView
            listView1.DoubleClick += listView1_DoubleClick;

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Clear existing items in the ListView
            listView1.Items.Clear();
            imageList1.Images.Clear(); // Clear existing images in the ImageList

            // Open the database connection
            con.Open();
            string quer = "SELECT Profile FROM Staff_reg WHERE JobType = @jobType"; // Use parameterized queries for security
            SqlCommand cmd = new SqlCommand(quer, con);
            cmd.Parameters.AddWithValue("@jobType", comboBox1.Text); // Add the parameter to prevent SQL injection
            SqlDataReader dr = cmd.ExecuteReader();

            int imageIndex = 0; // To keep track of the image index

            // Set ListView properties
            listView1.View = View.LargeIcon; // Set the view to LargeIcon
            listView1.LargeImageList = imageList1; // Assign the ImageList to the ListView

            // Add images and names to the ListView items
            while (dr.Read())
            {
                string imagePath = dr[0].ToString(); // Assuming the image path is in the first column
                if (File.Exists(imagePath))
                {
                    // Load the image and add it to the ImageList
                    Bitmap image = new Bitmap(imagePath);
                    imageList1.Images.Add(image);

                    // Get the filename without the extension
                    string imageNameWithoutExtension = Path.GetFileNameWithoutExtension(imagePath);

                    // Create a new ListViewItem with the image index
                    ListViewItem item = new ListViewItem
                    {
                        ImageIndex = imageIndex, // Set the index of the image in the ImageList
                        Text = imageNameWithoutExtension // Set the text to the filename without extension
                    };

                    listView1.Items.Add(item); // Add the ListViewItem to the ListView
                    imageIndex++; // Increment the image index for the next item
                }
            }
            con.Close();

            // Attach the DoubleClick event handler for the ListView
            listView1.DoubleClick += listView1_DoubleClick;
        }

        // Event handler for ListView double-click
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                // Get the selected item
                ListViewItem selectedItem = listView1.SelectedItems[0];
                string imageId = selectedItem.Text.ToString();
                // Show the image name in a message box
                this.Close();
                Customer_View_particular obj = new Customer_View_particular(imageId);
                obj.Show();

            }
        }

        private void Customer_Search_Load(object sender, EventArgs e)
        {

        }
    }
}
