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
    public partial class ctrlApplicationMajor : UserControl
    {
        public string department = "";
        public string major = "";
        public ctrlApplicationMajor()
        {
            InitializeComponent();
        }


        void FillDepartmentComboBox()
        {
            foreach(DataRow row in clsDepartment.ListDepartments().Rows)
            {
                cbDepartments.Items.Add(row[1]);
            }
        


            

        }
        private void ctrlApplicationMajor_Load(object sender, EventArgs e)
        {
            FillDepartmentComboBox();
        }

        public bool ValidateMajor()
        {
            return cbMajors.SelectedIndex >= 0;
        }

        void FillMajorsComboBox()
        {
            cbMajors.Items.Clear();
           DataTable dtmajors=clsMajor.ListMajors();
            dtmajors.DefaultView.RowFilter = "departmentname like '" + cbDepartments.Text + "'";
            foreach (DataRow row in dtmajors.DefaultView.ToTable(false,"majorname").Rows)
            {
                cbMajors.Items.Add(row[0]);
            }
            
        }

        private void cbDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            department = cbDepartments.Text;
            FillMajorsComboBox();
        }

        private void cbMajors_SelectedIndexChanged(object sender, EventArgs e)
        {
            major = cbMajors.Text;
            ctrlMajorCard1.major = clsMajor.Find(major);
            ctrlMajorCard1.FillInfo();
        }
    }
}
