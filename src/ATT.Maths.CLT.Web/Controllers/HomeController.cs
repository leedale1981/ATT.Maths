using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Chart.Mvc;
using Chart.Mvc.ComplexChart;
using ATT.Maths.Models;
using System.Collections;
using ATT.Maths.CLT.Web.ViewModels;

namespace ATT.Maths.CLT.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(LineChartViewModel model)
        {
            LineChart chart = this.GetChart(model.MinValue, model.MaxValue,
                    this.GetMeanFrequencies(
                        model.SampleSize, model.NumberOfSamples, model.MinValue, model.MaxValue));
            model.LineChart = chart;
            return View(model);
        }

        private SortedDictionary<double, double> GetMeanFrequencies(int sampleSize, int numberOfSamples, int minValue, int maxValue)
        {
            var clt = new CentralLimitTheorem(sampleSize, numberOfSamples, minValue, maxValue);
            SortedDictionary<double, double> meanFrequencies = clt.GetFrequencyOfMeans();

            return meanFrequencies;
        }

        private LineChart GetChart(int minValue, int maxValue, SortedDictionary<double, double> means)
        {
            var chart = new LineChart();
            chart.ComplexData.Labels.AddRange(means.Keys.Select(m => m.ToString()).ToArray());
            chart.ComplexData.Datasets.AddRange(new List<ComplexDataset>
            {
                new ComplexDataset
                {
                    Data = means.Values.ToList(),
                    Label = "Means"
                }
            });

            return chart;
        }
    }
}
