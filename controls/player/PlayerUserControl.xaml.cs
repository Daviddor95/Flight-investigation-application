using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ViewModel;
using Model;

namespace View
{
    /*
        The PlayerUserControl class
        The class responsible to the interaction between the user and the player
     */
    public partial class PlayerUserControl : UserControl
    {
        // Declaring a field for the view model
        private PlayerViewModel playerVM;
        // Constructor of the PlayerUserControl class
        public PlayerUserControl()
        {
            InitializeComponent();
            this.playerVM = new PlayerViewModel(FIAModel.Model);
            DataContext = this.playerVM;
        }
        // Open the "Open File" dialog to load the CSV file
        private void OpenCSV_Click(object sender, RoutedEventArgs e)
        {
            this.playerVM.loadCSV();
            this.exception.Text = "";
        }
        // Pause the video on mouse up
        private void Pause_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.playerVM.pause();
        }
        // Play the video on mouse up
        private void Play_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.playerVM.play();
        }
        // Stop the video on mouse up
        private void Stop_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.playerVM.stop();
        }
        // Jump 10 seconds backwards on mouse up
        private void FastBackwards_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.playerVM.fastBackwards();
        }
        // Jump 10 seconds forward on mouse up
        private void FastForward_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.playerVM.fastForward();
        }
        // Jump to the start of the video on mouse up
        private void JumpToStart_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.playerVM.jumpToStart();
        }
        // Jump to the end of the video on mouse up
        private void JumpToEnd_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.playerVM.jumpToEnd();
        }
        // Jump to the new time set when the slider's value change
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.playerVM.VM_Time = (int)playerSlider.Value;
        }
        // Change the playback speed based on the input, on enter key up
        private void playbackSpeed_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && playbackSpeed != null)
            {
                if (this.playerVM.VM_PlaybackSpeed == 0)
                {
                    this.playerVM.play();
                }
                float speed;
                bool valid = float.TryParse(playbackSpeed.Text, out speed);
                if (valid)
                {
                    this.playerVM.VM_PlaybackSpeed = speed;
                    this.exception.Text = "";
                }
                else
                {
                    this.exception.Text = "Please enter a valid value";
                    this.playbackSpeed.Text = this.playerVM.VM_PlaybackSpeed.ToString();
                }
            }
        }
        // Open the "Open File" dialog to load the XML file
        private void openXML_Click(object sender, RoutedEventArgs e)
        {
            this.playerVM.loadXML();
            this.openRegFlight.IsEnabled = true;
            this.exception.Text = "Please open regular flight file";
        }
        // Open the "Open File" dialog to load the regular flight CSV file
        private void openRegFlight_Click(object sender, RoutedEventArgs e)
        {
            this.playerVM.loadRegFlight();
            this.OpenCSV.IsEnabled = true;
            this.exception.Text = "Please open test flight file";
        }
    }
}
