namespace AU
{
    partial class frmEmails
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
            this.ctrlEmailsList1 = new AU.ctrlEmailsList();
            this.SuspendLayout();
            // 
            // ctrlEmailsList1
            // 
            this.ctrlEmailsList1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ctrlEmailsList1.Location = new System.Drawing.Point(-2, 12);
            this.ctrlEmailsList1.Name = "ctrlEmailsList1";
            this.ctrlEmailsList1.Size = new System.Drawing.Size(1343, 767);
            this.ctrlEmailsList1.TabIndex = 0;
            // 
            // frmEmails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1338, 781);
            this.Controls.Add(this.ctrlEmailsList1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmEmails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Emails";
            this.Load += new System.EventHandler(this.frmEmails_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlEmailsList ctrlEmailsList1;
    }
}