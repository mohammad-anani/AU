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
    public partial class frmStudentSessions : Form
    {
        clsStudent Student = new clsStudent();
        public frmStudentSessions(clsStudent Student)
        {
            InitializeComponent();
            this.Student = Student;
        }

        private void frmStudentSessions_Load(object sender, EventArgs e)
        {
            ctrlStudentSessions1.Student=Student;
            ctrlStudentSessions1.FillInfo();
        }
    }
}
