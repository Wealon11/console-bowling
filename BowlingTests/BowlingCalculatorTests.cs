using Bowling;
using NUnit.Framework;

namespace BowlingTests
{

    [TestFixture]
    public class BowlingCalculatorTests
    {
        private IBowlingCalculator _bowlingCalculator;

        [SetUp]
        public void SetUp()
        {
            _bowlingCalculator = new BowlingCalculator();
        }

        [TearDown]
        public void TearDown()
        {
            _bowlingCalculator = null;
        }

        [Test]
        public void TestRollingAllStrike()
        {
            ThrowMany(10, 0);
            _bowlingCalculator.RecordFrame(10, 10, 10);

            Assert.That(_bowlingCalculator.Score, Is.EqualTo(300));
        }

        [Test]
        public void TestRollingAllSpare()
        {
            ThrowMany(5, 5);
            _bowlingCalculator.RecordFrame(5, 5, 5);

            Assert.That(_bowlingCalculator.Score, Is.EqualTo(150));
        }

        [Test]
        public void TestRollingAllOne()
        {
            ThrowMany(1, 1);
            _bowlingCalculator.RecordFrame(1, 1);

            Assert.That(_bowlingCalculator.Score, Is.EqualTo(20));
        }

        [Test]
        public void TestRollingAllZero()
        {
            ThrowMany(0, 0);
            _bowlingCalculator.RecordFrame(0, 0);

            Assert.That(_bowlingCalculator.Score, Is.EqualTo(0));
        }


        private void ThrowMany(params int[] rolls)
        {
            for (var i = 1; i <= 9; i++) _bowlingCalculator.RecordFrame(rolls);
        }
    }
}