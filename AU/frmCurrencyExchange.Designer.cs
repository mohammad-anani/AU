namespace AU
{
    partial class frmCurrencyExchange
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtpriceusd = new System.Windows.Forms.TextBox();
            this.txttopay = new System.Windows.Forms.TextBox();
            this.lblremainderusd = new System.Windows.Forms.Label();
            this.lblremainderlbp = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblrate = new System.Windows.Forms.Label();
            this.lblpricelbp = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbcurrency = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(36)))));
            this.label2.Location = new System.Drawing.Point(883, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 39);
            this.label2.TabIndex = 30;
            this.label2.Text = "LBP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(36)))));
            this.label1.Location = new System.Drawing.Point(488, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 39);
            this.label1.TabIndex = 31;
            this.label1.Text = "USD";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(36)))));
            this.label3.Location = new System.Drawing.Point(93, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 39);
            this.label3.TabIndex = 32;
            this.label3.Text = "Price:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(36)))));
            this.label4.Location = new System.Drawing.Point(63, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 39);
            this.label4.TabIndex = 33;
            this.label4.Text = "To Pay:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(36)))));
            this.label5.Location = new System.Drawing.Point(4, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(193, 39);
            this.label5.TabIndex = 34;
            this.label5.Text = "Remainder:";
            // 
            // txtpriceusd
            // 
            this.txtpriceusd.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.txtpriceusd.Location = new System.Drawing.Point(258, 24);
            this.txtpriceusd.MaxLength = 5;
            this.txtpriceusd.Name = "txtpriceusd";
            this.txtpriceusd.Size = new System.Drawing.Size(224, 45);
            this.txtpriceusd.TabIndex = 35;
            this.txtpriceusd.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txttopay
            // 
            this.txttopay.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.txttopay.Location = new System.Drawing.Point(258, 118);
            this.txttopay.MaxLength = 11;
            this.txttopay.Name = "txttopay";
            this.txttopay.Size = new System.Drawing.Size(224, 45);
            this.txttopay.TabIndex = 37;
            this.txttopay.TextChanged += new System.EventHandler(this.txttopay_TextChanged);
            this.txttopay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttopay_KeyPress);
            // 
            // lblremainderusd
            // 
            this.lblremainderusd.AutoSize = true;
            this.lblremainderusd.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lblremainderusd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(36)))));
            this.lblremainderusd.Location = new System.Drawing.Point(258, 210);
            this.lblremainderusd.Name = "lblremainderusd";
            this.lblremainderusd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblremainderusd.Size = new System.Drawing.Size(36, 39);
            this.lblremainderusd.TabIndex = 39;
            this.lblremainderusd.Text = "0";
            // 
            // lblremainderlbp
            // 
            this.lblremainderlbp.AutoSize = true;
            this.lblremainderlbp.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lblremainderlbp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(36)))));
            this.lblremainderlbp.Location = new System.Drawing.Point(645, 210);
            this.lblremainderlbp.Name = "lblremainderlbp";
            this.lblremainderlbp.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblremainderlbp.Size = new System.Drawing.Size(36, 39);
            this.lblremainderlbp.TabIndex = 40;
            this.lblremainderlbp.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(36)))));
            this.label6.Location = new System.Drawing.Point(391, 402);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(259, 39);
            this.label6.TabIndex = 41;
            this.label6.Text = "Exchange Rate:";
            // 
            // lblrate
            // 
            this.lblrate.AutoSize = true;
            this.lblrate.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lblrate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(36)))));
            this.lblrate.Location = new System.Drawing.Point(656, 402);
            this.lblrate.Name = "lblrate";
            this.lblrate.Size = new System.Drawing.Size(323, 39);
            this.lblrate.TabIndex = 42;
            this.lblrate.Text = "90,000 LBP / 1 USD";
            // 
            // lblpricelbp
            // 
            this.lblpricelbp.AutoSize = true;
            this.lblpricelbp.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lblpricelbp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(36)))));
            this.lblpricelbp.Location = new System.Drawing.Point(645, 24);
            this.lblpricelbp.Name = "lblpricelbp";
            this.lblpricelbp.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblpricelbp.Size = new System.Drawing.Size(36, 39);
            this.lblpricelbp.TabIndex = 43;
            this.lblpricelbp.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(36)))));
            this.label7.Location = new System.Drawing.Point(488, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 39);
            this.label7.TabIndex = 44;
            this.label7.Text = "USD";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(36)))));
            this.label8.Location = new System.Drawing.Point(883, 210);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 39);
            this.label8.TabIndex = 45;
            this.label8.Text = "LBP";
            // 
            // cbcurrency
            // 
            this.cbcurrency.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.cbcurrency.FormattingEnabled = true;
            this.cbcurrency.Items.AddRange(new object[] {
            "USD",
            "LBP"});
            this.cbcurrency.Location = new System.Drawing.Point(488, 118);
            this.cbcurrency.Name = "cbcurrency";
            this.cbcurrency.Size = new System.Drawing.Size(108, 46);
            this.cbcurrency.TabIndex = 46;
            this.cbcurrency.SelectedIndexChanged += new System.EventHandler(this.cbcurrency_SelectedIndexChanged);
            // 
            // frmCurrencyExchange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(985, 450);
            this.Controls.Add(this.cbcurrency);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblpricelbp);
            this.Controls.Add(this.lblrate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblremainderlbp);
            this.Controls.Add(this.lblremainderusd);
            this.Controls.Add(this.txttopay);
            this.Controls.Add(this.txtpriceusd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCurrencyExchange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Currency Exchange";
            this.Load += new System.EventHandler(this.frmCurrencyExchange_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtpriceusd;
        private System.Windows.Forms.TextBox txttopay;
        private System.Windows.Forms.Label lblremainderusd;
        private System.Windows.Forms.Label lblremainderlbp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblrate;
        private System.Windows.Forms.Label lblpricelbp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbcurrency;
    }
}