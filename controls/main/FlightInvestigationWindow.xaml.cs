using System;
using System.Windows;
using ViewModel;
using Model;

namespace View
{
    /*
        The FlightInvestigationWindow class
        The class responsible to the interaction between the user and the main window
     */
    public partial class FlightInvestigationWindow : Window
    {
        // Declaring a field for the view model
        IFlightInvestigationViewModel mainVM;
        // Constructor of the FlightInvestigationWindow class
        public FlightInvestigationWindow()
        {
            InitializeComponent();
            this.mainVM = new FlightInvestigationViewModel(FIAModel.Model);
            DataContext = mainVM;
        }
        // Close window properly (disconnects the server)
        private void Window_Closed(object sender, EventArgs e)
        {
            this.mainVM.closeWindow();
        }
    }
}
