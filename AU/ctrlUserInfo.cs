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
    public partial class ctrlUserInfo : UserControl
    {
        public string username = "";
        public string password = "";
        public clsPerson Person=new clsPerson();
        public ctrlUserInfo()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {
            username = txtusername.Text;
        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {
            password = txtpassword.Text;
        }

        private void txtusername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtpassword.Focus();
            }
        }

        private void txtpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtconfirm.Focus();
            }
        }


        public void FillInfo()
        {
            if (Person.PersonID == -1)
            {
                return;
            }
            username = Person.Username;
            password = Person.Password;
            txtusername.Text = username;
            txtpassword.Text = password;
            txtconfirm.Text = password;
        }

        public bool ValidateNoEmptyStrings()
        {
            return txtusername.Text == "" ? false :txtpassword.Text==""?false: txtconfirm.Text == "" ? false : true;
        }

        public bool IsSamePasswords()
        {
            return txtconfirm.Text==txtpassword.Text;
        }

        public bool IsUsernameExist()
        {
        return clsPerson.UsernameExists(username);
        }

        private void ctrlUserInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
