using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model
{
    partial class FIAModel
    {
        public void start()
        {
            new Thread(delegate ()
            {
                while (this.playing && this.currentLine < this.CSVLines.Length - 1 && this.currentLine >= 0)
                {
                    this.playVideo();
                    this.startAllJoystickModel();
                    //graph();
                    if (this.PlaybackSpeed != 0)
                    {
                        Thread.Sleep((int)(1000 / (this.sampleRate * Math.Abs(this.PlaybackSpeed))));
                    }
                    else
                    {
                        this.playing = false;
                    }
                }
            }).Start();
        }
        public void closeWindow()
        {
            this.disconnect();
        }
    }
}
