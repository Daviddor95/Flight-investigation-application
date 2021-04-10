using System.Collections.Generic;
using System.ComponentModel;
using Util;

namespace ViewModel
{
    interface IJoystickViewModel: INotifyPropertyChanged
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
