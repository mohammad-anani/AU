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
    public partial class frmListBooks : Form
    {
        string FilterByName = "";

        DataTable dtbooks = clsBook.ListBooks();

        public frmListBooks()
        {
            InitializeComponent();
        }

        void RefreshList()
        {
            if (FilterByName != "")
            { dtbooks.DefaultView.RowFilter = "bookname like '" + FilterByName + "%' or bookauthor like '"+ FilterByName +"%'"; }
            else
                dtbooks.DefaultView.RowFilter = "";
            dgvstudents.DataSource = dtbooks;
            dgvstudents.Columns[0].HeaderText = "Book ID";
            dgvstudents.Columns[1].HeaderText = "Book Name";
            dgvstudents.Columns[2].HeaderText = "Book Author";
            dgvstudents.Columns[3].HeaderText = "Available Copies";
            lbltotal.Text = dgvstudents.Rows.Count.ToString();
        }

        private void frmListBooks_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FilterByName = textBox1.Text;
            RefreshList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateBook();
            frm.ShowDialog();
            dtbooks = clsBook.ListBooks();
            RefreshList();
        }

        private void dgvstudents_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvstudents.SelectedRows.Count == 0) return;

            Form frm = new frmAddUpdateBook(clsBook.Find(Convert.ToInt32(dgvstudents.SelectedRows[0].Cells[0].Value)));
            frm.ShowDialog();
            dtbooks = clsBook.ListBooks();
            RefreshList();
        }

        private void dgvstudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
