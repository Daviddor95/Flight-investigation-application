using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.Win32;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Client;
using System.Reflection;
using Util;

namespace Model
{
    public partial class FIAModel : IFIAModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ITelnetClient client;
        private volatile bool playing;
        private float playbackSpeed;
        private DateTime time;
        private string[] CSVLines;
        private string[] XMLLines;
        private int sampleRate;
        private float lengthSec;
        private int currentLine;
        private static IFIAModel model;
        private List<DataType> importantData;
        public float PlaybackSpeed
        {
            get
            {
                return this.playbackSpeed;
            }
            set
            {
                this.playbackSpeed = value;
                NotifyPropertyChanged("PlaybackSpeed");
            }
        }
        public DateTime Time
        {
            get
            {
                return this.time; ;
            }
            set
            {
                DateTime endTime = new DateTime().AddSeconds(this.LengthSec);
                if (value >= DateTime.MinValue && value <= endTime)
                {
                    this.time = value;
                }
                else if (value < DateTime.MinValue)
                {
                    this.time = DateTime.MinValue;
                }
                else
                {
                    this.time = endTime;
                }
                NotifyPropertyChanged("Time");
            }
        }
        public float LengthSec
        {
            get
            {
                return this.lengthSec;
            }
            set
            {
                this.lengthSec = value;
                NotifyPropertyChanged("LengthSec");
            }
        }
        public static IFIAModel Model
        {
            get
            {
                if (model == null)
                {
                    model = new FIAModel(new TelnetClient());
                }
                return model;
            }
        }
        private FIAModel(ITelnetClient client)
        {
            //this.loadXML();
            this.initialize(client);
            this.connect();
        }
        private void connect()
        {
            this.connect("127.0.0.1", 5400);
        }
        private void connect(string ip, int port)
        {
            client.connect(ip, port);
        }
        private void disconnect()
        {
            this.playing = false;
            this.client.disconnect();
        }
        private void playVideo()
        {
            this.client.write(this.CSVLines[this.currentLine]);
            if (this.PlaybackSpeed > 0 && this.currentLine < this.CSVLines.Length)
            {
                this.currentLine++;
                if (this.currentLine % this.sampleRate == 0)
                {
                    this.Time = this.Time.AddSeconds(1);
                }
            }
            else if (this.PlaybackSpeed < 0 && this.currentLine > 0)
            {
                this.currentLine--;
                if (this.currentLine % this.sampleRate == 0)
                {
                    this.Time = this.Time.Subtract(DateTime.MinValue.AddSeconds(1) - DateTime.MinValue);
                }
            }
        }
        public void play()
        {
            this.playing = true;
            this.start();
        }
        public void pause()
        {
            this.playing = false;
        }
        public void stop()
        {
            this.jumpToStart();
            this.pause();
        }
        public void jumpToStart()
        {
            this.currentLine = 0;
            this.Time = DateTime.MinValue;
            this.playVideo();
        }
        public void jumpToEnd()
        {
            this.currentLine = this.CSVLines.Length - 5;
            this.Time = DateTime.MinValue.AddSeconds(this.lengthSec);
            this.playVideo();
        }
        public void fastForward()
        {
            if (this.Time < DateTime.MinValue.AddSeconds(this.lengthSec - 10))
            {
                this.Time = this.Time.AddSeconds(10);
                this.jumpToTime();
            }
            else
            {
                this.jumpToEnd();
            }
        }
        public void fastBackwards()
        {
            if (this.Time > DateTime.MinValue.AddSeconds(10))
            {
                this.Time = this.Time.Subtract(new TimeSpan(0, 0, 10));
                this.jumpToTime();
            }
            else
            {
                this.jumpToStart();
            }
        }
        public void jumpToTime()
        {
            TimeSpan diff = this.Time - DateTime.MinValue;
            this.currentLine =(int) diff.TotalSeconds * this.sampleRate;
            this.playVideo();
        }
        public void loadCSVFile()
        {
            this.initialize(this.client);
            OpenFileDialog FileDialog = new OpenFileDialog();
            if ((bool)FileDialog.ShowDialog())
            {
                string csv;
                using (StreamReader input = new StreamReader(FileDialog.FileName))
                {
                    csv = input.ReadToEnd();
                }
                this.CSVLines = csv.Split('\n').Where(x => !string.IsNullOrEmpty(x)).ToArray();
                this.LengthSec = this.CSVLines.Length / this.sampleRate;
            }
        }
/*        private void loadXML()
        {
            string xml;
            // Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"settings\playback_small.xml"
            // System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), System.IO.Path.Combine(@"\settings\", "playback_speed.xml"))
            using (StreamReader input = new StreamReader(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), System.IO.Path.Combine(@"settings\", "playback_speed.xml"))))
            {
                xml = input.ReadToEnd();
            }
            this.XMLLines = xml.Split('\n');
            foreach (string s in this.XMLLines)
            {
                if (s.Contains("Recording:"))
                {
                    this.sampleRate = Int32.Parse(s.Where(Char.IsDigit).ToString());
                    break;
                }
            }
        }*/
        private void initialize(ITelnetClient client)
        {
            this.client = client;
            this.playing = false;
            this.PlaybackSpeed = 1;
            this.Time = DateTime.MinValue;
            this.sampleRate = 10;
            this.currentLine = 0;

            this.importantData = new List<DataType>();
            this.importantData.Add(new DataType() { Data = "altimeter:i.a.f", Value = 0 });//altimeter_indicated-altitude-ft
            //importantData.Add(new DataType() { Data = "altimeter:p.a.f", Value = 10001 }); // altimeter_pressure-alt-ft
            this.importantData.Add(new DataType() { Data = "airspeed", Value = 0 }); // airspeed-kt
            //importantData.Add(new DataType() { Data = "Indicated airspeed", Value = 20001 }); //airspeed-indicator_indicated-speed-kt
            this.importantData.Add(new DataType() { Data = "direction", Value = 0 });//heading-deg
            this.importantData.Add(new DataType() { Data = "yaw", Value = 0 }); //(side-slip-deg)
            this.importantData.Add(new DataType() { Data = "roll", Value = 0 });
            this.importantData.Add(new DataType() { Data = "pitch", Value = 0 });
        }
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
