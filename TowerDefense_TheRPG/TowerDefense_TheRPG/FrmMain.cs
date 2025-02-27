using TowerDefense_TheRPG.code;
using TowerDefense_TheRPG.Properties;
using System.Windows.Media;
using System.Data;

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
        private List<PowerUp> power_ups;
        private List<Tuple<int, string>> power_up_temp;
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
            attackLabel.Text = ((int)(player.Attack * 100)).ToString();
            speedLabel.Text = (player.MoveSpeed).ToString();
            moneyLabel.Text = "$" + player.Money.ToString();
            btn_upSpeed.Location = new System.Drawing.Point(((Width / 2) - 300), ((Height / 2) + 300));
            btn_upAttack.Location = new System.Drawing.Point(((Width / 2) + 100), ((Height / 2) + 300));
            lblRound.Location = new System.Drawing.Point(((Width / 2) - 150), ((Height / 2) - 400));
            roundHelper(player.Level, player.XP, player.Money);
        }
        private void tmrSpawnPowerUps_Tick(object sender, EventArgs e)
        {
            GenPowerUpPos(out int x, out int y);
            int powerUpType = rand.Next(2);
            PowerUp powerup;
            switch (powerUpType)
            {
                case 0:
                    powerup = PowerUp.MakeAtackPowerUp(x, y);
                    break;
                default:
                    powerup = PowerUp.MakeSpeedPowerUp(x, y);
                    break;
            }
            power_ups.Add(powerup);
        }
        private void tmrMovePowerUps_Tick(object sender, EventArgs e)
        {
            MovePowerUps();
        }

        private void tmrRemovePowerUps_tick(object sender, EventArgs e)
        {
            RemovePowerUps();
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

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (player is object)
            {
                if (village.IsVisible == true)
                {
                    SwapPause(Keys.Escape);
                    DialogResult dialogResult = MessageBox.Show("Save Player?", "Saver", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        SaveStats();
                    }
                }
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
            power_ups = new List<PowerUp>();
            power_up_temp = new List<Tuple<int, string>>();
            arrows = new List<Arrow>();
            player = new Player(Width / 2, Height / 2 + 100);
            player.Name = textBox1.Text; // set player name attribute from the text box on the start screen
            textBox1.Visible = false; // have to hide element so that it does not override player controls (it will)
            textBox1.Enabled = false; // see previous comment above
            label1.Visible = false; // also have to hide this
            player.ControlNameLabel.Text = player.Name;
            player.ControlNameLabel.Visible = true;
            player.ControlHealthBarFull.Visible = false;
            player.ControlHealthBarEmpty.Visible = false;
            village = new Village(Width / 2 - 80, Height / 2 - 50);
            village.ControlContainer.SendToBack();
            tmrSpawnEnemies.Enabled = true;
            tmrMoveEnemies.Enabled = true;
            tmrSpawnPowerUps.Enabled = true;
            tmrMovePowerUps.Enabled = true;
            tmrRemovePowerUps.Enabled = true;
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

            // string path = String.Format(@"{0}\SavedPlayer.txt", Application.StartupPath);
            if (File.Exists("SavedPlayer.txt"))
            {
                DialogResult dialogResult = MessageBox.Show("Do You Want To Load Your Previous Player", "Loader", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    LoadStats();
                }
            }
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
                tmrSpawnPowerUps.Enabled = false;
                tmrMovePowerUps.Enabled = false;
                tmrRemovePowerUps.Enabled = false;
                tmrMoveArrows.Enabled = false;
                tmrTextCrawl.Enabled = true;
                lblPause.Visible = false;
                btn_upSpeed.Enabled = false;
                btn_upSpeed.Visible = false;
                btn_upAttack.Enabled = false;
                btn_upAttack.Visible = false;
                textBox1.Visible = false;
                label1.Visible = false;
                settingsBtn.Visible = false;
                settingsXbtn.Visible = false;
                settingMenu.Visible = false;
                volumeBar.Visible = false;
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
                textBox1.Visible = true;
                label1.Visible = true;
                settingsBtn.Visible = true;
                settingsBtn.Enabled = true;
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
            getRound(level);
            lblRound.Text = ("Round:" + round.ToString() + " | Level:" + level.ToString());
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
        public void GenPowerUpPos(out int x, out int y)
        {
            x = rand.Next(60, Width - 60);
            y = rand.Next(60, Height - 60);
        }
        private void MovePowerUps()
        {
            List<PowerUp> powerUpsToRemove = new List<PowerUp>();
            foreach (PowerUp power in power_ups)
            {
                if (power.DidCollide(player))
                {
                    power.TakeDamageFrom(player);
                    if (power.CurHealth <= 0)
                    {
                        power.Hide();
                        player.GainTempStats(power.StatsMultiplier, power.StatsType);
                        power_up_temp.Add(Tuple.Create(power.StatsMultiplier, power.StatsType));
                    }
                    powerUpsToRemove.Add(power);
                }
            }
            foreach (PowerUp power in powerUpsToRemove)
            {
                power_ups.Remove(power);
            }
        }
        private void RemovePowerUps()
        {
            //if (power_up_temp?.Any() == false)
            //{
            //    power_up_temp.Add(Tuple.Create(0, "attack"));
            //}
            if (power_up_temp.Count() >= 1)
            {
                Tuple<int, string> power = power_up_temp[0];
                power_up_temp.RemoveAt(0);
                player.RemoveTempStats(power.Item1, power.Item2);
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
                        tmrSpawnPowerUps.Enabled = false;
                        tmrMovePowerUps.Enabled = false;
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
                            player.GainMoney(enemy.MoneyGiven);
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
                tmrSpawnPowerUps.Enabled = false;
                lblPause.Visible = true;
                btn_upSpeed.Visible = true;
                btn_upSpeed.Enabled = true;
                btn_upAttack.Enabled = true;
                btn_upAttack.Visible = true;
                attackLabel.Visible = true;
                speedLabel.Visible = true;
                moneyLabel.Visible = true;
                statsMenu.Visible = true;
                btn_upSpeed.Text = "SPD^ $" + MoneySpeedCounter.ToString();
                btn_upAttack.Text = "ATK^ $" + MoneyAttackCounter.ToString();
            }
            else
            {
                tmrSpawnEnemies.Enabled = true;
                tmrMoveEnemies.Enabled = true;
                tmrSpawnArrows.Enabled = arrowBefore;
                tmrMoveArrows.Enabled = true;
                tmrSpawnPowerUps.Enabled = true;
                btn_upSpeed.Visible = false;
                btn_upSpeed.Enabled = false;
                btn_upAttack.Enabled = false;
                btn_upAttack.Visible = false;
                attackLabel.Visible = false;
                speedLabel.Visible = false;
                moneyLabel.Visible = false;
                statsMenu.Visible = false;
                lblPause.Visible = false;
                tmrBtnFix.Enabled = false;
            }
        }

        private void SaveStats()
        {
            // create/overwrite the text file
            TextWriter tw = new StreamWriter("SavedPlayer.txt");

            // write lines of text to the file
            tw.WriteLine(player.Money);
            tw.WriteLine(player.XP);
            tw.WriteLine(player.Level);
            tw.WriteLine(player.AutoShoot);
            tw.WriteLine(player.Attack);
            tw.WriteLine(player.MaxHealth);
            tw.WriteLine(player.CurHealth);
            tw.WriteLine(player.MoveSpeed);
            tw.WriteLine(round);
            tw.WriteLine(player.Name);



            // close the stream     
            tw.Close();
        }

        private void LoadStats()
        {
            // create reader and open file
            TextReader tr = new StreamReader("SavedPlayer.txt");

            // read lines of text
            string money = tr.ReadLine();
            string xp = tr.ReadLine();
            string lvl = tr.ReadLine();
            string auto_shoot = tr.ReadLine();
            string attack = tr.ReadLine();
            string max_health = tr.ReadLine();
            string curr_health = tr.ReadLine();
            string move_speed = tr.ReadLine();
            string theRound = tr.ReadLine();
            string playerName = tr.ReadLine();

            //Convert the strings to int, bool, or float
            int one;
            if (int.TryParse(money, out one))
            {
                player.Money = one;
                Console.WriteLine("Money: " + one);
            }
            if (int.TryParse(xp, out one))
            {
                player.XP = one;
                Console.WriteLine("XP: " + one);
            }
            if (int.TryParse(lvl, out one))
            {
                player.Level = one;
                Console.WriteLine("Level: " + one);
            }
            bool two;
            if (bool.TryParse(auto_shoot, out two))
            {
                player.AutoShoot = two;
                Console.WriteLine("AutoShoot: " + two);
            }
            float three;
            if (float.TryParse(attack, out three))
            {
                player.Attack = three;
                Console.WriteLine("Attack: " + three);
            }
            if (float.TryParse(max_health, out three))
            {
                player.MaxHealth = three;
                Console.WriteLine("MaxHealth: " + three);
            }
            if (float.TryParse(curr_health, out three))
            {
                player.CurHealth = three;
                Console.WriteLine("CurHealth: " + three);
            }
            if (int.TryParse(move_speed, out one))
            {
                player.MoveSpeed = one;
                Console.WriteLine("MoveSpeed: " + one);
            }
            if (int.TryParse(theRound, out one))
            {
                round = one;
            }
            player.Name = playerName;
            player.ControlNameLabel.Text = player.Name;


            // close the stream
            tr.Close();

            UpdateStats();
        }

        /// <summary>
        /// function used to update things related to stats when you load a previous save
        /// </summary>
        public void UpdateStats()
        {
            if (player.Level <= 3)
            {
                player.UpdatePic("playerL" + player.Level);
            }
            else if (player.Level > 3)
            {
                player.UpdatePic("playerL3");
            }
            if (player.Level >= 2)
            {
                player.AutoShoot = true;
            }
            if (player.Level >= 2)
            {
                tmrSpawnArrows.Enabled = true;
                tmrMoveArrows.Enabled = true;
                FireArrows();
            }
            if (player.Level >= 3)
            {
                tmrSpawnArrows.Interval = 2500;
                tmrSpawnArrows.Enabled = true;
                FireArrows();
            }
        }
        #endregion

        #endregion

    }
}
