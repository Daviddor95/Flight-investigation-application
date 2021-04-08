using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//namespace Flight_investigation_application.controls.Joystick
namespace Model
{
    public partial interface IFIAModel : INotifyPropertyChanged
    {
        float aileronJoystickX
        {
            set;
            get;
        }

        float elevatorJoystickY
        {
            set;
            get;
        }
        
        float throttleScrollerY
        {
            set;
            get;
        }

        float rudderScrollerX
        {
            set;
            get;
        }

        
        void startJoystick();
        void startDataTable();
    }
}
