using Model;
using System;
using System.ComponentModel;

namespace ViewModel
{
    public class JoystickViewModel : IJoystickViewModel
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private IFIAModel model;
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
