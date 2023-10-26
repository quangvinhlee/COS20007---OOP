using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SwinAdventure
{
    public class LookCommandTest
    {
        private Item _gem;
        private Command _lookCommand;
        private Player _player;
        private Bag _bag;
        private Location _location;
        [SetUp]
        public void SetUp()
        {
            _gem = new Item(new string[] { "gem" }, "a gem", "This is a gem");
            _lookCommand = new LookCommand();
            _player = new Player("Vinh", "PVinh's Player");
            _bag = new Bag(new string[] { "bag" }, $"Player's bag", $"This is {_player.FirstID} bag");
            _location = new Location("My Room", "This is my room");
        }

        [Test]
        public void TestLookAtMe()
        {

            string output = _lookCommand.Execute(_player, new string[] { "look", "at", "inventory" });
            string expected = $"You are {_player.Name}, You are carrying: {_player.Inventory.ItemList}";
            Assert.AreEqual(expected, output);
        }



      [Test]
         public void TestLookAtGem()
         {
             _player.Inventory.Put(_gem);
             string output = _lookCommand.Execute(_player, new string[] { "look", "at", "gem" });
             string expected = $"{_gem.FullDescription}";
             Assert.AreEqual(expected, output);
         }
        
       [Test]
       public void TestLookAtUnk()
       {
           string output = _lookCommand.Execute(_player, new string[] { "look", "at", "gem" });
           string expected = $"I can't find the gem";
           Assert.AreEqual(expected, output);
       }
       
       [Test]
       public void TestLookAtGemInMe()
       {
          
           _player.Inventory.Put(_gem);

           string output = _lookCommand.Execute(_player, new string[] { "look", "at", "gem", "in", "me" });
           string expected = $"{_gem.FullDescription}";
            // console.WriteLine(expected);
           Assert.AreEqual(expected, output);
       }
         
      [Test]
      public void TestLookAtGemInBag()
      {
            _player.Inventory.Put(_bag);

            _bag.Inventory.Put(_gem);

          string output = _lookCommand.Execute(_player, new string[] { "look", "at", "gem", "in", "bag" });
          string expected = $"{_gem.FullDescription}";
          //Console.WriteLine(expected);
          Assert.AreEqual(expected, output);
      }
        [Test]
        public void TestLookAtPlayerLocation()
        {
            _player.Location = _location;
            string result = _lookCommand.Execute(_player, new string[] { "look", "at", "location" });

            Assert.AreEqual("\nYou are at My Room\nRoom Description: This is my room\n\nItems at this location:\n", result);
        }
        [Test]
        public void TestLookAtLocationWithItems()
        {
            _player.Location = _location;

            _location.Inventory.Put(_gem);
            string result = _lookCommand.Execute(_player, new string[] { "look", "at", "location" });

            Assert.AreEqual($"\nYou are at My Room\nRoom Description: This is my room\n\nItems at this location:\na gem (gem)\n", result);


        }

        [Test]
      public void TestLookAtGemInNoBag()
      {
          _player.Inventory.Put(_gem);
          string output = _lookCommand.Execute(_player, new string[] { "look", "at", "gem" });
          string expected = "This is a gem";
          Assert.AreEqual(expected, output);
      }
     [Test]
     public void TestLookAtNoGemInBag()
     {
         _player.Inventory.Put(_bag);
         string output = _lookCommand.Execute(_player, new string[] { "look", "at", "gem", "in", "bag" });
         string expected = $"I can't find the gem";
         Assert.AreEqual(expected, output);
     }


     [Test]
     public void TestInvalidLook()
     {
         Assert.AreEqual(_lookCommand.Execute(_player, new string[] { "look", "around" }), "What do you want to look at?");
         Assert.AreEqual(_lookCommand.Execute(_player, new string[] { "look", "ahead" }), "What do you want to look at?");

     }

    }
}


