using System;

namespace SemesterTest
{
    class Program
    {
        static void Main(string[] args)
        {
            FileSystem fileSystem = new FileSystem();

            while (true)
            {
                Console.WriteLine("1. Add Folder");
                Console.WriteLine("2. Add File");
                Console.WriteLine("3. Print Contents");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter folder name: ");
                        string folderName = Console.ReadLine();
                        Folder folder = new Folder(folderName);
                        fileSystem.AddFolder(folder);
                        break;
                    case "2":
                        Console.Write("Enter file name: ");
                        string fileName = Console.ReadLine();
                        Console.Write("Enter file extension: ");
                        string fileExtension = Console.ReadLine();
                        Console.Write("Enter file size (in bytes): ");
                        int fileSize = int.Parse(Console.ReadLine());
                        File file = new File(fileName, fileExtension, fileSize);
                        fileSystem.AddFile(file);
                        break;
                    case "3":
                        fileSystem.PrintContent();
                        break;
                    case "4":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }
    }
}
