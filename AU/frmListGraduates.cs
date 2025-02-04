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
    public partial class frmListGraduates : Form
    {
        string FilterByName = "";

        DataTable dtGrads = clsGraduate.ListGrads();
        public frmListGraduates()
        {
            InitializeComponent();
        }

        void RefreshList()
        {
            if (FilterByName != "")
            { dtGrads.DefaultView.RowFilter = "StudentFullName like '" + FilterByName + "%'"; }
            else
                dtGrads.DefaultView.RowFilter = "";
            dgvstudents.DataSource = dtGrads;
            dgvstudents.Columns[0].HeaderText = "Student ID";
            dgvstudents.Columns[1].HeaderText = "Student Full Name";
            dgvstudents.Columns[2].HeaderText = "Graduation Date";
            lbltotal.Text = dgvstudents.Rows.Count.ToString();
        }

        private void frmListGraduates_Load(object sender, EventArgs e)
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
            if (dgvstudents.SelectedRows.Count == 0) return;

            Form form = new frmStudentCard(clsStudent.FindStudentByID(Convert.ToInt32(dgvstudents.SelectedRows[0].Cells[0].Value)));
            form.ShowDialog();
        }
    }
}
