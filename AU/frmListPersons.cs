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
    public partial class frmListPersons : Form
    {

        string FilterByName = "";

        DataTable dtpersons = clsPerson.ListPersons();
        public frmListPersons()
        {
            InitializeComponent();
        }

        void FillComboBox()
        {
        }

        void RefreshList()
        {
            if (FilterByName != "")
            { dtpersons.DefaultView.RowFilter = "FullName like '" + FilterByName + "%'"; }
            else
                dtpersons.DefaultView.RowFilter = "";
            dgvpesons.DataSource = dtpersons;
            dgvpesons.Columns[0].HeaderText = "Person ID";
            dgvpesons.Columns[1].HeaderText = "Full Name";
            lbltotal.Text=dgvpesons.Rows.Count.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson form=new frmAddUpdatePerson();
            form.ShowDialog();
            dtpersons = clsPerson.ListPersons();
            RefreshList();
        }

        private void frmListPersons_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void dgvpesons_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(dgvpesons.SelectedRows.Count==0)return;

            Form form = new frmPersonCard(clsPerson.Find(Convert.ToInt32(dgvpesons.SelectedRows[0].Cells[0].Value)));
            form.ShowDialog();
            dtpersons = clsPerson.ListPersons();
            RefreshList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FilterByName = textBox1.Text;

            RefreshList();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lbltotal_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvpesons_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
