namespace AU
{
    partial class frmStudentSessions
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
            this.ctrlStudentSessions1 = new AU.ctrlStudentSessions();
            this.SuspendLayout();
            // 
            // ctrlStudentSessions1
            // 
            this.ctrlStudentSessions1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ctrlStudentSessions1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.ctrlStudentSessions1.Location = new System.Drawing.Point(-3, 11);
            this.ctrlStudentSessions1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ctrlStudentSessions1.Name = "ctrlStudentSessions1";
            this.ctrlStudentSessions1.Size = new System.Drawing.Size(989, 680);
            this.ctrlStudentSessions1.TabIndex = 0;
            // 
            // frmStudentSessions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(998, 853);
            this.Controls.Add(this.ctrlStudentSessions1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmStudentSessions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student Sessions";
            this.Load += new System.EventHandler(this.frmStudentSessions_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlStudentSessions ctrlStudentSessions1;
    }
}