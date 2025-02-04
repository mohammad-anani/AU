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
    public partial class frmListNews : Form
    {
        string FilterByName = "";

        public frmListNews()
        {
            InitializeComponent();
        }

        DataTable dtnews=new DataTable();



        void RefillList()
        {
            dtnews = clsNews.ListNews();
            if(dtnews.Rows.Count>0 ) 
            dtnews=dtnews.DefaultView.ToTable(false, "NewsID", "Title");
        }

        void RefreshList()
        {
            if (dtnews.Rows.Count == 0) return;

            if (FilterByName != "")
            { dtnews.DefaultView.RowFilter = "Title like '" + FilterByName + "%'"; }
            else
                dtnews.DefaultView.RowFilter = "";
            dgvstudents.DataSource = dtnews;
            lbltotal.Text = dgvstudents.Rows.Count.ToString();
        }

        private void frmListNews_Load(object sender, EventArgs e)
        {
            RefillList();
            RefreshList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new frmAddUpdateNews();
            form.ShowDialog();
            RefillList();
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

            Form form = new frmAddUpdateNews(clsNews.Find(Convert.ToInt32(dgvstudents.SelectedRows[0].Cells[0].Value)));
            form.ShowDialog();
            RefillList();
            RefreshList();
        }
    }
}
