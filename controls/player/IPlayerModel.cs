using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Model
{
    /*
        The IFIAModel interface
        Part of the interface of the FIAModel class
     */
    public partial interface IFIAModel : INotifyPropertyChanged
    {
        // Properties for the PlaybackSpeed, Time and LengthSec (flight's length in seconds)
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
        // Play the video
        void play();
        // Pause the video
        void pause();
        // Stop the video
        void stop();
        // Jump 10 seconds forward
        void fastForward();
        // Jump 10 seconds backwards
        void fastBackwards();
        // Jump to the start of the video
        void jumpToStart();
        // Jump to the end of the video
        void jumpToEnd();
        // Jump to the new time set
        void jumpToTime();
        // Load the CSV file to the project
        void loadCSVFile();
        // Load the XML file to the project
        void loadXML();
    }
}
