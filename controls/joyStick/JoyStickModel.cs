using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Model
{
    public partial class FIAModel : IFIAModel
    {
        //public event PropertyChangedEventHandler PropertyChanged;
        private float xOfJoystick;
        private float yOfJoystick;
        private float xOfRudderScroller;
        private float yOfThrottleScroller;
        //private float radiusOfOutercircle = 100;
        /*private float altimeter;
        private float yOfThrottleScroller;
        private float yOfThrottleScroller;
        private float yOfThrottleScroller;
        private float yOfThrottleScroller;*/

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

        
        
       
        public void startJoystick()
        {
            float radius = 55;
            float x = Int32.Parse(this.CSVLines[currentLine].Split(new string[] { "," }, StringSplitOptions.None)[0]);
            float y = Int32.Parse(this.CSVLines[currentLine].Split(new string[] { "," }, StringSplitOptions.None)[1]);
            this.aileronJoystickX = x * radius;
            this.elevatorJoystickY = y * radius;  
        }

        public void startScrollers()
        {
            this.rudderScrollerX = Int32.Parse(this.CSVLines[currentLine].Split(new string[] { "," }, StringSplitOptions.None)[2]);
            this.throttleScrollerY = Int32.Parse(this.CSVLines[currentLine].Split(new string[] { "," }, StringSplitOptions.None)[6]);

        }
        public void startDataTable()
        {
            float x = this.rudderScrollerX;
            float y = this.throttleScrollerY;
            //????????????

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
 

