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
        String[] VM_ElementListNames { get; set; }

        SeriesCollection VM_SeriesCollectionChart6 { set; get; }
        List<string> VM_LabelsChart67 { get; set; } //this is the X line's labels with is the time, so it's the same in chart 6 & 7
        float VM_MaxValueChart6 { get; set; }
        float VM_MinValueChart6 { get; set; }
        float VM_MaxRangeChart6 { get; set; }
        float VM_MinRangeChart6 { get; set; }
        LineSeries VM_MylineseriesChart6 { set; get; } //first Y values in a chart

    }
}
