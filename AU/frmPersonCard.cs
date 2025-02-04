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
    public partial class frmPersonCard : Form
    {
        clsPerson Person =new clsPerson();
        public frmPersonCard(clsPerson person )
        {
            InitializeComponent();
            Person = person;
        }

        private void frmPersonCard_Load(object sender, EventArgs e)
        {
            ctrlPersonCard1.person=Person;
            ctrlPersonCard1.fillinfo();
            if(Person.PersonID==1)
            {
                guna2Button2.Visible = true;
            }
            else
                guna2Button2.Visible=false;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This Deletion Will Delete Related Persons or Teachers,Emails and Applications."
      , "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            if (MessageBox.Show("Confirm Permanent Deletion?"
            , "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            clsStudent student = clsStudent.FindStudentByPersonID(Person.PersonID);
            clsTeacher teacher=clsTeacher.FindTeacherByPersonID(Person.PersonID);

            if(student.StudentID!=-1)
            {
                if(!clsStudent.DeleteStudent(student.StudentID))
                {
                    return;
                }
            }
            if (teacher.TeacherID != -1)
            {
                if (!clsTeacher.DeleteTeacher(teacher.TeacherID))
                {
                    return;
                }

            }
            if (clsPerson.DeletePerson(Person.PersonID))
            {
                MessageBox.Show("Person and Everything Related Successfully Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Failed");
            }
            this.Close();
        }

        private void ctrlPersonCard1_Load(object sender, EventArgs e)
        {

        }
    }
}
