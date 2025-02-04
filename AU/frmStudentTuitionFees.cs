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
    public partial class frmStudentTuitionFees : Form
    {
        clsTuitionFees tuitionFees=new clsTuitionFees();
        public frmStudentTuitionFees(clsTuitionFees tuitionFees)
        {
            InitializeComponent();
            this.tuitionFees = tuitionFees;

        }

        private void frmStudentTuitionFees_Load(object sender, EventArgs e)
        {
            ctrlStudentCard1.Student=tuitionFees.Student;
            ctrlStudentCard1.FillInfo();
            lblyearprice.Text = (tuitionFees.Student.YearPrice * ((double)1 - (double)tuitionFees.Student.Scholarship / (double)100)).ToString();
            lblpaid.Text=tuitionFees.YearlyPaid.ToString();
            lblremaining.Text=tuitionFees.RemainingPrice.ToString();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(!double.TryParse(txtwillpay.Text, out double value))
            {
                MessageBox.Show("Missing/Invalid Fields!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error); 
                return;
            }

            if(Convert.ToSingle(txtwillpay.Text)>(float)tuitionFees.RemainingPrice)
            {
                MessageBox.Show("Amount Exceeds Remaining Price!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tuitionFees.YearlyPaid+=Convert.ToDouble(txtwillpay.Text);
            tuitionFees.RemainingPrice = tuitionFees.RemainingPrice - Convert.ToDouble(txtwillpay.Text);
            if (!tuitionFees.UpdateTuitions())
            {
                MessageBox.Show("Amount Not Paid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Amount Successfully Paid", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblpaid.Text = tuitionFees.YearlyPaid.ToString();
            lblremaining.Text = tuitionFees.RemainingPrice.ToString();
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new frmCurrencyExchange();
            form.ShowDialog();
        }

        private void ctrlStudentCard1_Load(object sender, EventArgs e)
        {

        }
    }
}
