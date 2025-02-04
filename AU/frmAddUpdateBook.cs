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
    public partial class frmAddUpdateBook : Form
    {
        clsBook Book =new clsBook();
        public frmAddUpdateBook()
        {
            InitializeComponent();
        }

        public frmAddUpdateBook(clsBook Book)
        {
            InitializeComponent();
            this.Book = Book;
            lbltitle.Text = "Update Book";
            guna2Button1.Text = "Update";
            textBox1.Text = Book.BookName;
            textBox2.Text = Book.BookAuthor;
            numericUpDown1.Value = Book.NumberOfCopies;
            numericUpDown1.Minimum = Book.NumberOfCopies - Book.AvailableCopies;
        }

        private void frmAddUpdateBook_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) textBox2.Focus();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(textBox1.TextLength==0 || textBox2.TextLength==0)
            {
                MessageBox.Show("Missing Fields.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Confrim Save?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            Book.BookName = textBox1.Text;
            Book.BookAuthor = textBox2.Text;
            Book.NumberOfCopies = (int)numericUpDown1.Value;

            if(Book.Save())
            {
                MessageBox.Show("Book Successfully Saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Confirm Delete?","Attention",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No) return;

            if (clsBook.DeleteBook(Book.BookID))
            {
                MessageBox.Show("Book Deleted.");
            }
            else
                MessageBox.Show("Error");
            this.Close();
        }
    }
}
