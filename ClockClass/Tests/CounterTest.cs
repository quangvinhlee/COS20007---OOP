using NUnit.Framework;
using ClockClass;
namespace Tests
{
    public class TestCounter
    {
        private Counter _counterTest;

        [SetUp]
        public void Setup()
        {
            _counterTest = new Counter("Test");
        }

                
        public void test_start9()
        {
            Assert.AreEqual(0, _counterTest.Ticks);
        }

        [Test]
        public void test_name()
        {
            Assert.AreEqual("Test", _counterTest.Name);
        }

        [Test]
        public void test_count_reset()
        {
            _counterTest.Increment();
            _counterTest.Reset();
            Assert.AreEqual(0, _counterTest.Ticks);
        }

        [TestCase(60, 60)]
        [TestCase(100, 100)]
        public void test_increment(int Ticks, int result)
        {
            int i;
            for (i = 0; i < Ticks; i++)
            {
                _counterTest.Increment();
            }
            Assert.AreEqual(result, _counterTest.Ticks);
        }
    }
}