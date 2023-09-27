using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemesterTest
{
    public class FileSystem
    {
        private List<Thing> _contents;

        public FileSystem()
        {
            _contents = new List<Thing>();
        }
        public void Add(Thing thing)
        {
            _contents.Add(thing);
        }
        
        public void PrintContents()
        {
            Console.WriteLine("This file system contains: ");
            foreach (Thing thing in _contents)
            {
                thing.Print();
            }
            
        }
    }
}
