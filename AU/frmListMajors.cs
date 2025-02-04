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
    public partial class frmListMajors : Form
    {
        string FilterByName = "";

        DataTable dtMajors=clsMajor.ListMajors().DefaultView.ToTable(false,"MajorID","MajorName");
        public frmListMajors()
        {
            InitializeComponent();
        }

        void RefreshList()
        {
            if (FilterByName != "")
            { dtMajors.DefaultView.RowFilter = "MajorName like '" + FilterByName + "%'"; }
            else
                dtMajors.DefaultView.RowFilter = "";
            dgvmajors.DataSource = dtMajors;
            lbltotal.Text = dgvmajors.Rows.Count.ToString();
        }

        private void frmListMajors_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FilterByName = textBox1.Text;
            RefreshList();
        }

        private void dgvmajors_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvmajors.SelectedRows.Count == 0) return;

            Form form = new frmMajorCardForAdministrator(clsMajor.Find(Convert.ToInt32(dgvmajors.SelectedRows[0].Cells[0].Value)));
            form.ShowDialog();
            dtMajors = clsMajor.ListMajors().DefaultView.ToTable(false, "MajorID", "MajorName");
            RefreshList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new frmAddMajor();
            form.ShowDialog();
            dtMajors = clsMajor.ListMajors().DefaultView.ToTable(false, "MajorID", "MajorName");
            RefreshList();
        }

        private void dgvmajors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
