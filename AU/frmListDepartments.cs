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
    public partial class frmListDepartments : Form
    {

        string FilterByName = "";

        DataTable dtDepartments = clsDepartment.ListDepartments();
        public frmListDepartments()
        {
            InitializeComponent();
        }

        void RefreshList()
        {
            if (FilterByName != "")
            {
                dtDepartments.DefaultView.RowFilter = "DepartmentName like '" + FilterByName + "%' ";
            }
            else
                dtDepartments.DefaultView.RowFilter = "";

            dgvdepartments.DataSource = dtDepartments;
            lbltotal.Text = dgvdepartments.Rows.Count.ToString();
        }

        private void frmListDepartments_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FilterByName=textBox1.Text;
            RefreshList();
        }

        private void dgvdepartments_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvdepartments.SelectedRows.Count == 0) return;

            Form form = new frmListDepartmentsMajorsAndCourses(clsDepartment.Find(Convert.ToInt32(dgvdepartments.SelectedRows[0].Cells[0].Value)));
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new frmAddDepartment();
            form.ShowDialog();
            dtDepartments = clsDepartment.ListDepartments();
            RefreshList();
        }
    }
}
