using System;
using System.Linq;
namespace SemesterTest
{
    class Program
    {
        static void Main(string[] args)
        {
            FileSystem fileSystem = new FileSystem();

            //Add File
            fileSystem.Add(new File("AnImage.jpg", ".jpg", 5342));
            fileSystem.Add(new File("SomeFile.txt", ".txt", 832));

            //Add Folder contains file
            Folder folder = new Folder("Save File");
            folder.Add(new File("Save 1 - The Citadel.data", ".data", 2348));
            fileSystem.Add(folder);

            //Add Folder contais folder that contains file
            Folder folder2 = new Folder("MyFolder");
            Folder subFolder = new Folder("MyFolder2");
            subFolder.Add(new File("SemesterTest.txt", ".txt", 6900));
            folder2.Add(subFolder);
            fileSystem.Add(folder2);

            //Add empty folder
            fileSystem.Add(new Folder("New Folder"));

            fileSystem.PrintContents();
            
        }
    }
}
