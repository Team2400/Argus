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

            cartesianChart1.Series = new SeriesCollection
            {
                 new LineSeries
                {
                    Values = new ChartValues<double> {6, 7, 3, 4, 6,5,3,2,6,7,8,7,5},
                    PointGeometry = null,
                    LineSmoothness = 0//직선
                }

            };

            cartesianChart1.AxisX.Add(new Axis
            {
                Title="Time",
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
            }) ;

            cartesianChart1.AxisY.Add(new Axis
            {
                Title="Usage",
                LabelFormatter = value => value + "%",
                //LabelFormatter = value => value.ToString("P"),//표준형식지정자 (P) 사용
                Separator = new Separator()
            });

            cartesianChart2.Series = new SeriesCollection
            {
                 new LineSeries
                {
                    Values = new ChartValues<double> {6, 7, 3, 4, 6,5,3,2,6,7,8,7,5},
                    PointGeometry = null,
                    LineSmoothness = 0//직선
                }

            };

            cartesianChart2.AxisX.Add(new Axis
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

            cartesianChart2.AxisY.Add(new Axis
            {
                Title = "Usage",
                LabelFormatter = value => value + "%",
                //LabelFormatter = value => value.ToString("P"),//표준형식지정자 (P) 사용
                Separator = new Separator()
            });

            cartesianChart3.Series = new SeriesCollection
            {
                 new LineSeries
                {
                    Values = new ChartValues<double> {6, 7, 3, 4, 6,5,3,2,6,7,8,7,5},
                    PointGeometry = null,
                    LineSmoothness = 0//직선
                }

            };

            cartesianChart3.AxisX.Add(new Axis
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

            cartesianChart3.AxisY.Add(new Axis
            {
                Title = "Usage",
                LabelFormatter = value => value + "%",
                //LabelFormatter = value => value.ToString("P"),//표준형식지정자 (P) 사용
                Separator = new Separator()
            });
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {

        }

    }
}
