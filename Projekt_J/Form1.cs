using Projekt_J.Enemies;
using Projekt_J.States;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_J
{
    public partial class Projekt_Jusytna : Form
    {
        private GameState currentState;
        private PlayerCastle playerCastle;
        List<LevelClass> levels;

        public Projekt_Jusytna()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Controls.Clear();

            playerCastle = new PlayerCastle(this, 50);
            levels = new List<LevelClass>() { new LevelClass(this,playerCastle,1, 10, 0, 0, 0), new LevelClass(this, playerCastle, 2, 15, 0, 0, 0), new LevelClass(this, playerCastle, 3, 10, 5, 0, 0), new LevelClass(this, playerCastle, 4, 15, 5, 3, 0), new LevelClass(this, playerCastle, 5, 20, 7, 7, 0), new LevelClass(this, playerCastle, 6, 10, 6, 6, 1), new LevelClass(this, playerCastle, 7, 20, 10, 3, 2), new LevelClass(this, playerCastle, 8, 20, 15, 6, 5) };
            currentState =new MainMenuState(this,null,playerCastle, levels);
        }

        private void MainTimerEvent(object sender, EventArgs e)
        {
            GameState state = currentState.Run();
            if (currentState != state)
            {
                currentState = state;
            }

        }


    }
}
