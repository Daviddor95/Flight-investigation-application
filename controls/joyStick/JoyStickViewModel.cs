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
    class JoystickViewModel : IJoystickViewModel
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private IFIAModel model;
        public float VM_Elevator
        {
            get
            {
                return model.elevatorJoystickY;
            }
            set
            {
                model.elevatorJoystickY = value;
            }
        }
        public float VM_Aileron
        {
            get
            {
                return model.aileronJoystickX;
            }
            set
            {
                model.aileronJoystickX = value;
            }
        }
        public float VM_Rudder
        {
            get
            {
                return model.rudderScrollerX;
            }
            set
            {
                model.rudderScrollerX = value;
            }
        }
        public float VM_Throttle
        {
            get
            {
                return model.throttleScrollerY;
            }
            set
            {
                model.throttleScrollerY = value;
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

        public List<DataType> VM_DataTable
        {
            get
            {
                return model.DataTableM;
            }
            set
            {
                model.DataTableM = value;
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
