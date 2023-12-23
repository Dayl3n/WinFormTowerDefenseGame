using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Projekt_J.States
{
    internal class LoseState : GameState
    {
        PictureBox image;
        public LoseState(Form parrentform, GameState previousState, PlayerCastle playerCastle) : base(parrentform, previousState, playerCastle)
        {
            image = new PictureBox();
            image.Image = Properties.Resources.GameOver;
            image.SizeMode= PictureBoxSizeMode.AutoSize;
            image.BackColor = Color.Transparent;
            image.Left = parrentForm.Width/2-image.Width/2;
            image.Top = parrentForm.Height/2-image.Height/2;
            parrentForm.KeyDown += new KeyEventHandler(KeyIsDown);
            parrentForm.Controls.Add(image);
            image.BringToFront();

        }

        public override void HideGUI()
        {
            
        }

        public override GameState Run()
        {
            return this;
        }

        public override void ShowGUI()
        {
            
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                Environment.Exit(0);
            }
        }
    }
}
