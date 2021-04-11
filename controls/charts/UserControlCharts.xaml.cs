using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;
using ViewModel;
using Model;

namespace View
{
    /// <summary>
    /// Interaction logic for UserControlCharts.xaml
    /// it's mosly empty here
    /// </summary>
    public partial class UserControlCharts : UserControl
    {
       /* private SeriesCollection TseriesCollectionChart6;
        private double TmaxValueChart6;
        private double TminValueChart6;
        private double TmaxRangeChart6;
        private double TminRangeChart6;
        private List<string> TlabelsChart67;
        //LineSeries mylineseries;
        private float[] temp = { 0, 0, 0, 0, 0, 0, 0, 0 };*/

        ChartsViewModel chartsVM;
        public UserControlCharts()
        {
            InitializeComponent();
            chartsVM = new ChartsViewModel(FIAModel.Model);
            DataContext = chartsVM;
 
            // Instantiate a line chart
           /* LineSeries Tmylineseries = new LineSeries();
            // Set the title of the polyline, the name of the chosen element
            Tmylineseries.Title = ":)";
            // line chart line form
            Tmylineseries.LineSmoothness = 0;
            //Distance style of line chart
            Tmylineseries.PointGeometry = null;
            // Add the abscissa //this is the X line's marks like 0 1 2 3->
            TlabelsChart67 = new List<string> {};
            // Add the data of the line chart
            Tmylineseries.Values = new ChartValues<float>(temp);
            TseriesCollectionChart6 = new SeriesCollection {};
            TseriesCollectionChart6.Add(Tmylineseries);

            TmaxValueChart6 = 10;
            TminValueChart6 = -10;
            TmaxRangeChart6 = 10;
            TminRangeChart6 = -10;*/
        }

        private void elementList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //empty
        }
    }
}
