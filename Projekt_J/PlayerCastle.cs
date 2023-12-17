using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_J
{
    internal class PlayerCastle
    {
        private List<PictureBox> castleStates = new List<PictureBox>();
        private PictureBox currentImage;
        private ProgressBar hpBar;
        private Form parrentForm;
        private int maxHp,castleLvl=1,attackLvl=1,UnitsLvl=1,avaiablePoints,currentHp,attackValue=20;

        public int AvaiablePoints
        {
            get { return avaiablePoints; }
            set { if(value > 0) avaiablePoints=value; }
        }

        public int CastleLevel
        {
            get { return castleLvl; }
        }
        public int AttackLvl
        {
            get { return attackLvl; }
        }     
        public int AttackValue
        {
            get { return attackValue; }
        }

        public int MaxHp
        {
            get { return maxHp; }
        }

        public PictureBox HitBox { get { return castleStates[0]; } }
        public ProgressBar HPBar { get { return hpBar; } }
        //private CastleState currentState;

        public PlayerCastle(Form form, int maxHp)
        {
            this.maxHp = maxHp;
            currentHp = maxHp;

            parrentForm = form;
            currentImage = new PictureBox();
            currentImage.SizeMode = PictureBoxSizeMode.AutoSize;
            currentImage.Image = Properties.Resources.castle_tier1;
            currentImage.BackColor = Color.Transparent;
            currentImage.Left = 869;
            currentImage.Top = 211;
            hpBar = new ProgressBar();
            hpBar.Maximum = maxHp;
            hpBar.Value = maxHp;

            PictureBox damgedCastle = new PictureBox();
            damgedCastle.SizeMode = PictureBoxSizeMode.AutoSize;
            damgedCastle.BackColor = Color.Transparent;
            damgedCastle.Left = 869;
            damgedCastle.Top = 211;
            damgedCastle.Image = Properties.Resources.Castle_Tier1_dmg;

            castleStates.Add(currentImage);
            castleStates.Add(damgedCastle);




            hpBar.Left = currentImage.Left;
            hpBar.Top = currentImage.Top;

            parrentForm.Controls.Add(hpBar);
            parrentForm.Controls.Add(currentImage);
            hpBar.Hide();
            castleStates[0].Hide();
        }

        public void changeHp(int dmg)
        {
            currentHp -= dmg; 
            if(currentHp < 0)
            {
                hpBar.Value = 0;
                
            }
            else
            {
                hpBar.Value = currentHp; 
            }
            
            if (hpBar.Value <= maxHp/2)
            {
                currentImage.Image = castleStates[1].Image;
            }
        }

        public int[] location()
        {
            int[] cords = {currentImage.Left,currentImage.Top};
            return cords;
        }

        public void ShowCastle()
        {
            hpBar.Show();
            currentImage.Show();
        }

        public void HideCastle()
        {
            hpBar.Hide();
            currentImage.Hide();
        }

        public void UpgradeCastle(List<PictureBox> newPictureBoxes)
        {
            if (avaiablePoints > 0&& castleLvl<3)
            {
                castleLvl++;
                maxHp = castleLvl * 50;
                currentHp = maxHp;
                hpBar.Maximum = maxHp;
                hpBar.Value = maxHp;

                castleStates[0].Image = newPictureBoxes[0].Image;
                castleStates[1].Image = newPictureBoxes[1].Image;
                currentImage.Image = newPictureBoxes[0].Image;
                avaiablePoints--;
            }
        }

        public void UpgradeDamge()
        {
            if (avaiablePoints > 0&&castleLvl<5)
            {
                attackLvl++;
                attackValue = attackLvl * 20;
                avaiablePoints--;
            }
        }

        public void UpgradeUnits()
        {
            Console.WriteLine("dupa");
        }

        public void restartCastle()
        {
            currentImage.Image = castleStates[0].Image;
            currentHp = maxHp;
            hpBar.Value = currentHp;
        }


    }
}
