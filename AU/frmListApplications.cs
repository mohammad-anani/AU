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
    public partial class frmListApplications : Form
    {
        string FilterValue = "";
        DataTable dtActiveApplications = clsApplication.ListApplications();
        bool AllApps=false;
        public frmListApplications(bool All)
        {
            InitializeComponent();
            this.AllApps = All;
        }

        public frmListApplications()
        {
            InitializeComponent();
            
        }

        private void frmListApplications_Load(object sender, EventArgs e)
        { 
            RefreshList();
        }

     

        void ReFillList()
        {
            dtActiveApplications = clsApplication.ListApplications();
            RefreshList();
        }
        
        void RefreshList()
        {
            if(!AllApps)
            {
                if (FilterValue != "")
                {
                    dtActiveApplications.DefaultView.RowFilter ="ApplicantFullName like '" + FilterValue + "%'";

                    dtActiveApplications.DefaultView.RowFilter += " and Status='New' or Status='Accepted'";
                }
                else
                    dtActiveApplications.DefaultView.RowFilter = "Status='New' or Status='Accepted'";
            }
            else
            {
                if (FilterValue != "")
                {
                    dtActiveApplications.DefaultView.RowFilter = 
                        "ApplicantFullName like '" + FilterValue + "%'";
                }
            }

            dgvactiveapplications.DataSource = dtActiveApplications;
            dgvactiveapplications.Columns[0].HeaderText = "Application ID";
            dgvactiveapplications.Columns[1].HeaderText = "Applicant Full Name";
            dgvactiveapplications.Columns[2].HeaderText = "Application Date";
            lbltotal.Text=dgvactiveapplications.Rows.Count.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form=new frmAddApplication();
            form.ShowDialog();
            ReFillList();
        }

    

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FilterValue = textBox1.Text;
            RefreshList();
        }

        private void dgvactiveapplications_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(dgvactiveapplications.SelectedRows.Count==0)return;

            Form form = new frmApplicationInfo(Convert.ToInt32(dgvactiveapplications.SelectedRows[0].Cells[0].Value));
            form.ShowDialog();
            ReFillList();
        }
    }
}
