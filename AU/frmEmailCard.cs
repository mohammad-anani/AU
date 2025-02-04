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
    public partial class frmEmailCard : Form
    {
        public clsEmail Email=new clsEmail();
        public frmEmailCard(clsEmail email)
        {
            InitializeComponent();
            Email=email;
        }

        private void frmEmailCard_Load(object sender, EventArgs e)
        {
            if(!Email.IsOpen)
            {
                Email.OpenEmail();
            }
            ctrlEmailCard1.Email=Email;
            ctrlEmailCard1.FillInfo();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new frmSendEmail(Email.ToPerson, Email.FromPersonID);
            form.ShowDialog();
        }
    }
}
