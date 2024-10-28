namespace Blue_Collared
{
    partial class Customer_Search
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            comboBox1 = new ComboBox();
            imageList1 = new ImageList(components);
            listView1 = new ListView();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(789, 120);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(202, 28);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged_1;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(124, 124);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // listView1
            // 
            listView1.BackColor = Color.FromArgb(109, 166, 198);
            listView1.LargeImageList = imageList1;
            listView1.Location = new Point(72, 73);
            listView1.Name = "listView1";
            listView1.Size = new Size(681, 450);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(789, 79);
            label1.Name = "label1";
            label1.Size = new Size(55, 23);
            label1.TabIndex = 3;
            label1.Text = "Select";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(50, 22);
            label2.Name = "label2";
            label2.Size = new Size(142, 31);
            label2.TabIndex = 4;
            label2.Text = "Serach Staff";
            // 
            // Customer_Search
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(109, 166, 198);
            ClientSize = new Size(1114, 556);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listView1);
            Controls.Add(comboBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Customer_Search";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Customer_Search";
            Load += Customer_Search_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox comboBox1;
        private ImageList imageList1;
        private ListView listView1;
        private Label label1;
        private Label label2;
    }
}