﻿using System.ComponentModel;

//namespace Flight_investigation_application.controls.Joystick
namespace Model
{
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
