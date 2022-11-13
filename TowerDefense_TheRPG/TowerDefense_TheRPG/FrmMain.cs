using TowerDefense_TheRPG.code;
using TowerDefense_TheRPG.Properties;
using System.Windows.Media;


namespace TowerDefense_TheRPG
{
    public partial class FrmMain : Form
    {
        #region Fields
        public MediaPlayer bgMusic;
        public MediaPlayer rdMusic;
        private string FilePath;
        private Player player;
        private Village village;
        private List<Enemy> enemies;
        private List<Arrow> arrows;
        private string storyLine;
        private int curStoryLineIndex;
        private Random rand;
        private bool pause = false;
        private bool inSettings = false;
        private int round = 1;
        private bool arrowBefore;
        private int MoneySpeedCounter = 10;
        private int MoneyAttackCounter = 10;
        #endregion

        #region Methods
        #region Ctor
        public FrmMain()
        {
            InitializeComponent();
            FilePath = Directory.GetCurrentDirectory();
            FilePath = Path.GetFullPath(Path.Combine(FilePath, @"..\..\..\"));
            bgMusic = new MediaPlayer();
            rdMusic = new MediaPlayer();
            bgMusic.MediaEnded += new EventHandler(BGMusic_Ended);
            rdMusic.Open(new Uri(FilePath + "data/horn002-106060.wav"));
            bgMusic.Open(new Uri(FilePath + "data/rpg-city-8381.wav"));
            bgMusic.Play();
            lblRound.Visible = false;
            btn_upSpeed.Visible = false;
            btn_upSpeed.Enabled = false;
            btn_upAttack.Enabled = false;
            btn_upAttack.Visible = false;
            settingMenu.Visible = false;
            volumeBar.Visible = false;
            volumeBar.Maximum = 100;
            volumeBar.Minimum = 0;
            volumeBar.Value = (int)(bgMusic.Volume * 100);
            settingsXbtn.Visible = false;
            FormManager.PushToFormStack(this);
            DoubleBuffered = true;
            ControlManager.ResMan = Resources.ResourceManager;
            ControlManager.Form = this;
            rand = new Random();
        }
        #endregion

        #region Event functions
        private void BGMusic_Ended(object sender, EventArgs e)
        {
            bgMusic.Position = TimeSpan.Zero;
            bgMusic.Play();
        }

        // timers
        private void tmrTextCrawl_Tick(object sender, EventArgs e)
        {
            if (curStoryLineIndex < storyLine.Length)
            {
                lblStoryLine.Text += storyLine[curStoryLineIndex++];
                lblStoryLine.Refresh();
            }
            else
            {
                tmrTextCrawl.Enabled = false;
            }
        }
        private void tmrSpawnEnemies_Tick(object sender, EventArgs e)
        {
            GenEnemyPos(out int x, out int y);

            Enemy balloon;
            switch (round)
            {
                case 1:
                    tmrSpawnEnemies.Interval = 3000;
                    balloon = Enemy.MakeRedBalloon(x, y);
                    break;
                case 2:
                    tmrSpawnEnemies.Interval = 2000;
                    balloon = Enemy.MakeRedBalloon(x, y);
                    break;
                case 3:
                    tmrSpawnEnemies.Interval = 3000;
                    balloon = Enemy.MakeOrangeBalloon(x, y);
                    break;
                case 4:
                    tmrSpawnEnemies.Interval = 2000;
                    balloon = Enemy.MakeOrangeBalloon(x, y);
                    break;
                case 5:
                    tmrSpawnEnemies.Interval = 2000;
                    balloon = Enemy.MakePurpleBalloon(x, y);
                    break;
                case 6:
                    tmrSpawnEnemies.Interval = 1000;
                    balloon = Enemy.MakePurpleBalloon(x, y);
                    break;
                case 7:
                    tmrSpawnEnemies.Interval = 2000;
                    balloon = Enemy.MakeGrayBalloon(x, y);
                    break;
                case 8:
                    tmrSpawnEnemies.Interval = 1000;
                    balloon = Enemy.MakeGrayBalloon(x, y);
                    break;
                default:
                    balloon = Enemy.MakeRedBalloon(x, y);
                    break;

            }
            enemies.Add(balloon);
        }
        private void tmrMoveEnemies_Tick(object sender, EventArgs e)
        {
            MoveEnemies();
        }
        private void tmrSpawnArrows_Tick(object sender, EventArgs e)
        {
            FireArrows();
        }
        private void tmrMoveArrows_Tick(object sender, EventArgs e)
        {
            MoveArrows();
        }
        private void tmrBtnReset(object sender, EventArgs e)
        {
            if (btn_upSpeed.Visible == false)
            {
                btn_upSpeed.Visible = true;
                btn_upSpeed.Enabled = true;
            }
            if (btn_upAttack.Visible == false)
            {
                btn_upAttack.Visible = true;
                btn_upAttack.Enabled = true;
            }
        }
        private void round_Tick(object sender, EventArgs e)
        {
            CenterVillage();
            btn_upSpeed.Location = new System.Drawing.Point(((Width / 2) - 300), ((Height / 2) + 300));
            btn_upAttack.Location = new System.Drawing.Point(((Width / 2) + 100), ((Height / 2) + 300));
            lblRound.Location = new System.Drawing.Point(((Width / 2) - 150), ((Height / 2) - 400));
            roundHelper(player.Level, player.XP, player.Money);
        }

        // form
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (inSettings)
                {
                    settingsXbtn.PerformClick();
                }
                else
                {
                    SwapPause(e.KeyCode);
                }
            }
            else if (!pause)
            {
                PlayerMove(e.KeyCode);
            }
            
        }

        // buttons
        private void btnStart_Click(object sender, EventArgs e)
        {
            bgMusic.Open(new Uri(FilePath + "data/comatose-114706.wav"));
            bgMusic.Play();
            BackgroundImage = null;
            btnStart.Visible = false;
            btnStart.Enabled = false;
            btnStoryLine.Visible = false;
            btnStart.Enabled = false;
            lblStoryLine.Visible = false;

            enemies = new List<Enemy>();
            arrows = new List<Arrow>();
            player = new Player(Width / 2, Height / 2 + 100);
            village = new Village(Width / 2 - 80, Height / 2 - 50);
            village.ControlContainer.SendToBack();
            tmrSpawnEnemies.Enabled = true;
            tmrMoveEnemies.Enabled = true;
            tmrMoveArrows.Enabled = true;
            tmrTextCrawl.Enabled = false;
            lblPause.Visible = false;
            lblRound.Visible = true;
            tmrRound.Enabled = true;

            // TODO: setting the background image here causes visual defects as enemies and player move
            //       around the screen. Consider either fixing these defects or setting BackgroundImage to null
            BackgroundImage = Resources.ground;

            // important, keep this call to Focus()!
            // otherwise, for whatever reason, the start button retains focus (even when enabled = false)
            // and arrow key presses are ignored and won't move player.
            Focus();
        }
        private void btnStoryLine_Click(object sender, EventArgs e)
        {
            if (btnStoryLine.Text.StartsWith("Show"))
            {
                bgMusic.Open(new Uri(FilePath + "data/never-again-108445.wav"));
                bgMusic.Play();
                Storyline();
                BackgroundImage = null;
                btnStart.Visible = false;
                btnStoryLine.Text = "Hide Storyline";
                lblStoryLine.Visible = true;

                tmrSpawnEnemies.Enabled = false;
                tmrMoveEnemies.Enabled = false;
                tmrMoveArrows.Enabled = false;
                tmrTextCrawl.Enabled = true;
                lblPause.Visible = false;
                btn_upSpeed.Enabled = false;
                btn_upSpeed.Visible = false;
                btn_upAttack.Enabled = false;
                btn_upAttack.Visible = false;
            }
            else
            {
                bgMusic.Open(new Uri(FilePath + "data/rpg-city-8381.wav"));
                bgMusic.Play();
                BackgroundImage = Resources.title;
                btnStart.Visible = true;
                btnStoryLine.Text = "Show Storyline";
                lblStoryLine.Visible = false;
                tmrTextCrawl.Enabled = false;
                lblPause.Visible = false;
            }
        }

        private void settingsXbtn_Click(object sender, EventArgs e)
        {
            settingMenu.Visible = false;
            volumeBar.Visible = false;
            settingsXbtn.Visible = false;
            settingsXbtn.Enabled = false;
            settingsBtn.Visible = true;
            settingsBtn.Enabled = true;
            inSettings = false;
            Focus();
        }

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            settingMenu.Visible = true;
            volumeBar.Visible = true;
            settingsXbtn.Visible = true;
            settingsXbtn.Enabled = true;
            settingsBtn.Visible = false;
            settingsBtn.Enabled = false;
            pause = false;
            inSettings = true;
            if (lblRound.Visible)
                SwapPause(Keys.Escape);
            Focus();
        }

        private void volumeBar_Scroll(object sender, ScrollEventArgs e)
        {
            bgMusic.Volume = ((double)volumeBar.Value / 100);
            rdMusic.Volume = bgMusic.Volume;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Focus();
        }
        private void upSpeed_Click(object sender, EventArgs e)
        {
            if (player.Money >= MoneySpeedCounter)
            {
                player.SpendMoney(MoneySpeedCounter);
                player.upgradeMoveSpeed();
                MoneySpeedCounter += 5;
            }
            btn_upSpeed.Text = "SPD^ $" + MoneySpeedCounter.ToString();
            btn_upSpeed.Visible = false;
            btn_upSpeed.Enabled = false;

            Focus();
        }
        private void upAttack_Click(object sender, EventArgs e)
        {
            if (player.Money >= MoneyAttackCounter)
            {
                player.SpendMoney(MoneyAttackCounter);
                player.upgradeAttack();
                MoneyAttackCounter += 5;
            }
            btn_upAttack.Text = "ATK^ $" + MoneyAttackCounter.ToString();
            btn_upAttack.Visible = false;
            btn_upAttack.Enabled = false;

            Focus();
        }
        private void Pause(object sender, KeyEventArgs e)
        {
            SwapPause(e.KeyCode);
        }


        #endregion

        #region Helper functions 
        private void Storyline()
        {
            // TODO: probably should be read from a resource text file
            storyLine = "Ok, you want a story line, here it is. Once upon a time, there was this village. ";
            storyLine += "In this village were towers. These were great times where towers could roam around, ";
            storyLine += "free of their nature predator..... the balloon! One day, dark clouds appeared in the sky. ";
            storyLine += "It looked like M Night Shamaleon was creating another movie. Then, something strange happened! ";
            storyLine += "Evil balloons started entering the village. 1 balloon, then 2 balloons, then several more. The towers became afraid. ";
            storyLine += "As everyone knows, if a balloon hits a tower and pops, the tower loses health (and it hurts the tower's feelings). ";
            storyLine += "Well, one of the towers was having none of this and decided to take action! Wearing the only balloon proof vest in the entire town, ";
            storyLine += "Peaches the tower stood guard against the balloons. ";
            storyLine += "Your role in this game is to play as Peaches and defeat the evil balloons thereby defending the village (and the towers within).";
            lblStoryLine.Text = "";
            tmrTextCrawl.Enabled = true;
            curStoryLineIndex = 0;
        }
        public void CenterVillage()
        {
            village.ControlContainer.Top = ((Height - 100) / 2);
            village.ControlContainer.Left = ((Width - 165) / 2);
        }
        public int getRound(int level)
        {
            if (level % 10 == 0)
            {
                rdMusic.Play();
                round = (level / 10)+1;
            }
            return round;
        }
        public void roundHelper(int level, int xp, int money)
        {
            lblRound.Text = ("Round:" + getRound(level).ToString() + " | Level:" + level.ToString() + " | $:" + money.ToString());
        }
        public void GenEnemyPos(out int x, out int y)
        {
            int enterDir = rand.Next(4);
            const int offscreen = 50;
            switch (enterDir)
            {
                case 0: // left
                    y = rand.Next(0, Height);
                    x = -offscreen;
                    break;
                case 1: // bottom
                    x = rand.Next(0, Width);
                    y = Height + offscreen;
                    break;
                case 2: // right
                    y = rand.Next(0, Height);
                    x = Width + offscreen;
                    break;
                default: // top
                    x = rand.Next(0, Width);
                    y = -offscreen;
                    break;
            }
        }
        private void MoveEnemies()
        {
            foreach (var enemy in enemies)
            {
                if (enemy.CurHealth <= 0)
                {
                    continue;
                }
                int xDir = 0;
                int yDir = 0;
                if (enemy.ControlContainer.Left < Width / 2)
                {
                    xDir = 1;
                }
                else
                {
                    xDir = -1;
                }
                if (enemy.ControlContainer.Top < Height / 2)
                {
                    yDir = 1;
                }
                else
                {
                    yDir = -1;
                }
                enemy.Move(xDir, yDir);
                if (enemy.DidCollide(player))
                {
                    enemy.TakeDamageFrom(player);
                    if (enemy.CurHealth <= 0)
                    {
                        enemy.Hide();
                        int levelBefore = player.Level;
                        player.GainXP(enemy.XPGiven);
                        player.GainMoney(enemy.MoneyGiven);
                        int levelAfter = player.Level;
                        if (levelBefore == 1 && levelAfter == 2)
                        {
                            tmrSpawnArrows.Enabled = true;
                            tmrMoveArrows.Enabled = true;
                            FireArrows();
                        }
                        else if (levelBefore == 2 && levelAfter == 3)
                        {
                            tmrSpawnArrows.Interval = 2500;
                            tmrSpawnArrows.Enabled = true;
                            FireArrows();
                        }
                    }
                    else
                    {
                        enemy.KnockBack();
                    }
                }
                else if (enemy.DidCollide(village))
                {
                    village.TakeDamageFrom(enemy);
                    if (village.CurHealth <= 0)
                    {
                        village.Hide(); // defeated
                        bgMusic.Stop();
                        Form frmGO = new FrmGameOver(bgMusic.Volume);
                        frmGO.Show();
                        this.Hide();
                        FormManager.PushToFormStack(frmGO);

                        // disable timers
                        tmrMoveArrows.Enabled = false;
                        tmrMoveEnemies.Enabled = false;
                        tmrSpawnArrows.Enabled = false;

                        tmrSpawnEnemies.Enabled = false;
                    }
                    else
                    {
                        enemy.KnockBack();
                    }
                }
            }

            List<Enemy> enemiesToRemove = new List<Enemy>();
            foreach (Enemy enemy in enemies)
            {
                if (enemy.CurHealth <= 0)
                {
                    enemiesToRemove.Add(enemy);
                }
            }

            foreach (Enemy enemy in enemiesToRemove)
            {
                enemies.Remove(enemy);
            }
        }
        private void MoveArrows()
        {
            List<Arrow> arrowsToRemove = new List<Arrow>();
            foreach (Arrow arrow in arrows)
            {
                arrow.Move();
                foreach (Enemy enemy in enemies)
                {
                    if (arrow.DidCollide(enemy))
                    {
                        enemy.TakeDamage(0.1f);
                        if (enemy.CurHealth <= 0)
                        {
                            enemy.Hide();
                            player.GainXP(enemy.XPGiven);
                        }
                        else
                        {
                            enemy.KnockBack();
                        }
                        arrowsToRemove.Add(arrow);
                    }
                }
            }
            foreach (Arrow arrow in arrowsToRemove)
            {
                arrows.Remove(arrow);
                Controls.Remove(arrow.ControlCharacter);
            }
        }
        private void FireArrows()
        {
            Arrow arrowLeft = new Arrow(player.X, player.Y, -1, 0);
            Arrow arrowRight = new Arrow(player.X, player.Y, +1, 0);
            arrows.Add(arrowLeft);
            arrows.Add(arrowRight);
            arrowLeft.ControlCharacter.BringToFront();
            arrowRight.ControlCharacter.BringToFront();
        }
        private void PlayerMove(Keys keyCode)
        {
            switch (keyCode)
            {
                case Keys.Up:
                case Keys.W:
                    player.Move(0, -1);
                    break;
                case Keys.Down:
                case Keys.S:
                    player.Move(0, +1);
                    break;
                case Keys.Left:
                case Keys.A:
                    player.Move(-1, 0);
                    break;
                case Keys.Right:
                case Keys.D:
                    player.Move(+1, 0);
                    break;
                case Keys.Escape:
                    SwapPause(Keys.Escape);
                    break;
            }
        }
        
        private void SwapPause(Keys keyCode)
        {
            if (keyCode == Keys.Escape)
            {
                pause = !pause;
            }
            if (pause)
            {
                tmrBtnFix.Enabled = true;
                tmrSpawnEnemies.Enabled = false;
                tmrMoveEnemies.Enabled = false;
                arrowBefore = tmrSpawnArrows.Enabled;
                tmrSpawnArrows.Enabled = false;
                tmrMoveArrows.Enabled = false;
                lblPause.Visible = true;
                btn_upSpeed.Visible = true;
                btn_upSpeed.Enabled = true;
                btn_upAttack.Enabled = true;
                btn_upAttack.Visible = true;
                btn_upSpeed.Text = "SPD^ $" + MoneySpeedCounter.ToString();
                btn_upAttack.Text = "ATK^ $" + MoneyAttackCounter.ToString();
            }
            else
            {
                tmrSpawnEnemies.Enabled = true;
                tmrMoveEnemies.Enabled = true;
                tmrSpawnArrows.Enabled = arrowBefore;
                tmrMoveArrows.Enabled = true;
                btn_upSpeed.Visible = false;
                btn_upSpeed.Enabled = false;
                btn_upAttack.Enabled = false;
                btn_upAttack.Visible = false;
                lblPause.Visible = false;
                tmrBtnFix.Enabled = false;
            }
        }
        #endregion

        #endregion
    }
}
