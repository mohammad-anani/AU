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
    public partial class frmAddBorrowing : Form
    {
        public frmAddBorrowing()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                clsStudent student = clsStudent.FindStudentByPersonID(clsPerson.Find(textBox1.Text).PersonID);
                if(student.StudentID==-1)
                {
                    MessageBox.Show("Student Not Found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    ctrlStudentCard1.Student=student;
                    ctrlStudentCard1.FillInfo();
                }
            }
        }

        private void frmAddBorrowing_Load(object sender, EventArgs e)
        {
            foreach(DataRow row in clsBook.ListBooks().Rows)
            {
                if (Convert.ToInt32(row[3])>0)
                comboBox1.Items.Add(row[1].ToString() + "-" + row[2].ToString());
            }
            comboBox1.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(ctrlStudentCard1.Student.StudentID==-1)
            {
                MessageBox.Show("Missing Fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsBorrowing borrowing = new clsBorrowing();
            borrowing.BookID = comboBox1.SelectedIndex + 1;
            borrowing.StudentID = ctrlStudentCard1.Student.StudentID;

            if (borrowing.AddBorrorwing())
            {
                MessageBox.Show("Book Successfully Borrowed.\nBook Should Be Returned on " + borrowing.DueDate.ToShortDateString() + ".", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error");

            this.Close();
        }
    }
}
