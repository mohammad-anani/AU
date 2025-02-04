using AU_Business;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;

namespace AU
{
    public partial class frmIntroductionToUniversity : Form
    {
        public frmIntroductionToUniversity()
        {
            InitializeComponent();
            
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        private void frmIntroductionToUniversity_Load(object sender, EventArgs e)
        {
            DataTable dtMajors = clsMajor.ListMajors();

            //dtMajors.DefaultView.RowFilter = "departmentname='Engineering and Technology'";
            //DataTable dtengineering = dtMajors.DefaultView.ToTable(false, "MajorName");
            //dgvengineering.DataSource = dtengineering;

            //dtMajors.DefaultView.RowFilter = "departmentname='Information and Communication'";
            //DataTable dtinfocom = dtMajors.DefaultView.ToTable(false, "MajorName");
            //dgvinfocom.DataSource = dtinfocom;

            //dtMajors.DefaultView.RowFilter = "departmentname='Health and Psychology'";
            //DataTable dthealth = dtMajors.DefaultView.ToTable(false, "MajorName");
            //dgvhealth.DataSource = dthealth;

            //dtMajors.DefaultView.RowFilter = "departmentname='Arts and Music'";
            //DataTable dtarts = dtMajors.DefaultView.ToTable(false, "MajorName");
            //dgvarts.DataSource = dtarts;

            //dtMajors.DefaultView.RowFilter = "departmentname='Pure Sciences'";
            //DataTable dtsciences = dtMajors.DefaultView.ToTable(false, "MajorName");
            //dgvsciences.DataSource = dtsciences;

            foreach(DataRow row in clsDepartment.ListDepartments().Rows)
            {
                ctrlListDepartmentMajors list=new ctrlListDepartmentMajors();
                list.Department = clsDepartment.Find(Convert.ToInt32(row[0]));
                list.dtMajors=dtMajors;
                list.FillInfo();
                flowLayoutPanel1.Controls.Add(list);
            }

            string Activated = File.ReadAllText("AU_Settings.txt");
            chkfee.Text = "a fee of " + Convert.ToInt32(Activated.Substring(3, 2)) + "$ should be paid to the university before the application's deadline.";
        }

        

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

      

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dgvengineering_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView dgv=(DataGridView)sender;

            Form form = new frmMajorCard(clsMajor.Find(dgv.SelectedRows[0].Cells[0].Value.ToString()));
            form.ShowDialog();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void btnnext2_Click(object sender, EventArgs e)
        {
            if(!ctrlAddUpdatePerson1.IsValidatedNoEmptyBoxes())
            {
                MessageBox.Show("Missing Fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tabControl1.SelectedIndex = 3;

        }

        private void btnback2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (!ctrlAddApplication1.IsAllStringFloatValues())
            {
                MessageBox.Show("Missing/Invalid Fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tabControl1.SelectedIndex = 4;
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (!ctrlApplicationMajor1.ValidateMajor())
            {
                MessageBox.Show("Please Select a Major.","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            tabControl1.SelectedIndex = 5;
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            if(!ctrlUserInfo1.ValidateNoEmptyStrings())
            {
                MessageBox.Show("Missing Fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ctrlUserInfo1.IsSamePasswords())
            {
                MessageBox.Show("Passwords Don't Match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(ctrlUserInfo1.IsUsernameExist())
            {
                MessageBox.Show("Username Already Exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            tabControl1.SelectedIndex = 6;

        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 5;
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 7;
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 6;
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            if(!chkagree.Checked || !chkdocs.Checked || !chkfee.Checked)
            {
                MessageBox.Show("Please Check The Aggreements Above.","Error",MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                return;
            }

            if(MessageBox.Show("Are you sure you want to submit the application\nApplication's info \"cannot be changed\"","Attention"
                ,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
            {
                return;
            }

            clsPerson person = new clsPerson();
            person.FirsrtName=ctrlAddUpdatePerson1.fname;
            person.SecondName=ctrlAddUpdatePerson1.sname;
            person.LastName=ctrlAddUpdatePerson1.lname;
            person.Phone=ctrlAddUpdatePerson1.phone;
            person.Gender=ctrlAddUpdatePerson1.gender;
            person.CountryID = clsCountry.Find(ctrlAddUpdatePerson1.countryname).CountryID;
            person.DateOfBirth = ctrlAddUpdatePerson1.DateOfBirth;
            person.Username=ctrlUserInfo1.username;
            person.Password=ctrlUserInfo1.password;
            
            if(ctrlAddUpdatePerson1.imagepath!="")
            {
                person.ImagePath=ctrlAddUpdatePerson1.imagepath;
            }

            if(!person.Save())
            {
                MessageBox.Show("Error:Application Not Submitted","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Close();
                return;
            }  
            
            clsApplication application = new clsApplication();
            application.PersonID=person.PersonID;
            application.Grade10avg = float.Parse(ctrlAddApplication1.grade10avg);
            application.Grade11avg= float.Parse(ctrlAddApplication1.grade11avg);
            application.Grade12avg= float.Parse(ctrlAddApplication1.grade12avg);
            application.Bacavg = float.Parse(ctrlAddApplication1.bacavg);
            application.Grade12School = ctrlAddApplication1.grade12school;
            application.Grade12Specialization = ctrlAddApplication1.grade12spec;
            application.ApplicationDate=DateTime.Now;
            application.MajorID = clsMajor.Find(ctrlApplicationMajor1.major).MajorID;

            if(!application.AddApplication())
            {
                MessageBox.Show("Error:Application Not Submitted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }


            MessageBox.Show("Application Successfully Submitted.","Message",MessageBoxButtons.OK, MessageBoxIcon.Information);
            clsEmail.SendEmailFromAdministrator(person.PersonID, "Welcome!", "Dear Applicant,Welcome to our university\n" +
                "This account is made for new applicants waiting for their admission as a full student while their application is being processed.\n" +
                "Kindly note that,for your acceptance,you should submit all required documents.\nBest Regards,\nAU administration.");
            this.Close();
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void chkfee_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void dgvengineering_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
