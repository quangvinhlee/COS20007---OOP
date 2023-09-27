using System;
using System.Linq;
namespace SemesterTest
{
    class Program
    {
        static void Main(string[] args)
        {
            FileSystem fileSystem = new FileSystem();

            fileSystem.Add(new File("AnImage.jpg", ".jpg", 5342));
            fileSystem.Add(new File("SomeFile.txt", ".txt", 832));

            Folder folder = new Folder("Save File");
            folder.Add(new File("Save 1 - The Citadel.data", ".data", 2348));
            fileSystem.Add(folder);

            Folder subFolder = new Folder("MyFolder");
            Folder subFolder2 = new Folder("MyFolder2");
            subFolder2.Add(new File("SemesterTest.txt", ".txt", 6900));
            subFolder.Add(subFolder2);
            fileSystem.Add(subFolder);

            fileSystem.Add(new Folder("New Folder"));

            fileSystem.PrintContents();
            
        }
    }
}
