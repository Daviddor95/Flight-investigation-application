using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using LiveCharts;
using LiveCharts.Wpf;

namespace ViewModel
{
    interface InterfaceChartsViewModel : INotifyPropertyChanged
    {
        SeriesCollection SeriesCollectionChart6 { set; get; }
    //    SeriesCollection SeriesCollectionChart7 { set; get; }
        List<string> LabelsChart67 { get; set; } //this is the X line's labels with is the time, so it's the same in chart 6 & 7
        double MaxValueChart6 { get; set; }
        double MinValueChart6 { get; set; }
        double MaxRangeChart6 { get; set; }
        double MinRangeChart6 { get; set; }
      //  double MaxValueChart7 { get; set; }
       // double MinValueChart7 { get; set; }
        //double MaxRangeChart7 { get; set; }
        //double MinRangeChart7 { get; set; }
        LineSeries mylineseries { set; get; } //first Y values in a chart
    //    string ChosenElement { set; get; }
      //  string PeasonElement { set; get; }

        //

    }
}
