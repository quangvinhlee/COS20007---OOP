using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventureTests
{
    public class ItemTest
    {
        private Item _itemObject;
        private string[] idents = new[] { "Wooden Sword", "The basic sword" };

        [SetUp]
        public void SetUp()
        {
            _itemObject = new Item(idents, "Wooden Sword", "Wooden Sword is the first sword that players will obtain after finishing the first quest.");
        }

        [Test]
        public void TestItemIsIdentifiable()
        {
            Assert.IsTrue(_itemObject.AreYou(id: "Wooden Sword"));
        }

        [Test]
        public void TestShortDescription()
        {
            Assert.AreEqual("Wooden Sword (Wooden Sword)", _itemObject.ShortDescription);
        }

        [Test]
        public void TestFullDescription()
        {
            Assert.AreEqual("Wooden Sword is the first sword that players will obtain after finishing the first quest.", _itemObject.FullDescription);
        }
    }
}
