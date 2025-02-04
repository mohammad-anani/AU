namespace AU
{
    partial class ctrlStudentCoursesTab
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvEnnrolledCourses = new System.Windows.Forms.DataGridView();
            this.lblcompletedcourses = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblyear = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage12 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvscheduledcourses = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnnrolledCourses)).BeginInit();
            this.tabPage12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvscheduledcourses)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage11);
            this.tabControl1.Controls.Add(this.tabPage12);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.tabControl1.ItemSize = new System.Drawing.Size(405, 100);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1367, 730);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage11
            // 
            this.tabPage11.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tabPage11.Controls.Add(this.label3);
            this.tabPage11.Controls.Add(this.dgvEnnrolledCourses);
            this.tabPage11.Controls.Add(this.lblcompletedcourses);
            this.tabPage11.Controls.Add(this.label2);
            this.tabPage11.Controls.Add(this.lblyear);
            this.tabPage11.Controls.Add(this.label1);
            this.tabPage11.Location = new System.Drawing.Point(4, 104);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage11.Size = new System.Drawing.Size(1359, 622);
            this.tabPage11.TabIndex = 0;
            this.tabPage11.Text = "My Courses";
            this.tabPage11.Click += new System.EventHandler(this.tabPage11_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.DarkGray;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label3.Location = new System.Drawing.Point(6, 515);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(341, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "Double Click Course To Drop";
            // 
            // dgvEnnrolledCourses
            // 
            this.dgvEnnrolledCourses.AllowUserToAddRows = false;
            this.dgvEnnrolledCourses.AllowUserToDeleteRows = false;
            this.dgvEnnrolledCourses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEnnrolledCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEnnrolledCourses.Location = new System.Drawing.Point(3, 143);
            this.dgvEnnrolledCourses.Name = "dgvEnnrolledCourses";
            this.dgvEnnrolledCourses.ReadOnly = true;
            this.dgvEnnrolledCourses.RowHeadersVisible = false;
            this.dgvEnnrolledCourses.RowHeadersWidth = 51;
            this.dgvEnnrolledCourses.RowTemplate.Height = 50;
            this.dgvEnnrolledCourses.RowTemplate.ReadOnly = true;
            this.dgvEnnrolledCourses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEnnrolledCourses.Size = new System.Drawing.Size(1350, 473);
            this.dgvEnnrolledCourses.TabIndex = 4;
            this.dgvEnnrolledCourses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEnnrolledCourses_CellContentClick);
            this.dgvEnnrolledCourses.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvEnnrolledCourses_MouseDoubleClick);
            // 
            // lblcompletedcourses
            // 
            this.lblcompletedcourses.AutoSize = true;
            this.lblcompletedcourses.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblcompletedcourses.Location = new System.Drawing.Point(315, 86);
            this.lblcompletedcourses.Name = "lblcompletedcourses";
            this.lblcompletedcourses.Size = new System.Drawing.Size(55, 29);
            this.lblcompletedcourses.TabIndex = 3;
            this.lblcompletedcourses.Text = "N/A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(6, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(303, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Year Completed Courses:";
            // 
            // lblyear
            // 
            this.lblyear.AutoSize = true;
            this.lblyear.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblyear.Location = new System.Drawing.Point(315, 35);
            this.lblyear.Name = "lblyear";
            this.lblyear.Size = new System.Drawing.Size(55, 29);
            this.lblyear.TabIndex = 1;
            this.lblyear.Text = "N/A";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(237, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Year:";
            // 
            // tabPage12
            // 
            this.tabPage12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tabPage12.Controls.Add(this.label4);
            this.tabPage12.Controls.Add(this.dgvscheduledcourses);
            this.tabPage12.Location = new System.Drawing.Point(4, 104);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage12.Size = new System.Drawing.Size(1359, 622);
            this.tabPage12.TabIndex = 1;
            this.tabPage12.Text = "Enroll";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.DarkGray;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label4.Location = new System.Drawing.Point(6, 509);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(352, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = "Double Click Course To Enroll";
            // 
            // dgvscheduledcourses
            // 
            this.dgvscheduledcourses.AllowUserToAddRows = false;
            this.dgvscheduledcourses.AllowUserToDeleteRows = false;
            this.dgvscheduledcourses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvscheduledcourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvscheduledcourses.Location = new System.Drawing.Point(6, 6);
            this.dgvscheduledcourses.MultiSelect = false;
            this.dgvscheduledcourses.Name = "dgvscheduledcourses";
            this.dgvscheduledcourses.ReadOnly = true;
            this.dgvscheduledcourses.RowHeadersVisible = false;
            this.dgvscheduledcourses.RowHeadersWidth = 51;
            this.dgvscheduledcourses.RowTemplate.Height = 50;
            this.dgvscheduledcourses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvscheduledcourses.Size = new System.Drawing.Size(1347, 610);
            this.dgvscheduledcourses.TabIndex = 0;
            this.dgvscheduledcourses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvscheduledcourses_CellContentClick);
            this.dgvscheduledcourses.DoubleClick += new System.EventHandler(this.dgvscheduledcourses_DoubleClick);
            // 
            // ctrlStudentCoursesTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.tabControl1);
            this.Name = "ctrlStudentCoursesTab";
            this.Size = new System.Drawing.Size(1373, 730);
            this.Load += new System.EventHandler(this.ctrlStudentCoursesTab_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage11.ResumeLayout(false);
            this.tabPage11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnnrolledCourses)).EndInit();
            this.tabPage12.ResumeLayout(false);
            this.tabPage12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvscheduledcourses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage11;
        private System.Windows.Forms.TabPage tabPage12;
        private System.Windows.Forms.DataGridView dgvEnnrolledCourses;
        private System.Windows.Forms.Label lblcompletedcourses;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblyear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvscheduledcourses;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
