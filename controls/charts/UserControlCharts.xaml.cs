using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using LiveCharts;
using LiveCharts.Wpf;
using ViewModel;
using Model;

namespace View
{
    /// <summary>
    /// Interaction logic for UserControlCharts.xaml
    /// it's mosly empty here
    /// </summary>
    public partial class UserControlCharts : UserControl
    {
        ChartsViewModel chartsVM;
        public UserControlCharts()
        {
            InitializeComponent();
            chartsVM = new ChartsViewModel(FIAModel.Model);
            DataContext = chartsVM;
        }

        private void elementList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //empty
        }
    }
}
