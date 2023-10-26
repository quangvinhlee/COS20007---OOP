using System;
using System.Numerics;
using System.Collections.Generic;
using System.Collections;
using System.Xml.Linq;

namespace SwinAdventure
{
    public class Program
    {
        static void LookCommandExecute(Command look, string input, Player player)
        {
            Console.WriteLine(look.Execute(player, input.Split()));

        }

        static void Main(string[] args)
        {
            string name, desc;
            string help = "Here are some useful commands:\n-look\n\nGetting list of item:\n-look at me\n-look at bag\n\nGetting item description:\n-look at {item}\n-look at {item} in me\n-look at {item} in bag\n\nQuit game:\n-quit\n\n";

            Console.WriteLine("Welcome to SwinAdventure...\n");



            Console.Write("Enter Player Name: ");
            name = Console.ReadLine();
            Console.Write("Enter Player Description: ");
            desc = Console.ReadLine();
            Player player = new Player(name, desc);
            Console.Write("\nEnter 'help' to show some useful commnads.");



            Item sword = new Item(new string[] { "sword" }, "a sword", "This is a sword");
            Item touch = new Item(new string[] { "touch" }, "a touch", "This is a touch");
            Item ruby = new Item(new string[] { "ruby" }, "a ruby", "This is a ruby");

            Location myRoom = new Location("My Room", "This is my room");
            player.Location = myRoom;



            Bag bag = new Bag(new string[] { $"bag" }, $"{player.Name}'s bag", $"This is {player.Name}'s bag");
            player.Inventory.Put(sword);
            player.Inventory.Put(touch);
            player.Inventory.Put(bag);
            bag.Inventory.Put(ruby);
            myRoom.Inventory.Put(ruby);
            myRoom.Inventory.Put(touch);


            Command look = new LookCommand();

            while (true)
            {
                Console.Write("\nCommand: ");
                string _input = Console.ReadLine();
                if (_input == "help")
                {
                    Console.Write(help);

                }
                else if (_input == "quit")
                {
                    break;
                }
                else
                {
                    LookCommandExecute(look, _input, player);
                }

            }

        }
    }
}