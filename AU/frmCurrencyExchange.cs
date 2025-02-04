using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AU
{
    public partial class frmCurrencyExchange : Form
    {

        float rate = 90000;
        public frmCurrencyExchange()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtpriceusd.Text.Length == 0)
            {
                lblpricelbp.Text = "0";
                lblremainderlbp.Text = "0";
                lblremainderusd.Text = "0";
                return;
            }

            char lastchar = txtpriceusd.Text[txtpriceusd.Text.Length - 1];
            if (!char.IsDigit(lastchar))
            {
                txtpriceusd.Clear();
                return;
            }

            if (txtpriceusd.Text.Length == 4 && !txtpriceusd.Text.Contains(","))
            {
                txtpriceusd.Text = txtpriceusd.Text.Insert(1, ",");
                txtpriceusd.SelectionStart = txtpriceusd.TextLength;
            }
            else
            {
                if (txtpriceusd.Text.Length < 5 && txtpriceusd.Text.Contains(","))
                {
                    txtpriceusd.Text = txtpriceusd.Text.Remove(txtpriceusd.Text.IndexOf(","), 1);
                    txtpriceusd.SelectionStart = txtpriceusd.TextLength;
                }
            }

            lblpricelbp.Text = ConvertFloatToString(ConvertStringToFloat(txtpriceusd.Text) * rate);
            CalculateRemainder();

        }

        string ConvertFloatToString(float value)
        {
            string newvalue = value.ToString("G12");
            if (value >= 1000)
            {
                newvalue = newvalue.Insert(newvalue.Length - 3, ",");
            }
            if (value >= 1000000)
            {
                newvalue = newvalue.Insert(newvalue.Length - 7, ",");
            }
            if (value >= 1000000000)
            {
                newvalue = newvalue.Insert(newvalue.Length - 11, ",");
            }
            return newvalue;
        }

        float ConvertStringToFloat(string value)
        {
            if (value.Length > 3)
                value = value.Remove(value.IndexOf(","), 1);

            if (value.Length > 6)
                value = value.Remove(value.IndexOf(","), 1);

            return Convert.ToSingle(value);

        }

        private void frmCurrencyExchange_Load(object sender, EventArgs e)
        {
            cbcurrency.SelectedIndex = 0;
            lblrate.Text = rate.ToString() + " LBP / 1 USD";
        }

        void CalculateRemainder()
        {
            if (txttopay.Text.Length == 0 || txtpriceusd.Text.Length == 0)
            {
                lblremainderlbp.Text = "0";
                lblremainderusd.Text = "0";
                return;
            }

            switch (cbcurrency.SelectedIndex)
            {
                case 0:
                    if (ConvertStringToFloat(txttopay.Text) < ConvertStringToFloat(txtpriceusd.Text))
                    {
                        lblremainderlbp.Text = "0";
                        lblremainderusd.Text = "0";
                        return;
                    }
                    lblremainderusd.Text = ConvertFloatToString(ConvertStringToFloat(txttopay.Text) - ConvertStringToFloat(txtpriceusd.Text));
                    lblremainderlbp.Text = ConvertFloatToString(((ConvertStringToFloat(txttopay.Text) * rate) - ConvertStringToFloat(lblpricelbp.Text)));
                    break;
                case 1:
                    if (ConvertStringToFloat(txttopay.Text) < ConvertStringToFloat(lblpricelbp.Text))
                    {
                        lblremainderlbp.Text = "0";
                        lblremainderusd.Text = "0";
                        return;
                    }
                    lblremainderlbp.Text = ConvertFloatToString(ConvertStringToFloat(txttopay.Text) - ConvertStringToFloat(lblpricelbp.Text));
                    lblremainderusd.Text = ConvertFloatToString(((ConvertStringToFloat(txttopay.Text)) / rate) - (ConvertStringToFloat(txtpriceusd.Text)));
                    break;
            }
        }

        private void txttopay_TextChanged(object sender, EventArgs e)
        {
            if (txttopay.Text.Length == 0)
            {
                lblremainderlbp.Text = "0";
                lblremainderusd.Text = "0";
                return;
            }

            char lastchar = txttopay.Text[txttopay.Text.Length - 1];
            if(!char.IsDigit(lastchar))
            {
                txttopay.Clear();
                return;
            }
           

            MatchCollection matches = Regex.Matches(txttopay.Text, Regex.Escape(","));

            if (txttopay.TextLength == 4 && txttopay.Text.Contains(","))
            {
                txttopay.Text = txttopay.Text.Remove(1, 1);
            }
            else if (txttopay.TextLength == 4)
            {
                txttopay.Text = txttopay.Text.Insert(1, ",");
            }
            else if (txttopay.TextLength == 5 && txttopay.Text.IndexOf(",") == 2)
            {
                string newvalue = txttopay.Text;
                newvalue = newvalue.Remove(2, 1);
                newvalue = newvalue.Insert(1, ",");
                txttopay.Text = newvalue;
            }
            else if (txttopay.TextLength == 6 && txttopay.Text.IndexOf(",") == 1)
            {
                string newvalue = txttopay.Text;
                newvalue = newvalue.Remove(1, 1);
                newvalue = newvalue.Insert(2, ",");
                txttopay.Text = newvalue;
            }
            else if (txttopay.TextLength == 6 && txttopay.Text.IndexOf(",") == 3)
            {
                string newvalue = txttopay.Text;
                newvalue = newvalue.Remove(3, 1);
                newvalue = newvalue.Insert(2, ",");
                txttopay.Text = newvalue;
            }
            else if (txttopay.TextLength == 7 && txttopay.Text.IndexOf(",") == 2)
            {
                string newvalue = txttopay.Text;
                newvalue = newvalue.Remove(2, 1);
                newvalue = newvalue.Insert(3, ",");
                txttopay.Text = newvalue;
            }
            else if (txttopay.TextLength == 8 && matches.Count == 1)
            {
                string newvalue = txttopay.Text;
                newvalue = newvalue.Remove(3, 1);
                newvalue = newvalue.Insert(4, ",");
                newvalue = newvalue.Insert(1, ",");
                txttopay.Text = newvalue;
            }
            else if (txttopay.TextLength == 8 && matches.Count == 2)
            {
                string newvalue = txttopay.Text;
                newvalue = newvalue.Remove(5, 1);
                newvalue = newvalue.Insert(3, ",");
                newvalue = newvalue.Remove(1, 1);
                txttopay.Text = newvalue;
            }
            else if (txttopay.TextLength == 9 && txttopay.Text.IndexOf(",") == 2)
            {
                string newvalue = txttopay.Text;
                newvalue = newvalue.Remove(6, 1);
                newvalue = newvalue.Insert(5, ",");
                newvalue = newvalue.Remove(2, 1);
                newvalue = newvalue.Insert(1, ",");
                txttopay.Text = newvalue;
            }
            else if (txttopay.TextLength == 10 && txttopay.Text.IndexOf(",") == 1)
            {
                string newvalue = txttopay.Text;
                newvalue = newvalue.Remove(5, 1);
                newvalue = newvalue.Insert(6, ",");
                newvalue = newvalue.Remove(1, 1);
                newvalue = newvalue.Insert(2, ",");
                txttopay.Text = newvalue;
            }
            else if (txttopay.TextLength == 10 && txttopay.Text.IndexOf(",") == 3)
            {
                string newvalue = txttopay.Text;
                newvalue = newvalue.Remove(7, 1);
                newvalue = newvalue.Insert(6, ",");
                newvalue = newvalue.Remove(3, 1);
                newvalue = newvalue.Insert(2, ",");
                txttopay.Text = newvalue;
            }
            else if (txttopay.TextLength == 11 && txttopay.Text.IndexOf(",") == 2)
            {
                string newvalue = txttopay.Text;
                newvalue = newvalue.Remove(6, 1);
                newvalue = newvalue.Insert(7, ",");
                newvalue = newvalue.Remove(2, 1);
                newvalue = newvalue.Insert(3, ",");
                txttopay.Text = newvalue;
            }


            txttopay.SelectionStart = txttopay.TextLength;
            CalculateRemainder();
        }

        private void cbcurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbcurrency.SelectedIndex)
            {
                case 0:
                    txttopay.MaxLength = 5;

                    break;
                case 1:
                    txttopay.MaxLength = 11;
                    break;
            }
            txttopay.Clear();
        }

      
        private void txttopay_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
    }
