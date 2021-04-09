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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControlCharts : UserControl
    {
        ChartsViewModel chartsVM;
        public UserControlCharts()
        {
            InitializeComponent();
            chartsVM = new ChartsViewModel(FIAModel.Model);
            DataContext = chartsVM;
            /*
            // Instantiate ListBox
            List<String> elements = new List<String>();

            // Instantiate a line chart
            LineSeries mylineseries = new LineSeries();
            // Set the title of the polyline, the name of the chosen element
            mylineseries.Title = "";
            // line chart line form
            mylineseries.LineSmoothness = 0;
            //Distance style of line chart
            mylineseries.PointGeometry = null;
            // Add the abscissa //this is the X line's marks like 0 1 2 3->
            LabelsChart67 = new List<string> {};
            // Add the data of the line chart
            mylineseries.Values = new ChartValues<double>(temp);
            SeriesCollectionChart6 = new SeriesCollection {};
            SeriesCollectionChart6.Add(mylineseries);
            _new_Y_value = 8; //this is the Y in the points //Ordinate

            MaxValueChart6 = 10;
            MinValueChart6 = -10;
            MaxRangeChart6 = 10;
            MinRangeChart6 = -10;

            // Start the Chart line drewing
            linestart();
            DataContext = this;
            */
        }
        
        /*//Continuous line chart method
        public void linestart()
        {
            Task.Run(() =>
            {
                var r = new Random(); //this is the Y in the points //Ordinate
                while (true)
                {
                    //here we update new current X and Y
                    // y is the new time , x is the value of the element in the new time
                    Thread.Sleep(1000); //need to go
                    _new_Y_value = r.Next(-5, 5);
                    // Update the UI element of the form in the worker thread through Dispatcher
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        // Update the horizontal time , the X line
                        LabelsChart67.Add(DateTime.Now.ToString()); //new time
                        LabelsChart67.RemoveAt(0); // remove the erliast time
                                            // Update the ordinate data, the Y value of the new point
                        SeriesCollectionChart6[0].Values.Add(_new_Y_value); // add new data
                        SeriesCollectionChart6[0].Values.RemoveAt(0); // remove data from the start
                    });
                }
            });
        }*/

        private void elementList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.chartsVM.chosenElementName = elementList.SelectedItem.ToString();
        }
    }
}
