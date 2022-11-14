namespace TowerDefense_TheRPG.code
{
    /// <summary>
    /// Class for our player
    /// </summary>
    public class Player : Character
    {
        /// <summary>
        /// Amount of money the player has.
        /// </summary>
        public int Money { get; set; }

        /// <summary>
        /// Current amount of experience. You gain experience by defeating
        /// <see cref="Enemy"/> objects (e.g. balloons)
        /// </summary>
        public int XP { get; set; }

        /// <summary>
        /// Current level player has
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// If this is set to true, player will automatically shoot arrows
        /// every so often (the time interval is set as the Interval property
        /// of the tmrSpawnArrows object in FrmMain)
        /// </summary>
        public bool AutoShoot { get; set; }

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
        /// Internal function that is automatically called when 
        /// player gains a level (called from GainXP method)
        /// </summary>
        private void GainLevel()
        {
            Level++;
            //Attack *= 1.5f;
            if (Level <= 3)
            {
                ChangeCharacterPic("playerL" + Level);
            }
            if (Level >= 2)
            {
                AutoShoot = true;
            }
        }

        /// <summary>
        /// used to access ChangeCharacterPic function from FrmMain
        /// </summary>
        /// <param name="resourceName"></param> The name of the resource file.
        public void UpdatePic(string resourceName)
        {
            ChangeCharacterPic(resourceName);
        }

        /// <summary>
        /// Internal function that is automatically called when 
        /// player upgrades attack
        /// </summary>
        public void upgradeAttack()
        {
            Attack *= 1.5f;
        }

        /// <summary>
        /// Internal function that is automatically called when 
        /// player upgrades move speed
        /// </summary>
        public void upgradeMoveSpeed()
        {
            MoveSpeed += 1;
        }

        /// <summary>
        /// Call this function whenever the player defeats an <see cref="Enemy"/>
        /// </summary>
        /// <param name="moneyGained">How much money the player should gain. 
        ///                        Use <see cref="Enemy.MoneyGiven"/> for this</param>
        public void GainMoney(int moneyGained)
        {
            Money += moneyGained;
        }

        /// <summary>
        /// Call this function whenever the player defeats an <see cref="Enemy"/>
        /// </summary>
        /// <param name="moneySpent">How much money the player should gain. 
        ///                        Use <see cref="Enemy.MoneyGiven"/> for this</param>
        public void SpendMoney(int moneySpent)
        {
            Money -= moneySpent;
        }
    }
}
