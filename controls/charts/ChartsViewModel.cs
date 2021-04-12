using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using LiveCharts;
using LiveCharts.Wpf;
using Model;

namespace ViewModel
{
    public class ChartsViewModel : InterfaceChartsViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private IFIAModel model;
        public ChartsViewModel(IFIAModel model)
        {
            this.model = model;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs eventArgs)
            {
                NotifyPropertyChanged("VM_" + eventArgs.PropertyName);
            };
        }
        public void NotifyPropertyChanged(string propName)
        {
            if(this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        // for comboBox ----------------------------------------------
        public String VM_ChosenElementName
        {
            get { return this.model.ChosenElementName; }
            set { 
                this.model.ChosenElementName = value;
                NotifyPropertyChanged("VM_ChosenElementName");
            }
        }
        public int VM_LocationOfElement6
        {
            get
            {
                return model.LocationOfElement6;
            }
            set
            {
                model.LocationOfElement6 = value;
                NotifyPropertyChanged("VM_LocationOfElement6");
            }
        }
        public string[] VM_ElementListNames
        {
            get
            {
                return model.ElementListNames;
            }
            set
            {
                model.ElementListNames = value;
                NotifyPropertyChanged("VM_ElementListNames");
            }
        }
        // chart 8 ---------------------------------------
        public SeriesCollection VM_SeriesCollectionChart8
        {
            get
            {
                return model.SeriesCollectionChart8;
            }
            set
            {
                model.SeriesCollectionChart8 = (value);
                NotifyPropertyChanged("VM_SeriesCollectionChart8");
            }
        }
        public ScatterSeries VM_MyScatterSeriesChart8
        {
            get
            {
                return model.MyScatterSeriesChart8;
            }
            set
            {
                model.MyScatterSeriesChart8 = (value);
                NotifyPropertyChanged("VM_MyScatterSeriesChart8");
            }
        }
        // for chart 6 and 7 -----------------------------------
        public SeriesCollection VM_SeriesCollectionChart6 //what points we see on the chart
        { 
            get 
            {
                if (model.SeriesCollectionChart6 != null)
                    return model.SeriesCollectionChart6;
                return null;
            }
            set 
            {
                model.SeriesCollectionChart6 = value;
                NotifyPropertyChanged("VM_SeriesCollectionChart6");
            }
        }
        public List<string> VM_LabelsChart67 { //line X values like 01234..., here it's time
            get 
            {
                return model.LabelsChart67;
            }
            set
            {
                model.LabelsChart67 = value;
                NotifyPropertyChanged("VM_LabelsChart67");
            }
        }
        public LineSeries VM_MylineseriesChart6
        {
            get { return this.model.MylineseriesChart6; }
            set
            {
                this.model.MylineseriesChart6 = value;
                NotifyPropertyChanged("VM_MylineseriesChart6");
            }
        }
        // set what range of values the chart can show (like: from 0 to 10 or -100 to 100....)
        public float VM_MaxValueChart6 { 
            get {
                if (model.MaxValueChart6 == 0)
                    return 2;
                return model.MaxValueChart6; 
            }
            set {
                this.model.MaxValueChart6 = value;
                NotifyPropertyChanged("VM_MaxValueChart6");
            }
        }
        public float VM_MinValueChart6 { 
            get { return this.model.MinValueChart6; } 
            set {
                this.model.MinValueChart6 = value;
                NotifyPropertyChanged("MinValueChart6");
            }
        }
        public float VM_MaxRangeChart6 { 
            get { return this.model.MinRangeChart6; }
            set {
                this.model.MinRangeChart6 = value;
                NotifyPropertyChanged("MinRangeChart6");
            }
        }
        public float VM_MinRangeChart6 { 
            get { return this.model.MinRangeChart6; } 
            set {
                this.model.MinRangeChart6 = value;
                NotifyPropertyChanged("MinRangeChart6");
            }
        }

        internal InterfaceChartsViewModel InterfaceChartsViewModel
        {
            get => default;
            set
            {
            }
        }
    }
}
