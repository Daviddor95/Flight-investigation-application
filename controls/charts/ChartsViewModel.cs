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
    class ChartsViewModel
    {
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

        public event PropertyChangedEventHandler PropertyChanged;
        private IFIAModel model;

        public String ChosenElementName {
            get { return model.ChosenElementName; }
            set { model.ChosenElementName = value; }
        }

        public SeriesCollection SeriesCollectionChart6 { get { return model.SeriesCollectionChart6; } }
      //  public SeriesCollection SeriesCollectionChart7 { get { return model.SeriesCollectionChart7; } }
        public List<string> LabelsChart67 { get { return model.LabelsChart67; } }
        public Double MaxValueChart6 { get { return model.MaxValueChart6; } }
        public Double MinValueChart6 { get { return model.MinValueChart6; } }
        public Double MaxRangeChart6 { get { return model.MaxRangeChart6; } }
        public Double MinRangeChart6 { get { return model.MinRangeChart6; } }
        //public Double MaxValueChart7 { get { return model.MaxValueChart7; } }
        //public Double MinValueChart7 { get { return model.MinValueChart7; } }
        //public Double MaxRangeChart7 { get { return model.MaxRangeChart7; } }
        //public Double MinRangeChart7 { get { return model.MinRangeChart7; } }
        public LineSeries mylineseries { get { return model.Mylineseries; } } //first Y values in a chart
    //    public string ChosenElement { get { return model.ChosenElement; } }
     //   public string PeasonElement { get { return model.PeasonElement; } }
    }
}
