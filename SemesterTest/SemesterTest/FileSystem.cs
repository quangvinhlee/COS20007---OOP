using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemesterTest
{
    public class FileSystem
    {
        private List<Folder> _folders;
        private List<File> _files;
        public FileSystem()
        {
            _folders = new List<Folder>();
            _files = new List<File>();
        }
        public List<Folder> Folders
        {
            get { return _folders; }
        }

       public List <File> Files
        { 
            get { return _files  ; } 
        }
        public void AddFolder(Folder folder)
        {
            _folders.Add(folder);
        }
       public void AddFile(File file)
        {
            _files.Add(file);
        }
        public void PrintContent()
        {
            Console.WriteLine($"This file system contains:");

            foreach (Folder folder in _folders)
            {
                folder.Print();
            }

            foreach (File file in _files)
            {
                file.Print();
            }
        }
    }

}
