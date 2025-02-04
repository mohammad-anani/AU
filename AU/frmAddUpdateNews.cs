using AU_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AU
{
    public partial class frmAddUpdateNews : Form
    {
        clsNews News=new clsNews();
        public frmAddUpdateNews(clsNews News)
        {
            InitializeComponent();
            this.News = News;
            textBox1.Text= News.Title;
            textBox2.Text= News.Description;
            pictureBox1.ImageLocation=News.ImagePath==""?"":News.ImagePath;
            lblchooseimage.Visible=false;
            label2.Text = "Update News";
            guna2Button1.Text = "Update";
        }

        public frmAddUpdateNews()
        {
            InitializeComponent();
        }


        void SetImage()
        {
            openFileDialog1.Filter = "Images (png,jpeg,jpg)|*.png;*.jpeg:*.jpg";
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonPictures);
            openFileDialog1.Title = "Choose Your Image";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                lblchooseimage.Visible = false;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SetImage();
        }

        private void lblchooseimage_Click(object sender, EventArgs e)
        {
            SetImage();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length == 0 || textBox2.Text.Length==0)
            {
                MessageBox.Show("Missing Fields","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            News.Title = textBox1.Text;
            News.Description = textBox2.Text;
            News.ImagePath = pictureBox1.ImageLocation == "" ? "" : pictureBox1.ImageLocation;

            if(News.Save())
            {
                MessageBox.Show("News Saved Successfully","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
             
            }
            else
                MessageBox.Show("News Saving Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Close();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
