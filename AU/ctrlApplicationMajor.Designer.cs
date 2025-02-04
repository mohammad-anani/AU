namespace AU
{
    partial class ctrlApplicationMajor
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
            this.cbDepartments = new System.Windows.Forms.ComboBox();
            this.cbMajors = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrlMajorCard1 = new AU.ctrlMajorCard();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(19, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Department:";
            // 
            // cbDepartments
            // 
            this.cbDepartments.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.cbDepartments.FormattingEnabled = true;
            this.cbDepartments.Location = new System.Drawing.Point(161, 24);
            this.cbDepartments.Name = "cbDepartments";
            this.cbDepartments.Size = new System.Drawing.Size(407, 37);
            this.cbDepartments.TabIndex = 1;
            this.cbDepartments.SelectedIndexChanged += new System.EventHandler(this.cbDepartments_SelectedIndexChanged);
            // 
            // cbMajors
            // 
            this.cbMajors.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.cbMajors.FormattingEnabled = true;
            this.cbMajors.Location = new System.Drawing.Point(161, 91);
            this.cbMajors.Name = "cbMajors";
            this.cbMajors.Size = new System.Drawing.Size(407, 37);
            this.cbMajors.TabIndex = 3;
            this.cbMajors.SelectedIndexChanged += new System.EventHandler(this.cbMajors_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(88, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Major:";
            // 
            // ctrlMajorCard1
            // 
            this.ctrlMajorCard1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ctrlMajorCard1.Location = new System.Drawing.Point(0, 145);
            this.ctrlMajorCard1.Name = "ctrlMajorCard1";
            this.ctrlMajorCard1.Size = new System.Drawing.Size(947, 367);
            this.ctrlMajorCard1.TabIndex = 4;
            // 
            // ctrlApplicationMajor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.ctrlMajorCard1);
            this.Controls.Add(this.cbMajors);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbDepartments);
            this.Controls.Add(this.label1);
            this.Name = "ctrlApplicationMajor";
            this.Size = new System.Drawing.Size(871, 523);
            this.Load += new System.EventHandler(this.ctrlApplicationMajor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDepartments;
        private System.Windows.Forms.ComboBox cbMajors;
        private System.Windows.Forms.Label label2;
        private ctrlMajorCard ctrlMajorCard1;
    }
}
