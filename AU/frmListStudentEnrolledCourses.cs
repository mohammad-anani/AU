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
    public partial class frmListStudentEnrolledCourses : Form
    {
        public clsStudent Student=new clsStudent();
        public frmListStudentEnrolledCourses(clsStudent student)
        {
            InitializeComponent();
            Student=student;
        }

        private void frmListStudentEnrolledCourses_Load(object sender, EventArgs e)
        {
            ctrlStudentCoursesTab1.Student = Student;
            ctrlStudentCoursesTab1.FillInfo();
        }
    }
}
