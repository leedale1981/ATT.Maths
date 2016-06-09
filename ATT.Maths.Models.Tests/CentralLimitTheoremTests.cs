using System;
using NUnit.Framework;

namespace ATT.Maths.Models.Tests
{
    [TestFixture]
    public class CentralLimitTheoremTests
    {
        [Test]
        public void GetMeanSampleTest()
        {
            int minNumber = 1;
            int maxNumber = 6;
            int sampleSize = 4;
            int numberOfSamples = 1000;

            var clt = new CentralLimitTheorem(sampleSize, numberOfSamples, minNumber, maxNumber);
            double[] samples = clt.GetMeanSamples();

            Assert.Equals(numberOfSamples, samples.Length);
        }

        [Test]
        public void GetRandomNumberTest()
        {
            int minNumber = 1;
            int maxNumber = 6;
            int sampleSize = 4;
            int numberOfSamples = 1000;

            var clt = new CentralLimitTheorem(sampleSize, numberOfSamples, minNumber, maxNumber);
            double randomNumber = clt.GetRandomNumber();

            Assert.Greater(randomNumber, minNumber);
            Assert.Less(randomNumber, maxNumber);
        }
    }
}