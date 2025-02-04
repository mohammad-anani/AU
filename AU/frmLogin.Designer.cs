namespace AU
{
    partial class frmLogin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.txtusername = new System.Windows.Forms.TextBox();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnlogin = new Guna.UI2.WinForms.Guna2Button();
            this.lblor = new System.Windows.Forms.Label();
            this.btnapply = new Guna.UI2.WinForms.Guna2Button();
            this.chkrememberme = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtusername
            // 
            this.txtusername.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtusername.Location = new System.Drawing.Point(113, 240);
            this.txtusername.MaxLength = 30;
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(309, 36);
            this.txtusername.TabIndex = 1;
            this.txtusername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtusername_KeyDown);
            // 
            // txtpassword
            // 
            this.txtpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtpassword.Location = new System.Drawing.Point(113, 348);
            this.txtpassword.MaxLength = 30;
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.PasswordChar = '*';
            this.txtpassword.Size = new System.Drawing.Size(309, 36);
            this.txtpassword.TabIndex = 2;
            this.txtpassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpassword_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(105, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(105, 314);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password:";
            // 
            // btnlogin
            // 
            this.btnlogin.Animated = true;
            this.btnlogin.AutoRoundedCorners = true;
            this.btnlogin.BorderRadius = 27;
            this.btnlogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnlogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnlogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnlogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnlogin.FillColor = System.Drawing.SystemColors.ControlLight;
            this.btnlogin.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.btnlogin.ForeColor = System.Drawing.Color.Black;
            this.btnlogin.Location = new System.Drawing.Point(161, 450);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(212, 56);
            this.btnlogin.TabIndex = 5;
            this.btnlogin.Text = "Login";
            this.btnlogin.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // lblor
            // 
            this.lblor.AutoSize = true;
            this.lblor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblor.ForeColor = System.Drawing.Color.White;
            this.lblor.Location = new System.Drawing.Point(237, 518);
            this.lblor.Name = "lblor";
            this.lblor.Size = new System.Drawing.Size(40, 29);
            this.lblor.TabIndex = 6;
            this.lblor.Text = "Or";
            // 
            // btnapply
            // 
            this.btnapply.Animated = true;
            this.btnapply.AutoRoundedCorners = true;
            this.btnapply.BorderRadius = 27;
            this.btnapply.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnapply.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnapply.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnapply.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnapply.FillColor = System.Drawing.Color.Gray;
            this.btnapply.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.btnapply.ForeColor = System.Drawing.Color.Black;
            this.btnapply.Location = new System.Drawing.Point(161, 563);
            this.btnapply.Name = "btnapply";
            this.btnapply.Size = new System.Drawing.Size(212, 56);
            this.btnapply.TabIndex = 7;
            this.btnapply.Text = "Apply";
            this.btnapply.Click += new System.EventHandler(this.btnapply_Click);
            // 
            // chkrememberme
            // 
            this.chkrememberme.AutoSize = true;
            this.chkrememberme.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chkrememberme.ForeColor = System.Drawing.Color.Transparent;
            this.chkrememberme.Location = new System.Drawing.Point(115, 400);
            this.chkrememberme.Name = "chkrememberme";
            this.chkrememberme.Size = new System.Drawing.Size(162, 29);
            this.chkrememberme.TabIndex = 9;
            this.chkrememberme.Text = "Remember Me";
            this.chkrememberme.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(112, 670);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(295, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "All Rights Reserved To Anani University 2024\r\n";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::AU.Properties.Resources.xwhite;
            this.pictureBox2.Location = new System.Drawing.Point(519, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(41, 45);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AU.Properties.Resources.AU_LOGO;
            this.pictureBox1.Location = new System.Drawing.Point(130, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(275, 139);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Check your Inbox";
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(563, 696);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkrememberme);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnapply);
            this.Controls.Add(this.lblor);
            this.Controls.Add(this.btnlogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.txtusername);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogin";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btnlogin;
        private System.Windows.Forms.Label lblor;
        private Guna.UI2.WinForms.Guna2Button btnapply;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.CheckBox chkrememberme;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}