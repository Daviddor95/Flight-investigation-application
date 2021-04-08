using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Model;
using Client;

namespace ViewModel
{
    public class FlightInvestigationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private IFIAModel model;
        public FlightInvestigationViewModel(IFIAModel model)
        {
            this.model = model;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs eventArgs)
            {
                NotifyPropertyChanged("VM_" + eventArgs.PropertyName);
            };
        }
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        public void closeWindow()
        {
            this.model.closeWindow();
        }
    }
}
