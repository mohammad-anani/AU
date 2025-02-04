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
    public partial class frmAdministratorScreen : Form
    {

        public delegate void OnApplyChanged(object sender);
        public event OnApplyChanged OnApply;

        public frmAdministratorScreen()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAdministratorScreen_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Form form = new frmListApplications();
            form.ShowDialog();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Form form = new frmListApplications(true);
            form.ShowDialog();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form form = new frmListPersons();
            form.ShowDialog();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Form form = new frmListStudents();
            form.ShowDialog();
        }

        private void frmAdministratorScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnApply?.Invoke(this);
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Form form = new frmSettings();
            form.ShowDialog();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Form form = new frmListTeachers();
            form.ShowDialog();
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {

            Form form = new frmEmails(clsGLobalSettings.CurrentPerson);
            form.ShowDialog();
                
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            Form form = new frmListMajors();
            form.ShowDialog();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            Form form = new frmListCourses();
            form.ShowDialog();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            Form form = new frmListScheduledCourses();
            form.ShowDialog();
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            Form form = new frmListDepartments();
            form.ShowDialog();
        }

        private void guna2Button14_Click(object sender, EventArgs e)
        {
            Form form = new frmListNews();
            form.ShowDialog();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            Form frm = new frmListTuitions();
            frm.ShowDialog();
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            Form FORM = new frmGeneralEmails();
            FORM.ShowDialog();
        }

        private void guna2Button15_Click(object sender, EventArgs e)
        {
            Form frm = new frmListGraduates();
            frm.ShowDialog();
        }

        private void guna2Button16_Click(object sender, EventArgs e)
        {
            Form from = new frmListBooks();
            from.ShowDialog();
        }

        private void guna2Button18_Click(object sender, EventArgs e)
        {

            Form frm = new frmListBorrowings(true);
            frm.ShowDialog();
        }

        private void guna2Button17_Click(object sender, EventArgs e)
        {
            Form frm = new frmListBorrowings();
            frm.ShowDialog();
        }

        private void guna2Button19_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdatePerson(clsGLobalSettings.CurrentPerson);
            frm.ShowDialog();
        }
    }
}
