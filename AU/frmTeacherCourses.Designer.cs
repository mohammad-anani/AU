namespace AU
{
    partial class frmTeacherCourses
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
            this.ctrlTeacherCourses1 = new AU.ctrlTeacherCourses();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ctrlTeacherCourses1
            // 
            this.ctrlTeacherCourses1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ctrlTeacherCourses1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.ctrlTeacherCourses1.Location = new System.Drawing.Point(5, 101);
            this.ctrlTeacherCourses1.Margin = new System.Windows.Forms.Padding(7);
            this.ctrlTeacherCourses1.Name = "ctrlTeacherCourses1";
            this.ctrlTeacherCourses1.Size = new System.Drawing.Size(998, 468);
            this.ctrlTeacherCourses1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(36)))));
            this.label2.Location = new System.Drawing.Point(215, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(562, 76);
            this.label2.TabIndex = 21;
            this.label2.Text = "Teacher  Courses";
            // 
            // frmTeacherCourses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1008, 585);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ctrlTeacherCourses1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmTeacherCourses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTeacherCourses";
            this.Load += new System.EventHandler(this.frmTeacherCourses_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlTeacherCourses ctrlTeacherCourses1;
        private System.Windows.Forms.Label label2;
    }
}