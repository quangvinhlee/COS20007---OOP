using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventureTests
{
    public class IdentifiableObjectTests
    {
        private IdentifiableObject _iObject;
        private string[] idents = new[] { "Fred", "Bob" };

        [SetUp]
        public void Setup()
        {
            _iObject = new IdentifiableObject(idents);
        }

        [Test]
        public void TestAreYou()
        {
            Assert.True(_iObject.AreYou("Fred"));
        }

        [Test]
        public void TestNotAreYou()
        {
            Assert.False(_iObject.AreYou("Anh"));
        }

        [Test]
        public void TestCaseSensitive()
        {
            Assert.True(_iObject.AreYou("fred"));
            Assert.True(_iObject.AreYou("frED"));
            Assert.True(_iObject.AreYou("FRED"));
        }

        [Test]
        public void TestFirstId()
        {
            Assert.AreEqual("Fred", _iObject.FirstID);
        }

        [Test]
        public void TestFirstIdWithNoId()
        {
            string[] emptyIdents = new string[] { };
            _iObject = new IdentifiableObject(emptyIdents);
            Assert.AreEqual("", _iObject.FirstID);
        }

        [Test]
        public void TestAddId()
        {
            _iObject.AddIdentifier("Wilma");
            Assert.True(_iObject.AreYou("Wilma"));
        }
    }
}
