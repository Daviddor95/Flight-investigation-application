using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using LiveCharts;
using LiveCharts.Wpf;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace Model
{
    public partial class FIAModel : IFIAModel
    {
        // variables -- small letters ------------------------------------------------------
        //public event PropertyChangedEventHandler PropertyChanged;
        private int elementPreasonIndex;
        private int elementChosenIndex;

        private SeriesCollection seriesCollectionChart6;
        private double maxValueChart6;
        private double minValueChart6;
        private double maxRangeChart6;
        private double minRangeChart6;
        private List<string> labelsChart67;
        private LineSeries mylineseries;
        // get set for variables -- big letter ---------------------------------------------
        public SeriesCollection SeriesCollectionChart6 { 
            get { return seriesCollectionChart6; }
            set { 
                seriesCollectionChart6 = value;
                NotifyPropertyChanged("seriesCollectionChart6");
            }
        }
        public List<string> LabelsChart67 { 
            get { return labelsChart67; }
            set
            {
                labelsChart67 = value;
                NotifyPropertyChanged("LabelsChart67");
            }
        }
        public Double MaxValueChart6 { 
            get { return maxValueChart6; }
            set
            {
                maxValueChart6 = value;
                NotifyPropertyChanged("MaxValueChart6");
            }
        }
        public Double MinValueChart6 { get { return minValueChart6; }
            set
            {
                minValueChart6 = value;
                NotifyPropertyChanged("MinValueChart6");
            }
        }
        public Double MaxRangeChart6 { get { return maxRangeChart6; }
            set
            {
                maxRangeChart6 = value;
                NotifyPropertyChanged("MaxRangeChart6");
            }
        }
        public Double MinRangeChart6 { get { return minRangeChart6; }
            set
            {
                minRangeChart6 = value;
                NotifyPropertyChanged("MinRangeChart6");
            }
        }
        public LineSeries Mylineseries { get { return mylineseries; }
            set
            {
                mylineseries = value;
                NotifyPropertyChanged("Mylineseries");
            }
        } //first Y values in a chart
        
      /*  public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }*/

        private double _new_Y_value;
        private double[] temp = { 0, 0, 0, 0, 0, 0, 0, 0 };

        // functions -----------------------------------------------------------------------
        public void chart() // will be called every new currentLine of CSV
        {
            // Instantiate ListBox
            List<String> elements = new List<String>();

            // Instantiate a line chart
            LineSeries mylineseries = new LineSeries();
            // Set the title of the polyline, the name of the chosen element
            mylineseries.Title = "element";
            // line chart line form
            mylineseries.LineSmoothness = 0;
            //Distance style of line chart
            mylineseries.PointGeometry = null;
            // Add the abscissa //this is the X line's marks like 0 1 2 3->
            labelsChart67 = new List<string> { "0:00", "0:00", "0:00", "0:00", "0:00" };
            // Add the data of the line chart
            mylineseries.Values = new ChartValues<double>(temp);
            seriesCollectionChart6 = new SeriesCollection { };
            seriesCollectionChart6.Add(mylineseries);
            _new_Y_value = 8; //this is the Y in the points //Ordinate

            maxValueChart6 = 10;
            minValueChart6 = -10;
            maxRangeChart6 = 10;
            minRangeChart6 = -10;

            // Start the Chart line drewing
            startLine();
           // DataContext = this;

            //get30SecOfEleCSV(elementChosenIndex, currentLine);
            //findMaxMinValueRange(elementChosenIndex);
            //changeChart6();
            // get30SecOfEleCSV(elementPreasonIndex);
            // findMaxMinValueRange(elementPreasonIndex);
            // changeChart7();
        }
        public void startLine() //mabye dont need this, if i make the chart again ever second 
        {
            var r = new Random(); //this is the Y in the points //Ordinate
            _new_Y_value = r.Next(-5, 5);
            LabelsChart67.Add(DateTime.Now.ToString()); //new time
            LabelsChart67.RemoveAt(0); // remove the erliast time
            // Update the ordinate data, the Y value of the new point
            SeriesCollectionChart6[0].Values.Add(_new_Y_value); // add new data
            SeriesCollectionChart6[0].Values.RemoveAt(0); // remove data from the start

            /*//for now just copyied from xaml.cs
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
            });*/
        }

        //--------------------------------------------------------------------------------
        /*
        void get30SecOfEleCSV(int elementLocationInCSV) { }
        void findMaxMinValueRange(int eleLocation) //goes over the 30secArray and find min & max value
        {
           /* string max = "0";
            string min = "0";
            for (int i = currentLine - 30; i < currentLine; i++)
            {
                if (max < CSVLines[currentLine])
                {
                    max = CSVLines[currentLine];
                }
                else if (min > CSVLines[currentLine])
                {
                    min = CSVLines[currentLine];
                }
            }
            MaxValue = (double)max;
            MinValue = (double)min;
           
        }
        void elementChange() // when a new element is chosen //calls to get30sec and changeCharts and findPeaEle
        {
            //get new ele name
            //find location of new ele in CSV
            elementChosenIndex = 0;
            get30SecOfEleCSV(elementChosenIndex);
            findMaxMinValueRange(elementChosenIndex);
            changeChart6();
            //findPearsonEle(elementChosenIndex);
            //get30SecOfEleCSV(elementPreasonIndex);
            //findMaxMinValueRange(elementPreasonIndex);
            //changeChart7();
        }
        //chart 6 = chosen element, time chart
        void changeChart6() //creates a new SeriesCollection for chart 6
        { }
        */
    }
}
