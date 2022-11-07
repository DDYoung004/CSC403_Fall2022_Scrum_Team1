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

namespace TowerDefense_TheRPG {
  public partial class FrmGameOver : Form {

    private SoundPlayer bgMusic;
    private string FilePath;

    public FrmGameOver() {
      InitializeComponent();
      FilePath = Directory.GetCurrentDirectory();
      FilePath = Path.GetFullPath(Path.Combine(FilePath, @"..\..\..\"));
      bgMusic = new SoundPlayer(FilePath + "data/hopeless-119866.wav");
      bgMusic.PlayLooping();
    }

    private void FrmGameOver_FormClosing(object sender, FormClosingEventArgs e) {
      FormManager.ClearAndCloseFormStack();
    }
  }
}
