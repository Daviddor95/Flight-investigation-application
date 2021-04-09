using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using Client;
using ViewModel;
using Model;

namespace View
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class PlayerUserControl : UserControl
    {
        private PlayerViewModel playerVM;
        public PlayerUserControl()
        {
            InitializeComponent();
            this.playerVM = new PlayerViewModel(FIAModel.Model);
            DataContext = this.playerVM;
        }

        private void OpenCSV_Click(object sender, RoutedEventArgs e)
        {
            this.playerVM.loadCSV();
        }

        private void Pause_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.playerVM.pause();
        }

        private void Play_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.playerVM.play();
        }

        private void Stop_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.playerVM.stop();
        }

        private void FastBackwards_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.playerVM.fastBackwards();
        }

        private void FastForward_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.playerVM.fastForward();
        }

        private void JumpToStart_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.playerVM.jumpToStart();
        }

        private void JumpToEnd_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.playerVM.jumpToEnd();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.playerVM.VM_Time = (int)playerSlider.Value;
        }

        private void playbackSpeed_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && playbackSpeed != null)
            {
                this.playerVM.VM_PlaybackSpeed = float.Parse(playbackSpeed.Text);
            }
        }
    }
}
