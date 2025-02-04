namespace AU
{
    partial class frmStudentCard
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblcompletedcourses = new System.Windows.Forms.Label();
            this.btnsessions = new Guna.UI2.WinForms.Guna2Button();
            this.btnadvance = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.ctrlStudentCard1 = new AU.ctrlStudentCard();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.btngraduate = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(12, 399);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 58);
            this.label1.TabIndex = 1;
            this.label1.Text = "Year \r\nCompleted Courses:";
            // 
            // lblcompletedcourses
            // 
            this.lblcompletedcourses.AutoSize = true;
            this.lblcompletedcourses.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblcompletedcourses.Location = new System.Drawing.Point(262, 428);
            this.lblcompletedcourses.Name = "lblcompletedcourses";
            this.lblcompletedcourses.Size = new System.Drawing.Size(55, 29);
            this.lblcompletedcourses.TabIndex = 2;
            this.lblcompletedcourses.Text = "N/A";
            // 
            // btnsessions
            // 
            this.btnsessions.Animated = true;
            this.btnsessions.AutoRoundedCorners = true;
            this.btnsessions.BorderRadius = 31;
            this.btnsessions.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnsessions.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnsessions.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnsessions.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnsessions.FillColor = System.Drawing.Color.Turquoise;
            this.btnsessions.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.btnsessions.ForeColor = System.Drawing.Color.Black;
            this.btnsessions.Location = new System.Drawing.Point(398, 475);
            this.btnsessions.Name = "btnsessions";
            this.btnsessions.Size = new System.Drawing.Size(203, 64);
            this.btnsessions.TabIndex = 7;
            this.btnsessions.Text = "View Sessions";
            this.btnsessions.Click += new System.EventHandler(this.btnsessions_Click);
            // 
            // btnadvance
            // 
            this.btnadvance.Animated = true;
            this.btnadvance.AutoRoundedCorners = true;
            this.btnadvance.BorderRadius = 31;
            this.btnadvance.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnadvance.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnadvance.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnadvance.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnadvance.FillColor = System.Drawing.Color.Lime;
            this.btnadvance.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.btnadvance.ForeColor = System.Drawing.Color.Black;
            this.btnadvance.Location = new System.Drawing.Point(607, 475);
            this.btnadvance.Name = "btnadvance";
            this.btnadvance.Size = new System.Drawing.Size(203, 64);
            this.btnadvance.TabIndex = 8;
            this.btnadvance.Text = "Advance Year";
            this.btnadvance.Click += new System.EventHandler(this.btnadvance_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.Animated = true;
            this.guna2Button1.AutoRoundedCorners = true;
            this.guna2Button1.BorderRadius = 31;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.Turquoise;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.guna2Button1.ForeColor = System.Drawing.Color.Black;
            this.guna2Button1.Location = new System.Drawing.Point(41, 475);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(351, 64);
            this.guna2Button1.TabIndex = 9;
            this.guna2Button1.Text = "View Enrolled Courses";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // ctrlStudentCard1
            // 
            this.ctrlStudentCard1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ctrlStudentCard1.Location = new System.Drawing.Point(2, 3);
            this.ctrlStudentCard1.Name = "ctrlStudentCard1";
            this.ctrlStudentCard1.Size = new System.Drawing.Size(818, 410);
            this.ctrlStudentCard1.TabIndex = 0;
            // 
            // guna2Button2
            // 
            this.guna2Button2.Animated = true;
            this.guna2Button2.AutoRoundedCorners = true;
            this.guna2Button2.BorderColor = System.Drawing.Color.DimGray;
            this.guna2Button2.BorderRadius = 33;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.Red;
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.guna2Button2.ForeColor = System.Drawing.Color.Black;
            this.guna2Button2.Location = new System.Drawing.Point(607, 545);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(203, 68);
            this.guna2Button2.TabIndex = 57;
            this.guna2Button2.Text = "Delete";
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // guna2Button3
            // 
            this.guna2Button3.Animated = true;
            this.guna2Button3.AutoRoundedCorners = true;
            this.guna2Button3.BorderRadius = 31;
            this.guna2Button3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button3.FillColor = System.Drawing.Color.Turquoise;
            this.guna2Button3.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.guna2Button3.ForeColor = System.Drawing.Color.Black;
            this.guna2Button3.Location = new System.Drawing.Point(250, 549);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.Size = new System.Drawing.Size(351, 64);
            this.guna2Button3.TabIndex = 58;
            this.guna2Button3.Text = "View Tuition Fees";
            this.guna2Button3.Click += new System.EventHandler(this.guna2Button3_Click);
            // 
            // btngraduate
            // 
            this.btngraduate.Animated = true;
            this.btngraduate.AutoRoundedCorners = true;
            this.btngraduate.BorderRadius = 31;
            this.btngraduate.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btngraduate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btngraduate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btngraduate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btngraduate.FillColor = System.Drawing.Color.CadetBlue;
            this.btngraduate.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.btngraduate.ForeColor = System.Drawing.Color.Black;
            this.btngraduate.Location = new System.Drawing.Point(607, 475);
            this.btngraduate.Name = "btngraduate";
            this.btngraduate.Size = new System.Drawing.Size(203, 64);
            this.btngraduate.TabIndex = 59;
            this.btngraduate.Text = "Graduate";
            this.btngraduate.Click += new System.EventHandler(this.btngraduate_Click);
            // 
            // frmStudentCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(813, 617);
            this.Controls.Add(this.btngraduate);
            this.Controls.Add(this.guna2Button3);
            this.Controls.Add(this.guna2Button2);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.btnadvance);
            this.Controls.Add(this.btnsessions);
            this.Controls.Add(this.lblcompletedcourses);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlStudentCard1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmStudentCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student Card";
            this.Load += new System.EventHandler(this.frmStudentCard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlStudentCard ctrlStudentCard1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblcompletedcourses;
        private Guna.UI2.WinForms.Guna2Button btnsessions;
        private Guna.UI2.WinForms.Guna2Button btnadvance;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private Guna.UI2.WinForms.Guna2Button btngraduate;
    }
}