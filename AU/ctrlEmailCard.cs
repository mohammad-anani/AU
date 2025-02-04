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
    public partial class ctrlEmailCard : UserControl
    {
        public clsEmail Email=new clsEmail();
        public ctrlEmailCard()
        {
            InitializeComponent();
        }

        public void FillInfo()
        {
            if (Email ==new clsEmail())
            {
                return;
            }
            lblfrom.Text = Email.FromPerson.Username;
            lblto.Text = Email.ToPerson.Username;
            lblbody.Text = Email.Body;
            lbltitle.Text = Email.Title;
        }

        private void ctrlEmailCard_Load(object sender, EventArgs e)
        {

        }
    }
}
