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

        //private string[] CSVLines;
        //private int currentLine;

        public float aileronJoystickX
        {
            get
            {
                return xOfJoystick;
            }
            set
            {
                xOfJoystick = value;
                NotifyPropertyChanged("ailerohJoystickX");
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
            this.aileronJoystickX = this.currentLine;
            this.elevatorJoystickY = 9;
            //x = x * radiusOfOutercircle;
            //y = y * radiusOfOutercircle;
            //????????????   
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
 

