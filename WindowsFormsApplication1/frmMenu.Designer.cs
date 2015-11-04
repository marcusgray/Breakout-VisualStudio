namespace Breakout


{
    partial class frmMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmdPlay = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cmdExit = new System.Windows.Forms.Button();
            this.cmdSettings = new System.Windows.Forms.Button();
            this.cmdControls = new System.Windows.Forms.Button();
            this.txtHighscores = new System.Windows.Forms.RichTextBox();
            this.lblHighscores = new System.Windows.Forms.Label();
            this.cmbMode = new System.Windows.Forms.ComboBox();
            this.lblMode = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdPlay
            // 
            this.cmdPlay.Location = new System.Drawing.Point(79, 258);
            this.cmdPlay.Name = "cmdPlay";
            this.cmdPlay.Size = new System.Drawing.Size(168, 49);
            this.cmdPlay.TabIndex = 0;
            this.cmdPlay.Text = "Play";
            this.cmdPlay.UseVisualStyleBackColor = true;
            this.cmdPlay.Click += new System.EventHandler(this.cmdPlay_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(69, 55);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(217, 55);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Breakout";
            // 
            // cmdExit
            // 
            this.cmdExit.Location = new System.Drawing.Point(79, 423);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(168, 49);
            this.cmdExit.TabIndex = 2;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // cmdSettings
            // 
            this.cmdSettings.Location = new System.Drawing.Point(79, 313);
            this.cmdSettings.Name = "cmdSettings";
            this.cmdSettings.Size = new System.Drawing.Size(168, 49);
            this.cmdSettings.TabIndex = 3;
            this.cmdSettings.Text = "Settings";
            this.cmdSettings.UseVisualStyleBackColor = true;
            this.cmdSettings.Click += new System.EventHandler(this.cmdSettings_Click);
            // 
            // cmdControls
            // 
            this.cmdControls.Location = new System.Drawing.Point(79, 368);
            this.cmdControls.Name = "cmdControls";
            this.cmdControls.Size = new System.Drawing.Size(168, 49);
            this.cmdControls.TabIndex = 4;
            this.cmdControls.Text = "Controls";
            this.cmdControls.UseVisualStyleBackColor = true;
            this.cmdControls.Click += new System.EventHandler(this.cmdControls_Click);
            // 
            // txtHighscores
            // 
            this.txtHighscores.BackColor = System.Drawing.SystemColors.Control;
            this.txtHighscores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHighscores.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtHighscores.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtHighscores.Location = new System.Drawing.Point(427, 162);
            this.txtHighscores.Name = "txtHighscores";
            this.txtHighscores.ReadOnly = true;
            this.txtHighscores.Size = new System.Drawing.Size(455, 428);
            this.txtHighscores.TabIndex = 7;
            this.txtHighscores.Text = "";
            // 
            // lblHighscores
            // 
            this.lblHighscores.AutoSize = true;
            this.lblHighscores.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighscores.Location = new System.Drawing.Point(418, 58);
            this.lblHighscores.Name = "lblHighscores";
            this.lblHighscores.Size = new System.Drawing.Size(239, 51);
            this.lblHighscores.TabIndex = 6;
            this.lblHighscores.Text = "Highscores";
            // 
            // cmbMode
            // 
            this.cmbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMode.FormattingEnabled = true;
            this.cmbMode.Items.AddRange(new object[] {
            "Classic",
            "Custom",
            "Co-op",
            "Versus"});
            this.cmbMode.Location = new System.Drawing.Point(152, 208);
            this.cmbMode.Name = "cmbMode";
            this.cmbMode.Size = new System.Drawing.Size(168, 33);
            this.cmbMode.TabIndex = 8;
            this.cmbMode.SelectedIndexChanged += new System.EventHandler(this.cmbMode_SelectedIndexChanged);
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(74, 211);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(72, 25);
            this.lblMode.TabIndex = 9;
            this.lblMode.Text = "Mode:";
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 602);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.cmbMode);
            this.Controls.Add(this.txtHighscores);
            this.Controls.Add(this.lblHighscores);
            this.Controls.Add(this.cmdControls);
            this.Controls.Add(this.cmdSettings);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.cmdPlay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmMenu";
            this.Text = "Breakout";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdPlay;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Button cmdSettings;
        private System.Windows.Forms.Button cmdControls;
        private System.Windows.Forms.RichTextBox txtHighscores;
        private System.Windows.Forms.Label lblHighscores;
        private System.Windows.Forms.ComboBox cmbMode;
        private System.Windows.Forms.Label lblMode;
    }
}