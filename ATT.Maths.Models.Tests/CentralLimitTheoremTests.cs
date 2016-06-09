using System;
using NUnit.Framework;

namespace ATT.Maths.Models.Tests
{
    [TestFixture]
    public class CentralLimitTheoremTests
    {
        [Test]
        public void GetMeanTest()
        {
            int minNumber = 1;
            int maxNumber = 6;
            int sampleSize = 4;

            var clt = new CentralLimitTheorem(sampleSize, minNumber, maxNumber);
            double mean = clt.GetMeanValue();

            Assert.Greater(mean, minNumber);
            Assert.Less(mean, maxNumber);
        }

        [Test]
        public void GetRandomNumberTest()
        {
            int minNumber = 1;
            int maxNumber = 6;
            int sampleSize = 4;

            var clt = new CentralLimitTheorem(sampleSize, minNumber, maxNumber);
            double randomNumber = clt.GetRandomNumber();

            Assert.Greater(randomNumber, minNumber);
            Assert.Less(randomNumber, maxNumber);
        }
    }
}