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
    public partial class ctrlMajorCard : UserControl
    {

       public clsMajor major=new clsMajor();
        public ctrlMajorCard()
        {
            InitializeComponent();
        }

        public void FillInfo()
        {
           if (major == new clsMajor())
            {
                return;
            }
            lblmajorname.Text = major.MajorName;
            lbldepartmentname.Text = major.Department.DepartmentName;
            lblcompletionyears.Text = major.CompletionYears.ToString();
            if(major.TotalNumberOfCourses!=-1)
           { lblnumofcourses.Text = major.TotalNumberOfCourses.ToString();
            lblprice.Text=major.TotalPrice.ToString();
                lblcredits.Text = major.TotalCredits.ToString();
            }
            else
            {
                lblnumofcourses.Text = "N/A";
                lblprice.Text = "N/A";
                lblcredits.Text ="N/A";
            }

            
        }

        private void ctrlMajorCard_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new frmListMajorCourses(major);
            form.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new frmDepartmentCard(major.Department);
            form.ShowDialog();
        }
    }
}
