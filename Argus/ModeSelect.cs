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
    public partial class ModeSelect : Form
    {
        public MODE mode { get; set; }
        public ModeSelect(MODE _mode)
        {
            InitializeComponent();

            if (_mode == MODE.SECONDS) rdoSec.Select();
            if (_mode == MODE.MINUTES) rdoMin.Select();
            if (_mode == MODE.HOURS) rdoHour.Select();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (rdoSec.Checked) mode = MODE.SECONDS;
            if (rdoMin.Checked) mode = MODE.MINUTES;
            if (rdoHour.Checked) mode = MODE.HOURS;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
