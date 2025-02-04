using AU_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AU
{
    public partial class ctrlNews : UserControl
    {
        public ctrlNews()
        {
            InitializeComponent();
        }

        public void FillInfo()
        {
            dataGridView1.DataSource = clsNews.ListNews().DefaultView.ToTable(false, "NewsID", "Title");
        }
        private void ctrlNews_Load(object sender, EventArgs e)
        {
          
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            Form form = new frmNewsCard(clsNews.Find(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value)));
            form.ShowDialog();
        }
    }
}
