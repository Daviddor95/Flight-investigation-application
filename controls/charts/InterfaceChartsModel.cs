using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using LiveCharts;
using LiveCharts.Wpf;

namespace Model
{
    public partial interface IFIAModel : INotifyPropertyChanged
    {
        //for element List
        String ChosenElementName { get; set; }

        //for the charts
        SeriesCollection SeriesCollectionChart6 { set; get; }
       // SeriesCollection SeriesCollectionChart7 { set; get; }
        List<string> LabelsChart67 { get; set; } //this is the X line's labels with is the time, so it's the same in chart 6 & 7
        double MaxValueChart6 { get; set; }
        double MinValueChart6 { get; set; }
        double MaxRangeChart6 { get; set; }
        double MinRangeChart6 { get; set; }
        LineSeries Mylineseries { set; get; } //first Y values in a chart
     //   string ChosenElement { set; get; }
       // string PeasonElement { set; get; }

        //functions
        void chart();
        void createLine();
        /*
        void get30SecOfEleCSV(int elementLocationInCSV);
        double findMaxMinValueRange(); //goes over the 30secArray and find min & max value
        void timeChange(); //when the current time change //calls to get30sec and changeCharts
        void elementChange(); // when a new element is chosen //calls to get30sec and changeCharts and findPeaEle
        //chart 6 = chosen element, time chart
        void changeChart6(); //creates a new SeriesCollection for chart 6
        //chart 7 = chosen element most peason element, time chart
        void changeChart7();
        //chart 8 = Anomaly chart, both elements chart
        void changeChart8();
        void findPearsonEle(); // when elechange // finds the most peason element to the chosenElement
        */
    }
}
