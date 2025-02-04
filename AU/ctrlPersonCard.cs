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
    public partial class ctrlPersonCard : UserControl
    {

        public clsPerson person=new clsPerson();
        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        public void fillinfo()
        {
            if(person==new clsPerson())
            {
                return;
            }
            if(person.PersonID==clsGLobalSettings.CurrentPerson.PersonID)
            {
                llemail.Visible = false;
            }
            lblfullname.Text = person.FullName();
            lblphone.Text = person.Phone;
            lblcountry.Text = person.Country.CountryName;
            lblusername.Text = person.Username;
            lblbirth.Text = person.DateOfBirth.ToShortDateString();
            lblgender.Text = person.Gender;
            if(person.ImagePath!="")
            {
                pbimage.ImageLocation=person.ImagePath;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void ctrlPersonCard_Load(object sender, EventArgs e)
        {

        }

        private void llemail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new frmSendEmail(clsGLobalSettings.CurrentPerson, person.PersonID);
            form.ShowDialog();
        }
    }
}
