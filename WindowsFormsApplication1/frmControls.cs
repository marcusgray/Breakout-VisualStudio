using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Breakout
{
    public partial class frmControls : Form
    {
        public frmControls()
        {
            InitializeComponent();
            this.FormClosed += delegate { new frmMenu().Show(); };
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
