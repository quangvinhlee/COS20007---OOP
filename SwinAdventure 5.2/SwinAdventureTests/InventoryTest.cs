using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinAdventure;

namespace SwinAdventureTests
{
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
            Assert.IsTrue(_inventoryObject.HasItem(_shovel.FirstID));
        }
        [Test]
        public void TestNoItemFind() 
        {
            _inventoryObject.Put(_shovel);
            Assert.IsFalse(_inventoryObject.HasItem(_sword.FirstID));
        }
        [Test]
        public void TestFetchItem()
        {
            _inventoryObject.Put(_shovel);
            Item fetchItem = _inventoryObject.Fetch(_shovel.FirstID);

            Assert.AreEqual(_shovel, fetchItem);
            Assert.IsTrue(_inventoryObject.HasItem(_shovel.FirstID));
        }
        [Test]
        public void TestTakeItem()
        {
            _inventoryObject.Put(_shovel);
            _inventoryObject.Take(_shovel.FirstID);

            Assert.IsFalse(_inventoryObject.HasItem(_shovel.FirstID));
        }
        [Test]
        public void TestItemList()
        {
            _inventoryObject.Put(_shovel);
            _inventoryObject.Put(_sword);
            Assert.IsTrue(_inventoryObject.HasItem(_shovel.FirstID));
            Assert.IsTrue(_inventoryObject.HasItem(_sword.FirstID));

            string expectOutput = "a shovel (shovel)\n" + "a sword (sword)\n";
            Assert.AreEqual(_inventoryObject.ItemList, expectOutput);
        }
    }
}
