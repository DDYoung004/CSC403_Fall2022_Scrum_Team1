using System.Collections.Generic;
using TowerDefense_TheRPG.code;
using TowerDefense_TheRPG.Properties;

namespace TowerDefense_TheRPG
{
    public partial class FrmMain : Form
    {
        #region Fields
        private Player player;
        private Village village;
        private List<Enemy> enemies;
        private List<PowerUp> power_ups;
        private List<Tuple<int, string>> power_up_temp;
        private List<Arrow> arrows;
        private string storyLine;
        private int curStoryLineIndex;
        private Random rand;
        public bool pause = false;
        private int round;
        #endregion

        #region Methods
        #region Ctor
        public FrmMain()
        {
            InitializeComponent();
            FormManager.PushToFormStack(this);
            DoubleBuffered = true;
            ControlManager.ResMan = Resources.ResourceManager;
            ControlManager.Form = this;
            rand = new Random();
        }
        #endregion

        #region Event functions
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
                    balloon = Enemy.MakeGrayBalloon(x, y);
                    break;
                case 2:
                    balloon = Enemy.MakeOrangeBalloon(x, y);
                    break;
                case 3:
                    balloon = Enemy.MakePurpleBalloon(x, y);
                    break;
                default:
                    balloon = Enemy.MakeRedBalloon(x, y);
                    break;

            }
            enemies.Add(balloon);
        }
        private void tmrMoveEnemies_Tick(object sender, EventArgs e)
        {
            roundHelper(player.Level, player.XP);
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
            if (!pause)
            {
                PlayerMove(e.KeyCode);
            }
        }

        // buttons
        private void btnStart_Click(object sender, EventArgs e)
        {
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
                tmrSpawnPowerUps.Enabled = true;
                tmrMovePowerUps.Enabled = true;
                tmrRemovePowerUps.Enabled = true;
            }
            else
            {
                BackgroundImage = Resources.title;
                btnStart.Visible = true;
                btnStoryLine.Text = "Show Storyline";
                lblStoryLine.Visible = false;
                tmrTextCrawl.Enabled = false;
            }
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
        public int getRound(int level)
        {   
            if (level % 10 == 0)
            {
                round = level / 10;
            }
            return round;
        }
        public void roundHelper(int level, int xp)
        {
            lblRound.Text = ("Round:" + getRound(level).ToString() + " | Level:" + level.ToString());
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
            if (power_up_temp?.Any() == false)
            {
                power_up_temp.Add(Tuple.Create(0, "attack"));
            }
            Tuple<int, string> power = power_up_temp[0];
            player.RemoveTempStats(power.Item1, power.Item2);
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
                        Form frmGO = new FrmGameOver();
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
            }
        }
        private bool SwapPause(Keys keyCode)
        {
            if (keyCode == Keys.Escape)
            {
                pause = !pause;
            }
            if (pause)
            {
                tmrSpawnEnemies.Enabled = false;
                tmrMoveEnemies.Enabled = false;
                tmrMoveArrows.Enabled = false;
                lblPause.Visible = true;
            }
            else
            {
                tmrSpawnEnemies.Enabled = true;
                tmrMoveEnemies.Enabled = true;
                tmrMoveArrows.Enabled = true;
                lblPause.Visible = false;
            }
            return pause;
        }
        #endregion
        #endregion
    }
}
