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
    public partial class frmSendEmail : Form
    {
       clsEmail Email = new clsEmail();
        public frmSendEmail(clsEmail Email)
        {
            InitializeComponent();
            this.Email = Email;
        }

        public frmSendEmail(clsPerson fromperson,int topersonid)
        {
            InitializeComponent();
            ctrlSendEmail1.SenderPerson=fromperson;
            ctrlSendEmail1.ReceiverUsername=clsPerson.Find(topersonid).Username;
            ctrlSendEmail1.FillComboBox();
        }

        private void frmSendEmail_Load(object sender, EventArgs e)
        {
            if(this.Email.EmailID!=-1)
           { ctrlSendEmail1.Email = this.Email;
                ctrlSendEmail1.FillInfo();
            }
        }
    }
}
