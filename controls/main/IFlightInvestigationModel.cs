using System.ComponentModel;

namespace Model
{
    /*
        The IFIAModel interface
        Part of interface of the FIAModel class
     */
    partial interface IFIAModel : INotifyPropertyChanged
    {
        // Starts the operation of the other controllers
        void start();
        // Closes the window and disconnects from the server
        void closeWindow();
    }
}
