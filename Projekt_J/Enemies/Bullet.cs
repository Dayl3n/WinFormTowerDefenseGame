
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace Projekt_J.Enemies
{
    internal class Bullet
    {
        private Timer timer;
        private int speed=5;
        private PictureBox image;
        private int attackValue;
        private bool isShooted = false;
        private Form form;

        
        public Bullet(Form form,int attackValue, PlayerCastle playerCastle)
        {
            this.attackValue = attackValue;
            this.timer = new Timer();
            timer.Interval = speed;
            timer.Tick += new EventHandler((s, e) => Move(playerCastle));
            this.form = form;
        }


        public void GenerateBullet(int[] cords)
        {
            if (!isShooted)
            {               
                image = new PictureBox();
                image.Image = Properties.Resources.Arrow;
                image.SizeMode = PictureBoxSizeMode.AutoSize;
                image.BackColor = Color.Transparent;
                form.Controls.Add(image);
                

                isShooted =true;
                image.Left = cords[0];
                image.Top = cords[1];

                timer.Start();
            }
        }

        public void DealDmg(PlayerCastle target)
        {
            target.changeHp(attackValue);
        }

        private void Move(PlayerCastle target)
        {
            if (image != null)
            {
                if (image.Left + image.Width <= target.HitBox.Left)
                {
                    image.Left += 2;
                }
                else
                {
                    DealDmg(target);
                    isShooted = false;
                    form.Controls.Remove(image);
                    image.Dispose();
                    image = null;

                }
            }
        }
    }
}
