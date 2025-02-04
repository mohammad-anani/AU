namespace AU
{
    partial class frmReturnBook
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
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.guna2RatingStar1 = new Guna.UI2.WinForms.Guna2RatingStar();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.lblbook = new System.Windows.Forms.Label();
            this.lblstudent = new System.Windows.Forms.Label();
            this.lblborrowdate = new System.Windows.Forms.Label();
            this.lblduedate = new System.Windows.Forms.Label();
            this.lbltotalfees = new System.Windows.Forms.Label();
            this.lblfeeperday = new System.Windows.Forms.Label();
            this.lbllatedays = new System.Windows.Forms.Label();
            this.lblreturn = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(36)))));
            this.label2.Location = new System.Drawing.Point(334, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(403, 76);
            this.label2.TabIndex = 37;
            this.label2.Text = "Return Book";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label4.Location = new System.Drawing.Point(41, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 29);
            this.label4.TabIndex = 41;
            this.label4.Text = "Book Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(12, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 29);
            this.label1.TabIndex = 42;
            this.label1.Text = "Student Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label3.Location = new System.Drawing.Point(35, 262);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 29);
            this.label3.TabIndex = 43;
            this.label3.Text = "Borrow Date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label5.Location = new System.Drawing.Point(68, 338);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 29);
            this.label5.TabIndex = 44;
            this.label5.Text = "Due Date:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label6.Location = new System.Drawing.Point(589, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 29);
            this.label6.TabIndex = 45;
            this.label6.Text = "Late Days:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label7.Location = new System.Drawing.Point(570, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 29);
            this.label7.TabIndex = 46;
            this.label7.Text = "Return Date:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label8.Location = new System.Drawing.Point(610, 262);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 29);
            this.label8.TabIndex = 47;
            this.label8.Text = "Fee/Day:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label9.Location = new System.Drawing.Point(586, 338);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(139, 29);
            this.label9.TabIndex = 48;
            this.label9.Text = "Total Fees:";
            // 
            // guna2RatingStar1
            // 
            this.guna2RatingStar1.BorderColor = System.Drawing.Color.Gold;
            this.guna2RatingStar1.Location = new System.Drawing.Point(121, 483);
            this.guna2RatingStar1.Name = "guna2RatingStar1";
            this.guna2RatingStar1.RatingColor = System.Drawing.Color.Gold;
            this.guna2RatingStar1.Size = new System.Drawing.Size(288, 64);
            this.guna2RatingStar1.TabIndex = 49;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label10.Location = new System.Drawing.Point(22, 504);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 29);
            this.label10.TabIndex = 50;
            this.label10.Text = "Rating:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.checkBox1.Location = new System.Drawing.Point(27, 583);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(149, 33);
            this.checkBox1.TabIndex = 51;
            this.checkBox1.Text = "Fees Paid";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Animated = true;
            this.btnSave.AutoRoundedCorners = true;
            this.btnSave.BorderRadius = 27;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.Turquoise;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(834, 649);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(212, 56);
            this.btnSave.TabIndex = 52;
            this.btnSave.Text = "Return";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblbook
            // 
            this.lblbook.AutoSize = true;
            this.lblbook.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblbook.Location = new System.Drawing.Point(200, 123);
            this.lblbook.Name = "lblbook";
            this.lblbook.Size = new System.Drawing.Size(55, 29);
            this.lblbook.TabIndex = 53;
            this.lblbook.Text = "N/A";
            // 
            // lblstudent
            // 
            this.lblstudent.AutoSize = true;
            this.lblstudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblstudent.Location = new System.Drawing.Point(200, 190);
            this.lblstudent.Name = "lblstudent";
            this.lblstudent.Size = new System.Drawing.Size(55, 29);
            this.lblstudent.TabIndex = 54;
            this.lblstudent.Text = "N/A";
            // 
            // lblborrowdate
            // 
            this.lblborrowdate.AutoSize = true;
            this.lblborrowdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblborrowdate.Location = new System.Drawing.Point(200, 262);
            this.lblborrowdate.Name = "lblborrowdate";
            this.lblborrowdate.Size = new System.Drawing.Size(55, 29);
            this.lblborrowdate.TabIndex = 55;
            this.lblborrowdate.Text = "N/A";
            // 
            // lblduedate
            // 
            this.lblduedate.AutoSize = true;
            this.lblduedate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblduedate.Location = new System.Drawing.Point(200, 338);
            this.lblduedate.Name = "lblduedate";
            this.lblduedate.Size = new System.Drawing.Size(55, 29);
            this.lblduedate.TabIndex = 56;
            this.lblduedate.Text = "N/A";
            // 
            // lbltotalfees
            // 
            this.lbltotalfees.AutoSize = true;
            this.lbltotalfees.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lbltotalfees.Location = new System.Drawing.Point(744, 338);
            this.lbltotalfees.Name = "lbltotalfees";
            this.lbltotalfees.Size = new System.Drawing.Size(55, 29);
            this.lbltotalfees.TabIndex = 60;
            this.lbltotalfees.Text = "N/A";
            // 
            // lblfeeperday
            // 
            this.lblfeeperday.AutoSize = true;
            this.lblfeeperday.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblfeeperday.Location = new System.Drawing.Point(744, 262);
            this.lblfeeperday.Name = "lblfeeperday";
            this.lblfeeperday.Size = new System.Drawing.Size(55, 29);
            this.lblfeeperday.TabIndex = 59;
            this.lblfeeperday.Text = "N/A";
            // 
            // lbllatedays
            // 
            this.lbllatedays.AutoSize = true;
            this.lbllatedays.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lbllatedays.Location = new System.Drawing.Point(744, 190);
            this.lbllatedays.Name = "lbllatedays";
            this.lbllatedays.Size = new System.Drawing.Size(55, 29);
            this.lbllatedays.TabIndex = 58;
            this.lbllatedays.Text = "N/A";
            // 
            // lblreturn
            // 
            this.lblreturn.AutoSize = true;
            this.lblreturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblreturn.Location = new System.Drawing.Point(744, 123);
            this.lblreturn.Name = "lblreturn";
            this.lblreturn.Size = new System.Drawing.Size(55, 29);
            this.lblreturn.TabIndex = 57;
            this.lblreturn.Text = "N/A";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.linkLabel1.Location = new System.Drawing.Point(902, 483);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(144, 29);
            this.linkLabel1.TabIndex = 61;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Send Email";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // frmReturnBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1058, 720);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.lbltotalfees);
            this.Controls.Add(this.lblfeeperday);
            this.Controls.Add(this.lbllatedays);
            this.Controls.Add(this.lblreturn);
            this.Controls.Add(this.lblduedate);
            this.Controls.Add(this.lblborrowdate);
            this.Controls.Add(this.lblstudent);
            this.Controls.Add(this.lblbook);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.guna2RatingStar1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmReturnBook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Return Book";
            this.Load += new System.EventHandler(this.frmReturnBook_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2RatingStar guna2RatingStar1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBox1;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private System.Windows.Forms.Label lblbook;
        private System.Windows.Forms.Label lblstudent;
        private System.Windows.Forms.Label lblborrowdate;
        private System.Windows.Forms.Label lblduedate;
        private System.Windows.Forms.Label lbltotalfees;
        private System.Windows.Forms.Label lblfeeperday;
        private System.Windows.Forms.Label lbllatedays;
        private System.Windows.Forms.Label lblreturn;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}