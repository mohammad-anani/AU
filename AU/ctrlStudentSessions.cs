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
    public partial class ctrlStudentSessions : UserControl
    {
        public clsStudent Student=new clsStudent();
        public ctrlStudentSessions()
        {
            InitializeComponent();
        }

        public void FillInfo()
        {
            if (Student.StudentID == -1)
                return;

            dgvsessions.DataSource=clsSession.ListSessionsForStudent(Student.StudentID);
            if(dgvsessions.Rows.Count>0)
           { dgvsessions.Columns[0].HeaderText = "Course Name";
            dgvsessions.Columns[1].HeaderText = "Teacher Name";
            dgvsessions.Columns[2].HeaderText = "Session Date";
                dgvsessions.Columns[3].HeaderText = "Is Present";
            }
            lblstudent.Text = Student.Person.FullName();
        }

        private void ctrlStudentSessions_Load(object sender, EventArgs e)
        {

        }

        private void dgvsessions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
