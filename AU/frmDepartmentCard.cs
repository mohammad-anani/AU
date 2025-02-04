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
    public partial class frmDepartmentCard : Form
    {
        public frmDepartmentCard(clsDepartment dep)
        {
            InitializeComponent();
            lblname.Text=dep.DepartmentName;
            lblppc.Text = dep.PricePerCredit.ToString();
        }

        private void frmDepartmentCard_Load(object sender, EventArgs e)
        {

        }
    }
}
