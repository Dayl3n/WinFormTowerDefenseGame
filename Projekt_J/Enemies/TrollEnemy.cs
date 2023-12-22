using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_J.Enemies
{
    internal class TrollEnemy : Enemy
    {
        public TrollEnemy(Form parrentForm, PlayerCastle target, int maxHp, int attackValue, int[] cords) : base(parrentForm, target, maxHp, attackValue, cords)
        {
            attackCooldown = 3000;
            hitBox.Image = Properties.Resources.Enemy_05;
        }

        protected override int Attack()
        {
            target.changeHp(attackValue);

            return attackValue;
        }
    }
}
