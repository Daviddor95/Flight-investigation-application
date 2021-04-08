using System.ComponentModel;

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
        /*void radiusVM();
        
        void startJoystickVM();
        
        void startDataTableVM();
        */


    }
}
