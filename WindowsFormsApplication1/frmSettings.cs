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
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
            this.FormClosed += delegate { new frmMenu().Show(); };
            updateSettings();
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdDefaults_Click(object sender, EventArgs e)
        {
            Game.SpeedIncrease = Game.DefaultSpeedIncrease;
            Game.MaxSpeed = Game.DefaultMaxSpeed;
            Game.StartSpeed = Game.DefaultStartSpeed;
            Game.PaddleSpeed = Game.DefaultPaddleSpeed;
            Game.BlockRows = Game.DefaultBlockRows;
            Game.BlockColumns = Game.DefaultBlockColumns;
            updateSettings();
        }

        private void updateSettings()
        {
            updateSettingsValue();
            updateSettingsText();
        }

        private void updateSettingsValue()
        {
            barBlockRows.Value = Game.BlockRows;
            barBlockColumns.Value = Game.BlockColumns;
            barBallSpeedIncrease.Value = (int)(Game.SpeedIncrease * 10);
            barBallMaxSpeed.Value = (int)(Game.MaxSpeed * 10);
            barBallSpeed.Value = (int)(Game.StartSpeed * 10);
            barPaddleSpeed.Value = (int)(Game.PaddleSpeed * 10);
        }

        private void updateSettingsText()
        {
            lblBallMaxSpeedValue.Text = Game.MaxSpeed.ToString();
            lblBallSpeedIncreaseValue.Text = Game.SpeedIncrease.ToString();
            lblBallSpeedValue.Text = Game.StartSpeed.ToString();
            lblPaddleSpeedValue.Text = Game.PaddleSpeed.ToString();
            lblBlockRowsValue.Text = Game.BlockRows.ToString();
            lblBlockColumnsValue.Text = Game.BlockColumns.ToString();
        }

        private void barBlockRows_Scroll(object sender, EventArgs e)
        {
            Game.BlockRows = barBlockRows.Value;
            updateSettingsText();
        }

        private void barBlockColumns_Scroll(object sender, EventArgs e)
        {
            Game.BlockColumns = barBlockColumns.Value;
            updateSettingsText();
        }

        private void barBallSpeedIncrease_Scroll(object sender, EventArgs e)
        {
            Game.SpeedIncrease = barBallSpeedIncrease.Value*0.1f;
            updateSettingsText();
        }

        private void barBallMaxSpeed_Scroll(object sender, EventArgs e)
        {
            Game.MaxSpeed = barBallMaxSpeed.Value * 0.1f;
            updateSettingsText();
        }

        private void barBallSpeed_Scroll(object sender, EventArgs e)
        {
            Game.StartSpeed = barBallSpeed.Value * 0.1f;
            updateSettingsText();
        }

        private void barPaddleSpeed_Scroll(object sender, EventArgs e)
        {
            Game.PaddleSpeed = barPaddleSpeed.Value * 0.1f;
            updateSettingsText();
        }
    }
}
