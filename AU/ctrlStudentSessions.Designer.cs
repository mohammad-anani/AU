namespace AU
{
    partial class ctrlStudentSessions
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
            this.label3 = new System.Windows.Forms.Label();
            this.dgvsessions = new System.Windows.Forms.DataGridView();
            this.lblstudent = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsessions)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(36)))));
            this.label3.Location = new System.Drawing.Point(308, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(304, 76);
            this.label3.TabIndex = 5;
            this.label3.Text = "Sessions";
            // 
            // dgvsessions
            // 
            this.dgvsessions.AllowUserToAddRows = false;
            this.dgvsessions.AllowUserToDeleteRows = false;
            this.dgvsessions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvsessions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvsessions.Location = new System.Drawing.Point(4, 156);
            this.dgvsessions.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dgvsessions.Name = "dgvsessions";
            this.dgvsessions.ReadOnly = true;
            this.dgvsessions.RowHeadersVisible = false;
            this.dgvsessions.RowHeadersWidth = 51;
            this.dgvsessions.RowTemplate.Height = 40;
            this.dgvsessions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvsessions.Size = new System.Drawing.Size(992, 692);
            this.dgvsessions.TabIndex = 4;
            this.dgvsessions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvsessions_CellContentClick);
            // 
            // lblstudent
            // 
            this.lblstudent.AutoSize = true;
            this.lblstudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblstudent.Location = new System.Drawing.Point(109, 114);
            this.lblstudent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblstudent.Name = "lblstudent";
            this.lblstudent.Size = new System.Drawing.Size(55, 29);
            this.lblstudent.TabIndex = 7;
            this.lblstudent.Text = "N/A";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(4, 114);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 29);
            this.label1.TabIndex = 6;
            this.label1.Text = "Student:";
            // 
            // ctrlStudentSessions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.lblstudent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvsessions);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "ctrlStudentSessions";
            this.Size = new System.Drawing.Size(1000, 850);
            this.Load += new System.EventHandler(this.ctrlStudentSessions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvsessions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvsessions;
        private System.Windows.Forms.Label lblstudent;
        private System.Windows.Forms.Label label1;
    }
}
