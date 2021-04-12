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
        String[] ElementListNames { get; set; }
        int LocationOfElement6 { get; set; }

    //for the charts
    SeriesCollection SeriesCollectionChart6 { set; get; }
        List<string> LabelsChart67 { get; set; } //this is the X line's labels with is the time, so it's the same in chart 6 & 7
        float MaxValueChart6 { get; set; }
        float MinValueChart6 { get; set; }
        float MaxRangeChart6 { get; set; }
        float MinRangeChart6 { get; set; }
        LineSeries MylineseriesChart6 { set; get; } //first Y values in a chart

        //functions
        void chart();
        void createLine();
    }
}
