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
        private String chosenElementName;
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
        public String ChosenElementName
        {
            get
            {
                return chosenElementName;
            }
            set
            {
                String chosenElementName = value;
                NotifyPropertyChanged("chosenElementName");
            }
        }
        public SeriesCollection SeriesCollectionChart6 {
            get
            {
                return seriesCollectionChart6;
            }
            set
            {
                seriesCollectionChart6 = (value);
                NotifyPropertyChanged("seriesCollectionChart6");
            }
        }
        public List<string> LabelsChart67 {
            get { return labelsChart67; }
            set
            {
                labelsChart67 = (value);
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
        public LineSeries Mylineseries {
            get
            {
                return mylineseries;
            }
            set
            {
                mylineseries = (value);
                NotifyPropertyChanged("Mylineseries");
            }
        }

        private float _new_Y_value;
        private float[] temp = { 0, 0, 0, 0, 0, 0, 0, 0 };

        // functions -----------------------------------------------------------------------
        public void chart() // will be called every new currentLine of CSV
        {
            //Application.Current.Dispatcher.Invoke((Action)delegate{
                // Instantiate ListBox
                //List<String> elements = new List<String>();

                // Instantiate a line chart
                this.Mylineseries = new LineSeries();
                // Set the title of the polyline, the name of the chosen element
                this.Mylineseries.Title = "";
                // line chart line form
                this.Mylineseries.LineSmoothness = 0;
                //Distance style of line chart
                this.Mylineseries.PointGeometry = null;
                // Add the abscissa //this is the X line's marks like 0 1 2 3->
                //this.labelsChart67 = new List<string> { "0:00", "0:00", "0:00", "0:00", "0:00" };
                // Add the data of the line chart
                this.Mylineseries.Values = new ChartValues<float>(temp);

                // Start the Chart line drewing
                createLine();
            //});
        }
        public void createLine()
        {
            var r = new Random(); //this is the Y in the points //Ordinate
            this._new_Y_value = r.Next(-5, 5);
            this.LabelsChart67 = new List<string> { "0:00", "0:00", "0:00", "0:00", "0:00" };
            this.LabelsChart67.Add(DateTime.Now.ToString()); //new time
            this.LabelsChart67.RemoveAt(0); // remove the erliast time
            NotifyPropertyChanged("LabelsChart67");

            // Update the ordinate data, the Y value of the new point
            this.SeriesCollectionChart6 = new SeriesCollection { };
            this.SeriesCollectionChart6.Add(this.mylineseries);
            this.SeriesCollectionChart6[0].Values.Add(_new_Y_value); // add new data
            this.SeriesCollectionChart6[0].Values.RemoveAt(0); // remove data from the start
            NotifyPropertyChanged("SeriesCollectionChart6");
            

            /*
            //code that should work with CSV and time
            int locationOfElement = 21;//the index in csvLine[currentLine]
            float max = Int32.Parse(this.CSVLines[currentLine].Split(new string[] { "," }, StringSplitOptions.None)[locationOfElement]);
            float min = max;
            DateTime timeTemp = this.Time; //so Time wont change by opps

            for (int i = 30; i > 0; --i)//start from 30sec before correntTime, and goes to currentTime
            {
                LabelsChart67.Add((timeTemp.AddSeconds(-i)).ToString()); //new time
                LabelsChart67.RemoveAt(0); // remove the erliast time
                // Update the ordinate data, the Y value of the new point
                _new_Y_value = Int32.Parse(this.CSVLines[currentLine - i].Split(new string[] { "," }, StringSplitOptions.None)[locationOfElement]);
                SeriesCollectionChart6[0].Values.Add(_new_Y_value); // add new data
                SeriesCollectionChart6[0].Values.RemoveAt(0); // remove data from the start
                //finding max & min Value/Range for the chart
                if (max < _new_Y_value)
                {
                    max = _new_Y_value;
                }
                if (min > _new_Y_value)
                {
                    min = _new_Y_value;
                }
            }
            maxValueChart6 = max;
            minValueChart6 = min;
            maxRangeChart6 = maxValueChart6;
            minRangeChart6 = minValueChart6;
            */

            /* //for now just copyied from xaml.cs
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
        void elementChange() // when a new element is chosen
        {
            createLine();
        }
        */
    }
}
