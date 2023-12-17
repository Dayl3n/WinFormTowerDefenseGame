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
        public Projekt_Jusytna()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            playerCastle = new PlayerCastle(this, 50);
            currentState =new MainMenuState(this,null,playerCastle);
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
