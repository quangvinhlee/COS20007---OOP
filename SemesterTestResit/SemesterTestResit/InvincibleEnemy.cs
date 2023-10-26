using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemesterTestResit
{
    public class InvincibleEnemy : Enemy
    {
        public override void GetHit(int Damage)
        {
            Console.WriteLine("Ha! Nice try");
        }
    }
}
