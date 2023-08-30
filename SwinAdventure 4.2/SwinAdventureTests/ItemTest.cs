using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinAdventure;

namespace SwinAdventureTests
{
    public class ItemTest
    {
        private Item _itemObject;
        private string[] idents = new[] { "Bronze Sword", "The basic sword" };

        [SetUp]
        public void SetUp()
        {
            _itemObject = new Item(idents, "Bronze Sword", "Bronze Sword is the first sword that players will obtain after finishing the first quest");
        }
        [Test]
        public void TestItemIsIdentifiable()
        {
            Assert.IsTrue(_itemObject.AreYou(id: "Bronze Sword"));
        }
        [Test]
        public void TestShortDescription()
        {
            Assert.AreEqual("Bronze Sword (Bronze Sword)", _itemObject.ShortDescription);
        }
        [Test]
        public void TestLongDescription()
        {
            Assert.AreEqual("Bronze Sword is the first sword that players will obtain after finishing the first quest", _itemObject.FullDescription);
        }

    }
}
