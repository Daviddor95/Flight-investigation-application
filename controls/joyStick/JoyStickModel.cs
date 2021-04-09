using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Util;

namespace Model
{
    public partial class FIAModel : IFIAModel
    {
        //public event PropertyChangedEventHandler PropertyChanged;
        private float xOfJoystick;
        private float yOfJoystick;

        private float xOfRudderScroller;
        private float yOfThrottleScroller;

        private float direction;
        private float altimeter;
        private float airspeed;
        private float yaw;
        private float roll;
        private float pitch;

        public float aileronJoystickX
        {
            get
            {
                return xOfJoystick;
            }
            set
            {
                xOfJoystick = value;
                NotifyPropertyChanged("xOfJoystick");
            }
        }
        public float elevatorJoystickY
        {
            get
            {
                return yOfJoystick;
            }
            set
            {
                yOfJoystick = value;
                NotifyPropertyChanged("yOfJoystick");
            }
        }

        public float throttleScrollerY
        {
            get
            {
                return yOfThrottleScroller;
            }
            set
            {
                yOfThrottleScroller = value;
                NotifyPropertyChanged("yOfThrottleScroller");
            }
        }

        public float rudderScrollerX
        {
            get
            {
                return xOfRudderScroller;
            }
            set
            {
                xOfRudderScroller = value;
                NotifyPropertyChanged("xOfRudderScroller");
            }
        }

        public float directionM
        {
            get
            {
                return direction;
            }
            set
            {
                direction = value;
                NotifyPropertyChanged("direction");
            }
        }

        public float altimeterM
        {
            get
            {
                return altimeter;
            }
            set
            {
                altimeter = value;
                NotifyPropertyChanged("altimeter");
            }
        }
        public float airspeedM
        {
            get
            {
                return airspeed;
            }
            set
            {
                airspeed = value;
                NotifyPropertyChanged("airspeed");
            }
        }

        public float yawM
        {
            get
            {
                return yaw;
            }
            set
            {
                yaw = value;
                NotifyPropertyChanged("yaw");
            }
        }
        public float rollM
        {
            get
            {
                return roll;
            }
            set
            {
                roll = value;
                NotifyPropertyChanged("roll");
            }
        }

        public float pitchM
        {
            get
            {
                return pitch;
            }
            set
            {
                pitch = value;
                NotifyPropertyChanged("pitch");
            }
        }

        public List<DataType> DataTableM
        {
            get
            {
                return importantData;
            }
            set
            {
                importantData = value;
                NotifyPropertyChanged("importantData");
            }
        }


        public void startJoystick()
        {
            float radius = 55;
            float x = Int32.Parse(this.CSVLines[currentLine].Split(new string[] { "," }, StringSplitOptions.None)[0]);
            float y = Int32.Parse(this.CSVLines[currentLine].Split(new string[] { "," }, StringSplitOptions.None)[1]);
            this.aileronJoystickX = 135 + x * radius;
            this.elevatorJoystickY = 20 + y * radius;
        }

        public void startScrollers()
        {
            this.rudderScrollerX = Int32.Parse(this.CSVLines[currentLine].Split(new string[] { "," }, StringSplitOptions.None)[2]);
            this.throttleScrollerY = Int32.Parse(this.CSVLines[currentLine].Split(new string[] { "," }, StringSplitOptions.None)[6]);

        }
        public void startDataTable()
        {
            this.direction = Int32.Parse(this.CSVLines[currentLine].Split(new string[] { "," }, StringSplitOptions.None)[19]);
            this.airspeed = Int32.Parse(this.CSVLines[currentLine].Split(new string[] { "," }, StringSplitOptions.None)[21]);
            this.altimeter = Int32.Parse(this.CSVLines[currentLine].Split(new string[] { "," }, StringSplitOptions.None)[26]);
            this.yaw = Int32.Parse(this.CSVLines[currentLine].Split(new string[] { "," }, StringSplitOptions.None)[20]);
            this.roll = Int32.Parse(this.CSVLines[currentLine].Split(new string[] { "," }, StringSplitOptions.None)[17]);
            this.pitch = Int32.Parse(this.CSVLines[currentLine].Split(new string[] { "," }, StringSplitOptions.None)[18]);
            this.importantData[0].Value = this.altimeter;
            this.importantData[1].Value = this.airspeed;
            this.importantData[2].Value = this.direction;
            this.importantData[3].Value = this.yaw;
            this.importantData[4].Value = this.roll;
            this.importantData[5].Value = this.pitch;

        }

        public void startDastartAllJoystickModel()
        {
            startJoystick();
            startScrollers();
            startDataTable();

        }

        /*public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }*/
    }
}
 

