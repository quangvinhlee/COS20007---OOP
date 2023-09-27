using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinAdventure;
using NUnit.Framework;

namespace SwinAdventureTests
{
    [TestFixture]
    public class PlayerTest
    {
        private Player _playerObject;
        private Item _shovel;
        private Item _sword;

        [SetUp]
        public void SetUp()
        {
            _playerObject = new Player("Vinh", "SwinAdventure");
            _shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a shovel");
            _sword = new Item(new string[] { "sword" }, "a sword", "This is a Sword");
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
            Assert.AreEqual(_shovel, _playerObject.Locate("shovel"));
        }

        [Test]
        public void TestPlayerLocatesItself()
        {
            Assert.AreEqual(_playerObject, _playerObject.Locate("me"));
            Assert.AreEqual(_playerObject, _playerObject.Locate("inventory"));
        }

        [Test]
        public void TestPlayerLocateNothing()
        {
            Assert.IsNull(_playerObject.Locate("hi"));
        }

        [Test]
        public void TestPlayerFullDescription()
        {
            _playerObject.Inventory.Put(_sword);
            _playerObject.Inventory.Put(_shovel);
            string expected = $"You are {_playerObject.Name}, You are carrying: {_playerObject.Inventory.ItemList}";
            Assert.AreEqual(expected, _playerObject.FullDescription);
        }
    }
}
