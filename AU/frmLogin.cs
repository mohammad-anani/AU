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
using System.IO;

namespace AU
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        
        void SetDeactivationDateForPreDeactivatedApplications()
        {
            foreach(DataRow row  in clsApplication.ListPreDeactivatedApplications().Rows)
            {
                clsApplication app = clsApplication.FindByApplicationID(Convert.ToInt32(row[0]));
               app.SetDeactivationDate();
                app.RejectApplication();
                clsEmail.SendEmailFromAdministrator(app.PersonID, "You are rejected", "Dear applicant,unfortunately,your application " +
                  "was automatically rejected.However,you can still contact us in case you still have any reason or document that can cancel your rejection." +
                  "\nElse,Your account will deactivate and be inaccessible after 30 days.\nBest regards,\nAU administration.");

            }
        }

        void ManageApply()
        {
            string Activated = File.ReadAllText("AU_Settings.txt");
            if (Activated[0] == '1')
            {
                lblor.Visible = true;
                btnapply.Visible = true;
            }
            else
            {
                lblor.Visible = false;
                btnapply.Visible = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ManageApply();
            SetDeactivationDateForPreDeactivatedApplications();


            string text = File.ReadAllText("AUlogin.txt");
            if (text.Length!=0)
            {
                txtusername.Text=text.Substring(0,text.IndexOf(" "));
                txtpassword.Text = text.Substring(text.IndexOf(" ")+1);
                chkrememberme.Checked = true;
            }
          
          
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(txtusername.Text.Length==0 || txtpassword.Text.Length==0)
            {
                MessageBox.Show("Missing Fields.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            clsPerson currentperson=clsPerson.Find(txtusername.Text,txtpassword.Text);
            if (currentperson.PersonID == -1)
            {
                MessageBox.Show("Invalid Username/Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
              txtpassword.Clear();
                txtusername.Clear();
                return;
            }

            clsGLobalSettings.CurrentPerson = currentperson;

            if (chkrememberme.Checked)
            {
                File.WriteAllText("AUlogin.txt",txtusername.Text+" "+txtpassword.Text);
            }
            else
            {
                File.WriteAllText("AUlogin.txt", "");
            }

            DateTime deactivationdate = clsApplication.FindByPersonID(currentperson.PersonID).DeactivationDate;
            if (deactivationdate != DateTime.MinValue && deactivationdate < DateTime.Now)
            {
                MessageBox.Show("This Account is Deactivated.\nKindly Contact Your Administrator", "Access Denied",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsEmail.IsPersonHasNewEmails(currentperson.PersonID))
            {
                notifyIcon1.Visible = true;
                notifyIcon1.Icon = SystemIcons.Information;
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon1.BalloonTipTitle = "You Have New Email/s";
                notifyIcon1.BalloonTipText = "Check your Inbox";
                notifyIcon1.ShowBalloonTip(3000);
            }

            clsStudent currentstudent = clsStudent.FindStudentByPersonID(currentperson.PersonID);
            if(currentstudent.StudentID != -1)
            {
                clsGLobalSettings.CurrentTeacher = new clsTeacher();
            clsGLobalSettings.CurrentStudent = currentstudent;
                Form form2 = new frmStudentScreen();
                form2.ShowDialog();
                return;
            }

            clsTeacher currentteacher=clsTeacher.FindTeacherByPersonID(currentperson.PersonID);
            if( currentteacher.TeacherID != -1)
            {
                clsGLobalSettings.CurrentStudent=new clsStudent();
                clsGLobalSettings.CurrentTeacher = currentteacher;
                Form form2 = new frmTeacherScreen();
                form2.ShowDialog();
                return;
            }

            if(currentperson.PersonID==1)
            {
                clsGLobalSettings.CurrentTeacher = new clsTeacher();
                clsGLobalSettings.CurrentStudent = new clsStudent();
                frmAdministratorScreen form2 = new frmAdministratorScreen();
                form2.OnApply += Form2_OnApply;
                form2.ShowDialog();
                return;
            }

           
           
            Form form =new frmPersonScreen();
            form.ShowDialog();
        }

        private void Form2_OnApply(object sender)
        {
            ManageApply();
        }

        private void txtusername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtpassword.Focus();
            }
        }

        private void txtpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnlogin.PerformClick();
            }
        }

        private void btnapply_Click(object sender, EventArgs e)
        {
            clsGLobalSettings.CurrentPerson=new clsPerson();
            Form form =new frmIntroductionToUniversity();
            form.ShowDialog();
        }
    }
}
