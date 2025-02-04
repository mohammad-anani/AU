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
    public partial class frmTeacherCourses : Form
    {
        clsTeacher Teacher=new clsTeacher();
        public frmTeacherCourses(clsTeacher Teacher)
        {
            InitializeComponent();
            this.Teacher = Teacher;
        }

        private void frmTeacherCourses_Load(object sender, EventArgs e)
        {
            ctrlTeacherCourses1.Teacher=Teacher;
            ctrlTeacherCourses1.FillInfo();
        }
    }
}
