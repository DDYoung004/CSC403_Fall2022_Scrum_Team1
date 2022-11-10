using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TowerDefense_TheRPG.code;
using System.Media;
using System.Diagnostics;
using System.Windows.Media;

namespace TowerDefense_TheRPG {
  public partial class FrmGameOver : Form {

    private MediaPlayer bgMusic;
    private string FilePath;

    public FrmGameOver(double volume) {
      InitializeComponent();
      FilePath = Directory.GetCurrentDirectory();
      FilePath = Path.GetFullPath(Path.Combine(FilePath, @"..\..\..\"));
      bgMusic = new MediaPlayer();
      bgMusic.MediaEnded += new EventHandler(BGMusic_Ended);
      bgMusic.Volume = volume;
      bgMusic.Open(new Uri(FilePath + "data/hopeless-119866.wav"));
      bgMusic.Play();

    }

    private void BGMusic_Ended(object sender, EventArgs e)
    {
        bgMusic.Position = TimeSpan.Zero;
        bgMusic.Play();
    }

    private void FrmGameOver_FormClosing(object sender, FormClosingEventArgs e) {
      FormManager.ClearAndCloseFormStack();
    }
  }
}
