using Argus.src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Argus
{
    public partial class AlertDialog : Form
    {
        public Alert alert { get; set; }
        public AlertDialog(Alert _alert)
        {
            InitializeComponent();

            alert = new Alert { type = _alert.type };
            if (_alert.initialized == true)
            {
                thresholdTxt.Text = _alert.threshold.ToString();
                messageTxt.Text = _alert.message.ToString();
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            alert.threshold = Convert.ToInt32(thresholdTxt.Text);
            alert.message = messageTxt.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void thresholdTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void thresholdTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (thresholdTxt.Text != "")
            {
                var current = Convert.ToInt32(thresholdTxt.Text);
                thresholdTxt.Text = (current % 100).ToString();
            }
        }
    }
}
