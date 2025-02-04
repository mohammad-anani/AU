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
    public partial class frmListBorrowings : Form
    {
        string FilterByName = "";
        bool all = false;

        DataTable dtborrowings = new DataTable();

       

        public frmListBorrowings()
        {
            InitializeComponent();
            dtborrowings=clsBorrowing.ListBorrowings(all);
        }

        public frmListBorrowings(bool all)
        {
            InitializeComponent();
            this.all = all;
            lbltitle.Text = "All Borrowings";
           dtborrowings= clsBorrowing.ListBorrowings(all);
        }

        void RefreshList()
        {
            if (dtborrowings.Rows.Count == 0) return;
            if (FilterByName != "")
            { dtborrowings.DefaultView.RowFilter = "bookname like '" + FilterByName + "%' or studentfullname like '" + FilterByName + "%'"; }
            else
                dtborrowings.DefaultView.RowFilter = "";
         
            dgvstudents.DataSource = dtborrowings;
            dgvstudents.Columns[0].HeaderText = "ID";
            dgvstudents.Columns[1].HeaderText = "Book Name";
            dgvstudents.Columns[2].HeaderText = "Student Full Name";
            dgvstudents.Columns[3].HeaderText = "Due Date";
            lbltotal.Text = dgvstudents.Rows.Count.ToString();

            if (all)
                return;

            foreach(DataGridViewRow row in dgvstudents.Rows )
            {
                if (Convert.ToDateTime(row.Cells[3].Value).Date==DateTime.Now.Date)
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                }
                else if (Convert.ToDateTime(row.Cells[3].Value).Date < DateTime.Now.Date)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }



        private void frmListBorrowings_Load(object sender, EventArgs e)
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
            Form frm = new frmAddBorrowing();
            frm.ShowDialog();
            dtborrowings = clsBorrowing.ListBorrowings(all);
            RefreshList();
        }


        private void dgvstudents_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(dgvstudents.SelectedRows.Count == 0) return;

            Form frm = new frmReturnBook(clsBorrowing.Find(Convert.ToInt32(dgvstudents.SelectedRows[0].Cells[0].Value)));
            frm.ShowDialog();
            dtborrowings = clsBorrowing.ListBorrowings(all);
            RefreshList();
        }
    }
}
