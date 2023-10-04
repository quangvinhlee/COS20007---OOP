using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemesterTest
{
    public class Folder : Thing
    {
        private List<Thing> _contents;

        public Folder(string name) : base(name)
        {
            _contents = new List<Thing>();
        }

        public void Add(Thing thing)
        {
            _contents.Add(thing);
        }

        public override int Size()
        {
            int folderSize = 0;
            foreach (Thing thing in _contents)
            {
                folderSize += thing.Size();
            }
            return folderSize;
        }

        public override void Print()
        {
            if (_contents.Count != 0)
            {
                Console.WriteLine($"The folder '{Name}' contains {Size()} bytes total:");
                foreach (Thing thing in _contents)
                {
                    thing.Print();
                }
            }
            else
            {
                Console.WriteLine($"The folder '{Name}' is empty!");
            }
        }
    }
}
