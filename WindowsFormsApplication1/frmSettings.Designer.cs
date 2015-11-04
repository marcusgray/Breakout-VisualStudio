namespace Breakout
{
    partial class frmSettings
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
            this.cmdBack = new System.Windows.Forms.Button();
            this.cmdDefaults = new System.Windows.Forms.Button();
            this.lblPaddleSpeedTitle = new System.Windows.Forms.Label();
            this.lblBallSpeedTitle = new System.Windows.Forms.Label();
            this.lblBallMaxSpeedTitle = new System.Windows.Forms.Label();
            this.lblBallSpeedIncreaseTitle = new System.Windows.Forms.Label();
            this.lblPaddleSpeedValue = new System.Windows.Forms.Label();
            this.barPaddleSpeed = new System.Windows.Forms.TrackBar();
            this.barBallSpeed = new System.Windows.Forms.TrackBar();
            this.lblBallSpeedValue = new System.Windows.Forms.Label();
            this.barBallMaxSpeed = new System.Windows.Forms.TrackBar();
            this.lblBallMaxSpeedValue = new System.Windows.Forms.Label();
            this.barBallSpeedIncrease = new System.Windows.Forms.TrackBar();
            this.lblBallSpeedIncreaseValue = new System.Windows.Forms.Label();
            this.barBlockColumns = new System.Windows.Forms.TrackBar();
            this.lblBlockColumnsValue = new System.Windows.Forms.Label();
            this.barBlockRows = new System.Windows.Forms.TrackBar();
            this.lblBlockRowsValue = new System.Windows.Forms.Label();
            this.lblBlockColumnsTitle = new System.Windows.Forms.Label();
            this.lblBlockRowsTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barPaddleSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barBallSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barBallMaxSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barBallSpeedIncrease)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barBlockColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barBlockRows)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdBack
            // 
            this.cmdBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBack.Location = new System.Drawing.Point(12, 534);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Size = new System.Drawing.Size(163, 82);
            this.cmdBack.TabIndex = 5;
            this.cmdBack.Text = "Back";
            this.cmdBack.UseVisualStyleBackColor = true;
            this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
            // 
            // cmdDefaults
            // 
            this.cmdDefaults.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDefaults.Location = new System.Drawing.Point(596, 534);
            this.cmdDefaults.Name = "cmdDefaults";
            this.cmdDefaults.Size = new System.Drawing.Size(163, 82);
            this.cmdDefaults.TabIndex = 6;
            this.cmdDefaults.Text = "Defaults";
            this.cmdDefaults.UseVisualStyleBackColor = true;
            this.cmdDefaults.Click += new System.EventHandler(this.cmdDefaults_Click);
            // 
            // lblPaddleSpeedTitle
            // 
            this.lblPaddleSpeedTitle.AutoSize = true;
            this.lblPaddleSpeedTitle.Location = new System.Drawing.Point(28, 36);
            this.lblPaddleSpeedTitle.Name = "lblPaddleSpeedTitle";
            this.lblPaddleSpeedTitle.Size = new System.Drawing.Size(147, 25);
            this.lblPaddleSpeedTitle.TabIndex = 7;
            this.lblPaddleSpeedTitle.Text = "Paddle Speed";
            // 
            // lblBallSpeedTitle
            // 
            this.lblBallSpeedTitle.AutoSize = true;
            this.lblBallSpeedTitle.Location = new System.Drawing.Point(28, 157);
            this.lblBallSpeedTitle.Name = "lblBallSpeedTitle";
            this.lblBallSpeedTitle.Size = new System.Drawing.Size(116, 25);
            this.lblBallSpeedTitle.TabIndex = 8;
            this.lblBallSpeedTitle.Text = "Ball Speed";
            // 
            // lblBallMaxSpeedTitle
            // 
            this.lblBallMaxSpeedTitle.AutoSize = true;
            this.lblBallMaxSpeedTitle.Location = new System.Drawing.Point(28, 278);
            this.lblBallMaxSpeedTitle.Name = "lblBallMaxSpeedTitle";
            this.lblBallMaxSpeedTitle.Size = new System.Drawing.Size(163, 25);
            this.lblBallMaxSpeedTitle.TabIndex = 9;
            this.lblBallMaxSpeedTitle.Text = "Ball Max Speed";
            // 
            // lblBallSpeedIncreaseTitle
            // 
            this.lblBallSpeedIncreaseTitle.AutoSize = true;
            this.lblBallSpeedIncreaseTitle.Location = new System.Drawing.Point(28, 399);
            this.lblBallSpeedIncreaseTitle.Name = "lblBallSpeedIncreaseTitle";
            this.lblBallSpeedIncreaseTitle.Size = new System.Drawing.Size(204, 25);
            this.lblBallSpeedIncreaseTitle.TabIndex = 10;
            this.lblBallSpeedIncreaseTitle.Text = "Ball Speed Increase";
            // 
            // lblPaddleSpeedValue
            // 
            this.lblPaddleSpeedValue.AutoSize = true;
            this.lblPaddleSpeedValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaddleSpeedValue.Location = new System.Drawing.Point(300, 64);
            this.lblPaddleSpeedValue.Name = "lblPaddleSpeedValue";
            this.lblPaddleSpeedValue.Size = new System.Drawing.Size(29, 31);
            this.lblPaddleSpeedValue.TabIndex = 11;
            this.lblPaddleSpeedValue.Text = "0";
            // 
            // barPaddleSpeed
            // 
            this.barPaddleSpeed.Location = new System.Drawing.Point(33, 64);
            this.barPaddleSpeed.Maximum = 20;
            this.barPaddleSpeed.Minimum = 5;
            this.barPaddleSpeed.Name = "barPaddleSpeed";
            this.barPaddleSpeed.Size = new System.Drawing.Size(261, 90);
            this.barPaddleSpeed.TabIndex = 16;
            this.barPaddleSpeed.Value = 5;
            this.barPaddleSpeed.Scroll += new System.EventHandler(this.barPaddleSpeed_Scroll);
            // 
            // barBallSpeed
            // 
            this.barBallSpeed.Location = new System.Drawing.Point(33, 185);
            this.barBallSpeed.Maximum = 30;
            this.barBallSpeed.Minimum = 5;
            this.barBallSpeed.Name = "barBallSpeed";
            this.barBallSpeed.Size = new System.Drawing.Size(261, 90);
            this.barBallSpeed.TabIndex = 18;
            this.barBallSpeed.Value = 5;
            this.barBallSpeed.Scroll += new System.EventHandler(this.barBallSpeed_Scroll);
            // 
            // lblBallSpeedValue
            // 
            this.lblBallSpeedValue.AutoSize = true;
            this.lblBallSpeedValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBallSpeedValue.Location = new System.Drawing.Point(300, 185);
            this.lblBallSpeedValue.Name = "lblBallSpeedValue";
            this.lblBallSpeedValue.Size = new System.Drawing.Size(29, 31);
            this.lblBallSpeedValue.TabIndex = 17;
            this.lblBallSpeedValue.Text = "0";
            // 
            // barBallMaxSpeed
            // 
            this.barBallMaxSpeed.Location = new System.Drawing.Point(33, 306);
            this.barBallMaxSpeed.Maximum = 30;
            this.barBallMaxSpeed.Minimum = 5;
            this.barBallMaxSpeed.Name = "barBallMaxSpeed";
            this.barBallMaxSpeed.Size = new System.Drawing.Size(261, 90);
            this.barBallMaxSpeed.TabIndex = 20;
            this.barBallMaxSpeed.Value = 5;
            this.barBallMaxSpeed.Scroll += new System.EventHandler(this.barBallMaxSpeed_Scroll);
            // 
            // lblBallMaxSpeedValue
            // 
            this.lblBallMaxSpeedValue.AutoSize = true;
            this.lblBallMaxSpeedValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBallMaxSpeedValue.Location = new System.Drawing.Point(300, 306);
            this.lblBallMaxSpeedValue.Name = "lblBallMaxSpeedValue";
            this.lblBallMaxSpeedValue.Size = new System.Drawing.Size(29, 31);
            this.lblBallMaxSpeedValue.TabIndex = 19;
            this.lblBallMaxSpeedValue.Text = "0";
            // 
            // barBallSpeedIncrease
            // 
            this.barBallSpeedIncrease.LargeChange = 1;
            this.barBallSpeedIncrease.Location = new System.Drawing.Point(33, 427);
            this.barBallSpeedIncrease.Name = "barBallSpeedIncrease";
            this.barBallSpeedIncrease.Size = new System.Drawing.Size(261, 90);
            this.barBallSpeedIncrease.TabIndex = 22;
            this.barBallSpeedIncrease.Scroll += new System.EventHandler(this.barBallSpeedIncrease_Scroll);
            // 
            // lblBallSpeedIncreaseValue
            // 
            this.lblBallSpeedIncreaseValue.AutoSize = true;
            this.lblBallSpeedIncreaseValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBallSpeedIncreaseValue.Location = new System.Drawing.Point(300, 427);
            this.lblBallSpeedIncreaseValue.Name = "lblBallSpeedIncreaseValue";
            this.lblBallSpeedIncreaseValue.Size = new System.Drawing.Size(29, 31);
            this.lblBallSpeedIncreaseValue.TabIndex = 21;
            this.lblBallSpeedIncreaseValue.Text = "0";
            // 
            // barBlockColumns
            // 
            this.barBlockColumns.Location = new System.Drawing.Point(433, 185);
            this.barBlockColumns.Maximum = 16;
            this.barBlockColumns.Minimum = 1;
            this.barBlockColumns.Name = "barBlockColumns";
            this.barBlockColumns.Size = new System.Drawing.Size(261, 90);
            this.barBlockColumns.TabIndex = 30;
            this.barBlockColumns.Value = 1;
            this.barBlockColumns.Scroll += new System.EventHandler(this.barBlockColumns_Scroll);
            // 
            // lblBlockColumnsValue
            // 
            this.lblBlockColumnsValue.AutoSize = true;
            this.lblBlockColumnsValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlockColumnsValue.Location = new System.Drawing.Point(700, 185);
            this.lblBlockColumnsValue.Name = "lblBlockColumnsValue";
            this.lblBlockColumnsValue.Size = new System.Drawing.Size(29, 31);
            this.lblBlockColumnsValue.TabIndex = 29;
            this.lblBlockColumnsValue.Text = "0";
            // 
            // barBlockRows
            // 
            this.barBlockRows.Location = new System.Drawing.Point(433, 64);
            this.barBlockRows.Minimum = 2;
            this.barBlockRows.Name = "barBlockRows";
            this.barBlockRows.Size = new System.Drawing.Size(261, 90);
            this.barBlockRows.TabIndex = 28;
            this.barBlockRows.Value = 2;
            this.barBlockRows.Scroll += new System.EventHandler(this.barBlockRows_Scroll);
            // 
            // lblBlockRowsValue
            // 
            this.lblBlockRowsValue.AutoSize = true;
            this.lblBlockRowsValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlockRowsValue.Location = new System.Drawing.Point(700, 64);
            this.lblBlockRowsValue.Name = "lblBlockRowsValue";
            this.lblBlockRowsValue.Size = new System.Drawing.Size(29, 31);
            this.lblBlockRowsValue.TabIndex = 27;
            this.lblBlockRowsValue.Text = "0";
            // 
            // lblBlockColumnsTitle
            // 
            this.lblBlockColumnsTitle.AutoSize = true;
            this.lblBlockColumnsTitle.Location = new System.Drawing.Point(428, 157);
            this.lblBlockColumnsTitle.Name = "lblBlockColumnsTitle";
            this.lblBlockColumnsTitle.Size = new System.Drawing.Size(155, 25);
            this.lblBlockColumnsTitle.TabIndex = 24;
            this.lblBlockColumnsTitle.Text = "Block Columns";
            // 
            // lblBlockRowsTitle
            // 
            this.lblBlockRowsTitle.AutoSize = true;
            this.lblBlockRowsTitle.Location = new System.Drawing.Point(428, 36);
            this.lblBlockRowsTitle.Name = "lblBlockRowsTitle";
            this.lblBlockRowsTitle.Size = new System.Drawing.Size(124, 25);
            this.lblBlockRowsTitle.TabIndex = 23;
            this.lblBlockRowsTitle.Text = "Block Rows";
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 628);
            this.Controls.Add(this.barBlockColumns);
            this.Controls.Add(this.lblBlockColumnsValue);
            this.Controls.Add(this.barBlockRows);
            this.Controls.Add(this.lblBlockRowsValue);
            this.Controls.Add(this.lblBlockColumnsTitle);
            this.Controls.Add(this.lblBlockRowsTitle);
            this.Controls.Add(this.barBallSpeedIncrease);
            this.Controls.Add(this.lblBallSpeedIncreaseValue);
            this.Controls.Add(this.barBallMaxSpeed);
            this.Controls.Add(this.lblBallMaxSpeedValue);
            this.Controls.Add(this.barBallSpeed);
            this.Controls.Add(this.lblBallSpeedValue);
            this.Controls.Add(this.barPaddleSpeed);
            this.Controls.Add(this.lblPaddleSpeedValue);
            this.Controls.Add(this.lblBallSpeedIncreaseTitle);
            this.Controls.Add(this.lblBallMaxSpeedTitle);
            this.Controls.Add(this.lblBallSpeedTitle);
            this.Controls.Add(this.lblPaddleSpeedTitle);
            this.Controls.Add(this.cmdDefaults);
            this.Controls.Add(this.cmdBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmSettings";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.barPaddleSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barBallSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barBallMaxSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barBallSpeedIncrease)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barBlockColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barBlockRows)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdBack;
        private System.Windows.Forms.Button cmdDefaults;
        private System.Windows.Forms.Label lblPaddleSpeedTitle;
        private System.Windows.Forms.Label lblBallSpeedTitle;
        private System.Windows.Forms.Label lblBallMaxSpeedTitle;
        private System.Windows.Forms.Label lblBallSpeedIncreaseTitle;
        private System.Windows.Forms.Label lblPaddleSpeedValue;
        private System.Windows.Forms.TrackBar barPaddleSpeed;
        private System.Windows.Forms.TrackBar barBallSpeed;
        private System.Windows.Forms.Label lblBallSpeedValue;
        private System.Windows.Forms.TrackBar barBallMaxSpeed;
        private System.Windows.Forms.Label lblBallMaxSpeedValue;
        private System.Windows.Forms.TrackBar barBallSpeedIncrease;
        private System.Windows.Forms.Label lblBallSpeedIncreaseValue;
        private System.Windows.Forms.TrackBar barBlockColumns;
        private System.Windows.Forms.Label lblBlockColumnsValue;
        private System.Windows.Forms.TrackBar barBlockRows;
        private System.Windows.Forms.Label lblBlockRowsValue;
        private System.Windows.Forms.Label lblBlockColumnsTitle;
        private System.Windows.Forms.Label lblBlockRowsTitle;

    }
}