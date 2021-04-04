﻿using System;
using System.IO;
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
using Microsoft.Win32;
using Player;

namespace Flight_investigation_application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PlayerViewModel playerVM;
        public MainWindow()
        {
            InitializeComponent();
            playerVM = new PlayerViewModel(new FIAModel(new TelnetClient()));
            DataContext = playerVM;
/*            Binding bind = new Binding("Text");
            bind.Source = this.playerVM.VM_DigitalTime;
            time.SetBinding(TextBlock.TextProperty, bind);*/
        }
/*
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
            this.playerVM.VM_Time = PlayerUserControl.playerSlider.Value;
        }
        private void playbackSpeed_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox playbackSpeed = sender as TextBox;
            if (e.Key == Key.Enter && playbackSpeed != null)
            {
                this.playerVM.VM_PlaybackSpeed = float.Parse(playbackSpeed.Text);
            }
        }*/
        private void Window_Closed(object sender, EventArgs e)
        {
            this.playerVM.closeWindow();
        }


    }
}
