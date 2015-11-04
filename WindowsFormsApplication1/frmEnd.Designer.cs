namespace Breakout


{
    partial class frmEnd
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtHighscores = new System.Windows.Forms.RichTextBox();
            this.cmdSubmit = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.cmdRetry = new System.Windows.Forms.Button();
            this.cmdMenu = new System.Windows.Forms.Button();
            this.lblScores = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(359, 21);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(239, 51);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Highscores";
            // 
            // txtHighscores
            // 
            this.txtHighscores.BackColor = System.Drawing.SystemColors.Control;
            this.txtHighscores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHighscores.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtHighscores.Location = new System.Drawing.Point(368, 122);
            this.txtHighscores.Name = "txtHighscores";
            this.txtHighscores.ReadOnly = true;
            this.txtHighscores.Size = new System.Drawing.Size(518, 442);
            this.txtHighscores.TabIndex = 1;
            this.txtHighscores.Text = "";
            // 
            // cmdSubmit
            // 
            this.cmdSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSubmit.Location = new System.Drawing.Point(12, 230);
            this.cmdSubmit.Name = "cmdSubmit";
            this.cmdSubmit.Size = new System.Drawing.Size(221, 52);
            this.cmdSubmit.TabIndex = 2;
            this.cmdSubmit.Text = "Submit";
            this.cmdSubmit.UseVisualStyleBackColor = true;
            this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
            // 
            // txtInput
            // 
            this.txtInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput.Location = new System.Drawing.Point(12, 180);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(221, 44);
            this.txtInput.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(5, 140);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(112, 37);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Name:";
            // 
            // cmdRetry
            // 
            this.cmdRetry.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRetry.Location = new System.Drawing.Point(12, 436);
            this.cmdRetry.Name = "cmdRetry";
            this.cmdRetry.Size = new System.Drawing.Size(221, 61);
            this.cmdRetry.TabIndex = 5;
            this.cmdRetry.Text = "Retry";
            this.cmdRetry.UseVisualStyleBackColor = true;
            this.cmdRetry.Click += new System.EventHandler(this.cmdRetry_Click);
            // 
            // cmdMenu
            // 
            this.cmdMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMenu.Location = new System.Drawing.Point(12, 503);
            this.cmdMenu.Name = "cmdMenu";
            this.cmdMenu.Size = new System.Drawing.Size(221, 61);
            this.cmdMenu.TabIndex = 6;
            this.cmdMenu.Text = "Menu";
            this.cmdMenu.UseVisualStyleBackColor = true;
            this.cmdMenu.Click += new System.EventHandler(this.cmdMenu_Click);
            // 
            // lblScores
            // 
            this.lblScores.AutoSize = true;
            this.lblScores.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScores.Location = new System.Drawing.Point(12, 21);
            this.lblScores.Name = "lblScores";
            this.lblScores.Size = new System.Drawing.Size(158, 51);
            this.lblScores.TabIndex = 7;
            this.lblScores.Text = "Score: ";
            // 
            // frmEnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 576);
            this.Controls.Add(this.lblScores);
            this.Controls.Add(this.cmdMenu);
            this.Controls.Add(this.cmdRetry);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.cmdSubmit);
            this.Controls.Add(this.txtHighscores);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmEnd";
            this.Text = "Game Over";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmEnd_Closed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.RichTextBox txtHighscores;
        private System.Windows.Forms.Button cmdSubmit;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button cmdRetry;
        private System.Windows.Forms.Button cmdMenu;
        private System.Windows.Forms.Label lblScores;
    }
}