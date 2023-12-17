using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Projekt_J
{
    internal class ArcherEnemy : Enemy
    {
        public ArcherEnemy(Form form,PlayerCastle target, int maxHp, int attackValue, int[] cords) : base(form, target, maxHp, attackValue, cords)
        {
        }

        protected override int Attack()
        {
            throw new NotImplementedException();
        }
    }
}
