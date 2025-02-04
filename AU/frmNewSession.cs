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
    public partial class frmNewSession : Form
    {
        public clsScheduledCourse ScheduledCourse=new clsScheduledCourse();
        public frmNewSession(int scheduledcourseid)
        {
            InitializeComponent();
            ScheduledCourse=clsScheduledCourse.Find(scheduledcourseid);
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmNewSession_Load(object sender, EventArgs e)
        {
            DataTable dtstudents = clsSession.ListStudentsAttendances(ScheduledCourse.ScheduledCourseID);
            
            lblcoursename.Text=ScheduledCourse.Course.CourseName;
            lbldate.Text = DateTime.Now.ToString();
            if(dtstudents.Rows.Count > 0)
            {
                dtstudents.Columns.Add("Is Present", typeof(bool));
                dataGridView1.DataSource = dtstudents;
                dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = false;
            dataGridView1.Columns[0].HeaderText = "Student ID";
                dataGridView1.Columns[1].HeaderText = "Student Full Name";
            }
          
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm Save?These Informations Cannot Be Changed!", "Attention",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int NewSessionID = clsSession.AddSession(ScheduledCourse.ScheduledCourseID, DateTime.Now);
            if (NewSessionID==-1)
            {
                MessageBox.Show("Error In Adding New Session","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            bool Ispresent=false;

            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                Ispresent = row.Cells[2].Value == DBNull.Value ? false : true;
                if (!clsSession.GetStudentAttendance(NewSessionID, Convert.ToInt32(row.Cells[0].Value),
                    Ispresent))
                    {
                    MessageBox.Show("Error In Adding New Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            MessageBox.Show("Session Successfully Saved.");
            this.Close();

        }
    }
}
