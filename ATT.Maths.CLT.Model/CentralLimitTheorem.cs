using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATT.Maths.Models
{
    public class CentralLimitTheorem
    {
        public int SampleSize { get; private set; }
        public int MinValue { get; private set; }
        public int MaxValue { get; private set; }

        private readonly Random random = new Random();

        public CentralLimitTheorem(int samepleSize, int minValue, int maxValue)
        {
            this.SampleSize = samepleSize;
            this.MinValue = minValue;
            this.MaxValue = maxValue;
        }

        public double GetMeanValue()
        {
            double[] sample = new double[this.SampleSize];

            for (int sampleIndex = 0; sampleIndex < SampleSize; sampleIndex++)
            {
                double random = this.GetRandomNumber();
                sample[sampleIndex] = random;
            }

            return (sample.Sum() / this.SampleSize);
        }

        public double GetRandomNumber()
        {
            return (double)this.random.Next(this.MinValue, this.MaxValue) +
                this.random.NextDouble();
        }

    }
}
