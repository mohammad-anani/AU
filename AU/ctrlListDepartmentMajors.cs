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
    public partial class ctrlListDepartmentMajors : UserControl
    {
        public ctrlListDepartmentMajors()
        {
            InitializeComponent();
        }

        public clsDepartment Department=new clsDepartment();

        public DataTable dtMajors=new DataTable();

        public void FillInfo()
        {
            label5.Text = Department.DepartmentName.Insert(Department.DepartmentName.IndexOf(" ")+1, "\n");
             dtMajors.DefaultView.RowFilter = "departmentname='"+Department.DepartmentName+"'";
            DataTable dtengineering = dtMajors.DefaultView.ToTable(false, "MajorName");
            dgvengineering.DataSource = dtengineering;
        }

        private void dgvengineering_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvengineering_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form form = new frmMajorCard(clsMajor.Find(dgvengineering.SelectedRows[0].Cells[0].Value.ToString()));
            form.ShowDialog();
        }
    }
}
