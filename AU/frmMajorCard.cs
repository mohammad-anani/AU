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
    public partial class frmMajorCard : Form
    {
        public clsMajor Major=new clsMajor();
        public frmMajorCard(clsMajor major)
        {
            InitializeComponent();
            Major = major;
        }

        private void frmMajorCard_Load(object sender, EventArgs e)
        {
            ctrlMajorCard1.major = Major;
            ctrlMajorCard1.FillInfo();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
