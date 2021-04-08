using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using ViewModel;
using Model;
using Client;
using Flight_investigation_application;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class FlightInvestigationWindow : Window
    {
        FlightInvestigationViewModel mainVM;
        public FlightInvestigationWindow()
        {
            InitializeComponent();
            this.mainVM = new FlightInvestigationViewModel(FIAModel.Model);
            DataContext = mainVM;
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            this.mainVM.closeWindow();
        }
    }
}
