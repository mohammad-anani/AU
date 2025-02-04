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
    public partial class frmAddUpdatePerson : Form
    {
      public clsPerson Person =new clsPerson();
        public frmAddUpdatePerson(clsPerson person)
        {
            InitializeComponent();
            Person = person;
        }

        public frmAddUpdatePerson()
        {
            InitializeComponent();
            Person=new clsPerson();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(!ctrlAddUpdatePerson1.IsValidatedNoEmptyBoxes() || !ctrlUserInfo1.ValidateNoEmptyStrings())
            {
                MessageBox.Show("Missing Fields.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (!ctrlUserInfo1.IsSamePasswords())
            { 
                MessageBox.Show("Passwords Don't Match","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(ctrlUserInfo1.IsUsernameExist() && ctrlUserInfo1.username!=Person.Username)
            {
                MessageBox.Show("Username Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Person.FirsrtName = ctrlAddUpdatePerson1.fname;
            Person.SecondName = ctrlAddUpdatePerson1.sname;
            Person.LastName = ctrlAddUpdatePerson1.lname;
            Person.Gender = ctrlAddUpdatePerson1.gender;
            Person.CountryID = clsCountry.Find(ctrlAddUpdatePerson1.countryname).CountryID;
            Person.ImagePath = ctrlAddUpdatePerson1.imagepath;
            Person.Phone = ctrlAddUpdatePerson1.phone;
            Person.DateOfBirth = ctrlAddUpdatePerson1.DateOfBirth;
            Person.Username = ctrlUserInfo1.username;
            Person.Password = ctrlUserInfo1.password;
            if (Person.Save())
            {
                MessageBox.Show("Person Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }

            this.Close();
        }

        

        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {
            if (Person.PersonID != -1)
            {
                ctrlAddUpdatePerson1.Person = Person;
                ctrlAddUpdatePerson1.FillInfo();
                ctrlUserInfo1.Person = Person;
                ctrlUserInfo1.FillInfo();
                guna2Button1.Text = "Update";
            }
            else
                guna2Button1.Text = "Add";

        }
    }
}
