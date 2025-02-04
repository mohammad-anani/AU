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
    public partial class frmAddExam : Form
    {
        int numberofQuestions = 0;
        public frmAddExam()
        {
            InitializeComponent();
        }

        private void frmAddExam_Load(object sender, EventArgs e)
        {
            foreach(DataRow row in clsScheduledCourse.ListScheduledCoursesForteacher(clsGLobalSettings.CurrentTeacher.TeacherID).Rows)
            {
                cbcourses.Items.Add(row[0].ToString() + "-" + row[1].ToString());
            }
            cbcourses.SelectedIndex = 0;
      

            for(int i=0;i<5;i++)
            {
                numberofQuestions++;
                dataGridView1.Rows.Add(numberofQuestions, false, false, false, false);
            }
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (numberofQuestions == numericUpDown1.Value)
            {
                dataGridView1.AllowUserToAddRows = false;
            }
            numberofQuestions++;
            e.Row.Cells[0].Value = numberofQuestions;
            
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           

        
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

        

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count>numericUpDown1.Value)
            {
                    dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count-1);
                numberofQuestions--;
                
            }

            if(dataGridView1.Rows.Count<numericUpDown1.Value)
            {
                numberofQuestions++;
                dataGridView1.Rows.Add(numberofQuestions, false, false, false, false);
            }
        }

        bool ValidateQuestions()
        {
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                for(int i=1;i<=4;i++)
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
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(!ValidateQuestions())
            {
                MessageBox.Show("Missing Fields.","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsExam Exam=new clsExam();
            Exam.ScheduledCourseID = clsScheduledCourse.Find(Convert.ToInt32(cbcourses.Text.Substring(0, cbcourses.Text.IndexOf("-")))).ScheduledCourseID;
            Exam.Duration = (int)numericUpDown2.Value;
            Exam.Code = Guid.NewGuid().ToString().Substring(0, 4);
            if(!Exam.AddExam())
            {
                MessageBox.Show("Exam Not Saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            int rightanswer = -1;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
               
                for(int i=1;i<=4; i++)
                {
                    if (Convert.ToBoolean(row.Cells[i].Value))
                    {
                        rightanswer = i;
                    }
                }
                if(!clsQuestion.AddQuestion(Convert.ToInt32(row.Cells[0].Value),Exam.ExamID,rightanswer))
                {
                    MessageBox.Show("Exam Not Saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }

            MessageBox.Show("Exam Saved Successfully With Code='" + Exam.Code + "'.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void cbcourses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
