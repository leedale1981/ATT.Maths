using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Chart.Mvc;
using Chart.Mvc.ComplexChart;
using ATT.Maths.Models;
using System.Collections;

namespace ATT.Maths.CLT.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            int sampleSize = 100;
            int minValue = 1;
            int maxValue = 10;

            LineChart chart = this.GetChart(minValue, maxValue,
                    this.GetMeans(sampleSize, minValue, maxValue));
            return View(chart);
        }

        private double[] GetMeans(int sampleSize, int minValue, int maxValue)
        {
            var clt = new CentralLimitTheorem(sampleSize, minValue, maxValue);
            int numOfSamples = 100;
            double[] means = new double[numOfSamples];

            for (int index = 0; index < numOfSamples; index++)
            {
                double mean = clt.GetMeanValue();
                means[index] = mean;
            }

            return means;
        }

        private LineChart GetChart(int minValue, int maxValue, double[] means)
        {
            int current = minValue;
            int endRange = maxValue - minValue;
            string[] labelRange = new string[endRange + 1];
            
            for (int index = 0; index <= endRange; index++)
            {
                labelRange[index] = current.ToString();
                current++;
            }

            var chart = new LineChart();
            chart.ComplexData.Labels.AddRange(labelRange);
            chart.ComplexData.Datasets.AddRange(new List<ComplexDataset>
            {
                new ComplexDataset
                {
                    Data = means.ToList(),
                    Label = "Means"
                }
            });

            return chart;
        }
    }
}
