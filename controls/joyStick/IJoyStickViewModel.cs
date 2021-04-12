using System.ComponentModel;

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

        /*void radiusVM();
        
        void startJoystickVM();
        
        void startDataTableVM();
        */


    }
}
