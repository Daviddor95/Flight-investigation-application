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

        public String VM_ChosenElementName
        {
            get { return this.model.ChosenElementName; }
            set { this.model.ChosenElementName = value; }
        }

        public SeriesCollection VM_SeriesCollectionChart6 { get { return this.model.SeriesCollectionChart6; } }
        public List<string> VM_LabelsChart67 { get { return this.model.LabelsChart67; } }
        public Double VM_MaxValueChart6 { get { return this.model.MaxValueChart6; } }
        public Double VM_MinValueChart6 { get { return this.model.MinValueChart6; } }
        public Double VM_MaxRangeChart6 { get { return this.model.MaxRangeChart6; } }
        public Double VM_MinRangeChart6 { get { return this.model.MinRangeChart6; } }
        public LineSeries VM_Mylineseries { get { return this.model.Mylineseries; } } //first Y values in a chart
    //    public string ChosenElement { get { return model.ChosenElement; } }
     //   public string PeasonElement { get { return model.PeasonElement; } }
    }
}
