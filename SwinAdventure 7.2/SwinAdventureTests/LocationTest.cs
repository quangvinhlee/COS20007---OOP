using SwinAdventure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventureTests
{
    public class LocationTest
    {
        private Location _location;
        private Item _gem;
        private Player _player;

        [SetUp]
        public void SetUp()
        {
            _location = new Location("My Room", "This is my room");
            _gem = new Item(new string[] { "gem" }, "a gem", "This is a precious gem.");
            _player = new Player("Vinh", "SwinAdventure");
        }

        [Test]
        public void TestLocationIdentifyItself()
        {
            string actual = _location.FullDescription;

            Assert.AreEqual($"\nYou are at My Room\nRoom Description: This is my room\n\nItems at this location:\n", actual);
        }
            [Test]
        public void TestLocationCanLocateItems()
        {
            // Verify that locations can locate items they have.
            _location.Inventory.Put(_gem);

            var locatedGem = _location.Locate("gem");

            Assert.AreEqual(_gem, locatedGem);
        }

        [Test]
        public void TestPlayerCanLocateItemsInLocation()
        {
            // Check if the player can locate items in their location.
            _player.Location = _location;
            _location.Inventory.Put(_gem);

            var locatedGem = _player.Locate("gem");

            Assert.AreEqual(_gem, locatedGem);
        }
    }
}