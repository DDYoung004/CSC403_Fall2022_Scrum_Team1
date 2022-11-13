namespace TowerDefense_TheRPG
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblStoryLine = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.tmrTextCrawl = new System.Windows.Forms.Timer(this.components);
            this.tmrSpawnEnemies = new System.Windows.Forms.Timer(this.components);
            this.tmrMoveEnemies = new System.Windows.Forms.Timer(this.components);
            this.btnStoryLine = new System.Windows.Forms.Button();
            this.tmrMoveArrows = new System.Windows.Forms.Timer(this.components);
            this.tmrSpawnArrows = new System.Windows.Forms.Timer(this.components);
            this.lblPause = new System.Windows.Forms.Label();
            this.lblRound = new System.Windows.Forms.Label();
            this.settingMenu = new System.Windows.Forms.Panel();
            this.settingsXbtn = new System.Windows.Forms.Button();
            this.volumeBar = new System.Windows.Forms.HScrollBar();
            this.settingsBtn = new System.Windows.Forms.Button();
            this.settingMenu.SuspendLayout();
            this.tmrSpawnPowerUps = new System.Windows.Forms.Timer(this.components);
            this.tmrMovePowerUps = new System.Windows.Forms.Timer(this.components);
            this.tmrRemovePowerUps = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblStoryLine
            // 
            this.lblStoryLine.BackColor = System.Drawing.Color.Transparent;
            this.lblStoryLine.Font = new System.Drawing.Font("Segoe UI Emoji", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStoryLine.ForeColor = System.Drawing.Color.White;
            this.lblStoryLine.Location = new System.Drawing.Point(12, 9);
            this.lblStoryLine.Name = "lblStoryLine";
            this.lblStoryLine.Size = new System.Drawing.Size(1125, 619);
            this.lblStoryLine.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.AutoSize = true;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnStart.Location = new System.Drawing.Point(315, 617);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(220, 70);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Play";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tmrTextCrawl
            // 
            this.tmrTextCrawl.Interval = 20;
            this.tmrTextCrawl.Tick += new System.EventHandler(this.tmrTextCrawl_Tick);
            // 
            // tmrSpawnEnemies
            // 
            this.tmrSpawnEnemies.Interval = 3000;
            this.tmrSpawnEnemies.Tick += new System.EventHandler(this.tmrSpawnEnemies_Tick);
            // 
            // tmrMoveEnemies
            // 
            this.tmrMoveEnemies.Tick += new System.EventHandler(this.tmrMoveEnemies_Tick);
            // 
            // btnStoryLine
            // 
            this.btnStoryLine.AutoSize = true;
            this.btnStoryLine.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnStoryLine.Location = new System.Drawing.Point(630, 617);
            this.btnStoryLine.Name = "btnStoryLine";
            this.btnStoryLine.Size = new System.Drawing.Size(220, 70);
            this.btnStoryLine.TabIndex = 3;
            this.btnStoryLine.Text = "Show Storyline";
            this.btnStoryLine.UseVisualStyleBackColor = true;
            this.btnStoryLine.Click += new System.EventHandler(this.btnStoryLine_Click);
            // 
            // tmrMoveArrows
            // 
            this.tmrMoveArrows.Interval = 10;
            this.tmrMoveArrows.Tick += new System.EventHandler(this.tmrMoveArrows_Tick);
            // 
            // tmrSpawnArrows
            // 
            this.tmrSpawnArrows.Interval = 5000;
            this.tmrSpawnArrows.Tick += new System.EventHandler(this.tmrSpawnArrows_Tick);
            // 
            // lblPause
            // 
            this.lblPause.BackColor = System.Drawing.Color.Transparent;
            this.lblPause.Font = new System.Drawing.Font("Segoe UI Emoji", 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPause.ForeColor = System.Drawing.Color.White;
            this.lblPause.Location = new System.Drawing.Point(12, 9);
            this.lblPause.Name = "lblPause";
            this.lblPause.Size = new System.Drawing.Size(260, 100);
            this.lblPause.TabIndex = 0;
            this.lblPause.Text = "Paused";
            // 
            // lblRound
            // 
            this.lblRound.BackColor = System.Drawing.Color.Transparent;
            this.lblRound.Font = new System.Drawing.Font("Segoe UI Emoji", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRound.ForeColor = System.Drawing.Color.White;
            this.lblRound.Location = new System.Drawing.Point(770, 9);
            this.lblRound.Name = "lblRound";
            this.lblRound.Size = new System.Drawing.Size(250, 50);
            this.lblRound.TabIndex = 0;
            // 
            // settingMenu
            // 
            this.settingMenu.BackColor = System.Drawing.Color.DarkSlateGray;
            this.settingMenu.BackgroundImage = global::TowerDefense_TheRPG.Properties.Resources.SettingMenu;
            this.settingMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.settingMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.settingMenu.Controls.Add(this.settingsXbtn);
            this.settingMenu.Controls.Add(this.volumeBar);
            this.settingMenu.Location = new System.Drawing.Point(97, 99);
            this.settingMenu.Name = "settingMenu";
            this.settingMenu.Size = new System.Drawing.Size(954, 528);
            this.settingMenu.TabIndex = 4;
            // 
            // settingsXbtn
            // 
            this.settingsXbtn.BackgroundImage = global::TowerDefense_TheRPG.Properties.Resources.xbutton;
            this.settingsXbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.settingsXbtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.settingsXbtn.Location = new System.Drawing.Point(919, 3);
            this.settingsXbtn.Name = "settingsXbtn";
            this.settingsXbtn.Size = new System.Drawing.Size(30, 30);
            this.settingsXbtn.TabIndex = 1;
            this.settingsXbtn.TabStop = false;
            this.settingsXbtn.UseVisualStyleBackColor = true;
            this.settingsXbtn.Click += new System.EventHandler(this.settingsXbtn_Click);
            // 
            // volumeBar
            // 
            this.volumeBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.volumeBar.Location = new System.Drawing.Point(402, 111);
            this.volumeBar.Name = "volumeBar";
            this.volumeBar.Size = new System.Drawing.Size(350, 21);
            this.volumeBar.TabIndex = 0;
            this.volumeBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.volumeBar_Scroll);
            // 
            // settingsBtn
            // 
            this.settingsBtn.BackgroundImage = global::TowerDefense_TheRPG.Properties.Resources.settings;
            this.settingsBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.settingsBtn.Location = new System.Drawing.Point(1107, 9);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(30, 30);
            this.settingsBtn.TabIndex = 1;
            this.settingsBtn.TabStop = false;
            this.settingsBtn.UseVisualStyleBackColor = true;
            this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
            // 
            // tmrSpawnPowerUps
            // 
            this.tmrSpawnPowerUps.Interval = 15000;
            this.tmrSpawnPowerUps.Tick += new System.EventHandler(this.tmrSpawnPowerUps_Tick);
            // 
            // tmrMovePowerUps
            // 
            this.tmrMovePowerUps.Tick += new System.EventHandler(this.tmrMovePowerUps_Tick);
            // 
            // tmrRemovePowerUps
            // 
            this.tmrRemovePowerUps.Interval = 10000;
            this.tmrRemovePowerUps.Tick += new System.EventHandler(this.tmrRemovePowerUps_tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::TowerDefense_TheRPG.Properties.Resources.title;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1149, 726);
            this.Controls.Add(this.settingsBtn);
            this.Controls.Add(this.settingMenu);
            this.Controls.Add(this.btnStoryLine);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblStoryLine);
            this.Controls.Add(this.lblPause);
            this.Controls.Add(this.lblRound);
            this.DoubleBuffered = true;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tower Defense The RPG";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.settingMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblStoryLine;
        private Button btnStart;
        private System.Windows.Forms.Timer tmrTextCrawl;
        private System.Windows.Forms.Timer tmrSpawnEnemies;
        private System.Windows.Forms.Timer tmrMoveEnemies;
        private Button btnStoryLine;
        private System.Windows.Forms.Timer tmrMoveArrows;
        private System.Windows.Forms.Timer tmrSpawnArrows;
        private Label lblPause;
        internal Panel settingMenu;
        internal HScrollBar volumeBar;
        private Button settingsXbtn;
        private Button settingsBtn;
        private Label lblRound;
        private System.Windows.Forms.Timer tmrSpawnPowerUps;
        private System.Windows.Forms.Timer tmrMovePowerUps;
        private System.Windows.Forms.Timer tmrRemovePowerUps;
    }
}