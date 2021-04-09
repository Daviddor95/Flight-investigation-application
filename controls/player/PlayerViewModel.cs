using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Model;

namespace ViewModel
{
    public class PlayerViewModel : IPlayerViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private IFIAModel model;
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
                return (int)diff.TotalSeconds;
            }
            set
            {
                this.model.Time = DateTime.MinValue.AddSeconds(value);
                this.model.jumpToTime();
            }
        }
        public string VM_DigitalTime
        {
            get
            {
                return this.model.Time.ToString("HH:mm:ss");
            }
        }
        public float VM_LengthSec
        {
            get
            {
                return model.LengthSec;
            }
        }
        public PlayerViewModel(IFIAModel model)
        {
            this.model = model;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs eventArgs)
            {
                NotifyPropertyChanged("VM_" + eventArgs.PropertyName);
            };
        }
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        public void loadCSV()
        {
            this.model.loadCSVFile();
        }
        public void play()
        {
            this.model.play();
        }
        public void pause()
        {
            this.model.pause();
        }
        public void stop()
        {
            this.model.stop();
        }
        public void jumpToStart()
        {
            this.model.jumpToStart();
        }
        public void jumpToEnd()
        {
            this.model.jumpToEnd();
        }
        public void fastForward()
        {
            this.model.fastForward();
        }
        public void fastBackwards()
        {
            this.model.fastBackwards();
        }
        public void jumpToTime()
        {
            this.model.jumpToTime();
        }
    }
}
