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
    public partial class frmPersonScreen : Form
    {
       
        public frmPersonScreen()
        {
            InitializeComponent();
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPersonScreen_Load(object sender, EventArgs e)
        {
            if(clsGLobalSettings.CurrentPerson.ImagePath!="")
            {
                pbimage.ImageLocation= clsGLobalSettings.CurrentPerson.ImagePath;
            }
           label2.Text = clsGLobalSettings.CurrentPerson.Username;
            ctrlPersonCard1.person = clsGLobalSettings.CurrentPerson;
            ctrlPersonCard1.fillinfo();
            ctrlApplicationInfo1.application=clsApplication.FindByPersonID(clsGLobalSettings.CurrentPerson.PersonID);
            ctrlApplicationInfo1.FillInfo();
            ctrlEmailsList1.Person = clsGLobalSettings.CurrentPerson;
            guna2TabControl1.SelectedIndex = 4;

        }

        private void guna2TabControl1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void guna2TabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (guna2TabControl1.SelectedIndex == 8)
            {
                this.Close();
            }
        }

        private void guna2VSeparator1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form form = new frmAddUpdatePerson(clsGLobalSettings.CurrentPerson);
            form.ShowDialog();
            ctrlPersonCard1.fillinfo();
        }

        private void ctrlNews1_Load(object sender, EventArgs e)
        {
            ctrlNews1.FillInfo();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
