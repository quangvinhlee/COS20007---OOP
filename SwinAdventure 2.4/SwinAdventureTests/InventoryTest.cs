using SwinAdventure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventureTests
{
    public class InventoryTest
    {
        private Inventory _inventory;

        Item shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a shovel");

        [SetUp]
        public void SetUp()
        {
            _inventory = new Inventory();
        }
        [Test]
        public void TestFindItem()
        {
             _inventory.Put(shovel);
             Assert.IsTrue(_inventory.HasItem(shovel.FirstID));
        }
    }
}
