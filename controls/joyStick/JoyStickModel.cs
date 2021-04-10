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
    /// <summary>FIAModel is an partial class.
    /// its the Model part for the desktop app as part of the mvvm design pattern.
    /// here only specified the functions needed for 
    /// the joystick, it's scrollers and the other data desplayed(yaw, roll pitch...)
    /// </summary>

    public partial class FIAModel : IFIAModel
    {
        //the joystick's inner elipse coordinates
        private float xOfJoystick;
        private float yOfJoystick;

        //the Rudder scroller's value
        private float xOfRudderScroller;
        //the Rudder Throttle's value
        private float yOfThrottleScroller;

        //the data we need to display through a flight
        private float direction;
        private float altimeter;
        private float airspeed;
        private float yaw;
        private float roll;
        private float pitch;

        //the property of aileron
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

        //the property of elevator
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

        //the property of throttle
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

        //the property of rudder
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

        //the property of direction 
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

        //the property of altimeter
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

        //the property of airspeed
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

        //the property of yaw
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

        //the property of roll
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

        //the property of pitch
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

        //the property of DataTableM
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

        /// <summary>startJoystick func' 
        /// is made for changing the value of the coordinates of the inner elipse on the joystick.
        /// the set functions of the relevant properties are called.
        /// </summary>
        public void startJoystick()
        {
            float radius = 55;
            float x = float.Parse(this.CSVLines[currentLine].Split(',')[0]);
            float y = float.Parse(this.CSVLines[currentLine].Split(',')[1]);
            //135,45 are is the center of the outer elipse of joystick
            //so its the correct coordinates for the inner elipse of joystick
            //to be right in the middle of the outer elipse.
            //the elipse will move from themiddle due to
            //changes in the aileron and elevator values
            this.aileronJoystickX = 135 + x * radius;
            this.elevatorJoystickY = 45 + y * radius;
        }

        /// <summary>startScrollers func' 
        /// is made for changing the value of the 2 Scrollers that near the joystick.
        // /// the set functions of the relevant properties are called.
        /// </summary>
        public void startScrollers()
        {
            this.rudderScrollerX = float.Parse(this.CSVLines[currentLine].Split(',')[2]);
            this.throttleScrollerY = float.Parse(this.CSVLines[currentLine].Split(',')[6]);

        }

        /// <summary>startDataTable func' 
        /// is made for changing the value's written next to the names of the 6 features:
        /// roll, pitch, yaw, directio, altimeter and airspeed.
        // the set functions of the relevant properties are called.
        /// </summary>
        public void startDataTable()
        {
            this.directionM = float.Parse(this.CSVLines[currentLine].Split(',')[19]);
            this.airspeedM = float.Parse(this.CSVLines[currentLine].Split(',')[21]);
            this.altimeterM = float.Parse(this.CSVLines[currentLine].Split(',')[26]);
            this.yawM = float.Parse(this.CSVLines[currentLine].Split(',')[20]);
            this.rollM = float.Parse(this.CSVLines[currentLine].Split(',')[17]);
            this.pitchM = float.Parse(this.CSVLines[currentLine].Split(',')[18]);
        }
        
        //updating all data together
        public void startAllJoystickModel()
        {
            startJoystick();
            startScrollers();
            startDataTable();

        }

       

    }
}
 

