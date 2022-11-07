namespace TowerDefense_TheRPG {
  internal static class Program {
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main() {
      // To customize application configuration such as set high DPI settings or default font,
      // see https://aka.ms/applicationconfiguration.
      ApplicationConfiguration.Initialize();
      //System.Media.SoundPlayer sp = new System.Media.SoundPlayer(@"");
      Application.Run(new FrmMain());
    }
  }
}