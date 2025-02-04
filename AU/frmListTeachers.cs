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
    public partial class frmListTeachers : Form
    {
        string FilterByName = "";

        DataTable dtteachers = clsTeacher.ListTeachers();
        public frmListTeachers()
        {
            InitializeComponent();
        }


        void RefreshList()
        {
            if (FilterByName != "")
            { dtteachers.DefaultView.RowFilter = "TeacherFullName like '" + FilterByName + "%'"; }
            else
                dtteachers.DefaultView.RowFilter = "";
            dgvstudents.DataSource = dtteachers;
            lbltotal.Text = dgvstudents.Rows.Count.ToString();
        }

        private void frmListTeachers_Load(object sender, EventArgs e)
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
            Form form = new frmAddTeacher();
            form.ShowDialog();
            dtteachers = clsTeacher.ListTeachers();
            RefreshList();
        }

        private void dgvstudents_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(dgvstudents.SelectedRows.Count ==0)return;

            Form form=new frmTeacherCardForAdministrator(clsTeacher.FindTeacherByID(Convert.ToInt32(dgvstudents.SelectedRows[0].Cells[0].Value)));
            form.ShowDialog();
            dtteachers = clsTeacher.ListTeachers();
            RefreshList();
        }

        private void dgvstudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
