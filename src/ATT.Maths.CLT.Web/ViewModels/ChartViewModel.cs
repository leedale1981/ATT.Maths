using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chart.Mvc.ComplexChart;

namespace ATT.Maths.CLT.Web.ViewModels
{
    public class LineChartViewModel
    {
        public LineChart LineChart { get; set; }
        public int SampleSize { get; set; }
        public int NumberOfSamples { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
    }
}
