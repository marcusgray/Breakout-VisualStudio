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
    public partial class frmEnd : Form
    {
        private int score = 0;
        private bool manuallyClosing = false;
        private Form oldForm;

        public frmEnd(int Score, string ScoreText, Form OldForm)
        {
            InitializeComponent();
            score = Score;
            oldForm = OldForm;
            lblScores.Text = ScoreText;
            WriteResults();
            if(Game.CurrentMode != GameMode.Classic)
            {
                Controls.Remove(lblName);
                Controls.Remove(txtInput);
                Controls.Remove(cmdSubmit);
            }
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            string date = DateTime.Now.ToString();
            string result = Networking.SendResult(txtInput.Text, score, date);
            cmdSubmit.Enabled = false;
            txtInput.Enabled = false;
            WriteResults();
        }

        private void cmdRetry_Click(object sender, EventArgs e)
        {
            manuallyClosing = true;
            this.Close();
            oldForm.Close();
            new frmGame().Show();
        }

        private void cmdMenu_Click(object sender, EventArgs e)
        {
            manuallyClosing = true;
            this.Close();
            OpenMenu();
        }

        private void frmEnd_Closed(object sender, EventArgs e)
        {
            if(!manuallyClosing)
                OpenMenu();
        }

        private void OpenMenu()
        {
            oldForm.Close();
            new frmMenu().Show();
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
    }
}
