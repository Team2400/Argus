using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf; //The WPF controls
using LiveCharts.Defaults;
using LiveCharts.WinForms;
using System.Windows.Media;
using Brushes = System.Windows.Media.Brushes;

namespace Argus
{
    public partial class DashBoard : Form
    {

        public DashBoard()
        {
            InitializeComponent();

            cpuChart.Series = new SeriesCollection
            {
                 new LineSeries
                {
                    Values = new ChartValues<double> {6, 7, 3, 4, 6, 5, 3, 2, 6, 7, 8, 7, 5},
                    PointGeometry = null,
                    LineSmoothness = 0//직선
                }

            };

            cpuChart.AxisX.Add(new Axis
            {
                Title = "Time",
                Labels = new[]
                {
                "0","5","10","15","20","25","30","35","40","45","50","55","60"//나중에 timespan 문자열로?
                },
                Separator = new Separator // force the separator step to 1, so it always display all labels
                {
                    Step = 1,
                    IsEnabled = false //disable it to make it invisible.
                },
                LabelsRotation = 0//x축 label 기울기
            });

            cpuChart.AxisY.Add(new Axis
            {
                Title = "Usage",
                LabelFormatter = value => value + "%",
                //LabelFormatter = value => value.ToString("P"),//표준형식지정자 (P) 사용
                Separator = new Separator()
            });

            memoryChart.Series = new SeriesCollection
            {
                 new LineSeries
                {
                    Values = new ChartValues<double> {6, 7, 3, 4, 6, 5, 3, 2, 6, 7, 8, 7, 5},
                    PointGeometry = null,
                    LineSmoothness = 0//직선
                }

            };

            memoryChart.AxisX.Add(new Axis
            {
                Title = "Time",
                Labels = new[]
                {
                "0","5","10","15","20","25","30","35","40","45","50","55","60"//나중에 timespan 문자열로?
                },
                Separator = new Separator // force the separator step to 1, so it always display all labels
                {
                    Step = 1,
                    IsEnabled = false //disable it to make it invisible.
                },
                LabelsRotation = 0//x축 label 기울기
            });

            memoryChart.AxisY.Add(new Axis
            {
                Title = "Usage",
                LabelFormatter = value => value + "%",
                //LabelFormatter = value => value.ToString("P"),//표준형식지정자 (P) 사용
                Separator = new Separator()
            });

            diskChart.Series = new SeriesCollection
            {
                 new LineSeries
                {
                    Values = new ChartValues<double> {6, 7, 3, 4, 6, 5, 3, 2, 6, 7, 8, 7, 5},
                    PointGeometry = null,
                    LineSmoothness = 0//직선
                }

            };

            diskChart.AxisX.Add(new Axis
            {
                Title = "Time",
                Labels = new[]
                {
                "0","5","10","15","20","25","30","35","40","45","50","55","60"//나중에 timespan 문자열로?
                },
                Separator = new Separator // force the separator step to 1, so it always display all labels
                {
                    Step = 1,
                    IsEnabled = false //disable it to make it invisible.
                },
                LabelsRotation = 0//x축 label 기울기
            });

            diskChart.AxisY.Add(new Axis
            {
                Title = "Usage",
                LabelFormatter = value => value + "%",
                //LabelFormatter = value => value.ToString("P"),//표준형식지정자 (P) 사용
                Separator = new Separator()
            });
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
        }

    }
}
