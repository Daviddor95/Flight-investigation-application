using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace ViewModel
{
    /// <summary>JoystickViewModel a viewModel class, responsible, in our project, 
    /// for passing the value to the view of the joystick, it's scrollers and the a few more lines of text.
    /// </summary>
    public class JoystickViewModel : IJoystickViewModel
    {
        //if there is a change, through data binding for example, it will help us to be notified about it
        public event PropertyChangedEventHandler PropertyChanged;
        // the model we use in the project
        private IFIAModel model;

        //the property of elevator(canvas.Top of the inner elipse of joystick)
        public float VM_elevatorJoystickY
        {
            get
            {
                return model.elevatorJoystickY;
            }
            set
            {
                model.elevatorJoystickY = value;
                NotifyPropertyChanged("VM_elevatorJoystickY");
            }
        }

        //the property of aileron(canvas.left of the inner elipse of joystick)
        public float VM_aileronJoystickX
        {
            get
            {
                return model.aileronJoystickX;
            }
            set
            {
                model.aileronJoystickX = value;
                NotifyPropertyChanged("VM_aileronJoystickX");
            }
        }

        //the property of rudder(the scroller's, thats near and under the joystick, value)
        public float VM_rudderScrollerX
        {
            get
            {
                return model.rudderScrollerX;
            }
            set
            {
                model.rudderScrollerX = value;
                NotifyPropertyChanged("VM_rudderScrollerX");
            }
        }

        //the property of throttle(the left scroller's value, near the joystick)
        public float VM_throttleScrollerY
        {
            get
            {
                return model.throttleScrollerY;
            }
            set
            {
                model.throttleScrollerY = value;
                NotifyPropertyChanged("VM_throttleScrollerY");
            }

        }

        //the property of pitch
        public float VM_pitchM
        {
            get
            {
                return model.pitchM;
            }
            set
            {
                model.pitchM = value;
                NotifyPropertyChanged("VM_pitchM");
            }
        }

        //the property of roll
        public float VM_rollM
        {
            get
            {
                return model.rollM;
            }
            set
            {
                model.rollM = value;
                NotifyPropertyChanged("VM_rollM");
            }
        }

        //the property of yaw
        public float VM_yawM
        {
            get
            {
                return model.yawM;
            }
            set
            {
                model.yawM = value;
                NotifyPropertyChanged("VM_yawM");
            }
        }

        //the property of direction (the direction of the flight)
        public float VM_directionM
        {
            get
            {
                return model.directionM;
            }
            set
            {
                model.directionM = value;
                NotifyPropertyChanged("VM_directionM");
            }

        }

        //the property of altimeter
        public float VM_altimeterM
        {
            get
            {
                return model.altimeterM;
            }
            set
            {
                model.altimeterM = value;
                NotifyPropertyChanged("VM_altimeterM");
            }
        }

        //the property of airspeed
        public float VM_airspeedM
        {
            get
            {
                return model.airspeedM;
            }
            set
            {
                model.airspeedM = value;
                NotifyPropertyChanged("VM_airspeedM");
            }
        }

        public List<DataType> VM_DataTableM
        {
            get
            {
                return model.DataTableM;
            }
            set
            {
                model.DataTableM = value;
                NotifyPropertyChanged("VM_DataTableM");
            }
        }

        //initializing the model to be our model that this viewmodel is actually rellated to.
        //every property that changes in the model , notifies the rellevant property in the view model,
        //(so it wil eventually change the value, through DATA Binding, in the view part (XAML))
        public JoystickViewModel(IFIAModel model)
        {
            this.model = model;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs eventArgs)
            {
                NotifyPropertyChanged("VM_" + eventArgs.PropertyName);
            };
        }

        //once the property changes, it notifies this property has changed, so values will be updated as necessary
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

       /* public void startJoystickVM()
        {
            this.model.startJoystick();
        }
        
       
        public void startDataTableVM()
        {
            this.model.startDataTable();
        }*/
    }

}
