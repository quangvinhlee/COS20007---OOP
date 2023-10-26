using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemesterTestResit
{
    public abstract class Enemy
    {
        public Enemy()
        { 
        }
        public abstract void GetHit(int damage);
    }
}
