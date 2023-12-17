using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Projekt_J.States
{
    internal class LevelSelectionState : GameState
    {
        private List<LevelClass> levels;
        private GameState newState;
        private LevelClass nextLevel;
        private PictureBox upgrades;
        public LevelSelectionState(Form parrentform, GameState previousState, List<LevelClass> levels,PlayerCastle playerCastle) : base(parrentform, previousState,playerCastle)
        {
            newState = this;
            this.levels= levels;
            nextLevel = levels[0];

            levels[0].button.Image = Properties.Resources.Green_Button;
            levels[0].label.Image = Properties.Resources.Green_Button;
            levels[0].button.MouseClick += new MouseEventHandler((s, e) => StartLevel(levels[0]));
            parrentForm.Controls.Add(levels[0].button);
            parrentForm.Controls.Add(levels[0].label);
            levels[0].button.Left = 71;
            levels[0].button.Top = 163;
            levels[0].label.Top = levels[0].button.Top + 30;
            levels[0].label.Left = 156;
            levels[0].label.BringToFront();
            levels[0].button.Show();
            levels[0].label.Show();
            for (int i = 1; i < levels.Count; i++)
            {

                if (levels[i-1].isFinished)
                {
                    nextLevel = levels[i];
                    levels[i - 1].button.Enabled = false;
                    levels[i].button.Image = Properties.Resources.Green_Button;
                    levels[i].label.Image = Properties.Resources.Green_Button;
                    levels[i].button.MouseClick += new MouseEventHandler((s, e) => StartLevel(nextLevel));
                }
                else
                {
                    levels[i].button.Image = Properties.Resources.Red_Button;
                    levels[i].label.Image = Properties.Resources.Red_Button;
                }

                if (i < 4)
                {
                    levels[i].button.Left = 71;
                    levels[i].button.Top = 163 + i * 85;
                    levels[i].label.Top = levels[i].button.Top + 30;
                    levels[i].label.Left = 156;
                }
                else
                {
                    levels[i].button.Left = 319;
                    levels[i].button.Top = 163 + (i%4) * 85;
                    levels[i].label.Top = levels[i].button.Top + 30;
                    levels[i].label.Left = 406;
                }
                
                parrentForm.Controls.Add(levels[i].button);
                parrentForm.Controls.Add(levels[i].label);
                levels[i].label.BringToFront();
                levels[i].button.Show();
                levels[i].label.Show();
            }

            upgrades = new PictureBox();
            upgrades.Left = 938;
            upgrades.Top = 236;
            upgrades.Image = Properties.Resources.Purple_Button;
            upgrades.SizeMode = PictureBoxSizeMode.AutoSize;
            upgrades.BackColor = Color.Transparent;
            upgrades.MouseClick += new MouseEventHandler((s, e) => GoToUpgrades());

            parrentform.Controls.Add(upgrades);




        }

        public override GameState Run()
        {

            foreach (LevelClass level in levels)
            { 
                if (level.button.Image != Properties.Resources.Green_Button && level.isFinished)
                {
                    level.button.Image = Properties.Resources.Green_Button;
                    level.label.Image = Properties.Resources.Green_Button;
                    level.button.MouseClick += new MouseEventHandler((s, e) => StartLevel(level));
                }
            }
            return newState ;
        }

        private void StartLevel(LevelClass level)
        {

            HideGUI();
            newState = new InGameState(parrentForm, this, levels, level,playerCastle);
        }

        private void GoToUpgrades()
        {
            HideGUI();
            newState = new UpgradeState(parrentForm, this,playerCastle);
        }

        public override void HideGUI()
        {
            foreach(var lvl in levels)
            {
                lvl.button.Hide();
                lvl.label.Hide();
            }
            upgrades.Hide();
        }

        public override void ShowGUI()
        {
            foreach (var lvl in levels)
            {
                lvl.button.Show();
                lvl.label.Show();
            }
            upgrades.Show();
        }

        public void clearLvl(int levelIndex)
        {
            levels[levelIndex].isFinished = true;
        }
        



    }
}
