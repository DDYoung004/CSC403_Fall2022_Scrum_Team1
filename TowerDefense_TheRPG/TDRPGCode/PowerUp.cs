using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace TowerDefense_TheRPG.code
{
    /// <summary>
    /// Basic power up class
    /// </summary>
    public class PowerUp : Character
    {
        /// <summary>
        /// The amount of stats given to player if this power up is collected
        /// </summary>
        public int StatsMultiplier { get; private set; }
        
        /// <summary>
        /// The stat that the power up increases
        /// </summary>
        public string StatsType { get; private set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="name">Name of this power up</param>
        /// <param name="x">Initial X position</param>
        /// <param name="y">Initial Y position</param>
        /// <param name="w">Desired width of the picturebox showing this power up</param>
        /// <param name="h">Desired height of the picturebox showing this power up</param>
        public PowerUp(string name, int x, int y, int w, int h) : base(name, x, y, w, h)
        {
        }

        /// <summary>
        /// Create an attack power up <see cref="PowerUp"/> at the specified location
        /// </summary>
        /// <param name="x">Initial X location for the power up</param>
        /// <param name="y">Initial Y location for the power up</param>
        /// <returns>The power up <see cref="PowerUp"/> object</returns>
        public static PowerUp MakeAtackPowerUp(int x, int y)
        {
            PowerUp power_up = new PowerUp("attack_power_up", x, y, 40, 40);
            power_up.MoveSpeed = 0;
            power_up.SetMaxHealth(0.1f);
            power_up.Attack = 0.0f;
            power_up.StatsMultiplier = 1;
            power_up.StatsType = "Attack";
            return power_up;
        }

        /// <summary>
        /// Create a speed power up <see cref="PowerUp"/> at the specified location
        /// </summary>
        /// <param name="x">Initial X location for the power up</param>
        /// <param name="y">Initial Y location for the power up</param>
        /// <returns>The power up <see cref="PowerUp"/> object</returns>
        public static PowerUp MakeSpeedPowerUp(int x, int y)
        {
            PowerUp power_up = new PowerUp("speed_power_up", x, y, 40, 40);
            power_up.MoveSpeed = 0;
            power_up.SetMaxHealth(0.1f);
            power_up.Attack = 0.0f;
            power_up.StatsMultiplier = 2;
            power_up.StatsType = "MoveSpeed";
            return power_up;
        }
    }
}