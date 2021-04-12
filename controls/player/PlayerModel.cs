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
using System.Xml;

namespace Model
{
    public partial class FIAModel : IFIAModel
    {
        // Fields for the client (for client-server communication), playbackSpeed, time, sampleRate (number of rows in
        // the file which represent a second), lengthSec (length of the flight in seconds), currentLine (the current
        // line in the file), playing (flag that indicates that the video should play), CSVLines (holds the CSV file
        // in memory), model (holds the one and only instance of the class)
        private ITelnetClient client;
        private volatile bool playing;
        private float playbackSpeed;
        private DateTime time;
        private string[] CSVLines;
        private int sampleRate;
        private float lengthSec;
        private int currentLine;
        private static IFIAModel model;
        private List<DataType> importantData;
        // Properties for the PlaybackSpeed, Time, LengthSec and model
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
            if (this.CSVLines != null && !this.playing)
            {
                this.playing = true;
                this.start();
            }
        }
        public void pause()
        {
            if (this.CSVLines != null)
            {
                this.playing = false;
            }
        }
        public void stop()
        {
            if (this.CSVLines != null)
            {
                this.jumpToStart();
                this.pause();
            }
        }
        public void jumpToStart()
        {
            if (this.CSVLines != null)
            {
                this.currentLine = 0;
                this.Time = DateTime.MinValue;
                this.playVideo();
            }
        }
        public void jumpToEnd()
        {
            if (this.CSVLines != null)
            {
                this.currentLine = this.CSVLines.Length - 5;
                this.Time = DateTime.MinValue.AddSeconds(this.lengthSec);
                this.playVideo();
            }
        }
        public void fastForward()
        {
            if (this.CSVLines != null)
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
        }
        public void fastBackwards()
        {
            if (this.CSVLines != null)
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
        // Load the XML file to the project
        public void loadXML()
        {
            OpenFileDialog FileDialog = new OpenFileDialog();
            if ((bool)FileDialog.ShowDialog())
            {
                string xml;
                using (StreamReader input = new StreamReader(FileDialog.FileName))
                {
                    xml = input.ReadToEnd();
                }
                string[] XMLLines = xml.Split('\n');
                foreach (string s in XMLLines)
                {
                    if (s.Contains("Recording:"))
                    {
                        string rate = new string(s.Where(Char.IsDigit).ToArray());
                        this.sampleRate = Int32.Parse(rate);
                        break;
                    }
                }
            }

            /*string xml;
            using (StreamReader input = new StreamReader(Path.Combine(Environment.CurrentDirectory, @"settings\", "playback_small.xml")))
            {
                xml = input.ReadToEnd();
            }
            this.XMLLines = xml.Split('\n');
            foreach (string s in this.XMLLines)
            {
                if (s.Contains("Recording:"))
                {
                    string rate = new string(s.Where(Char.IsDigit).ToArray());
                    this.sampleRate = Int32.Parse(rate);
                    break;
                }
            }*/
        }
        private void initialize(ITelnetClient client)
        {
            this.client = client;
            this.playing = false;
            this.PlaybackSpeed = 1;
            this.Time = DateTime.MinValue;
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
    }
}
