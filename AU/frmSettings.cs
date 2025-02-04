using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace AU
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string Activated = guna2ToggleSwitch1.Checked ? "1" : "0";
            Activated += guna2ToggleSwitch2.Checked ? "1" : "0";
            Activated += " " + ((int)numericUpDown1.Value).ToString("D2");
            Activated += " " + ((int)numericUpDown2.Value).ToString("D2");
            Activated += " " + ((int)numericUpDown3.Value).ToString("D2");

            File.WriteAllText("AU_Settings.txt", Activated);

            MessageBox.Show("Setting Saved.","Message",MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            string Activated = File.ReadAllText("AU_Settings.txt");
            if (Activated[0] == '1')
            {
                guna2ToggleSwitch1.Checked = true;

            }
            else
                guna2ToggleSwitch1.Checked = false;

            if (Activated[1] == '1')
            {
                guna2ToggleSwitch2.Checked = true;

            }
            else
                guna2ToggleSwitch2.Checked = false;

           numericUpDown1.Value=Convert.ToInt32(Activated.Substring(3,2));
            numericUpDown2.Value= Convert.ToInt32(Activated.Substring(6, 2));
            numericUpDown3.Value= Convert.ToInt32(Activated.Substring(9, 2));
        }
    }
}
