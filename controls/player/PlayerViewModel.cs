using System;
using System.ComponentModel;
using Model;

namespace ViewModel
{
    /*
        The PlayerViewModel class
        The class responsible to pass notifications, data and function calls from the view to the model and backwards
     */
    public class PlayerViewModel : IPlayerViewModel
    {
        // Declaring an PropertyChangedEventHandler event field and a field for the model
        public event PropertyChangedEventHandler PropertyChanged;
        private IFIAModel model;
        // Properties for playback speed (VM_PlaybackSpeed), time in seconds (VM_Time), time in digital format
        // (VM_DigitalTime) and length of the flight in seconds (VM_LengthSec)
        public float VM_PlaybackSpeed
        {
            get
            {
                return model.PlaybackSpeed;
            }
            set
            {
                model.PlaybackSpeed = value;
            }
        }
        public float VM_Time
        {
            get
            {
                TimeSpan diff = model.Time - DateTime.MinValue;
                return (float) diff.TotalSeconds;
            }
            set
            {
                this.model.Time = DateTime.MinValue.AddSeconds(value);
                this.model.jumpToTime();
                NotifyPropertyChanged("VM_Time");
                NotifyPropertyChanged("VM_DigitalTime");
            }
        }
        public string VM_DigitalTime
        {
            get
            {
                return DateTime.MinValue.AddSeconds(this.VM_Time).ToString("HH:mm:ss");
            }
        }
        public float VM_LengthSec
        {
            get
            {
                return model.LengthSec;
            }
        }

        internal IPlayerViewModel IPlayerViewModel
        {
            get => default;
            set
            {
            }
        }

        // Constructor of the PlayerViewModel class
        public PlayerViewModel(IFIAModel model)
        {
            this.model = model;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs eventArgs)
            {
                NotifyPropertyChanged("VM_" + eventArgs.PropertyName);
            };
        }
        // Notifies that the given property has changed
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        // Load the CSV file to the project
        public void loadCSV()
        {
            this.model.loadCSVFile();
        }
        // Play the video
        public void play()
        {
            this.model.play();
        }
        // Pause the video
        public void pause()
        {
            this.model.pause();
        }
        // Stop the video
        public void stop()
        {
            this.model.stop();
        }
        // Jump to the start of the video
        public void jumpToStart()
        {
            this.model.jumpToStart();
        }
        // Jump to the end of the video
        public void jumpToEnd()
        {
            this.model.jumpToEnd();
        }
        // Jump 10 seconds forward
        public void fastForward()
        {
            this.model.fastForward();
        }
        // Jump 10 seconds backwards
        public void fastBackwards()
        {
            this.model.fastBackwards();
        }
        // Jump to the new time set
        public void jumpToTime()
        {
            this.model.jumpToTime();
        }
        // Load the XML file to the project
        public void loadXML()
        {
            this.model.loadXML();
        }
    }
}
