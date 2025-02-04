namespace AU
{
    partial class ctrlScheduledCourseCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblcourse = new System.Windows.Forms.Label();
            this.lblteacher = new System.Windows.Forms.Label();
            this.llteacher = new System.Windows.Forms.LinkLabel();
            this.llcourse = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(36)))));
            this.label1.Location = new System.Drawing.Point(51, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(714, 67);
            this.label1.TabIndex = 0;
            this.label1.Text = "Scheduled Course Details";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(14, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Course Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label3.Location = new System.Drawing.Point(3, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Teacher Name:";
            // 
            // lblcourse
            // 
            this.lblcourse.AutoSize = true;
            this.lblcourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblcourse.Location = new System.Drawing.Point(196, 140);
            this.lblcourse.Name = "lblcourse";
            this.lblcourse.Size = new System.Drawing.Size(55, 29);
            this.lblcourse.TabIndex = 3;
            this.lblcourse.Text = "N/A";
            // 
            // lblteacher
            // 
            this.lblteacher.AutoSize = true;
            this.lblteacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblteacher.Location = new System.Drawing.Point(196, 213);
            this.lblteacher.Name = "lblteacher";
            this.lblteacher.Size = new System.Drawing.Size(55, 29);
            this.lblteacher.TabIndex = 4;
            this.lblteacher.Text = "N/A";
            // 
            // llteacher
            // 
            this.llteacher.AutoSize = true;
            this.llteacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.llteacher.Location = new System.Drawing.Point(570, 213);
            this.llteacher.Name = "llteacher";
            this.llteacher.Size = new System.Drawing.Size(215, 29);
            this.llteacher.TabIndex = 5;
            this.llteacher.TabStop = true;
            this.llteacher.Text = "View Teacher Info";
            this.llteacher.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llteacher_LinkClicked);
            // 
            // llcourse
            // 
            this.llcourse.AutoSize = true;
            this.llcourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.llcourse.Location = new System.Drawing.Point(570, 140);
            this.llcourse.Name = "llcourse";
            this.llcourse.Size = new System.Drawing.Size(204, 29);
            this.llcourse.TabIndex = 6;
            this.llcourse.TabStop = true;
            this.llcourse.Text = "View Course Info";
            this.llcourse.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llcourse_LinkClicked);
            // 
            // ctrlScheduledCourseCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.llcourse);
            this.Controls.Add(this.llteacher);
            this.Controls.Add(this.lblteacher);
            this.Controls.Add(this.lblcourse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ctrlScheduledCourseCard";
            this.Size = new System.Drawing.Size(838, 272);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblcourse;
        private System.Windows.Forms.Label lblteacher;
        private System.Windows.Forms.LinkLabel llteacher;
        private System.Windows.Forms.LinkLabel llcourse;
    }
}
