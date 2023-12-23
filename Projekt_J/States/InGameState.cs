using Projekt_J.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_J.States
{
    internal class InGameState : GameState
    {
        private List<Enemy> enemies;
        private bool isWaveEnded;
        private LevelClass currentLevel;
        private List<LevelClass> levels;
        public InGameState(Form parrentform, GameState previousState,List<LevelClass> levels ,LevelClass currentLevel,PlayerCastle playerCastle) : base(parrentform, previousState,playerCastle)
        {
            isWaveEnded = false;
            this.currentLevel = currentLevel;

            parrentForm.BackgroundImage = Properties.Resources.Background;
            this.playerCastle = playerCastle;
            enemies = currentLevel.MonsterINC.CreateWave();
            
            this.levels = levels;
        }

        public override GameState Run()
        {
            playerCastle.ShowCastle();
            if (isWaveEnded)
            {
                parrentForm.BackgroundImage = Properties.Resources.Menu;
                playerCastle.AvaiablePoints++;
                playerCastle.restartCastle();
                HideGUI();
                foreach(LevelClass level in levels)
                {
                    if (level == currentLevel)
                    {
                        level.isFinished = true;
                    }
                }
                enemies.Clear();
                return new LevelSelectionState(parrentForm,this,levels,playerCastle);
            }
            foreach(Enemy enemy in enemies)
            {
                if (enemy.HPBar !=null && enemy.HPBar.Value <= 0)
                {
                    enemy.HPBar.Dispose();
                    enemy.HitBox.Dispose();
                    parrentForm.Controls.Remove(enemy.HPBar);
                    parrentForm.Controls.Remove(enemy.HitBox);

                    enemy.HPBar = null;
                    enemy.HitBox = null;                   
                }
                
            }
            isWaveEnded = enemies.All(s => s.HPBar == null);
            if (playerCastle.HPBar.Value <= 0)
            {
                foreach (Enemy enemy in enemies)
                {
                    enemy.enemyTimer.Stop();
                }
                return new LoseState(parrentForm,this,playerCastle);
            }


            return this;
        }
        public override void ShowGUI()
        {
            playerCastle.HitBox.Show();
            playerCastle.HPBar.Show();
        }
        public override void HideGUI()
        {
            playerCastle.HitBox.Hide();
            playerCastle.HPBar.Hide();
        }
    }

    
}
