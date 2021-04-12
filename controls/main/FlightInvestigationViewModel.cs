using System;
using System.ComponentModel;
using Model;

namespace ViewModel
{
    /*
        The FlightInvestigationViewModel class
        The class responsible to pass notifications, data and function calls from the view to the model and backwards
     */
    public class FlightInvestigationViewModel : IFlightInvestigationViewModel
    {
        // Declaring an PropertyChangedEventHandler event field and a field for the model
        public event PropertyChangedEventHandler PropertyChanged;
        private IFIAModel model;
        // Constructor of the FlightInvestigationViewModel class
        public FlightInvestigationViewModel(IFIAModel model)
        {
            this.model = model;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs eventArgs)
            {
                NotifyPropertyChanged("VM_" + eventArgs.PropertyName);
            };
        }

        internal IFlightInvestigationViewModel IFlightInvestigationViewModel
        {
            get => default;
            set
            {
            }
        }

        // Notifies that the given property has changed
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        // Closes the window and disconnects from the server
        public void closeWindow()
        {
            this.model.closeWindow();
        }
    }
}
