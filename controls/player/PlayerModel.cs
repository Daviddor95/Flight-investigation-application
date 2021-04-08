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
//using Flight_investigation_application.controls.player;
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
        private int lengthSec;
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
                return this.time;
            }
            set
            {
                DateTime endTime = new DateTime().AddSeconds(LengthSec);
                if (value >= DateTime.MinValue && value <= endTime)
                {
                    this.time = value;
                }
                else if (value < DateTime.MinValue)
                {
                    this.time = value;
                }
                else
                {
                    this.time = endTime;
                }
                NotifyPropertyChanged("Time");
            }
        }
        public int LengthSec
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
            /*
            this.client = client;
            this.playing = true;
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
*/
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
/*        public void start()
        {
            new Thread(delegate ()
            {
                while (this.playing && this.currentLine < this.CSVLines.Length && this.currentLine >= 0)
                {
                    this.playVideo();
                    if (this.PlaybackSpeed != 0)
                    {
                        Thread.Sleep((int)(1000 / (this.sampleRate * Math.Abs(this.PlaybackSpeed))));
                    }
                    else
                    {
                        this.playing = false;
                    }
                    //moveJoystick();
                    //graph();
                }
            }).Start();
        }*/
        private void playVideo()
        {
            this.client.write(this.CSVLines[this.currentLine]);
            if (this.PlaybackSpeed > 0)
            {
                this.currentLine++;
            }
            else
            {
                this.currentLine--;
            }
            if (this.currentLine % this.sampleRate == 0)
            {
                this.Time = this.Time.AddSeconds(1);
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
        }
        public void jumpToEnd()
        {
            this.currentLine = this.CSVLines.Length - 5;
            this.Time = DateTime.MinValue.AddSeconds(this.lengthSec);
        }
        public void fastForward()
        {
            if (this.currentLine + 10 * this.sampleRate < this.CSVLines.Length)
            {
                this.Time = this.Time.AddSeconds(10);
                this.currentLine += 10 * this.sampleRate;
            }
            else
            {
                this.jumpToEnd();
            }
        }
        public void fastBackwards()
        {
            if (this.currentLine - 10 * this.sampleRate > 0)
            {
                this.Time = this.Time.Subtract(new TimeSpan(0, 0, 10));
                this.currentLine -= 10 * this.sampleRate;
            }
            else
            {
                this.jumpToStart();
            }
        }
        public void jumpToTime()
        {
            TimeSpan diff = this.Time - DateTime.MinValue;
            this.currentLine = (int) diff.TotalSeconds * this.sampleRate;
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
                this.CSVLines = csv.Split('\n');
                this.LengthSec = this.CSVLines.Length / this.sampleRate;
            }
        }
/*        private void loadXML()
        {
            string xml;
            // Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"settings\playback_small.xml"
            using (StreamReader input = new StreamReader(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), System.IO.Path.Combine(@"\settings\", "playback_speed.xml"))))
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

/*            OpenFileDialog FileDialog = new OpenFileDialog();
            if ((bool)FileDialog.ShowDialog())
            {
                IPAddress addr = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
                using (Socket flightGear = new Socket(addr.AddressFamily, SocketType.Stream, ProtocolType.Tcp))
                {
                    flightGear.Connect(new IPEndPoint(addr, 5400));
                    using (StreamReader input = new StreamReader(FileDialog.FileName))
                    {
                        using (StreamWriter output = new StreamWriter(new NetworkStream(flightGear)))
                        {
                            string line;
                            while ((line = input.ReadLine()) != null)
                            {
                                output.WriteLine(line);
                                output.Flush();
                                Thread.Sleep(100);
                            }
                        }
                    }
                }
            }*/
