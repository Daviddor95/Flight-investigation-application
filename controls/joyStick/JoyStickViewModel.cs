using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    class JoystickViewModel : IJoystickViewModel
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private IFIAModel model;
        public float VM_Elevator
        {
            get
            {
                return model.elevatorJoyStickY;
            }
            
        }
        public float VM_Aileron
        {
            get
            {
                return model.aileronJoyStickX;
            }
            
        }
        public float VM_Rudder
        {
            get
            {
                return model.rudderScrollerX;
            }
            
        }
        public float VM_Throttle
        {
            get
            {
                return model.throttleScrollerY;
            }
            
        }
        //DON'T TOUCH, IT'S DAVID
        public JoystickViewModel(IFIAModel model)
        {
            this.model = model;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs eventArgs)
            {
                NotifyPropertyChanged("VM_" + eventArgs.PropertyName);
            };
        }
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

       /* public void startJoyStickVM()
        {
            this.model.startJoyStick();
        }
        
       
        public void startDataTableVM()
        {
            this.model.startDataTable();
        }*/
    }

}
