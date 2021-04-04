﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Player
{
    class PlayerViewModel : IPlayerViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private IPlayerModel model;
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
        public int VM_Time
        {
            get
            {
                TimeSpan diff = model.Time - DateTime.MinValue;
                return (int)diff.TotalSeconds;
            }
            set
            {
                model.Time = DateTime.MinValue.AddSeconds(value);
            }
        }
        public DateTime VM_DigitalTime
        {
            get
            {
                return model.Time;
            }
        }
        public int VM_LengthSec
        {
            get
            {
                return model.LengthSec;
            }
        }
        public PlayerViewModel(IPlayerModel model)
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
        public void jumpToTime(int time)
        {
            this.model.jumpToTime(time);
        }
        public void closeWindow()
        {
            this.model.closeWindow();
        }
    }
}
