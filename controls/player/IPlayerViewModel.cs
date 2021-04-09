using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace ViewModel
{
    interface IPlayerViewModel : INotifyPropertyChanged
    {
        float VM_PlaybackSpeed
        {
            set;
            get;
        }
        float VM_Time
        {
            set;
            get;
        }
        float VM_LengthSec
        {
            get;
        }
        string VM_DigitalTime
        {
            get;
        }
    }
}
