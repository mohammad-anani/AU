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
    public partial class frmAddApplication : Form
    {
        public frmAddApplication()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson form = new frmAddUpdatePerson();
            form.ShowDialog();
            if(form.Person.PersonID!=-1)
            {
                textBox1.Text = form.Person.Username;
                ctrlPersonCard1.person = form.Person;
                ctrlPersonCard1.fillinfo();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                clsPerson person = clsPerson.Find(textBox1.Text);
                if (person.PersonID==-1)
                {
                    MessageBox.Show("Person Not Found","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ctrlPersonCard1.person=person;
                ctrlPersonCard1.fillinfo();
            }
        }

        private void frmAddApplication_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(ctrlPersonCard1.person.PersonID==-1 || !ctrlAddApplication1.IsAllStringFloatValues() || !ctrlApplicationMajor1.ValidateMajor())
            {
                MessageBox.Show("Missing Fields","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if(clsStudent.FindStudentByPersonID(ctrlPersonCard1.person.PersonID).PersonID!=-1 ||
                clsTeacher.FindTeacherByPersonID(ctrlPersonCard1.person.PersonID).PersonID != -1 ||
                ctrlPersonCard1.person.PersonID==1)
            {
                MessageBox.Show("This Person Already has a position", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            clsApplication application=new clsApplication();
            application.PersonID = ctrlPersonCard1.person.PersonID;
            application.Grade10avg = float.Parse(ctrlAddApplication1.grade10avg);
            application.Grade11avg = float.Parse(ctrlAddApplication1.grade11avg);
            application.Grade12avg = float.Parse(ctrlAddApplication1.grade12avg);
            application.Bacavg = float.Parse(ctrlAddApplication1.bacavg);
            application.Grade12School = ctrlAddApplication1.grade12school;
            application.Grade12Specialization = ctrlAddApplication1.grade12spec;
            application.ApplicationDate = DateTime.Now;
            application.MajorID = clsMajor.Find(ctrlApplicationMajor1.major).MajorID;
            if (!application.AddApplication())
            {
                MessageBox.Show("Error:Application Not Added", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }


            MessageBox.Show("Application Successfully Added.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();


        }

        private void ctrlApplicationMajor1_Load(object sender, EventArgs e)
        {

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
