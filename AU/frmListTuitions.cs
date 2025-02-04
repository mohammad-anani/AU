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
    public partial class frmListTuitions : Form
    {
        string FilterByName = "";

        DataTable dtstudents = clsStudent.Liststudents().DefaultView.ToTable(false,"StudentID","StudentFullName");
        public frmListTuitions()
        {
            InitializeComponent();
        }

        void RefreshList()
        {
            if (FilterByName != "")
            { dtstudents.DefaultView.RowFilter = "StudentFullName like '" + FilterByName + "%'"; }
            else
                dtstudents.DefaultView.RowFilter = "";
            dgvstudents.DataSource = dtstudents;
            dgvstudents.Columns[0].HeaderText = "Student ID";
            dgvstudents.Columns[1].HeaderText = "Student Full Name";
            lbltotal.Text = dgvstudents.Rows.Count.ToString();
        }
        private void frmListTuitions_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FilterByName = textBox1.Text;
            RefreshList();
        }

        private void dgvstudents_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            clsTuitionFees tuitionfees = clsTuitionFees.Find(Convert.ToInt32(dgvstudents.SelectedRows[0].Cells[0].Value));
            if(tuitionfees.RemainingPrice==0)
            {
                MessageBox.Show("This Student Has Paid His Year Tuition Fees.","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Form frm = new frmStudentTuitionFees(tuitionfees);
            frm.ShowDialog();
        }
    }
}
