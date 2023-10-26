using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using SwinAdventure;
namespace SwinAdventureTests
{
    public class PlayerTest
    {
        private Player _playerObject;
        private Item _shovel; 
        private Item _sword;
        private Location _currentLocation;
        [SetUp]
        public void SetUp()
        {
            _playerObject = new Player("Vinh", "SwinAdventure");
            _shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a shovel");
            _sword = new Item(new string[] { "sword" }, "a sword", "This is a Sword");
            _currentLocation = new Location("My Room", "This is my room");
        }
        [Test]
        public void TestPlayerIsIdentifiable()
        {
            Assert.IsTrue(_playerObject.AreYou("me") && _playerObject.AreYou("inventory"));
        }
        [Test]
        public void TestPlayerLocatesItems()
        {
            _playerObject.Inventory.Put(_shovel);
            var itemLocate = _playerObject.Locate("shovel");
            Assert.AreEqual(_shovel, itemLocate);
        }
        [Test]
        public void TestPlayerLocatesItself()
        {
            var me = _playerObject.Locate("me");
            var inv = _playerObject.Locate("inventory");

            Assert.IsTrue(me == _playerObject || inv == _playerObject);
        }
        [Test]
        public void TestPlayerLocateNothing()
        {
            var me = _playerObject.Locate("hi");
            Assert.IsNull(me);
        }
        [Test]
        public void TestPlayerFullDescription()
        {
            _playerObject.Inventory.Put(_sword);
            _playerObject.Inventory.Put(_shovel);
            string expected = $"You are {_playerObject.Name}, You are carrying: {_playerObject.Inventory.ItemList}";
            Assert.AreEqual(expected, _playerObject.FullDescription);
        }
        [Test]
        public void TestPlayerHasLocation()
        {
            // Ensure that a Player has a location assigned to them.
            _playerObject.Location = _currentLocation;

            Assert.AreEqual(_currentLocation, _playerObject.Location);
        }
        [Test]
        public void TestPlayerCanLocateItemsInCurrentLocation()
        {
            // Verify that the player can locate items in their current location.
            _playerObject.Location = _currentLocation;
            _currentLocation.Inventory.Put(_sword);

            var locatedSword = _playerObject.Locate("sword");

            Assert.AreEqual(_sword, locatedSword);
        }
    }
}
