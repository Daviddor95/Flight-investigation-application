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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            List<DataType> importantData = new List<DataType>();
            importantData.Add(new DataType() { Data = "altimeter:i.a.f", Value = 10000 });//altimeter_indicated-altitude-ft
            //importantData.Add(new DataType() { Data = "altimeter:p.a.f", Value = 10001 }); // altimeter_pressure-alt-ft
            importantData.Add(new DataType() { Data = "airspeed", Value = 20000 }); // airspeed-kt
            //importantData.Add(new DataType() { Data = "Indicated airspeed", Value = 20001 }); //airspeed-indicator_indicated-speed-kt
            importantData.Add(new DataType() { Data = "direction", Value = 30000 });//heading-deg
            importantData.Add(new DataType() { Data = "yaw", Value = 40000 }); //(side-slip-deg)
            importantData.Add(new DataType() { Data = "roll", Value = 50000 });
            importantData.Add(new DataType() { Data = "pitch", Value = 60000 });
            dgSimple.ItemsSource = importantData;
        }





        /* public void startJoystick()
         {
             new Thread(delegate ()
             {
                 while (this.playing && this.currentLine < this.CSVLines.Length)
                 {
                     /*                    TimeSpan diff = this.time - DateTime.MinValue;
                                         long seconds = (long)diff.TotalSeconds;
                                         client.write(CSVLines[seconds * this.sampleRate]);
                     this.client.write(this.CSVLines[this.currentLine]);
                     this.currentLine++;
                     if (this.currentLine % this.sampleRate == 0)
                     {
                         this.time.AddSeconds(1);
                     }
                     if (this.playbackSpeed != 0)
                     {
                         Thread.Sleep((int)(1000 / (this.sampleRate * this.PlaybackSpeed)));
                     }
                     else
                     {
                         this.playing = false;
                     }
                 }
             }).Start();
         } */

        private void mcSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void mcSlider_Copy_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void dgSimple_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    

    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UserControl1());
        }
    }


    public class DataType
    {
        public string Data { get; set; }

        public int Value { get; set; }
    }
}

