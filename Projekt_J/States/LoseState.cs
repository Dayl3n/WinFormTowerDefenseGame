using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_J.States
{
    internal class LoseState : GameState
    {
        public LoseState(Form parrentform, GameState previousState, PlayerCastle playerCastle) : base(parrentform, previousState, playerCastle)
        {
        }

        public override void HideGUI()
        {
            throw new NotImplementedException();
        }

        public override GameState Run()
        {
            throw new NotImplementedException();
        }

        public override void ShowGUI()
        {
            throw new NotImplementedException();
        }
    }
}
