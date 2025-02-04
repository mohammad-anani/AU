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
    public partial class frmNewsCard : Form
    {
        clsNews News=new clsNews();
        public frmNewsCard(clsNews news)
        {
            InitializeComponent();
            News = news;
        }

        private void frmNewsCard_Load(object sender, EventArgs e)
        {
            if (News.NewsID == -1) return;

            lbltitle.Text = News.Title;
            lbldescription.Text = News.Description;
            pictureBox1.ImageLocation = News.ImagePath == "" ? "" : News.ImagePath;
        }
    }
}
