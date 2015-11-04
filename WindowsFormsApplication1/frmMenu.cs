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
    public partial class frmMenu : Form
    {
        private bool manuallyClosing = false;

        public frmMenu()
        {
            InitializeComponent();
            this.FormClosed += delegate
            {
                if(!manuallyClosing)
                    Application.Exit();
            };
            cmbMode.SelectedIndex = 0;
            txtHighscores.Text = String.Empty;
            try
            {
                foreach (HighScore result in Networking.GetResults())
                {
                    txtHighscores.Text += result.ID.ToString() + ". " + result.Name + " - " + result.Score.ToString() + " (" + result.Date + ") \n";
                }
            }
            catch
            {
            }
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdPlay_Click(object sender, EventArgs e)
        {
            manuallyClosing = true;
            this.Close();
            new frmGame().Show();
        }

        private void cmdSettings_Click(object sender, EventArgs e)
        {
            manuallyClosing = true;
            this.Close();
            new frmSettings().Show();
        }

        private void cmdControls_Click(object sender, EventArgs e)
        {
            manuallyClosing = true;
            this.Close();
            new frmControls().Show();
        }

        private void cmbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Console.WriteLine(cmbMode.SelectedIndex);
            if (cmbMode.SelectedIndex == 0)
                Game.CurrentMode = GameMode.Classic;
            if (cmbMode.SelectedIndex == 1)
                Game.CurrentMode = GameMode.Custom;
            if (cmbMode.SelectedIndex == 2)
                Game.CurrentMode = GameMode.Coop;
            if (cmbMode.SelectedIndex == 3)
                Game.CurrentMode = GameMode.Versus;
        }
    }
}
