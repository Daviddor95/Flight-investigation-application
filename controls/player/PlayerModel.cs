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

namespace Player
{
    partial class FIAModel : IPlayerModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ITelnetClient client;
        private volatile bool playing;
        private float playbackSpeed;
        private DateTime time;
        private string[] CSVLines;
        private int sampleRate;
        private int lengthSec;
        private int currentLine;
        public float PlaybackSpeed
        {
            get
            {
                return playbackSpeed;
            }
            set
            {
                playbackSpeed = value;
                NotifyPropertyChanged("PlaybackSpeed");
            }
        }
        public DateTime Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
                NotifyPropertyChanged("Time");
            }
        }
        public int LengthSec
        {
            get
            {
                return lengthSec;
            }
            set
            {
                lengthSec = value;
                NotifyPropertyChanged("LengthSec");
            }
        }
        public FIAModel(ITelnetClient client)
        {
            this.client = client;
            this.playing = true;
            this.PlaybackSpeed = 1;
            this.Time = DateTime.MinValue;
            this.sampleRate = 10;
            this.currentLine = 0;
        }
        public void connect()
        {
            client.connect("127.0.0.1", 5400);
        }
        public void connect(string ip, int port)
        {
            client.connect(ip, port);
        }
        public void disconnect()
        {
            this.playing = false;
            client.disconnect();
        }
        public void start()
        {
            new Thread(delegate ()
            {
                while (this.playing && this.currentLine < this.CSVLines.Length && this.currentLine >= 0)
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
                    /*if (this.currentLine % this.sampleRate == 0)
                    {
                        this.time = this.time.AddSeconds(1);
                    }*/
                    this.Time = this.Time.AddSeconds(1 / this.sampleRate);
                    if (this.PlaybackSpeed != 0)
                    {
                        Thread.Sleep((int)(1000 / (this.sampleRate * Math.Abs(this.PlaybackSpeed))));
                    }
                    else
                    {
                        this.playing = false;
                    }
                }
            }).Start();
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
        public void jumpToTime(int time)
        {
            this.Time = DateTime.MinValue.AddSeconds(time);
            this.currentLine = time * this.sampleRate;
        }
        public void loadCSVFile()
        {
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
                this.connect();
            }
        }
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public void closeWindow()
        {
            this.disconnect();
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
