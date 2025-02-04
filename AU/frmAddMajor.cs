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
    public partial class frmAddMajor : Form
    {
        public frmAddMajor()
        {
            InitializeComponent();
            FillComboBox();
        }

        clsMajor Major=new clsMajor();

        public frmAddMajor(clsMajor major)
        {
            InitializeComponent();
            FillComboBox();
            Major = major;
            label2.Text = "Update Major";
            guna2Button1.Text = "Update";
            textBox1.Text=major.MajorName;
            numericUpDown1.Value = major.CompletionYears;
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf(major.Department.DepartmentName);
        }


        void ValidateYear()
        {
            if (Major.MajorID == -1)
            {
                return;
            }
            int min = -1;
            int EnrollmentYear = -1;
            DataTable dtcourses = clsMajorCourse.ListMajorCourses();
            dtcourses.DefaultView.RowFilter = "majorname = '" + Major.MajorName + "'";
            foreach (DataRow row in clsMajorCourse.ListMajorCourses().DefaultView.ToTable(false,"MajorCourseID", "CourseName").Rows)
            {
                EnrollmentYear = clsMajorCourse.FindById(Convert.ToInt32(row[0])).EnrollmentYear;
                min = EnrollmentYear > min ? EnrollmentYear : min;
            }
            numericUpDown1.Minimum = min;
        }
        

        void FillComboBox()
        {
            foreach(DataRow row in clsDepartment.ListDepartments().Rows)
            {
                comboBox1.Items.Add(row[1]);
            }
            comboBox1.SelectedIndex = 0;
        }
        private void frmAddMajor_Load(object sender, EventArgs e)
        {
            ValidateYear();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("Missing Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Major.MajorName=textBox1.Text;
            Major.CompletionYears = (int)numericUpDown1.Value;
            Major.DepartmentID= comboBox1.SelectedIndex+1;

            if(Major.Save())
            {
                MessageBox.Show("Major Saved Successfully.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label1.Text = "Update Major";
                guna2Button1.Text = "Update";
            }
            else
                MessageBox.Show("Major Not Saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            this.Close();

        }

        private void numericUpDown1_Validating(object sender, CancelEventArgs e)
        {
         
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
