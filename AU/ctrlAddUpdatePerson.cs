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
    public partial class ctrlAddUpdatePerson : UserControl
    {

        public clsPerson Person=new clsPerson();

        public string fname="";

        public string sname="";

        public string lname="";

        public string phone="";

        public DateTime DateOfBirth = DateTime.MinValue;

        public string countryname = "";

        public string gender = "Male";

        public string imagepath = "";


        public ctrlAddUpdatePerson()
        {
            InitializeComponent();
        }

        private void lblchooseimage_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Images (png,jpeg,jpg)|*.png;*.jpeg:*.jpg";
            openFileDialog1.InitialDirectory=Environment.GetFolderPath(Environment.SpecialFolder.CommonPictures);
            openFileDialog1.Title = "Choose Your Image";
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbimage.ImageLocation=openFileDialog1.FileName;
                imagepath = openFileDialog1.FileName;
                lblchooseimage.Visible = false;
            }
        }

        private void pbimage_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Images (png,jpeg,jpg)|*.png;*.jpeg:*.jpg";
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonPictures);
            openFileDialog1.Title = "Choose Your Image";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbimage.ImageLocation = openFileDialog1.FileName;
                imagepath = openFileDialog1.FileName;
                lblchooseimage.Visible = false;
            }
        }

        public void FillInfo()
        {
            if(Person==new clsPerson())
            {
                return;
            }
            fname = Person.FirsrtName;
            sname = Person.SecondName;
            lname = Person.LastName;
            phone= Person.Phone;
            countryname = Person.Country.CountryName;
            DateOfBirth = Person.DateOfBirth;
            gender= Person.Gender;
            imagepath= Person.ImagePath;
            txtfname.Text = fname;
            txtsname.Text = sname;
            txtlname.Text = lname;
            txtphone.Text = phone;
            dtpdateofbirth.Value = Person.DateOfBirth;
            tglgender.Checked = (gender == "Female");
            cbcountry.SelectedIndex=cbcountry.Items.IndexOf(countryname);
            if(imagepath!="")
            {
                pbimage.ImageLocation=imagepath;
                lblchooseimage.Visible = false;
            }

        }

        void FillComboBoxWithCountries()
        {
            foreach(DataRow row in clsCountry.ListCountries().Rows)
            {
                cbcountry.Items.Add(row[1]);
            }
            cbcountry.SelectedIndex = cbcountry.Items.IndexOf("Lebanon");
        }

        private void ctrlAddUpdatePerson_Load(object sender, EventArgs e)
        {
            FillComboBoxWithCountries();
            dtpdateofbirth.MaxDate = DateTime.Now.AddYears(-17);
            dtpdateofbirth.MinDate = DateTime.Now.AddYears(-100);
        }

        private void txtfname_TextChanged(object sender, EventArgs e)
        {
            fname=txtfname.Text;
        }

        private void txtsname_TextChanged(object sender, EventArgs e)
        {
            sname=txtsname.Text;
        }

        private void txtlname_TextChanged(object sender, EventArgs e)
        {
            lname=txtlname.Text;
        }

        private void txtphone_TextChanged(object sender, EventArgs e)
        {
            phone=txtphone.Text;
        }

        private void dtpdateofbirth_ValueChanged(object sender, EventArgs e)
        {
            DateOfBirth=dtpdateofbirth.Value;
        }

        private void tglgender_CheckedChanged(object sender, EventArgs e)
        {
            if (tglgender.Checked)
            {
                gender = "Female";
            }
            else
                gender = "Male";
        }

        public bool IsValidatedNoEmptyBoxes()
        {
            return txtfname.Text == "" ? false : txtsname.Text == "" ? false :
                txtlname.Text == "" ? false : txtphone.Text == "" ? false : true;

        }

        private void txtfname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtsname.Focus();
            }
        }

        private void txtsname_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtlname.Focus();
            }
        }

        private void txtlname_KeyDown(object sender, KeyEventArgs e)
        {
            if( e.KeyCode == Keys.Enter)
            {
                txtphone.Focus();
            }
        }

        private void cbcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            countryname = cbcountry.Text;
        }
    }
}
