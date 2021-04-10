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
        String VM_ChosenElementName { get; set; }
        SeriesCollection VM_SeriesCollectionChart6 { set; get; }
    //    SeriesCollection SeriesCollectionChart7 { set; get; }
        List<string> VM_LabelsChart67 { get; set; } //this is the X line's labels with is the time, so it's the same in chart 6 & 7
        double VM_MaxValueChart6 { get; set; }
        double VM_MinValueChart6 { get; set; }
        double VM_MaxRangeChart6 { get; set; }
        double VM_MinRangeChart6 { get; set; }
      //  double MaxValueChart7 { get; set; }

        LineSeries mylineseries { set; get; } //first Y values in a chart


    }
}
