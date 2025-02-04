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
    public partial class frmReturnBook : Form
    {

        clsBorrowing Borrowing =new clsBorrowing();
        public frmReturnBook(clsBorrowing borrowing)
        {
            InitializeComponent();

            Borrowing = borrowing;
            lblbook.Text = borrowing.Book.BookName;
            lblstudent.Text = borrowing.Student.Person.FullName();
            lblborrowdate.Text = borrowing.BorrowDate.ToShortDateString();
            lblduedate.Text=borrowing.DueDate.ToShortDateString();
           
            

            if (Borrowing.ReturnDate!=DateTime.MinValue )
            {
                btnSave.Visible = false;
                checkBox1.Visible = false;
                guna2RatingStar1.Value = (float)Borrowing.Rating;
                guna2RatingStar1.Enabled= false;
                lbltotalfees.Text=borrowing.PaidFees.ToString();
                lblreturn.Text = borrowing.ReturnDate.ToShortDateString();

                int latedays = (borrowing.ReturnDate - borrowing.DueDate).Days;

                if (latedays > 0)
                {
                    lbllatedays.Text = latedays.ToString();
                    lblfeeperday.Text = (Convert.ToInt32(lbltotalfees.Text) / Convert.ToInt32(lbllatedays.Text)).ToString();
                }
            }
            else
            {
                string Activated = File.ReadAllText("AU_Settings.txt");
                int LateDays = (DateTime.Now - borrowing.DueDate).Days;
                lblfeeperday.Text = Activated.Substring(9, 2);

                if (LateDays > 0)
                {
                    lbllatedays.Text = LateDays.ToString();
                    lbltotalfees.Text = (Convert.ToInt32(lblfeeperday.Text) * LateDays).ToString();

                }
                else
                {
                    checkBox1.Checked = true;
                    checkBox1.Visible = false;
                }

            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void frmReturnBook_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!checkBox1.Checked)
            {
                MessageBox.Show("Student Should Pay Late Return Fees", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(guna2RatingStar1.Value==0)
            {
                MessageBox.Show("Please Rate Book", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }    

            Borrowing.PaidFees=(lbltotalfees.Text=="N/A"?0:Convert.ToDouble(lbltotalfees.Text));
            Borrowing.Rating = guna2RatingStar1.Value;

            if(Borrowing.ReturnBook())
            {
                MessageBox.Show("Book Successfully Returned.","Message",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error");
            }
            this.Close();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmSendEmail(clsGLobalSettings.CurrentPerson, Borrowing.Student.PersonID);
            frm.ShowDialog();
        }
    }
}
