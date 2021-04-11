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
        // for comboBox
        public String VM_ChosenElementName
        {
            get { return this.model.ChosenElementName; }
            set { 
                this.model.ChosenElementName = value;
                NotifyPropertyChanged("VM_ChosenElementName");
            }
        }
        // for chart 6 - the chosen element
        public SeriesCollection VM_SeriesCollectionChart6 //what points we see on the chart
        { 
            get 
            {
                //return model.SeriesCollectionChart6;

                if (model.SeriesCollectionChart6 != null)
                    return model.SeriesCollectionChart6;
                return null;

                //if it's null we need to create a simple one, that will change later.
                LineSeries Tmylineseries = new LineSeries();
                // Set the title of the polyline, the name of the chosen element
                Tmylineseries.Title = ":)";
                // line chart line form
                Tmylineseries.LineSmoothness = 0;
                //Distance style of line chart
                Tmylineseries.PointGeometry = null;
                // Add the data of the line chart
                float[] temp = { 0, 5, 0, 0, 5, 0, 7, 0 };
                Tmylineseries.Values = new ChartValues<float>(temp);
                model.SeriesCollectionChart6 = new SeriesCollection { };
                model.SeriesCollectionChart6.Add(Tmylineseries);
                return model.SeriesCollectionChart6;
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
                if (model.LabelsChart67 != null)
                    return model.LabelsChart67;
                model.LabelsChart67 = new List<string> { };
                return model.LabelsChart67;
            }
            set
            {
                model.LabelsChart67 = value;
                NotifyPropertyChanged("VM_LabelsChart67");
            }
        }
        public LineSeries VM_Mylineseries
        {
            get { return this.model.Mylineseries; }
            set
            {
                this.model.Mylineseries = value;
                NotifyPropertyChanged("VM_Mylineseries");
            }
        }
        // set what range of values the chart can show (like: from 0 to 10 or -100 to 100....)
        public Double VM_MaxValueChart6 { 
            get { return this.model.MaxValueChart6; }
            set {
                this.model.MaxValueChart6 = value;
                NotifyPropertyChanged("VM_MaxValueChart6");
            }
        }
        public Double VM_MinValueChart6 { 
            get { return this.model.MinValueChart6; } 
            set {
                this.model.MinValueChart6 = value;
                NotifyPropertyChanged("MinValueChart6");
            }
        }
        public Double VM_MaxRangeChart6 { 
            get { return this.model.MinRangeChart6; }
            set {
                this.model.MinRangeChart6 = value;
                NotifyPropertyChanged("MinRangeChart6");
            }
        }
        public Double VM_MinRangeChart6 { 
            get { return this.model.MinRangeChart6; } 
            set {
                this.model.MinRangeChart6 = value;
                NotifyPropertyChanged("MinRangeChart6");
            }
        }
        

    }
}
