namespace AU
{
    partial class ctrlTeacherCard
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
            this.lblspec = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.llteacher = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(36)))));
            this.label1.Location = new System.Drawing.Point(145, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(498, 76);
            this.label1.TabIndex = 1;
            this.label1.Text = "Teacher Details";
            // 
            // lblspec
            // 
            this.lblspec.AutoSize = true;
            this.lblspec.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblspec.Location = new System.Drawing.Point(208, 200);
            this.lblspec.Name = "lblspec";
            this.lblspec.Size = new System.Drawing.Size(55, 29);
            this.lblspec.TabIndex = 8;
            this.lblspec.Text = "N/A";
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblname.Location = new System.Drawing.Point(208, 127);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(55, 29);
            this.lblname.TabIndex = 7;
            this.lblname.Text = "N/A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label3.Location = new System.Drawing.Point(24, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 29);
            this.label3.TabIndex = 6;
            this.label3.Text = "Specialization:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(15, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "Teacher Name:";
            // 
            // llteacher
            // 
            this.llteacher.AutoSize = true;
            this.llteacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.llteacher.Location = new System.Drawing.Point(619, 127);
            this.llteacher.Name = "llteacher";
            this.llteacher.Size = new System.Drawing.Size(203, 29);
            this.llteacher.TabIndex = 9;
            this.llteacher.TabStop = true;
            this.llteacher.Text = "View Person Info";
            this.llteacher.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llteacher_LinkClicked);
            // 
            // ctrlTeacherCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.llteacher);
            this.Controls.Add(this.lblspec);
            this.Controls.Add(this.lblname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ctrlTeacherCard";
            this.Size = new System.Drawing.Size(835, 265);
            this.Load += new System.EventHandler(this.ctrlTeacherCard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblspec;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel llteacher;
    }
}
