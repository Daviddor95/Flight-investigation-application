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

        public float VM_Pitch
        {
            get
            {
                return model.pitchM;
            }
            set
            {
                model.pitchM = value;
            }
        }
        public float VM_Roll
        {
            get
            {
                return model.rollM;
            }
            set
            {
                model.rollM = value;
            }
        }
        public float VM_Yaw
        {
            get
            {
                return model.yawM;
            }
            set
            {
                model.yawM = value;
            }
        }
        public float VM_Direction
        {
            get
            {
                return model.directionM;
            }
            set
            {
                model.directionM = value;
            }

        }

        public float VM_Altimeter
        {
            get
            {
                return model.altimeterM;
            }
            set
            {
                model.altimeterM = value;
            }
        }
        public float VM_Airspeed
        {
            get
            {
                return model.airspeedM;
            }
            set
            {
                model.airspeedM = value;
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
