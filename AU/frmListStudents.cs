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
    public partial class frmListStudents : Form
    {
        string FilterByName = "";

        DataTable dtstudents = clsStudent.Liststudents();
        public frmListStudents()
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
        private void frmListStudents_Load(object sender, EventArgs e)
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
            if(dgvstudents.SelectedRows.Count == 0)return;

            Form form=new frmStudentCard(clsStudent.FindStudentByID(Convert.ToInt32(dgvstudents.SelectedRows[0].Cells[0].Value)));
            form.ShowDialog();
            dtstudents = clsStudent.Liststudents();
            RefreshList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new frmAddStudent();
            form.ShowDialog();
            dtstudents = clsStudent.Liststudents();
            RefreshList();
        }
    }
}
