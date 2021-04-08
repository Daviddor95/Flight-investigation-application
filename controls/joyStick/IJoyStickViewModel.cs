using System.Collections.Generic;
using System.ComponentModel;
using Util;

namespace ViewModel
{
    interface IJoystickViewModel: INotifyPropertyChanged
    {
        float VM_Elevator
        {
            set;
            get;
        }
        float VM_Aileron
        {
            set;
            get;
        }
        float VM_Rudder
        {
            set;
            get;
        }

        float VM_Throttle
        {
            set;
            get;
        }
        float VM_Airspeed
        {
            set;
            get;
        }
        float VM_Altimeter
        {
            set;
            get;

        }

        float VM_Direction
        {
            set;
            get;
        }
        float VM_Yaw
        {
            set;
            get;
        }
        float VM_Roll
        {
            set;
            get;
        }
        float VM_Pitch
        {
            set;
            get;
        }
        List<DataType> VM_DataTable
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
