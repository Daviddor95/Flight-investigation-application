using System.Collections.Generic;
using System.ComponentModel;
using Util;

namespace ViewModel
{
    /// <summary>IJoystickViewModel is an interface for the viewmodel that will be used for the joystick, its scroller and user story 5 
    /// (the data about yaw, roll, pitch, direction (of flight), airspeed and altimeter in the flight)
    /// the functions will be explained in the JoystickViewModel itself</summary>
    interface IJoystickViewModel : INotifyPropertyChanged
    {
        float VM_elevatorJoystickY
        {
            set;
            get;
        }
        float VM_aileronJoystickX
        {
            set;
            get;
        }
        float VM_rudderScrollerX
        {
            set;
            get;
        }

        float VM_throttleScrollerY
        {
            set;
            get;
        }
        float VM_airspeedM
        {
            set;
            get;
        }
        float VM_altimeterM
        {
            set;
            get;

        }

        float VM_directionM
        {
            set;
            get;
        }
        float VM_yawM
        {
            set;
            get;
        }
        float VM_rollM
        {
            set;
            get;
        }
        float VM_pitchM
        {
            set;
            get;
        }
        List<DataType> VM_DataTableM
        {
            set;
            get;
        }
        /*void radiusVM();
        
        void startJoystickVM();
        
        void startDataTableVM();
        */


    }
}
