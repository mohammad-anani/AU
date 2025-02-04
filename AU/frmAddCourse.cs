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
    public partial class frmAddCourse : Form
    {
        public clsCourse Course=new clsCourse();
        public frmAddCourse()
        {
            InitializeComponent();
            FillComboBox();
        }

        void FillComboBox()
        {
            foreach(DataRow row in clsDepartment.ListDepartments().Rows)
            {
                comboBox1.Items.Add(row[1]);
            }
            comboBox1.SelectedIndex = 0;
        }
        public frmAddCourse(clsCourse course)
        {
            InitializeComponent();
            FillComboBox();
            Course = course;
            txtname.Text = course.CourseName;
            txtdesc.Text = course.CourseDescription;
            txtcredits.Text=course.CourseCredits.ToString();
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf(course.Department.DepartmentName);
            btnaddupdate.Text = "Update";
            label2.Text = "Update Course";
        }

        private void frmAddCourse_Load(object sender, EventArgs e)
        {
            
        }

        private void txtcredits_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnaddupdate_Click(object sender, EventArgs e)
        {
            if(txtname.Text=="" || txtcredits.Text=="" || txtdesc.Text=="")
            {
                MessageBox.Show("Missing Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Course.CourseName = txtname.Text;
            Course.CourseCredits=Convert.ToInt32(txtcredits.Text);
            Course.CourseDescription=txtdesc.Text;
            Course.DepartmentID = comboBox1.SelectedIndex + 1;
            if (Course.Save())
            {
                btnaddupdate.Text = "Update";
                label2.Text = "Update Course";
                MessageBox.Show("Course Saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information) ;
            }
            else
            {
                MessageBox.Show("Error:Course Not Saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        private void txtname_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                txtcredits.Focus();
        }

        private void txtdesc_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                txtdesc.Focus();
        }
    }
}
