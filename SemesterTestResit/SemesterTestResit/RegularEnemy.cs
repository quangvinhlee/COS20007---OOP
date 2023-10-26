using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemesterTestResit
{
    public class RegularEnemy : Enemy
    {
        private int _health;
        public RegularEnemy()
        {
            _health = 10;
        }
        public override void GetHit(int damage)
        {
            if (_health > 0)
            {
                Console.WriteLine("Ow!");
                _health -= damage;
            } else
            {
                Console.WriteLine("You already got me!");
            }
        }

    }
}
