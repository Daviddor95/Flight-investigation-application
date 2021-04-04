using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Player
{
    interface IPlayerViewModel : INotifyPropertyChanged
    {
        float VM_PlaybackSpeed
        {
            set;
            get;
        }
        int VM_Time
        {
            set;
            get;
        }
        int VM_LengthSec
        {
            get;
        }
        DateTime VM_DigitalTime
        {
            get;
        }
    }
}
