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
            this.tmrSpawnPowerUps = new System.Windows.Forms.Timer(this.components);
            this.tmrMovePowerUps = new System.Windows.Forms.Timer(this.components);
            this.tmrRemovePowerUps = new System.Windows.Forms.Timer(this.components);
            this.lblPause = new System.Windows.Forms.Label();
            this.lblRound = new System.Windows.Forms.Label();
            this.settingMenu = new System.Windows.Forms.Panel();
            this.settingsXbtn = new System.Windows.Forms.Button();
            this.volumeBar = new System.Windows.Forms.HScrollBar();
            this.statsMenu = new System.Windows.Forms.Panel();
            this.moneyLabel = new System.Windows.Forms.Label();
            this.speedLabel = new System.Windows.Forms.Label();
            this.attackLabel = new System.Windows.Forms.Label();
            this.settingsBtn = new System.Windows.Forms.Button();
            this.btn_upSpeed = new System.Windows.Forms.Button();
            this.tmrBtnFix = new System.Windows.Forms.Timer(this.components);
            this.tmrRound = new System.Windows.Forms.Timer(this.components);
            this.btn_upAttack = new System.Windows.Forms.Button();
<<<<<<< Updated upstream
            this.settingMenu.SuspendLayout();
            this.statsMenu.SuspendLayout();
=======
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.settingMenu.SuspendLayout();
>>>>>>> Stashed changes
            this.SuspendLayout();
            // 
            // lblStoryLine
            // 
            this.lblStoryLine.BackColor = System.Drawing.Color.Transparent;
            this.lblStoryLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStoryLine.Font = new System.Drawing.Font("Segoe UI Emoji", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStoryLine.ForeColor = System.Drawing.Color.White;
<<<<<<< Updated upstream
            this.lblStoryLine.Location = new System.Drawing.Point(14, 12);
            this.lblStoryLine.Name = "lblStoryLine";
            this.lblStoryLine.Size = new System.Drawing.Size(1286, 825);
=======
            this.lblStoryLine.Location = new System.Drawing.Point(22, 17);
            this.lblStoryLine.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblStoryLine.Name = "lblStoryLine";
            this.lblStoryLine.Size = new System.Drawing.Size(2089, 1197);
>>>>>>> Stashed changes
            this.lblStoryLine.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.AutoSize = true;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
<<<<<<< Updated upstream
            this.btnStart.Location = new System.Drawing.Point(360, 823);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(251, 93);
=======
            this.btnStart.Location = new System.Drawing.Point(585, 1193);
            this.btnStart.Margin = new System.Windows.Forms.Padding(6);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(409, 135);
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
            this.btnStoryLine.Location = new System.Drawing.Point(720, 823);
            this.btnStoryLine.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStoryLine.Name = "btnStoryLine";
            this.btnStoryLine.Size = new System.Drawing.Size(251, 93);
=======
            this.btnStoryLine.Location = new System.Drawing.Point(1170, 1193);
            this.btnStoryLine.Margin = new System.Windows.Forms.Padding(6);
            this.btnStoryLine.Name = "btnStoryLine";
            this.btnStoryLine.Size = new System.Drawing.Size(409, 135);
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
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
=======
>>>>>>> Stashed changes
            // lblPause
            // 
            this.lblPause.BackColor = System.Drawing.Color.Transparent;
            this.lblPause.Font = new System.Drawing.Font("Segoe UI Emoji", 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPause.ForeColor = System.Drawing.Color.White;
<<<<<<< Updated upstream
            this.lblPause.Location = new System.Drawing.Point(14, 12);
            this.lblPause.Name = "lblPause";
            this.lblPause.Size = new System.Drawing.Size(297, 133);
=======
            this.lblPause.Location = new System.Drawing.Point(22, 17);
            this.lblPause.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPause.Name = "lblPause";
            this.lblPause.Size = new System.Drawing.Size(483, 193);
>>>>>>> Stashed changes
            this.lblPause.TabIndex = 0;
            this.lblPause.Text = "Paused";
            // 
            // lblRound
            // 
            this.lblRound.BackColor = System.Drawing.Color.Transparent;
            this.lblRound.Font = new System.Drawing.Font("Segoe UI Emoji", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRound.ForeColor = System.Drawing.Color.White;
            this.lblRound.Location = new System.Drawing.Point(0, 0);
<<<<<<< Updated upstream
            this.lblRound.Name = "lblRound";
            this.lblRound.Size = new System.Drawing.Size(400, 67);
=======
            this.lblRound.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblRound.Name = "lblRound";
            this.lblRound.Size = new System.Drawing.Size(650, 97);
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
            this.settingMenu.Location = new System.Drawing.Point(111, 132);
            this.settingMenu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.settingMenu.Name = "settingMenu";
            this.settingMenu.Size = new System.Drawing.Size(1090, 703);
=======
            this.settingMenu.Location = new System.Drawing.Point(180, 191);
            this.settingMenu.Margin = new System.Windows.Forms.Padding(6);
            this.settingMenu.Name = "settingMenu";
            this.settingMenu.Size = new System.Drawing.Size(1770, 1019);
>>>>>>> Stashed changes
            this.settingMenu.TabIndex = 4;
            // 
            // settingsXbtn
            // 
            this.settingsXbtn.BackgroundImage = global::TowerDefense_TheRPG.Properties.Resources.xbutton;
            this.settingsXbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.settingsXbtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
<<<<<<< Updated upstream
            this.settingsXbtn.Location = new System.Drawing.Point(1050, 4);
            this.settingsXbtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.settingsXbtn.Name = "settingsXbtn";
            this.settingsXbtn.Size = new System.Drawing.Size(34, 40);
=======
            this.settingsXbtn.Location = new System.Drawing.Point(1707, 6);
            this.settingsXbtn.Margin = new System.Windows.Forms.Padding(6);
            this.settingsXbtn.Name = "settingsXbtn";
            this.settingsXbtn.Size = new System.Drawing.Size(56, 58);
>>>>>>> Stashed changes
            this.settingsXbtn.TabIndex = 1;
            this.settingsXbtn.TabStop = false;
            this.settingsXbtn.UseVisualStyleBackColor = true;
            this.settingsXbtn.Click += new System.EventHandler(this.settingsXbtn_Click);
            // 
            // volumeBar
            // 
            this.volumeBar.Cursor = System.Windows.Forms.Cursors.Hand;
<<<<<<< Updated upstream
            this.volumeBar.Location = new System.Drawing.Point(459, 148);
            this.volumeBar.Name = "volumeBar";
            this.volumeBar.Size = new System.Drawing.Size(400, 21);
=======
            this.volumeBar.Location = new System.Drawing.Point(747, 215);
            this.volumeBar.Name = "volumeBar";
            this.volumeBar.Size = new System.Drawing.Size(650, 21);
>>>>>>> Stashed changes
            this.volumeBar.TabIndex = 0;
            this.volumeBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.volumeBar_Scroll);
            // 
            // statsMenu
            // 
            this.statsMenu.BackColor = System.Drawing.Color.DarkSlateGray;
            this.statsMenu.BackgroundImage = global::TowerDefense_TheRPG.Properties.Resources.StatsMenu;
            this.statsMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.statsMenu.Controls.Add(this.moneyLabel);
            this.statsMenu.Controls.Add(this.speedLabel);
            this.statsMenu.Controls.Add(this.attackLabel);
            this.statsMenu.Location = new System.Drawing.Point(5, 248);
            this.statsMenu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.statsMenu.Name = "statsMenu";
            this.statsMenu.Size = new System.Drawing.Size(375, 473);
            this.statsMenu.TabIndex = 2;
            this.statsMenu.Visible = false;
            // 
            // moneyLabel
            // 
            this.moneyLabel.AutoSize = true;
            this.moneyLabel.BackColor = System.Drawing.Color.Transparent;
            this.moneyLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.moneyLabel.ForeColor = System.Drawing.Color.White;
            this.moneyLabel.Location = new System.Drawing.Point(208, 345);
            this.moneyLabel.Name = "moneyLabel";
            this.moneyLabel.Size = new System.Drawing.Size(97, 41);
            this.moneyLabel.TabIndex = 2;
            this.moneyLabel.Text = "label3";
            this.moneyLabel.Visible = false;
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.BackColor = System.Drawing.Color.Transparent;
            this.speedLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.speedLabel.ForeColor = System.Drawing.Color.White;
            this.speedLabel.Location = new System.Drawing.Point(208, 200);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(97, 41);
            this.speedLabel.TabIndex = 1;
            this.speedLabel.Text = "label2";
            this.speedLabel.Visible = false;
            // 
            // attackLabel
            // 
            this.attackLabel.AutoSize = true;
            this.attackLabel.BackColor = System.Drawing.Color.Transparent;
            this.attackLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.attackLabel.ForeColor = System.Drawing.Color.White;
            this.attackLabel.Location = new System.Drawing.Point(208, 69);
            this.attackLabel.Name = "attackLabel";
            this.attackLabel.Size = new System.Drawing.Size(97, 41);
            this.attackLabel.TabIndex = 0;
            this.attackLabel.Text = "label1";
            this.attackLabel.Visible = false;
            // 
            // settingsBtn
            // 
            this.settingsBtn.BackgroundImage = global::TowerDefense_TheRPG.Properties.Resources.settings;
            this.settingsBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
<<<<<<< Updated upstream
            this.settingsBtn.Location = new System.Drawing.Point(14, 9);
            this.settingsBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(34, 40);
=======
            this.settingsBtn.Location = new System.Drawing.Point(22, 14);
            this.settingsBtn.Margin = new System.Windows.Forms.Padding(6);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(56, 58);
>>>>>>> Stashed changes
            this.settingsBtn.TabIndex = 1;
            this.settingsBtn.TabStop = false;
            this.settingsBtn.UseVisualStyleBackColor = true;
            this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
            // 
            // btn_upSpeed
            // 
            this.btn_upSpeed.AutoSize = true;
            this.btn_upSpeed.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_upSpeed.Location = new System.Drawing.Point(0, 0);
<<<<<<< Updated upstream
            this.btn_upSpeed.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_upSpeed.Name = "btn_upSpeed";
            this.btn_upSpeed.Size = new System.Drawing.Size(137, 47);
=======
            this.btn_upSpeed.Margin = new System.Windows.Forms.Padding(6);
            this.btn_upSpeed.Name = "btn_upSpeed";
            this.btn_upSpeed.Size = new System.Drawing.Size(223, 68);
>>>>>>> Stashed changes
            this.btn_upSpeed.TabIndex = 1;
            this.btn_upSpeed.TabStop = false;
            this.btn_upSpeed.UseVisualStyleBackColor = true;
            this.btn_upSpeed.Click += new System.EventHandler(this.upSpeed_Click);
            // 
            // tmrBtnFix
            // 
            this.tmrBtnFix.Tick += new System.EventHandler(this.tmrBtnReset);
            // 
            // tmrRound
            // 
            this.tmrRound.Tick += new System.EventHandler(this.round_Tick);
            // 
            // btn_upAttack
            // 
            this.btn_upAttack.AutoSize = true;
            this.btn_upAttack.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_upAttack.Location = new System.Drawing.Point(0, 0);
<<<<<<< Updated upstream
            this.btn_upAttack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_upAttack.Name = "btn_upAttack";
            this.btn_upAttack.Size = new System.Drawing.Size(137, 47);
=======
            this.btn_upAttack.Margin = new System.Windows.Forms.Padding(6);
            this.btn_upAttack.Name = "btn_upAttack";
            this.btn_upAttack.Size = new System.Drawing.Size(223, 68);
>>>>>>> Stashed changes
            this.btn_upAttack.TabIndex = 1;
            this.btn_upAttack.TabStop = false;
            this.btn_upAttack.UseVisualStyleBackColor = true;
            this.btn_upAttack.Click += new System.EventHandler(this.upAttack_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(1020, 20);
            this.textBox1.MaxLength = 7;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(542, 71);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "Player";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(701, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 58);
            this.label1.TabIndex = 6;
            this.label1.Text = "Player Name:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // FrmMain
            // 
<<<<<<< Updated upstream
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
=======
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 29F);
>>>>>>> Stashed changes
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::TowerDefense_TheRPG.Properties.Resources.title;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
<<<<<<< Updated upstream
            this.ClientSize = new System.Drawing.Size(1313, 968);
=======
            this.ClientSize = new System.Drawing.Size(2134, 1404);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.settingsBtn);
>>>>>>> Stashed changes
            this.Controls.Add(this.settingMenu);
            this.Controls.Add(this.settingsBtn);
            this.Controls.Add(this.statsMenu);
            this.Controls.Add(this.btnStoryLine);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblStoryLine);
            this.Controls.Add(this.lblPause);
            this.Controls.Add(this.lblRound);
            this.Controls.Add(this.btn_upSpeed);
            this.Controls.Add(this.btn_upAttack);
            this.DoubleBuffered = true;
<<<<<<< Updated upstream
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
=======
            this.Margin = new System.Windows.Forms.Padding(6);
>>>>>>> Stashed changes
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tower Defense The RPG";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.settingMenu.ResumeLayout(false);
            this.statsMenu.ResumeLayout(false);
            this.statsMenu.PerformLayout();
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
        private System.Windows.Forms.Timer tmrBtnFix;
        private System.Windows.Forms.Timer tmrRound;
        private System.Windows.Forms.Timer tmrSpawnPowerUps;
        private System.Windows.Forms.Timer tmrMovePowerUps;
        private System.Windows.Forms.Timer tmrRemovePowerUps;
        private Label lblPause;
        internal Panel settingMenu;
        internal HScrollBar volumeBar;
        private Button settingsXbtn;
        private Button settingsBtn;
        private Label lblRound;
        private Button btn_upSpeed;
        private Button btn_upAttack;
<<<<<<< Updated upstream
        private Panel statsMenu;
        private Label moneyLabel;
        private Label speedLabel;
        private Label attackLabel;
=======
        private TextBox textBox1;
        private Label label1;
>>>>>>> Stashed changes
    }
}