namespace AU
{
    partial class ctrlListDepartmentMajors
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
            this.dgvengineering = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvengineering)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvengineering
            // 
            this.dgvengineering.AllowUserToAddRows = false;
            this.dgvengineering.AllowUserToDeleteRows = false;
            this.dgvengineering.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvengineering.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvengineering.ColumnHeadersVisible = false;
            this.dgvengineering.Location = new System.Drawing.Point(3, 82);
            this.dgvengineering.Name = "dgvengineering";
            this.dgvengineering.ReadOnly = true;
            this.dgvengineering.RowHeadersVisible = false;
            this.dgvengineering.RowHeadersWidth = 51;
            this.dgvengineering.RowTemplate.Height = 40;
            this.dgvengineering.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvengineering.Size = new System.Drawing.Size(313, 284);
            this.dgvengineering.TabIndex = 14;
            this.dgvengineering.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvengineering_CellContentClick);
            this.dgvengineering.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvengineering_MouseDoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(36)))));
            this.label5.Location = new System.Drawing.Point(0, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(266, 78);
            this.label5.TabIndex = 13;
            this.label5.Text = "Engineering and\r\nTechnology";
            // 
            // ctrlListDepartmentMajors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.dgvengineering);
            this.Controls.Add(this.label5);
            this.Name = "ctrlListDepartmentMajors";
            this.Size = new System.Drawing.Size(316, 372);
            ((System.ComponentModel.ISupportInitialize)(this.dgvengineering)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvengineering;
        private System.Windows.Forms.Label label5;
    }
}
