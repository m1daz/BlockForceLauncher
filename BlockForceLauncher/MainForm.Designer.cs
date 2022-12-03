namespace BlockForceLauncher
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.comboVersion = new System.Windows.Forms.ComboBox();
            this.mainProcess = new System.Windows.Forms.Label();
            this.subProcess = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gunaFormAddon = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.launchButton = new Guna.UI2.WinForms.Guna2Button();
            this.bfLoadWindowAnim = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.downloadProgress = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(213, 386);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(609, 34);
            this.label1.TabIndex = 2;
            this.label1.Text = "Loading Version...";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboVersion
            // 
            this.comboVersion.Cursor = System.Windows.Forms.Cursors.No;
            this.comboVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboVersion.FormattingEnabled = true;
            this.comboVersion.Items.AddRange(new object[] {
            "Release",
            "Beta"});
            this.comboVersion.Location = new System.Drawing.Point(361, 425);
            this.comboVersion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboVersion.Name = "comboVersion";
            this.comboVersion.Size = new System.Drawing.Size(315, 28);
            this.comboVersion.TabIndex = 0;
            this.comboVersion.SelectedIndexChanged += new System.EventHandler(this.comboVersion_SelectedIndexChanged);
            // 
            // mainProcess
            // 
            this.mainProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mainProcess.AutoSize = true;
            this.mainProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainProcess.ForeColor = System.Drawing.Color.White;
            this.mainProcess.Location = new System.Drawing.Point(-3, 489);
            this.mainProcess.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mainProcess.Name = "mainProcess";
            this.mainProcess.Size = new System.Drawing.Size(199, 25);
            this.mainProcess.TabIndex = 5;
            this.mainProcess.Text = "Downloading Game";
            this.mainProcess.Visible = false;
            // 
            // subProcess
            // 
            this.subProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.subProcess.AutoSize = true;
            this.subProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subProcess.ForeColor = System.Drawing.Color.White;
            this.subProcess.Location = new System.Drawing.Point(0, 519);
            this.subProcess.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.subProcess.Name = "subProcess";
            this.subProcess.Size = new System.Drawing.Size(55, 20);
            this.subProcess.TabIndex = 6;
            this.subProcess.Text = "0/0MB";
            this.subProcess.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(361, 92);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(315, 290);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // gunaFormAddon
            // 
            this.gunaFormAddon.ContainerControl = this;
            this.gunaFormAddon.DockIndicatorTransparencyValue = 0.6D;
            this.gunaFormAddon.TransparentWhileDrag = true;
            // 
            // launchButton
            // 
            this.launchButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.launchButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.launchButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.launchButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.launchButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.launchButton.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.launchButton.ForeColor = System.Drawing.Color.White;
            this.launchButton.Location = new System.Drawing.Point(361, 469);
            this.launchButton.Name = "launchButton";
            this.launchButton.Size = new System.Drawing.Size(315, 61);
            this.launchButton.TabIndex = 7;
            this.launchButton.Text = "Launch";
            this.launchButton.Click += new System.EventHandler(this.launchButton_Click);
            // 
            // bfLoadWindowAnim
            // 
            this.bfLoadWindowAnim.AnimationType = Guna.UI2.WinForms.Guna2AnimateWindow.AnimateWindowType.AW_ACTIVATE;
            this.bfLoadWindowAnim.TargetForm = this;
            // 
            // downloadProgress
            // 
            this.downloadProgress.Location = new System.Drawing.Point(2, 575);
            this.downloadProgress.Name = "downloadProgress";
            this.downloadProgress.Size = new System.Drawing.Size(1065, 47);
            this.downloadProgress.TabIndex = 8;
            this.downloadProgress.Text = "downloadProgressBar";
            this.downloadProgress.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.downloadProgress.Visible = false;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.guna2Panel1.Controls.Add(this.exitButton);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Location = new System.Drawing.Point(-7, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1074, 65);
            this.guna2Panel1.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Candara", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(19, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 36);
            this.label2.TabIndex = 0;
            this.label2.Text = "Block Source";
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.75F);
            this.exitButton.ForeColor = System.Drawing.Color.White;
            this.exitButton.Location = new System.Drawing.Point(1009, 0);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(65, 65);
            this.exitButton.TabIndex = 10;
            this.exitButton.Text = "X";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.ClientSize = new System.Drawing.Size(1067, 615);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.downloadProgress);
            this.Controls.Add(this.launchButton);
            this.Controls.Add(this.subProcess);
            this.Controls.Add(this.mainProcess);
            this.Controls.Add(this.comboVersion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Block Source Launcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboVersion;
        private System.Windows.Forms.Label mainProcess;
        private System.Windows.Forms.Label subProcess;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2BorderlessForm gunaFormAddon;
        private Guna.UI2.WinForms.Guna2Button launchButton;
        private Guna.UI2.WinForms.Guna2AnimateWindow bfLoadWindowAnim;
        private Guna.UI2.WinForms.Guna2ProgressBar downloadProgress;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button exitButton;
    }
}

