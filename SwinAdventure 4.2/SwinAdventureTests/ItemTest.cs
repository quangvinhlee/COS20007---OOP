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
    public class ItemTest
    {
        private Item _itemObject;

        [SetUp]
        public void SetUp()
        {
            _itemObject = new Item(new string[] { "Bronze Sword", "The basic sword" }, "Bronze Sword", "Bronze Sword is the first sword that players will obtain after finishing the first quest");
        }

        [Test]
        public void TestItemIsIdentifiable()
        {
            Assert.IsTrue(_itemObject.AreYou("Bronze Sword"));
        }

        [Test]
        public void TestShortDescription()
        {
            Assert.AreEqual("Bronze Sword (bronze sword)", _itemObject.ShortDescription);
        }

        [Test]
        public void TestLongDescription()
        {
            Assert.AreEqual("Bronze Sword is the first sword that players will obtain after finishing the first quest", _itemObject.FullDescription);
        }
    }
}
