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
    // <summary>
    // View part of the mvvm design pattern, that is relevant for our project,
    // specificaly for the code behind view of the joystick,it's scrollers and
    // the other text with data displayed (roll, pitch...)
    // </summary>
    //
    public partial class joystickUserControl : UserControl
    {
        //the viewModel rellevant for this view
        private JoystickViewModel joystickVM;
        public joystickUserControl()
        {
            InitializeComponent();
            //creating a new view model that will match the obly model we have for the project)
            joystickVM = new JoystickViewModel(FIAModel.Model);

            //updating Data context to be the viewModel created,
            // so when proprty is updated there , 
            //it will be updated through ddata binding in the view (xaml file)
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
    }
}

