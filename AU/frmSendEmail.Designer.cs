namespace AU
{
    partial class frmSendEmail
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
            this.ctrlSendEmail1 = new AU.ctrlSendEmail();
            this.SuspendLayout();
            // 
            // ctrlSendEmail1
            // 
            this.ctrlSendEmail1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ctrlSendEmail1.Location = new System.Drawing.Point(1, -2);
            this.ctrlSendEmail1.Name = "ctrlSendEmail1";
            this.ctrlSendEmail1.Size = new System.Drawing.Size(845, 653);
            this.ctrlSendEmail1.TabIndex = 0;
            // 
            // frmSendEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(802, 667);
            this.Controls.Add(this.ctrlSendEmail1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSendEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Send Email";
            this.Load += new System.EventHandler(this.frmSendEmail_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlSendEmail ctrlSendEmail1;
    }
}