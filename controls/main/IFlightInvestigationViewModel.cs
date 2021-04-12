using System.ComponentModel;

namespace ViewModel
{
    /*
        The IFlightInvestigationViewModel interface
        The interface of the FlightInvestigationViewModel class
     */
    interface IFlightInvestigationViewModel : INotifyPropertyChanged
    {
        // Closes the window and disconnects from the server
        void closeWindow();
    }
}
