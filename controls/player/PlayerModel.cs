using System;
using System.IO;
using System.Linq;
using Microsoft.Win32;
using Client;

namespace Model
{
    /*
        The FIAModel class
        This part from the FIAModel class responsible to the logic behind the player controller
     */
    public partial class FIAModel : IFIAModel
    {
        // Fields for the client (for client-server communication), playbackSpeed, time, sampleRate (number of rows in
        // the file which represent a second), lengthSec (length of the flight in seconds), currentLine (the current
        // line in the file), playing (flag that indicates that the video should play), CSVLines (holds the CSV file
        // in memory), regFlight (holds the regular flight CSV file), model (holds the one and only instance of the
        // class)
        private ITelnetClient client;
        private volatile bool playing;
        private float playbackSpeed;
        private DateTime time;
        private string[] CSVLines;
        private string[] regFlight;
        private int sampleRate;
        private float lengthSec;
        private int currentLine;
        private static IFIAModel model;
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
        // Constructor of the FIAModel class. Used the singleton design pattern
        private FIAModel(ITelnetClient client)
        {
            this.initialize(client);
            this.connect();
        }
        // Connect to the localhost ip address and port 5400
        private void connect()
        {
            this.connect("127.0.0.1", 5400);
        }
        // Connect to the given IP address and port number
        private void connect(string ip, int port)
        {
            this.client.connect(ip, port);
        }
        // Disconnect from the server
        private void disconnect()
        {
            this.playing = false;
            this.client.disconnect();
        }
        // Show a single frame and update time and current line
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
        // Play the video
        public void play()
        {
            if (this.CSVLines != null && !this.playing)
            {
                this.playing = true;
                this.start();
            }
        }
        // Pause the video
        public void pause()
        {
            if (this.CSVLines != null)
            {
                this.playing = false;
            }
        }
        // Stop the video
        public void stop()
        {
            if (this.CSVLines != null)
            {
                this.jumpToStart();
                this.pause();
            }
        }
        // Jump to the start of the video
        public void jumpToStart()
        {
            if (this.CSVLines != null)
            {
                this.currentLine = 0;
                this.Time = DateTime.MinValue;
                this.playVideo();
            }
        }
        // Jump to the end of the video
        public void jumpToEnd()
        {
            if (this.CSVLines != null)
            {
                this.currentLine = this.CSVLines.Length - 5;
                this.Time = DateTime.MinValue.AddSeconds(this.lengthSec);
                this.playVideo();
            }
        }
        // Jump 10 seconds forward
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
        // Jump 10 seconds backwards
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
        // Jump to the new time set
        public void jumpToTime()
        {
            TimeSpan diff = this.Time - DateTime.MinValue;
            this.currentLine =(int) diff.TotalSeconds * this.sampleRate;
            this.playVideo();
        }
        // Load the CSV file to the project
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
        }
        // Initialize the model class
        private void initialize(ITelnetClient client)
        {
            this.client = client;
            this.playing = false;
            this.PlaybackSpeed = 1;
            this.Time = DateTime.MinValue;
            this.currentLine = 0;
        }
        // Load the regular flight CSV file to the project
        public void loadRegFlight()
        {
            OpenFileDialog FileDialog = new OpenFileDialog();
            if ((bool)FileDialog.ShowDialog())
            {
                string flight;
                using (StreamReader input = new StreamReader(FileDialog.FileName))
                {
                    flight = input.ReadToEnd();
                }
                this.regFlight = flight.Split('\n').Where(x => !string.IsNullOrEmpty(x)).ToArray();
            }
        }
    }
}
