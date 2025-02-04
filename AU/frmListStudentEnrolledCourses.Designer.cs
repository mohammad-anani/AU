namespace AU
{
    partial class frmListStudentEnrolledCourses
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrlStudentCoursesTab1 = new AU.ctrlStudentCoursesTab();
            this.SuspendLayout();
            // 
            // ctrlStudentCoursesTab1
            // 
            this.ctrlStudentCoursesTab1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ctrlStudentCoursesTab1.Location = new System.Drawing.Point(0, -2);
            this.ctrlStudentCoursesTab1.Name = "ctrlStudentCoursesTab1";
            this.ctrlStudentCoursesTab1.Size = new System.Drawing.Size(1373, 744);
            this.ctrlStudentCoursesTab1.TabIndex = 0;
            // 
            // frmListStudentEnrolledCourses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1372, 754);
            this.Controls.Add(this.ctrlStudentCoursesTab1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmListStudentEnrolledCourses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student Enrolled Courses";
            this.Load += new System.EventHandler(this.frmListStudentEnrolledCourses_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlStudentCoursesTab ctrlStudentCoursesTab1;
    }
}