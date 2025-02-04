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
    public partial class frmMajorCardForAdministrator : Form
    {
        clsMajor Major=new clsMajor();
        public frmMajorCardForAdministrator(clsMajor Major)
        {
            InitializeComponent();
            this.Major = Major;
        }

        private void frmMajorCardForAdministrator_Load(object sender, EventArgs e)
        {
            ctrlMajorCard1.major=Major;
            ctrlMajorCard1.FillInfo();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form form = new frmListMajorCourses(Major);
            form.ShowDialog();
            ctrlMajorCard1.major = clsMajor.Find(Major.MajorID);
            ctrlMajorCard1.FillInfo();
            

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Form form = new frmAddMajor(Major);
            form.ShowDialog();
            ctrlMajorCard1.major = Major;
            ctrlMajorCard1.FillInfo();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This Deletion Will Delete Related Students."
  , "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            if (MessageBox.Show("Confirm Permanent Deletion?"
            , "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

                if (clsMajor.DeleteMajor(Major.MajorID))
                {
                    MessageBox.Show("Major and Everything Related Successfully Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Failed");
                }
                this.Close();
            }
    }
}
