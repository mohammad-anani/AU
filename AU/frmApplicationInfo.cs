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
    public partial class frmApplicationInfo : Form
    {
        public clsApplication Application =new clsApplication();
        public frmApplicationInfo(int applicationid)
        {
            InitializeComponent();
            Application=clsApplication.FindByApplicationID(applicationid);
        }

        private void frmApplicationInfo_Load(object sender, EventArgs e)
        {
            ctrlApplicationInfo1.application=Application;
            ctrlApplicationInfo1.FillInfo();
            string Activated = File.ReadAllText("AU_Settings.txt");
            chkpaid.Text = "Paid "+Activated.Substring(3,2)+"$ Application Fees";
                ChangeButtonsByStatus();
           
        
        }

        void ChangeButtonsByStatus()
        {
            switch (Application.Status)
            {
                case "New":
                    btnaccept.Enabled = true;
                    btncancel.Visible = false;
                    btnreject.Visible = true;
                    btncomplete.Enabled = false;
                    chkpaid.Enabled = false;
                    chksubmit.Enabled = false;
                    break;
                case "Rejected":
                    btnaccept.Enabled = false;
                    btncancel.Visible = true;
                    btnreject.Visible = false;
                    btncomplete.Enabled = false;
                    chkpaid.Enabled = false;
                    chksubmit.Enabled = false;
                    break;
                case "Accepted":
                    btnaccept.Enabled = false;
                    btncancel.Visible = false;
                    btnreject.Enabled = false;
                    btncomplete.Enabled = true;
                    chkpaid.Enabled = true;
                    chksubmit.Enabled = true;
                    break;
                case "Completed":
                    btnaccept.Enabled = false;
                    btncancel.Visible = false;
                    btnreject.Enabled = false;
                    btncomplete.Enabled=false;
                    chkpaid.Enabled = false;
                    chksubmit.Enabled = false;
                    break;

            }
        }

        private void btnaccept_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you Sure You Want To Accept?","Attention",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                Application.AcceptApplication();
                Application.SetPreDeactivationDate();
                ChangeButtonsByStatus();
                ctrlApplicationInfo1.FillInfo();
                clsEmail.SendEmailFromAdministrator(Application.PersonID, "You are Accepted!", "Dear Applicant,we want to acknowledge you that you were successfully accepted " +
                    "and one step ahead from being a full AU student.\nYou have to pay the administration a 50$ fee withing a deadline of 30 days after this email,else your application will be" +
                    " automatically rejected.\nBest regards,\nAU administration.");

            }
        }

        int CalculateScholarship()
        {
            if (Application.Bacavg < 80)
            {
                return 0;
            }

            if (Application.Bacavg >= 95)
            {
                return 100;
            }

            return Convert.ToInt32(Application.Bacavg - 80) * 100 / 15;
        }
        private void btncomplete_Click(object sender, EventArgs e)
        {
            if(!chkpaid.Checked || !chksubmit.Checked)
            {
                MessageBox.Show("Please Check The Statements Above","Error",MessageBoxButtons.OK,MessageBoxIcon.Error); 
                return;
            }
            if (MessageBox.Show("Are you Sure You Want To Complete?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.CompleteApplication();
                Application.CancelDeactivationDate();
                Application.CancelPreDeactivationDate();
                ChangeButtonsByStatus();
                ctrlApplicationInfo1.FillInfo();
                clsStudent Student=new clsStudent();
                Student.PersonID=Application.PersonID;
                Student.MajorID=Application.MajorID;
                Student.Scholarship=CalculateScholarship();
                
                if(Student.AddStudent())
                {
                    if (!clsTuitionFees.AddTuitions(Student.StudentID))
                    {
                    }

                        MessageBox.Show("Application Successfully Completed\nNew Student Added", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clsEmail.SendEmailFromAdministrator(Application.PersonID, "Welcome Student!", "Dear Applicant,Your application is " +
                            "successfully completed!Welcome to your new student account."+(Student.Scholarship>0?"Due to your excellence in the official exam,you are granted a "+Student.Scholarship+"% scholarship for the first year.":"")+"This account allows you to see the latest news,manage emails,enroll for courses and track your session attendance.\n" +
                            "We hope for you the best time at AU.\nBest regards,AU administration.");
                    
                    }
            }
        }

        private void btnreject_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure You Want To Reject?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.RejectApplication();
                Application.SetDeactivationDate();
                ChangeButtonsByStatus();
                ctrlApplicationInfo1.FillInfo();
                clsEmail.SendEmailFromAdministrator(Application.PersonID, "You are rejected", "Dear applicant,unfortunately,your application " +
                    "was rejected.However,you can still contact us in case you still have any reason or document that can cancel your rejection." +
                    "\nElse,Your account will deactivate and be inaccessible after 30 days.\nBest regards,\nAU administration.");
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure You Want To Cancel Rejection?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.CancelRejection();
                Application.CancelDeactivationDate();
                Application.CancelPreDeactivationDate();
                ChangeButtonsByStatus();
                ctrlApplicationInfo1.FillInfo();
                clsEmail.SendEmailFromAdministrator(Application.PersonID, "Never Lose Hope!", "Dear Applicant,we cancelled your application " +
                    "rejection,your application is in process.Wait for our response.\nBest regards,\nAU administation.");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new frmCurrencyExchange();
            form.ShowDialog();
        }
    }
}
