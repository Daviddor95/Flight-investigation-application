using Model;
using System;
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
using ViewModel;

namespace View
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    //

    public partial class joystickUserControl : UserControl
    {
        //private List<DataType> importantData;
        private JoystickViewModel joystickVM;
        public joystickUserControl()
        {
            InitializeComponent();
            joystickVM = new JoystickViewModel(FIAModel.Model);
            DataContext = joystickVM;

        }

        private void mcSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void mcSlider_Copy_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void dgSimple_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void mcSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
        }

        private void mcSlider_Copy_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
        }

        private void dgSimple_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

       /* public void startJoystickVM()
        {
            this.joystickVM.startJoystickVM();
        }

        public void radiusVM()
        {
            this.joystickVM.radiusVM();
        }
        public void startDataTableVM()
        {
            this.joystickVM.startDataTableVM();
        }*/

    }
   


   /* public class DataType
    {
        public string Data { get; set; }

        public int Value { get; set; }
    }*/
}

