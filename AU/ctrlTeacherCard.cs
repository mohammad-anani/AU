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
    public partial class ctrlTeacherCard : UserControl
    {
        public clsTeacher Teacher =new clsTeacher();
        public ctrlTeacherCard()
        {
            InitializeComponent();
        }

        public void FillInfo()
        {
            if (Teacher.TeacherID == -1)
            { return; }

            lblname.Text = Teacher.Person.FullName();
            lblspec.Text = Teacher.Specialization;
            if (Teacher.Person.PersonID == clsGLobalSettings.CurrentPerson.PersonID)
            {
                llteacher.Visible = false;
            }
        }

        private void ctrlTeacherCard_Load(object sender, EventArgs e)
        {

        }

        private void llteacher_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new frmPersonCard(Teacher.Person);
            form.ShowDialog();
        }
    }
}
