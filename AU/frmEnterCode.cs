using AU_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AU
{
    public partial class frmEnterCode : Form
    {
        
        clsScheduledCourse course=new clsScheduledCourse();
        public frmEnterCode(clsScheduledCourse scheduledcourse)
        {
            InitializeComponent();
            lblexam.Text = scheduledcourse.Course.CourseName;
            this.course = scheduledcourse;
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode != Keys.Back)
            textBox2.Focus();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back && textBox2.TextLength == 0)
            {
                textBox1.Focus();
            }
            if (e.KeyCode != Keys.Back)
                textBox3.Focus();
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back &&textBox4.TextLength==0)
            {
                textBox3.Focus();
            }
         
             
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back && textBox3.TextLength == 0)
            {
                textBox2.Focus();
            }
            if (e.KeyCode != Keys.Back)
                textBox4.Focus();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            clsExam Exam = clsExam.Find(textBox1.Text + textBox2.Text + textBox3.Text + textBox4.Text,course.ScheduledCourseID);
           if (Exam.ExamID==-1)
            {
                MessageBox.Show("Incorrect Exam Code","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Focus();
                return;
            }

            if(MessageBox.Show("Start Exam?You cannot cancel your exam.","Attention",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.No)
                { return; }

            Form frm=new frmTakeExam(Exam);
            frm.ShowDialog();
            this.Close();
        }

     

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if(textBox4.Text.Length!=0)
            guna2Button1.PerformClick();
        }
    }
}
