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
    public partial class frmAddTeacher : Form
    {
        public clsTeacher Teacher=new clsTeacher();
        public frmAddTeacher()
        {
            InitializeComponent();
        }

        public frmAddTeacher(clsTeacher Teacher)
        {
            InitializeComponent();
            this.Teacher = Teacher;
            guna2Button1.Text = "Update";
            label3.Text = "Update Teacher";
            textBox1.Text = Teacher.Person.Username;
            ctrlPersonCard1.person= Teacher.Person;
            ctrlPersonCard1.fillinfo();
            txtspec.Text = Teacher.Specialization;
            textBox1.Enabled = false;
            button1.Enabled = false;


        }

        private void frmAddTeacher_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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
            if (ctrlPersonCard1.person.PersonID == -1 || txtspec.Text == "")
            {
                MessageBox.Show("Missing Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            clsTeacher existingteacher = clsTeacher.FindTeacherByPersonID(ctrlPersonCard1.person.PersonID);
            if (clsStudent.FindStudentByPersonID(ctrlPersonCard1.person.PersonID).PersonID != -1 ||
                ( existingteacher.TeacherID!= -1 && clsGLobalSettings.CurrentTeacher.TeacherID!=existingteacher.TeacherID) ||
                ctrlPersonCard1.person.PersonID == 1)
            {
                MessageBox.Show("This Person Already has a position", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            Teacher.PersonID = ctrlPersonCard1.person.PersonID;
            Teacher.Specialization = txtspec.Text;

            if (Teacher.Save())
            {
                MessageBox.Show("Teacher Saved Successfully.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            else
                MessageBox.Show("Teacher Saving Failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            this.Close();
        }
        }
    }
