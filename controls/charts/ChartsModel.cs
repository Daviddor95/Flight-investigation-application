using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using LiveCharts;
using LiveCharts.Wpf;
using System.Threading;
using System.Windows;

namespace Model
{
    public partial class FIAModel : IFIAModel
    {
        // variables -- small letters ------------------------------------------------------
        private String chosenElementName;
        private string[] elementListNames;
        //locationOfElement6 is only in model, put 0=aileron for when a element was not chosen yet
        private int locationOfElement6;//the index in csvLine[currentLine] for the chosenElementName

        private SeriesCollection seriesCollectionChart6;
        private float maxValueChart6;
        private float minValueChart6;
        private float maxRangeChart6;
        private float minRangeChart6;
        private List<string> labelsChart67;
        private LineSeries mylineseriesChart6;
        private LineSeries mylineseriesChart7;

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
                elementChange();
                NotifyPropertyChanged("ChosenElementName");
            }
        }
        public int LocationOfElement6
        {
            get
            {
                return locationOfElement6;
            }
            set
            {
                int locationOfElement6 = value;
            }
        }
        public String[] ElementListNames //the list of element we can chose from in combobox
        {
            get
            {
                //there are 5 elements in each row
                return elementListNames = new string[] { "aileron", "elevator", "rudder", "flaps", "slats", 
                    "speedbrake", "throttle", "throttle", "engine - pump", "electric - pump", 
                    "external - power", "APU - generator", "latitude - deg", "longitude - deg", "altitude - ft", 
                    "roll - deg", "pitch - deg", "heading - deg", "side - slip - deg", "airspeed - kt", 
                    "glideslope", "vertical - speed - fps", "airspeed - indicator_indicated - speed - kt", "altimeter_indicated - altitude - ft", "altimeter_pressure - alt - ft", 
                    "attitude - indicator_indicated - pitch - deg", "attitude - indicator_indicated - roll - deg", "attitude - indicator_internal - pitch - deg", "attitude - indicator_internal - roll - deg", "encoder_indicated - altitude - ft", 
                    "encoder_pressure - alt - ft", "gps_indicated - altitude - ft", "gps_indicated - ground - speed - kt", "gps_indicated - vertical - speed", "indicated - heading - deg", 
                    "magnetic - compass_indicated - heading - deg", "slip - skid - ball_indicated - slip - skid", "turn - indicator_indicated - turn - rate", "vertical - speed - indicator_indicated - speed - fpm", "engine_rpm" }; ;
            }
            set
            {
                String[] elementListNames = value;
                NotifyPropertyChanged("ElementListNames");
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
                NotifyPropertyChanged("SeriesCollectionChart6");
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
        public float MaxValueChart6 {
            get { return maxValueChart6; }
            set
            {
                maxValueChart6 = value;
                NotifyPropertyChanged("MaxValueChart6");
            }
        }
        public float MinValueChart6 { get { return minValueChart6; }
            set
            {
                minValueChart6 = value;
                NotifyPropertyChanged("MinValueChart6");
            }
        }
        public float MaxRangeChart6 { get { return maxRangeChart6; }
            set
            {
                maxRangeChart6 = value;
                NotifyPropertyChanged("MaxRangeChart6");
            }
        }
        public float MinRangeChart6 { get { return minRangeChart6; }
            set
            {
                minRangeChart6 = value;
                NotifyPropertyChanged("MinRangeChart6");
            }
        }
        public LineSeries MylineseriesChart6 {
            get
            {
                return mylineseriesChart6;
            }
            set
            {
                mylineseriesChart6 = (value);
                NotifyPropertyChanged("MylineseriesChart6");
            }
        }
        public LineSeries MylineseriesChart7
        {
            get
            {
                return mylineseriesChart7;
            }
            set
            {
                mylineseriesChart7 = (value);
                NotifyPropertyChanged("MylineseriesChart7");
            }
        }

        private float new_value_chart6;
        private float new_value_chart7;
        private float[] temp = { 0, 0, 0, 0, 0, 0, 0, 0 };

        // functions -----------------------------------------------------------------------
        public void chart() // called from start in mainModel
        { 
            NotifyPropertyChanged("ElementListNames");

            Application.Current.Dispatcher.Invoke(() =>
            {
                // Instantiate a line chart 
                this.MylineseriesChart6 = new LineSeries();
                // Set the title of the polyline, the name of the chosen element
                this.MylineseriesChart6.Title = elementListNames[this.LocationOfElement6];
                // line chart line form
                this.MylineseriesChart6.LineSmoothness = 0;
                //Distance style of line chart
                this.MylineseriesChart6.PointGeometry = null;
                // Add the data of the line chart
                this.MylineseriesChart6.Values = new ChartValues<float>(temp);
                this.MylineseriesChart7 = new LineSeries();
                // Set the title of the polyline, the name of the chosen element
                this.MylineseriesChart7.Title = "air speed";
                // line chart line form
                this.MylineseriesChart7.LineSmoothness = 0;
                //Distance style of line chart
                this.MylineseriesChart7.PointGeometry = null;
                // Add the data of the line chart
                this.MylineseriesChart7.Values = new ChartValues<float>(temp);
                this.SeriesCollectionChart6 = new SeriesCollection { };
                this.SeriesCollectionChart6.Add(this.mylineseriesChart6);
                this.SeriesCollectionChart6.Add(this.mylineseriesChart7);
                List<string> LabelsChart67 = new List<string> { "0:00", "0:00", "0:00", "0:00", "0:00" };

                //add the points to the chart
                // locationOfElement6 = 17;//the index in csvLine[currentLine] //17=roll
                int locationOfElement7 = 21;//the index in csvLine[currentLine] //21=airspeed
                DateTime timeTemp = this.Time; //so Time wont change by opps
                int j = 10;
                if(currentLine < j)//for the first 30sec of the video
                {
                    j = currentLine;
                }
                float max = float.Parse(this.CSVLines[currentLine].Split(',')[this.LocationOfElement6]);
                float min = max;
                
                for (int i = j; i > 0; --i)//start from 30sec before correntTime, and goes to currentTime
                {
                    //LabelsChart67.Add((timeTemp.AddSeconds(-i)).ToString()); //new time
                    LabelsChart67.Add("0");//this.Time.ToString("HH:mm:ss"));
                    LabelsChart67.RemoveAt(0); // remove the erliast time
                     // Update the ordinate data, the Y value of the new point
                     //chart 6
                    new_value_chart6 = float.Parse(this.CSVLines[currentLine - i].Split(',')[this.LocationOfElement6]);
                    SeriesCollectionChart6[0].Values.Add(new_value_chart6); // add new data
                    SeriesCollectionChart6[0].Values.RemoveAt(0); // remove data from the start
                     //chart 7
                    new_value_chart7 = float.Parse(this.CSVLines[currentLine - i].Split(',')[locationOfElement7]);
                    SeriesCollectionChart6[1].Values.Add(new_value_chart7); // add new data
                    SeriesCollectionChart6[1].Values.RemoveAt(0); // remove data from the start
                     //finding max & min Value/Range for the chart
                    if (max < Math.Max(new_value_chart6, new_value_chart7))
                    {
                        max = Math.Max(new_value_chart6, new_value_chart7);
                    }
                    if (min > Math.Min(new_value_chart6, new_value_chart7))
                    {
                        min = Math.Min(new_value_chart6, new_value_chart7);
                    }
                }
                this.MaxValueChart6 = (int)max + 1;
                this.MinValueChart6 = (int)min - 1;
                if (this.MaxValueChart6 < 0)
                    this.MaxValueChart6 = 0.1F;
                if (this.MinValueChart6 > 0)
                    this.MinValueChart6 = 0;
                NotifyPropertyChanged("SeriesCollectionChart6");
                NotifyPropertyChanged("LabelsChart67");
            });
        }
        //--------------------------------------------------------------------------------
        //yes, this isnt good if they change the elemts order in the csv&xml
        //  but for now, the ElementListNames is in the order that they shoe in csv so we will use it
        //here we find the index of the chosen ele from CSV, and we put it in locationOfElement6
        void elementChange() // when a new element is chosen
        {
            this.LocationOfElement6 = 17;
            for (int i = 0; i < elementListNames.Length; i++)
            {
                if(elementListNames[i].Equals(this.ChosenElementName))
                    this.LocationOfElement6 = i;
            }
        }
        
        public void createLine()
        {
            /*// for random values, for testing
                 var r = new Random(); //this is the Y in the points //Ordinate
                 this._new_Y_value = r.Next(-5, 5);
                 List<string> tempLabelsChart67 = new List<string> { "0:00", "0:00", "0:00", "0:00", "0:00" };
                 tempLabelsChart67.Add("0"); //new time
                 tempLabelsChart67.RemoveAt(0); // remove the erliast time
                 this.LabelsChart67 = tempLabelsChart67;
                 NotifyPropertyChanged("LabelsChart67");

                 // Update the ordinate data, the Y value of the new point
                 this.SeriesCollectionChart6 = new SeriesCollection { };
                 this.SeriesCollectionChart6.Add(this.mylineseries);
                 this.SeriesCollectionChart6[0].Values.Add(_new_Y_value); // add new data
                 this.SeriesCollectionChart6[0].Values.RemoveAt(0); // remove data from the start
                 NotifyPropertyChanged("SeriesCollectionChart6");
                 */
        }
    }
}
