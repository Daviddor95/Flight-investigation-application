using System;
using System.Threading;
using System.ComponentModel;

namespace Model
{
    /*
        The FIAModel class
        This part from the FIAModel class responsible to the logic behind the main controller of the program
     */
    partial class FIAModel : IFIAModel
    {
        // Declaring an PropertyChangedEventHandler event field
        public event PropertyChangedEventHandler PropertyChanged;
        // Starts the operation of the other controllers
        public void start()
        {
            // Create a new thread
            Thread theT = new Thread(delegate ()
            {
                // Runs while the current line didn't exceed the file's bounds
                while (this.playing && this.currentLine < this.CSVLines.Length - 1 && this.currentLine >= 0)
                {
                    this.playVideo();
                    this.startAllJoystickModel();
                    this.chart();
                    // Runs the simulator at the given playback speed based on the sample rate
                    if (this.PlaybackSpeed != 0)
                    {
                        Thread.Sleep((int)(1000 / (this.sampleRate * Math.Abs(this.PlaybackSpeed))));
                    }
                    else
                    {
                        this.playing = false;
                    }
                }
            });
            theT.SetApartmentState(ApartmentState.STA);
            // Starts the thread
            theT.Start();
        }
        // Closes the window and disconnects from the server
        public void closeWindow()
        {
            this.disconnect();
        }
        // Notifies that the given property has changed
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
