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
    public partial class ctrlAddApplication : UserControl
    {
        public string grade11avg = "";
        public string grade12avg = "";
        public string grade10avg = "";
        public string bacavg ="";
        public string grade12spec = clsApplication.ConvertGrade12Specialization(1);
        public string grade12school = "";

        public ctrlAddApplication()
        {
            InitializeComponent();
        }

        void FillComboBoxWithSpec()
        {

            cbspecialization.Items.Add(clsApplication.ConvertGrade12Specialization(1));
            cbspecialization.Items.Add(clsApplication.ConvertGrade12Specialization(2));
            cbspecialization.Items.Add(clsApplication.ConvertGrade12Specialization(3));
            cbspecialization.Items.Add(clsApplication.ConvertGrade12Specialization(4));
            cbspecialization.SelectedIndex = 0;

        }
        private void ctrlAddApplication_Load(object sender, EventArgs e)
        {
            FillComboBoxWithSpec();

        }

        private void txt10_TextChanged(object sender, EventArgs e)
        {
            grade10avg=txt10.Text;
        }

        private void txt10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt11.Focus();
            }
        }

        private void txt11_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txt12school.Focus();
            }
        }

        private void txt12grade_KeyDown(object sender, KeyEventArgs e)
        {
            if( e.KeyCode == Keys.Enter)
            {
                txtbac.Focus();
            }
        }

        private void txt11_TextChanged(object sender, EventArgs e)
        {
            grade11avg=txt11.Text;
        }

        private void txt12school_TextChanged(object sender, EventArgs e)
        {
            grade12school=txt12school.Text;
        }

        private void cbspecialization_SelectedIndexChanged(object sender, EventArgs e)
        {
            grade12spec = cbspecialization.Text;
        }

        private void txt12grade_TextChanged(object sender, EventArgs e)
        {
            grade12avg=txt12grade.Text;
        }

        private void txtbac_TextChanged(object sender, EventArgs e)
        {
            bacavg=txtbac.Text;
        }

        public bool IsAllStringFloatValues()
        {
            return !float.TryParse(grade10avg, out float val) || val>100 ? false :
                   !float.TryParse(grade11avg, out float v) ||v>100? false :
                   !float.TryParse(grade12avg, out float va) || va>100? false :
                   !float.TryParse(bacavg, out float valu) || valu>100? false :
                   grade12school == "" ? false : true;
        }
    }
}
