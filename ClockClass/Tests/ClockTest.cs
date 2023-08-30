using NUnit.Framework;
using ClockClass;
namespace Tests
{
    public class ClockTest
    {
        private Clock _clock;

        [SetUp]
        public void Setup()
        {
            _clock = new Clock();
        }

        [Test]
        public void TestClockStart()
        {
            Assert.AreEqual("00:00:00", _clock.CurrentTime());
        }

        [Test]
        public void TestReset()
        {
            int i;
            for (i = 0; i < 86400; i++)
            {
                _clock.Tick();
            }
            _clock.Reset();
            Assert.AreEqual("00:00:00", _clock.CurrentTime());

        }

        [TestCase(0, "00:00:00")] //0 min
        [TestCase(60, "00:01:00")] //1 min
        [TestCase(3600, "01:00:00")] //1 hour
        [TestCase(86340, "23:59:00")] //1 day

        public void TestRunning(int tick, string currenttime)
        {
            int i;
            for (i = 0; i < tick; i++)
            {
                _clock.Tick();
            }
            Assert.AreEqual(currenttime, _clock.CurrentTime());

        }
    }
}

      