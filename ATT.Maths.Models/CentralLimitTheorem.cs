using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATT.Maths.Models
{
    public class CentralLimitTheorem
    {
        public int SampleSize { get; private set; }
        public int NumberOfSamples { get; set; }
        public int MinValue { get; private set; }
        public int MaxValue { get; private set; }

        private readonly Random random = new Random();

        public CentralLimitTheorem(int samepleSize, int numberOfSamples, int minValue, int maxValue)
        {
            this.SampleSize = samepleSize;
            this.NumberOfSamples = numberOfSamples;
            this.MinValue = minValue;
            this.MaxValue = maxValue;
        }

        public double[] GetMeanSamples()
        {
            double[] sample = new double[this.SampleSize];
            double[] samples = new double[this.NumberOfSamples];

            for (int samplesIndex = 0; samplesIndex < NumberOfSamples; samplesIndex++)
            {
                for (int sampleIndex = 0; sampleIndex < SampleSize; sampleIndex++)
                {
                    double random = this.GetRandomNumber();
                    sample[sampleIndex] = random;
                }

                samples[samplesIndex] = Math.Round((sample.Sum() / this.SampleSize), 1);
            }

            return samples;
        }

        public SortedDictionary<double, double> GetFrequencyOfMeans()
        {
            double[] means = this.GetMeanSamples();
            SortedDictionary<double, double> frequencies = new SortedDictionary<double, double>();

            for (int meanIndex = 0; meanIndex < means.Length; meanIndex++)
            {
                double mean = means[meanIndex];
                if (frequencies.ContainsKey(mean))
                {
                    frequencies[mean] = frequencies[mean] + 1;
                }
                else
                {
                    frequencies.Add(mean, 1);
                }
            }

            return frequencies;
        }

        public double GetRandomNumber()
        {
            return Math.Round((double)this.random.Next(this.MinValue, this.MaxValue) +
                this.random.NextDouble(), 1);
        }

    }
}
