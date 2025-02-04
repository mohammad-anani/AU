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
    public partial class ctrlEmailsList : UserControl
    {
        public clsPerson Person=new clsPerson();
        public ctrlEmailsList()
        {
            InitializeComponent();
        }

        public void ListEmails()
        {
            if (Person == new clsPerson())
            {
                return;
            }
            ctrlSendEmail1.SenderPerson = Person;
            dgvReceived.DataSource = clsEmail.ListReceivedEmails(Person.PersonID);
            dgvSent.DataSource = clsEmail.ListSentEmails(Person.PersonID);
            if (dgvReceived.Columns.Count > 0 && dgvSent.Columns.Count > 0)
            {
                {
                    dgvReceived.Columns[0].HeaderText = "Email ID";
                    dgvReceived.Columns[1].HeaderText = "Sender";
                    dgvReceived.Columns[2].HeaderText = "Receiver";
                    dgvReceived.Columns[3].HeaderText = "Title";
                    dgvReceived.Columns[4].HeaderText = "Is Open";
                    dgvSent.Columns[0].HeaderText = "Email ID";
                    dgvSent.Columns[1].HeaderText = "Sender";
                    dgvSent.Columns[2].HeaderText = "Receiver";
                    dgvSent.Columns[3].HeaderText = "Title";
                }
            }
        }

        void ListReceivedEmails()
        {
            if (Person == new clsPerson())
            {
                return;
            }
            DataTable dtreceived = clsEmail.ListReceivedEmails(Person.PersonID);
            dtreceived.DefaultView.RowFilter = "senderusername like '" + textBox1 + "%' or receiverusername" +
                " like '" + textBox1.Text + "%' or title like '" + textBox1.Text + "%'";
            dgvReceived.DataSource = dtreceived;
            
            if(dgvReceived.Rows.Count > 0)
            {
                dgvReceived.Columns[0].HeaderText = "Email ID";
                dgvReceived.Columns[1].HeaderText = "Sender";
                dgvReceived.Columns[2].HeaderText = "Receiver";
                dgvReceived.Columns[3].HeaderText = "Title";
                dgvReceived.Columns[4].HeaderText = "Is Open";
            }

        }

        void ListSentEmails()
        {
            if (Person == new clsPerson())
            {
                return;
            }
            DataTable dtsent = clsEmail.ListSentEmails(Person.PersonID);
            dtsent.DefaultView.RowFilter = "senderusername like '" + textBox2 + "%' or receiverusername" +
                " like '" + textBox2.Text + "%' or title like '" + textBox2.Text + "%'";
            dgvSent.DataSource = dtsent;
            if (dgvSent.Rows.Count > 0)
            {
                dgvSent.Columns[0].HeaderText = "Email ID";
                dgvSent.Columns[1].HeaderText = "Sender";
                dgvSent.Columns[2].HeaderText = "Receiver";
                dgvSent.Columns[3].HeaderText = "Title";
            }
        }
        private void ctrlEmailsList_Load(object sender, EventArgs e)
        {
            ListEmails();
      


        }

        private void dgvSent_DoubleClick(object sender, EventArgs e)
        {
            if(dgvSent.SelectedRows.Count==0)return;

           frmSendEmail form=new frmSendEmail(clsEmail.Find(Convert.ToInt32(dgvSent.SelectedRows[0].Cells[0].Value)));
            form.ShowDialog();
            ListEmails();
        }

        

        private void dgvReceived_DoubleClick(object sender, EventArgs e)
        {
            if (dgvReceived.SelectedRows.Count == 0) return;

            Form form = new frmEmailCard(clsEmail.Find(Convert.ToInt32(dgvReceived.SelectedRows[0].Cells[0].Value)));
            form.ShowDialog();
            ListEmails();
        }

        private void ctrlSendEmail1_OnSendEvent()
        {
            ListEmails();
        }

        private void ctrlSendEmail1_Load(object sender, EventArgs e)
        {

        }

        private void dgvSent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvReceived_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ListReceivedEmails();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ListSentEmails();
        }
    }
}
