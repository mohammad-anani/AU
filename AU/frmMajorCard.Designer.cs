namespace AU
{
    partial class frmMajorCard
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
            this.ctrlMajorCard1 = new AU.ctrlMajorCard();
            this.SuspendLayout();
            // 
            // ctrlMajorCard1
            // 
            this.ctrlMajorCard1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ctrlMajorCard1.Location = new System.Drawing.Point(0, 0);
            this.ctrlMajorCard1.Name = "ctrlMajorCard1";
            this.ctrlMajorCard1.Size = new System.Drawing.Size(947, 369);
            this.ctrlMajorCard1.TabIndex = 0;
            // 
            // frmMajorCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(949, 369);
            this.Controls.Add(this.ctrlMajorCard1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmMajorCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMajorCard";
            this.Load += new System.EventHandler(this.frmMajorCard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlMajorCard ctrlMajorCard1;
    }
}