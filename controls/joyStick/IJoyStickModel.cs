using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//namespace Flight_investigation_application.controls.joyStick
namespace Player
{
    partial interface IJoyStickModel : INotifyPropertyChanged
    {
        float aileronJoyStickX
        {
            set;
            get;
        }

        float elevatorJoyStickY
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

        
        void startJoyStick();
        void startDataTable();
    }
}
