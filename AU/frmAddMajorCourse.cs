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
    public partial class frmAddMajorCourse : Form
    {
        clsMajor Major=new clsMajor();
        public frmAddMajorCourse(clsMajor Major)
        {
            InitializeComponent();
            this.Major = Major;
            lblmajor.Text = Major.MajorName;
        }

        clsCourse Course=new clsCourse();

        private void frmAddMajorCourse_Load(object sender, EventArgs e)
        {
            foreach (DataRow row in clsCourse.ListCourses().Rows)
            {
                comboBox1.Items.Add(row[1].ToString());
            }
            numericUpDown1.Maximum = Major.CompletionYears;
            numericUpDown1.Minimum = 1;
        }

        private void ctrlCourseCard1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem==null)
            {
                MessageBox.Show("Missing Fields","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            if(clsMajorCourse.FindByCourse(clsCourse.Find(comboBox1.Text).CourseId).MajorCourseID!=-1)
            {
                MessageBox.Show("Major Already Has This Course", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsMajorCourse MajorCourse=new clsMajorCourse();    

            MajorCourse.MajorID = Major.MajorID;
            MajorCourse.CourseID = Course.CourseId;
            MajorCourse.EnrollmentYear = (int)numericUpDown1.Value;
            if (MajorCourse.AddMajorCourse())
            {
                MessageBox.Show("Course Added Successfully To Major", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Course Not Added To Major", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Close();


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Course = clsCourse.Find(comboBox1.Text);
            ctrlCourseCard1.course=Course;
            ctrlCourseCard1.FillInfo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddCourse form = new frmAddCourse();
            form.ShowDialog();
            
            if(form.Course.CourseId!=-1)
            {
                frmAddMajorCourse_Load(null, null);
                comboBox1.SelectedIndex = comboBox1.Items.IndexOf(form.Course.CourseName);

            }

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
