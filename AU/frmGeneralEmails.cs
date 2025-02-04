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
    public partial class frmGeneralEmails : Form
    {
        public frmGeneralEmails()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmGeneralEmails_Load(object sender, EventArgs e)
        {
            cbpersons.Items.Add("All");
            cbpersons.Items.Add("Teachers");
            cbpersons.Items.Add("Students");
            cbdepartment.Items.Add("All");
            foreach(DataRow row in clsDepartment.ListDepartments().Rows)
            {
                cbdepartment.Items.Add(row[1]);
            }
            cbpersons.SelectedIndex = 0;
            cbdepartment.SelectedIndex = 0;
        }

        private void cbpersons_SelectedIndexChanged(object sender, EventArgs e)
        {
        if(cbpersons.SelectedIndex == 2)
            {
                pnldepartment.Visible = true;
            }
        else
            {
                pnldepartment.Visible = false;
            }
            pnlmajor.Visible = false;
            cbmajor.Items.Clear();
        }

        private void cbmajor_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbdepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbdepartment.SelectedIndex == 0)
            { 
                pnlmajor.Visible = false;
                cbmajor.Items.Clear();
                return;
            }
            pnlmajor.Visible= true;
            cbmajor.Items.Add("All");
            DataTable dtmajors=clsMajor.ListMajors();
            dtmajors.DefaultView.RowFilter = "DepartmentName='" + cbdepartment.Text + "'";
            foreach(DataRowView row in dtmajors.DefaultView)
            {
                cbmajor.Items.Add(row[1]);
            }
            cbmajor.SelectedIndex = 0;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        string query = "";

        void SetQuery()
        {
            string selectstatment = "select username from persons ";
            string fromtables = "";
            string wherestatment = "";

            switch (cbpersons.SelectedIndex)
            {
                case 0:
                    fromtables = "";
                    wherestatment = "";
                    break;
                case 1:
                    fromtables = " join teachers on teachers.personid=persons.personid ";
                    wherestatment = "";
                    break;
                case 2:
                    if (cbdepartment.SelectedIndex == 0)
                    {
                        fromtables = " join students on students.personid=persons.personid ";
                        wherestatment = "";
                    }
                    else
                    {
                        if (cbmajor.SelectedIndex == 0)
                        {
                            fromtables = " join students on students.personid=persons.personid join" +
                                " majors on students.majorid=majors.majorid join" +
                                " departments on departments.departmentid= majors.majorid ";
                            wherestatment = " where departments.departmentname='" + cbdepartment.Text + "' ";
                        }
                        else
                        {
                            fromtables = " join students on students.personid=persons.personid join" +
                            " majors on students.majorid=majors.majorid join" +
                            " departments on departments.departmentid= majors.majorid ";
                            wherestatment = " where majors.majorname='" + cbmajor.Text + "' ";
                        }

                    }
                    break;
            }
            query = selectstatment + fromtables + wherestatment;
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Confirm Sending?This Email Cannot Be Modified.","Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.No)
                { return; }

            SetQuery();
            string title = "", body = "";
            clsPerson Person=new clsPerson();
            foreach(DataRow row in clsPerson.GetUsernamesList(query).Rows)
            {
                Person = clsPerson.Find(row[0].ToString());

                title=txttitle.Text;
                body=txtbody.Text;
                title=title.Replace("<Name>", Person.FirsrtName);
                body=body.Replace("<Name>",Person.FirsrtName);

                if(!clsEmail.SendEmailFromAdministrator(Person.PersonID,title,body))
                {
                    MessageBox.Show("Failed");
                }
            }
            MessageBox.Show("Email Sent Successfully.","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Close();
        }

        private void txttitle_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            txtbody.Focus();
        }

        private void txtbody_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                guna2Button3.PerformClick();
        }
    }
}
