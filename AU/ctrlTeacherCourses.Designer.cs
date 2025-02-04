namespace AU
{
    partial class ctrlTeacherCourses
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
            this.dgvscheduledcourses = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvscheduledcourses)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvscheduledcourses
            // 
            this.dgvscheduledcourses.AllowUserToAddRows = false;
            this.dgvscheduledcourses.AllowUserToDeleteRows = false;
            this.dgvscheduledcourses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvscheduledcourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvscheduledcourses.Location = new System.Drawing.Point(0, 0);
            this.dgvscheduledcourses.Margin = new System.Windows.Forms.Padding(7);
            this.dgvscheduledcourses.MultiSelect = false;
            this.dgvscheduledcourses.Name = "dgvscheduledcourses";
            this.dgvscheduledcourses.ReadOnly = true;
            this.dgvscheduledcourses.RowHeadersVisible = false;
            this.dgvscheduledcourses.RowHeadersWidth = 51;
            this.dgvscheduledcourses.RowTemplate.Height = 50;
            this.dgvscheduledcourses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvscheduledcourses.Size = new System.Drawing.Size(998, 542);
            this.dgvscheduledcourses.TabIndex = 0;
            this.dgvscheduledcourses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvscheduledcourses_CellContentClick);
            this.dgvscheduledcourses.DoubleClick += new System.EventHandler(this.dgvscheduledcourses_DoubleClick);
            // 
            // ctrlTeacherCourses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 38F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.dgvscheduledcourses);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.Margin = new System.Windows.Forms.Padding(7);
            this.Name = "ctrlTeacherCourses";
            this.Size = new System.Drawing.Size(998, 542);
            this.Load += new System.EventHandler(this.ctrlTeacherCourses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvscheduledcourses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvscheduledcourses;
    }
}
