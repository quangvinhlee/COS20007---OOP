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
    public class InventoryTest
    {
        private Inventory _inventoryObject;
        private Item _shovel;
        private Item _sword;

        [SetUp]
        public void SetUp()
        {
            _inventoryObject = new Inventory();
            _shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a shovel");
            _sword = new Item(new string[] { "sword" }, "a sword", "This is a Sword");
        }

        [Test]
        public void TestFindItem()
        {
            _inventoryObject.Put(_shovel);
            Assert.IsTrue(_inventoryObject.HasItem("shovel"));
        }

        [Test]
        public void TestNoItemFind()
        {
            _inventoryObject.Put(_shovel);
            Assert.IsFalse(_inventoryObject.HasItem("sword"));
        }

        [Test]
        public void TestFetchItem()
        {
            _inventoryObject.Put(_shovel);
            Assert.AreEqual(_shovel, _inventoryObject.Fetch("shovel"));
            Assert.IsTrue(_inventoryObject.HasItem("shovel"));
        }

        [Test]
        public void TestTakeItem()
        {
            _inventoryObject.Put(_shovel);
            _inventoryObject.Take("shovel");
            Assert.IsFalse(_inventoryObject.HasItem("shovel"));
        }

        [Test]
        public void TestItemList()
        {
            _inventoryObject.Put(_shovel);
            _inventoryObject.Put(_sword);
            Assert.IsTrue(_inventoryObject.HasItem("shovel"));
            Assert.IsTrue(_inventoryObject.HasItem("sword"));

            string expectedOutput = "a shovel (shovel)\n" + "a sword (sword)\n";
            Assert.AreEqual(expectedOutput, _inventoryObject.ItemList);
        }
    }
}
