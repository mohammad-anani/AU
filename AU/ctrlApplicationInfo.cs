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
    public partial class ctrlApplicationInfo : UserControl
    {
        public clsApplication application=new clsApplication();
        public ctrlApplicationInfo()
        {
            InitializeComponent();
        }

        public void FillInfo()
        {
            if(application==new clsApplication())
            {
                return;
            }
            lblfullname.Text = application.Person.FullName();
            lbl10.Text = application.Grade10avg.ToString();
            lbl11.Text = application.Grade11avg.ToString();
            lbl12.Text = application.Grade12avg.ToString();
            lblspec.Text = application.Grade12Specialization;
            lblschool.Text = application.Grade12School;
            lbldate.Text = application.ApplicationDate.ToShortDateString();
            lblstatus.Text = application.Status;
            lblbac.Text = application.Bacavg.ToString();
            lblmajor.Text = application.Major.MajorName;

        }
        private void ctrlApplicationInfo_Load(object sender, EventArgs e)
        {

        }

        private void llpersoninfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (application != new clsApplication())
            {
                Form form = new frmPersonCard(application.Person);
                form.ShowDialog();
            }
        }

        private void llmajorinfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new frmMajorCard(application.Major);
            form.ShowDialog();
        }
    }
}
