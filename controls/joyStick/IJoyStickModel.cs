using System.ComponentModel;

//namespace Flight_investigation_application.controls.Joystick
namespace Model
{
    /// <summary>IFIAModel is an interface for the model that will be used for the joystick, its scroller and user story 5 
    /// (the data about yaw, roll, pitch, direction (of flight), airspeed and altimeter in the flight.)
    /// the functions will be explained in the FIAModel itself</summary>
    public partial interface IFIAModel : INotifyPropertyChanged
    {
        float aileronJoystickX
        {
            set;
            get;
        }

        float elevatorJoystickY
        {
            set;
            get;
        }

        float throttleScrollerY
        {
            set;
            get;
        }

        float rudderScrollerX
        {
            set;
            get;
        }


        float directionM
        {
            set;
            get;
        }

        float altimeterM
        {
            set;
            get;
        }

        float airspeedM
        {
            set;
            get;
        }

        float yawM
        {
            set;
            get;
        }


        float rollM
        {
            set;
            get;
        }

        float pitchM
        {
            set;
            get;
        }




        void startJoystick();
        void startScrollers();
        void startDataTable();
        void startAllJoystickModel();
    }
}
