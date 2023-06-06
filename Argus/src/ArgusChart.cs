using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts;
using LiveCharts.Wpf; //The WPF controls

namespace Argus
{
    internal class ArgusChart
    {
        public static void makeChart(LiveCharts.WinForms.CartesianChart someChart, List<string> labels)
        {
            someChart.AxisX.Add(new Axis
            {
                Labels = labels,
                Separator = new Separator // force the separator step to 1, so it always display all labels
                {
                    Step = 1,
                    IsEnabled = false //disable it to make it invisible.
                },
                LabelsRotation = 0 //x축 label 기울기
            });

            someChart.AxisY.Add(new Axis
            {
                Title = "Usage",
                LabelFormatter = value => value + "%",
                //LabelFormatter = value => value.ToString("P"),//표준형식지정자 (P) 사용
                Separator = new Separator(),
                MinValue = 0,
                MaxValue = 100,
            });
        }

        public static void updateChart(LiveCharts.WinForms.CartesianChart someChart, List<double> values, string title)
        {
            someChart.AxisX.First().Title = title;
            someChart.Series = new SeriesCollection
            {
                 new LineSeries
                {
                    Values = new ChartValues<double>(values),
                    PointGeometry = null,
                    LineSmoothness = 0//직선
                }
            };
        }
    }
}
