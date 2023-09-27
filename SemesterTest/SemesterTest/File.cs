using System;

namespace SemesterTest
{
    public class File
    {
        private string _name;
        private string _extension;
        private int _size;

        public File(string name, string extension, int size)
        {
            _name = name;
            _extension = extension;
            _size = size;
        }

        public int Size()
        {
            return _size;
        }

        public void Print()
        {
            Console.WriteLine($"File '{_name} - {_extension}' - {_size} bytes");
        }

        public string Name
        {
            get { return _name; }
        }
    }
}
