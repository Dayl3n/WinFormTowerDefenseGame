using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Cryptography;
using Projekt_J.Properties;
using System.ComponentModel;

namespace Projekt_J.States
{
    internal abstract class GameState
    {
        protected Form parrentForm;
        protected GameState previousState;
        protected PlayerCastle playerCastle;

        public GameState(Form parrentform,GameState previousState,PlayerCastle playerCastle) 
        {
            this.parrentForm = parrentform;
            this.previousState = previousState;
            this.playerCastle = playerCastle;
        }

        public void SetPreviousState(GameState state)
        {
            previousState = state != null ? state:this ;
        }
        public abstract GameState Run();

        public abstract void ShowGUI();
        public abstract void HideGUI();
    }
}
