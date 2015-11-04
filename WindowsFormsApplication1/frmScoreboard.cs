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
    public partial class frmScoreboard : Form
    {
        public frmScoreboard()
        {
            InitializeComponent();
            this.FormClosed += delegate { new frmMenu().Show(); };
            WriteResults();
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void WriteResults()
        {
            txtHighscores.Text = String.Empty;
            List<HighScore> Results = Networking.GetResults();
            try
            {
                foreach (HighScore result in Results)
                {
                    txtHighscores.Text += result.ID.ToString() + ". " + result.Name + " - " + result.Score.ToString() + " (" + result.Date + ") \n";
                }
            }
            catch
            {
            }
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            WriteResults();
        }
    }
}
