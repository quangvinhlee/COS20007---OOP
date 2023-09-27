using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SemesterTest
{
    public abstract class Thing
    {
        private string _name;
        public Thing(string name)
        {
            _name = name;
        }
        public string Name
        {
            get { return _name; }
        }

        public abstract int Size();
        public abstract void Print();
    }
}
