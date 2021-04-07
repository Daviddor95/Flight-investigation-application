using System.ComponentModel;

namespace Flight_investigation_application.controls.joyStick
{
    interface IJoyStickViewModel: INotifyPropertyChanged
    {
        float VM_Elevator
        {
            get;
        }
        float VM_Aileron
        {
            get;
        }
        float VM_Rudder
        {
            get;
        }

        float VM_Throttle
        {
            get;
        }
        /*void radiusVM();
        
        void startJoyStickVM();
        
        void startDataTableVM();
        */


    }
}
