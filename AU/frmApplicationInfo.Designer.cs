namespace AU
{
    partial class frmApplicationInfo
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
            this.btncomplete = new Guna.UI2.WinForms.Guna2Button();
            this.btnaccept = new Guna.UI2.WinForms.Guna2Button();
            this.btnreject = new Guna.UI2.WinForms.Guna2Button();
            this.btncancel = new Guna.UI2.WinForms.Guna2Button();
            this.chkpaid = new System.Windows.Forms.CheckBox();
            this.chksubmit = new System.Windows.Forms.CheckBox();
            this.ctrlApplicationInfo1 = new AU.ctrlApplicationInfo();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btncomplete
            // 
            this.btncomplete.Animated = true;
            this.btncomplete.AutoRoundedCorners = true;
            this.btncomplete.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btncomplete.BorderRadius = 31;
            this.btncomplete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btncomplete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btncomplete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btncomplete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btncomplete.Enabled = false;
            this.btncomplete.FillColor = System.Drawing.Color.Lime;
            this.btncomplete.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.btncomplete.ForeColor = System.Drawing.Color.Black;
            this.btncomplete.Location = new System.Drawing.Point(872, 777);
            this.btncomplete.Name = "btncomplete";
            this.btncomplete.Size = new System.Drawing.Size(238, 64);
            this.btncomplete.TabIndex = 1;
            this.btncomplete.Text = "Complete";
            this.btncomplete.Click += new System.EventHandler(this.btncomplete_Click);
            // 
            // btnaccept
            // 
            this.btnaccept.Animated = true;
            this.btnaccept.AutoRoundedCorners = true;
            this.btnaccept.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnaccept.BorderRadius = 31;
            this.btnaccept.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnaccept.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnaccept.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnaccept.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnaccept.FillColor = System.Drawing.Color.LawnGreen;
            this.btnaccept.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.btnaccept.ForeColor = System.Drawing.Color.Black;
            this.btnaccept.Location = new System.Drawing.Point(628, 777);
            this.btnaccept.Name = "btnaccept";
            this.btnaccept.Size = new System.Drawing.Size(238, 64);
            this.btnaccept.TabIndex = 2;
            this.btnaccept.Text = "Accept";
            this.btnaccept.Click += new System.EventHandler(this.btnaccept_Click);
            // 
            // btnreject
            // 
            this.btnreject.Animated = true;
            this.btnreject.AutoRoundedCorners = true;
            this.btnreject.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnreject.BorderRadius = 31;
            this.btnreject.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnreject.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnreject.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnreject.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnreject.FillColor = System.Drawing.Color.Red;
            this.btnreject.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.btnreject.ForeColor = System.Drawing.Color.Black;
            this.btnreject.Location = new System.Drawing.Point(384, 777);
            this.btnreject.Name = "btnreject";
            this.btnreject.Size = new System.Drawing.Size(238, 64);
            this.btnreject.TabIndex = 3;
            this.btnreject.Text = "Reject";
            this.btnreject.Click += new System.EventHandler(this.btnreject_Click);
            // 
            // btncancel
            // 
            this.btncancel.Animated = true;
            this.btncancel.AutoRoundedCorners = true;
            this.btncancel.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btncancel.BorderRadius = 31;
            this.btncancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btncancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btncancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btncancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btncancel.FillColor = System.Drawing.Color.Yellow;
            this.btncancel.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.btncancel.ForeColor = System.Drawing.Color.Black;
            this.btncancel.Location = new System.Drawing.Point(384, 777);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(238, 64);
            this.btncancel.TabIndex = 4;
            this.btncancel.Text = "Cancel Rejection";
            this.btncancel.Visible = false;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // chkpaid
            // 
            this.chkpaid.AutoSize = true;
            this.chkpaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.chkpaid.Location = new System.Drawing.Point(12, 647);
            this.chkpaid.Name = "chkpaid";
            this.chkpaid.Size = new System.Drawing.Size(317, 33);
            this.chkpaid.TabIndex = 5;
            this.chkpaid.Text = "Paid 50$ Application Fee";
            this.chkpaid.UseVisualStyleBackColor = true;
            // 
            // chksubmit
            // 
            this.chksubmit.AutoSize = true;
            this.chksubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.chksubmit.Location = new System.Drawing.Point(12, 709);
            this.chksubmit.Name = "chksubmit";
            this.chksubmit.Size = new System.Drawing.Size(322, 33);
            this.chksubmit.TabIndex = 6;
            this.chksubmit.Text = "Submitted All Documents";
            this.chksubmit.UseVisualStyleBackColor = true;
            // 
            // ctrlApplicationInfo1
            // 
            this.ctrlApplicationInfo1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ctrlApplicationInfo1.Location = new System.Drawing.Point(18, 1);
            this.ctrlApplicationInfo1.Name = "ctrlApplicationInfo1";
            this.ctrlApplicationInfo1.Size = new System.Drawing.Size(1092, 630);
            this.ctrlApplicationInfo1.TabIndex = 0;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.linkLabel1.Location = new System.Drawing.Point(773, 634);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(310, 29);
            this.linkLabel1.TabIndex = 43;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Open Currency Exchanger";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // frmApplicationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1122, 853);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.chksubmit);
            this.Controls.Add(this.chkpaid);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnreject);
            this.Controls.Add(this.btnaccept);
            this.Controls.Add(this.btncomplete);
            this.Controls.Add(this.ctrlApplicationInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmApplicationInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmApplicationInfo";
            this.Load += new System.EventHandler(this.frmApplicationInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlApplicationInfo ctrlApplicationInfo1;
        private Guna.UI2.WinForms.Guna2Button btncomplete;
        private Guna.UI2.WinForms.Guna2Button btnaccept;
        private Guna.UI2.WinForms.Guna2Button btnreject;
        private Guna.UI2.WinForms.Guna2Button btncancel;
        private System.Windows.Forms.CheckBox chkpaid;
        private System.Windows.Forms.CheckBox chksubmit;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}