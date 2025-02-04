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
    public partial class frmAddScheduledCourse : Form
    {
        public frmAddScheduledCourse()
        {
            InitializeComponent();
        }

        void FillComboBox()
        {
            foreach (DataRow row in clsCourse.ListCourses().Rows)
            {
                comboBox1.Items.Add(row[1].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddTeacher form=new frmAddTeacher();
            form.ShowDialog();
            if(form.Teacher.TeacherID!=-1)
            {
                ctrlTeacherCard1.Teacher = form.Teacher;
                ctrlTeacherCard1.FillInfo();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmAddCourse form=new frmAddCourse();
            form.ShowDialog();
            if(form.Course.CourseId!=-1)
            {
                ctrlCourseCard1.course = form.Course;
                ctrlCourseCard1.FillInfo();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            clsTeacher Teacher = clsTeacher.FindTeacherByPersonID(clsPerson.Find(textBox1.Text).PersonID);
            if(Teacher.TeacherID==-1)
            {
                MessageBox.Show("Teacher Not Found","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            ctrlTeacherCard1.Teacher = Teacher;
            ctrlTeacherCard1.FillInfo();
        }

        private void frmAddScheduledCourse_Load(object sender, EventArgs e)
        {
            FillComboBox();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           clsCourse Course = clsCourse.Find(comboBox1.Text);
            ctrlCourseCard1.course = Course;
            ctrlCourseCard1.FillInfo();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(ctrlTeacherCard1.Teacher.TeacherID==-1 || ctrlCourseCard1.course.CourseId==-1)
            {
                MessageBox.Show("Missing Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsScheduledCourse course =new clsScheduledCourse();

            course.TeacherID = ctrlTeacherCard1.Teacher.TeacherID;
            course.CourseID = ctrlCourseCard1.course.CourseId;

            if(course.ScheduleCourse())
            {
                MessageBox.Show("Course Scheduled Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Course Schedule Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            this.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
