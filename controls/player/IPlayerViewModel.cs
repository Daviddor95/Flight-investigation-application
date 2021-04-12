using System.ComponentModel;

namespace ViewModel
{
    /*
        The IPlayerViewModel interface
        The interface of the PlayerViewModel class
     */
    interface IPlayerViewModel : INotifyPropertyChanged
    {
        // Properties for playback speed (VM_PlaybackSpeed), time in seconds (VM_Time), time in digital format
        // (VM_DigitalTime) and length of the flight in seconds (VM_LengthSec)
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
        void loadCSV();
        // Load the XML file to the project
        void loadXML();
    }
}
