using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Model
{
    public partial interface IFIAModel : INotifyPropertyChanged
    {
        float PlaybackSpeed
        {
            set;
            get;
        }
        DateTime Time
        {
            set;
            get;
        }
        float LengthSec
        {
            get;
            set;
        }
        void start();
        void play();
        void pause();
        void stop();
        void fastForward();
        void fastBackwards();
        void jumpToStart();
        void jumpToEnd();
        void jumpToTime();
        void loadCSVFile();
    }
}
