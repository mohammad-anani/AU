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
    public partial class ctrlSendEmail : UserControl
    {
        public clsPerson SenderPerson=new clsPerson();

        public string ReceiverUsername = "";

        public clsEmail Email=new clsEmail();
        public ctrlSendEmail()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtbody.Focus();
            }
        }


        public void FillComboBox()
        {
            foreach(DataRow row in clsPerson.ListUsernames().Rows)
            {
                if(row["Username"].ToString()!=SenderPerson.Username)
                { comboBox1.Items.Add(row["Username"].ToString()); }
            }
            if(ReceiverUsername=="")
            { comboBox1.SelectedIndex = 0; }
            else
            { comboBox1.SelectedIndex = comboBox1.Items.IndexOf(ReceiverUsername);
            comboBox1.Enabled=false;
            }    
        }
        
         bool ValidateNoEmptyStrings()
        {
            return txttitle.Text == "" ? false : txtbody.Text == "" ? false : true;
        }


        void SendEmail()
        {
          
            Email.FromPersonID = SenderPerson.PersonID;
            Email.ToPersonID = clsPerson.Find(comboBox1.Text).PersonID;
            Email.Title = txttitle.Text;
            Email.Body = txtbody.Text;
            if (Email.Save())
            {
                MessageBox.Show("Email Sent Successfully.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtbody.Clear();
            }
            txttitle.Clear();
        }

        void UpdateEmail()
        {
            Email.FromPersonID = SenderPerson.PersonID;
            Email.ToPersonID = clsPerson.Find(comboBox1.Text).PersonID;
            Email.Title = txttitle.Text;
            Email.Body = txtbody.Text;
            if (Email.Save())
            {
                MessageBox.Show("Email Updated Successfully.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        public event Action OnSendEvent;
        protected virtual void OnSend()
        {
            Action handler= OnSendEvent;
            if (handler != null)
            {
                OnSendEvent();
            }
        }
        private void btnsend_Click(object sender, EventArgs e)
        {
            if(SenderPerson == new clsPerson())
            {
                return;
            }
            if(!ValidateNoEmptyStrings())
            {
                MessageBox.Show("Missing Fields.","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

    
            if(Email.Mode==clsEmail.enEmailMode.Add)
            {
                SendEmail();
                
            }
            else if(Email.Mode==clsEmail.enEmailMode.Update)
            {
                UpdateEmail();
            }
            if(OnSendEvent != null)
            {
                OnSend();
            }

        }

        public void FillInfo()
        {
            if (Email.EmailID != -1)
            {
                comboBox1.SelectedIndex = comboBox1.Items.IndexOf(Email.ToPerson.Username);
                lblfrom.Text = Email.FromPerson.Username;
                txttitle.Text = Email.Title;
                txtbody.Text = Email.Body;
                comboBox1.Enabled=false;
                btnsend.Text = "Update";
            }
          
        }
        private void ctrlSendEmail_Load(object sender, EventArgs e)
        {
            FillComboBox();
            lblfrom.Text = SenderPerson.Username;
            FillInfo();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
