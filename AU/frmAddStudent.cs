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
    public partial class frmAddStudent : Form
    {
        public frmAddStudent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson form = new frmAddUpdatePerson();
            form.ShowDialog();
            if (form.Person.PersonID != -1)
            {
                textBox1.Text = form.Person.Username;
                ctrlPersonCard1.person = form.Person;
                ctrlPersonCard1.fillinfo();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                clsPerson person = clsPerson.Find(textBox1.Text);
                if (person.PersonID == -1)
                {
                    MessageBox.Show("Person Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ctrlPersonCard1.person = person;
                ctrlPersonCard1.fillinfo();
            }
        }

     
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (ctrlPersonCard1.person.PersonID == -1 || !ctrlApplicationMajor1.ValidateMajor())
            {
                MessageBox.Show("Missing Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (clsStudent.FindStudentByPersonID(ctrlPersonCard1.person.PersonID).PersonID != -1 ||
                clsTeacher.FindTeacherByPersonID(ctrlPersonCard1.person.PersonID).PersonID != -1 ||
                ctrlPersonCard1.person.PersonID == 1)
            {
                MessageBox.Show("This Person Already has a position", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            clsStudent NewStudent= new clsStudent();
            NewStudent.PersonID= ctrlPersonCard1.person.PersonID;
            NewStudent.MajorID= clsMajor.Find(ctrlApplicationMajor1.major).MajorID;
            NewStudent.Scholarship = (int)numericUpDown1.Value;
            if(NewStudent.AddStudent())
            {
                if (!clsTuitionFees.AddTuitions(NewStudent.StudentID))
                {
                 
                }

                MessageBox.Show("Student Successfully Added.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }else
                MessageBox.Show("Student Adding Failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            this.Close();

        }

        private void ctrlPersonCard1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
