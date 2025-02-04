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
    public partial class frmTakeExam : Form
    {
        clsExam Exam=new clsExam();
        int minutes = 0;
        int seconds = 0;
        int rightanswers = 0;

        public frmTakeExam(clsExam Exam)
        {
            InitializeComponent();
            this.Exam = Exam;
            minutes = Exam.Duration;
            lbltime.Text = minutes.ToString("D2") + ":" + seconds.ToString("D2");
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 1:
                    dataGridView1.Rows[e.RowIndex].Cells[2].Value = false;
                    dataGridView1.Rows[e.RowIndex].Cells[3].Value = false;
                    dataGridView1.Rows[e.RowIndex].Cells[4].Value = false;
                    break;
                case 2:
                    dataGridView1.Rows[e.RowIndex].Cells[1].Value = false;
                    dataGridView1.Rows[e.RowIndex].Cells[3].Value = false;
                    dataGridView1.Rows[e.RowIndex].Cells[4].Value = false;
                    break;
                case 3:
                    dataGridView1.Rows[e.RowIndex].Cells[1].Value = false;
                    dataGridView1.Rows[e.RowIndex].Cells[2].Value = false;
                    dataGridView1.Rows[e.RowIndex].Cells[4].Value = false;
                    break;
                case 4:
                    dataGridView1.Rows[e.RowIndex].Cells[1].Value = false;
                    dataGridView1.Rows[e.RowIndex].Cells[3].Value = false;
                    dataGridView1.Rows[e.RowIndex].Cells[2].Value = false;
                    break;
            }
        }

        bool AreAllQuestionsAnswered()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                for (int i = 1; i <= 4; i++)
                {
                    if (Convert.ToBoolean(row.Cells[i].Value))
                    {
                        break;
                    }

                    if (i == 4) return false;
                }

            }
            return true;
        }

        private void frmTakeExam_Load(object sender, EventArgs e)
        {
            for(int i=1;i<=Exam.NumberOfQuestions; i++)
            {
                dataGridView1.Rows.Add(i, false, false, false, false);
            }
            timer1.Enabled = true;
        }

        

        private void label1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

       

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            if (seconds == 0 && minutes == 0)
            {
                timer1.Enabled = false;
                dataGridView1.Enabled = false;
                MessageBox.Show("Time Over!\n", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CorrectExam();
            }

            if (seconds == 0)
            {
                minutes--;
                seconds = 60;
            }
            seconds--;
            lbltime.Text = minutes.ToString("D2") + ":" + seconds.ToString("D2");
            
            
        }

        void CorrectExam()
        {
            
            DataTable dtquestions = clsQuestion.GetAnswers(Exam.ExamID);

            for (int i = 0; i < Exam.NumberOfQuestions; i++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[Convert.ToInt32(dtquestions.Rows[i][0])].Value))
                {
                    rightanswers++;
                }
            }
            CalculateGrade();
        }

        void CalculateGrade()
        {
            if(clsEnrolledCourse.SetGrade(clsEnrolledCourse.Find(Exam.ScheduledCourseID, clsGLobalSettings.CurrentStudent.StudentID).EnrolledCourseID, (float)(rightanswers*100) / (float)Exam.NumberOfQuestions))
            {
                MessageBox.Show("Exam Successfully Submitted and Corrected.Please Chek Your Grade in Courses Tab.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(!AreAllQuestionsAnswered())
            {
                if (MessageBox.Show("You Still Have Unanswered Questions.Confirm Submit?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) 
                { return; }
            }
            else
             if (MessageBox.Show("Confirm Submit?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            { return; }


            dataGridView1.Enabled = false;
            timer1.Enabled=false;


            CorrectExam();
        }
        
     
    }
}
