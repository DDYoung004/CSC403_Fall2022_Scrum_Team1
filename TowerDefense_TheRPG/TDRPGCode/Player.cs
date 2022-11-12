﻿namespace TowerDefense_TheRPG.code
{
    /// <summary>
    /// Class for our player
    /// </summary>
    public class Player : Character
    {
        /// <summary>
        /// Amount of money the player has. Currently this is not being
        /// used but you could add this as a feature.
        /// </summary>
        public int Money { get; private set; }

        /// <summary>
        /// Current amount of experience. You gain experience by defeating
        /// <see cref="Enemy"/> objects (e.g. balloons)
        /// </summary>
        public int XP { get; private set; }

        /// <summary>
        /// Current level player has
        /// </summary>
        public int Level { get; private set; }

        /// <summary>
        /// If this is set to true, player will automatically shoot arrows
        /// every so often (the time interval is set as the Interval property
        /// of the tmrSpawnArrows object in FrmMain)
        /// </summary>
        public bool AutoShoot { get; private set; }

        /// <summary>
        /// Explicit constructor
        /// </summary>
        /// <param name="x">Initial x position of player</param>
        /// <param name="y">Initial y position of player</param>
        public Player(int x, int y) : base("player", x, y, 50, 100)
        {
            SetMaxHealth(1.0f);
            Money = 0;
            Attack = 0.15f;
            MoveSpeed = 15;
            Level = 1;
            XP = 0;
            if (Level <= 3)
            {
                ChangeCharacterPic("playerL" + Level);
            }
        }

        /// <summary>
        /// Call this function whenever the player defeats an <see cref="Enemy"/>
        /// </summary>
        /// <param name="xpGained">How much experience the player should gain. 
        ///                        Use <see cref="Enemy.XPGiven"/> for this</param>
        public void GainXP(int xpGained)
        {
            XP += xpGained;
            if (XP >= (10*Level)+10)
            {
                GainLevel();
            }
            
        }

        /// <summary>
        /// Call this function whenever the player collides with an <see cref="PowerUp"/>
        /// </summary>
        /// <param name="statsMult">How much stats the player should gain. 
        ///                        Use <see cref="PowerUp.StatsMultiplier"/> for this</param>
        /// <param name="statsType">which stats the player should gain. 
        ///                        Use <see cref="PowerUp.StatsType"/> for this</param>
        public void GainTempStats(int statsMult, string statsType) {
          if (statsType == "Attack") {
                    Attack += statsMult;
          }
          if (statsType == "MoveSpeed") {
                    MoveSpeed += statsMult;
          }
        }

        /// <summary>
        /// Call this function whenever the player collides with an <see cref="PowerUp"/>
        /// </summary>
        /// <param name="statsMult">How much stats the player should gain. 
        ///                        Use <see cref="PowerUp.StatsMultiplier"/> for this</param>
        /// <param name="statsType">which stats the player should gain. 
        ///                        Use <see cref="PowerUp.StatsType"/> for this</param>
        public void RemoveTempStats(int statsMult, string statsType) {
          if (statsType == "Attack") {
                    Attack -= statsMult;
          }
          if (statsType == "MoveSpeed") {
                    MoveSpeed -= statsMult;
          }
        }

        /// <summary>
        /// Internal function that is automatically called when 
        /// player gains a level (called from GainXP method)
        /// </summary>
        private void GainLevel()
        {
            Level++;
            Attack *= 1.5f;
            if (Level <= 3)
            {
                ChangeCharacterPic("playerL" + Level);
            }
            if (Level >= 2)
            {
                AutoShoot = true;
            }
        }
    }
}
