using System;
using System.Collections.Generic;

namespace SemesterTest
{
    public class Folder
    {
        private List<File> _contents;
        private String _name;

        public Folder(string name)
        {
            _name = name;
            _contents = new List<File>();
        }

        public void Add(File _file)
        {
            _contents.Add(_file);
        }

        public int Size()
        {
            int size = 0;

            foreach (File file in _contents)
            {
                size += file.Size();
            }

            return size;
        }

        public void Print()
        {
            int folderSize = Size(); // Calculate the folder size.
            Console.WriteLine($"The folder '{Name}' contains {folderSize} bytes total:");

            foreach (File file in _contents)
            {
                file.Print();
            }
        }

        public String Name
        {
            get { return _name; }
        }
    }
}
