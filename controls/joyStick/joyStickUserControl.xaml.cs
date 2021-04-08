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
        JoyStickViewModel joystickVM;
        public joystickUserControl()
        {
            InitializeComponent();
            joystickVM = new JoyStickViewModel(FIAModel.Model);
            DataContext = joystickVM;

            /*  this.importantData = new List<DataType>();
              this.importantData.Add(new DataType() { Data = "altimeter:i.a.f", Value = 0});//altimeter_indicated-altitude-ft
              //importantData.Add(new DataType() { Data = "altimeter:p.a.f", Value = 10001 }); // altimeter_pressure-alt-ft
              this.importantData.Add(new DataType() { Data = "airspeed", Value = 0 }); // airspeed-kt
              //importantData.Add(new DataType() { Data = "Indicated airspeed", Value = 20001 }); //airspeed-indicator_indicated-speed-kt
              this.importantData.Add(new DataType() { Data = "direction", Value = 0 });//heading-deg
              this.importantData.Add(new DataType() { Data = "yaw", Value = 0 }); //(side-slip-deg)
              this.importantData.Add(new DataType() { Data = "roll", Value = 0 });
              this.importantData.Add(new DataType() { Data = "pitch", Value = 0 });*/
        }


        private void mcSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //this.joystickVM.VM_Throttle = (int)mcSlider.Value;
        }

        private void mcSlider_Copy_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //this.joystickVM.VM_VM_Rudder = (int)mcSlider_Copy.Value;
        }

        private void dgSimple_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

       /* public void startJoyStickVM()
        {
            this.joystickVM.startJoyStickVM();
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

