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
        private float xOfJoyStick;
        private float yOfJoyStick;
        private float xOfRudderScroller;
        private float yOfThrottleScroller;
        //private float radiusOfOutercircle = 100;

        //private string[] CSVLines;
        //private int currentLine;

        public float aileronJoyStickX
        {
            get
            {
                return xOfJoyStick;
            }
            set
            {
                xOfJoyStick = value;
                NotifyPropertyChanged("ailerohJoyStickX");
            }
        }
         public float elevatorJoyStickY
        {
            get
            {
                return yOfJoyStick;
            }
            set
            {
                yOfJoyStick = value;
                NotifyPropertyChanged("elevatorJoyStickY");
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

        
        
       
        public void startJoyStick()
        {
            this.aileronJoyStickX = this.currentLine;
            this.elevatorJoyStickY = 9;
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
 

