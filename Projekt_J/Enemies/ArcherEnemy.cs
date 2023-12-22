using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Projekt_J.Enemies;

namespace Projekt_J
{
    internal class ArcherEnemy : Enemy
    {
        private Bullet bullet;
        public ArcherEnemy(Form form,PlayerCastle target, int maxHp, int attackValue, int[] cords) : base(form, target, maxHp, attackValue, cords)
        {
            attackCooldown = 2000;
            bullet = new Bullet(form,attackValue, target);
            hitBox.Image = Properties.Resources.Enemy_03;
            
        }

        protected override void Move(object s, EventArgs e)
        {
            if (hitBox != null)
            {
                if (hitBox.Left + HitBox.Width >= parentForm.Width/3 )
                {
                    enemyTimer.Interval = attackCooldown;                   
                    Attack();                    
                }
                else
                {
                    hitBox.Left += speed / 5;
                    hpBar.Left += speed / 5;
                }
            }
        }

        protected override int Attack()
        {
            int[] arrowCords = { hitBox.Right, hitBox.Top + hitBox.Height / 2 };
            bullet.GenerateBullet(arrowCords);


            return attackValue;
        }
    }
}
