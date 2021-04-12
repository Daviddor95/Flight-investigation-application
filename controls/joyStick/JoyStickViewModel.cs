using Model;
using System;
using System.ComponentModel;

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

        //DON'T TOUCH, IT'S DAVID
        public JoystickViewModel(IFIAModel model)
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
