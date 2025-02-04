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
    public partial class frmAddDepartment : Form
    {

        clsDepartment department = new clsDepartment();
        public frmAddDepartment()
        {
            InitializeComponent();
        }

        public frmAddDepartment(clsDepartment department)
        {
            InitializeComponent();
            this.department = department;
            label1.Text = "Update Department";
            guna2Button1.Text = "Update";
            textBox1.Text = department.DepartmentName;
            textBox2.Text = department.PricePerCredit.ToString();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || !float.TryParse(textBox2.Text,out float i))
            {
                MessageBox.Show("Missing/Invalid Fields","Error",MessageBoxButtons.OK,MessageBoxIcon.Error); return;
            }

            
            department.DepartmentName = textBox1.Text;
            department.PricePerCredit=float.Parse(textBox2.Text);

            if(department.Save())
            {
                MessageBox.Show("Department Saved Successfully.","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
                label1.Text = "Update Department";
                guna2Button1.Text = "Update";
            }
            else
                MessageBox.Show("Department Not Saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            this.Close();
        }

        private void frmAddDepartment_Load(object sender, EventArgs e)
        {

        }
    }
}
