using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_J.Enemies
{
    internal class GolemEnemy : Enemy
    {
        public GolemEnemy(Form parrentForm, PlayerCastle target, int maxHp, int attackValue, int[] cords) : base(parrentForm, target, maxHp, attackValue, cords)
        {
        }

        protected override int Attack()
        {
            throw new NotImplementedException();
        }
    }
}
