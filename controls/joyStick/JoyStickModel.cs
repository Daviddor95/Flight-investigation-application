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
                NotifyPropertyChanged("aileronJoystickX");
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
                NotifyPropertyChanged("elevatorJoystickY");
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
                NotifyPropertyChanged("throttleScrollerY");
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
                NotifyPropertyChanged("rudderScrollerX");
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
                NotifyPropertyChanged("directionM");
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
                NotifyPropertyChanged("altimeterM");
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
                NotifyPropertyChanged("airspeedM");
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
                NotifyPropertyChanged("yawM");
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
                NotifyPropertyChanged("rollM");
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
                NotifyPropertyChanged("pitchM");
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
                NotifyPropertyChanged("DataTableM");
            }
        }


        public void startJoystick()
        {
            float radius = 55;
            float x = float.Parse(this.CSVLines[currentLine].Split(',')[0]);
            float y = float.Parse(this.CSVLines[currentLine].Split(',')[1]);
            this.aileronJoystickX = 135 + x * radius;
            this.elevatorJoystickY = 20 + y * radius;
            
            
        }

        public void startScrollers()
        {
            this.rudderScrollerX = float.Parse(this.CSVLines[currentLine].Split(',')[2]);
            this.throttleScrollerY = float.Parse(this.CSVLines[currentLine].Split(',')[6]);

        }
        public void startDataTable()
        {
            this.direction = float.Parse(this.CSVLines[currentLine].Split(',')[19]);
            this.airspeed = float.Parse(this.CSVLines[currentLine].Split(',')[21]);
            this.altimeter = float.Parse(this.CSVLines[currentLine].Split(',')[26]);
            this.yaw = float.Parse(this.CSVLines[currentLine].Split(',')[20]);
            this.roll = float.Parse(this.CSVLines[currentLine].Split(',')[17]);
            this.pitch = float.Parse(this.CSVLines[currentLine].Split(',')[18]);
            this.importantData[0].Value = this.altimeter;
            this.importantData[1].Value = this.airspeed;
            this.importantData[2].Value = this.direction;
            this.importantData[3].Value = this.yaw;
            this.importantData[4].Value = this.roll;
            this.importantData[5].Value = this.pitch;

        }

        public void startAllJoystickModel()
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
 

