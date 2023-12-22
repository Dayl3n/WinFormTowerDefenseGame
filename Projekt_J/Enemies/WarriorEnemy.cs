using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace Projekt_J
{
    internal class WarriorEnemy : Enemy
    {
        public WarriorEnemy(Form form, PlayerCastle target, int maxHp, int attackValue, int[] cords) : base(form, target, maxHp, attackValue, cords)
        {
            attackCooldown = 1000;
            if(maxHp<=50)
                hitBox.Image = Properties.Resources.Enemy_01;
            else
                hitBox.Image = Properties.Resources.Enemy_02;
        }

        protected override int Attack()
        {
            target.changeHp(attackValue);
            
            return attackValue;
        }
    }
}
