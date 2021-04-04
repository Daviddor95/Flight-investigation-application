using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Player
{
    class TelnetClient : ITelnetClient
    {
        private Socket simulator;
        private StreamReader input;
        private StreamWriter output;
        public TelnetClient()
        {
        }
        public void connect(string ip, int port)
        {
            IPAddress addr = IPAddress.Parse(ip);
            simulator = new Socket(addr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            simulator.Connect(new IPEndPoint(addr, 5400));
            this.input = new StreamReader(new NetworkStream(this.simulator));
            this.output = new StreamWriter(new NetworkStream(this.simulator));
        }
        public void write(string operation)
        {
            if (this.simulator.Connected)
            {
                this.output.WriteLine(operation);
            }
        }
        public string read()
        {
            return this.input.ReadLine();
        }
        public void disconnect()
        {
            if (this.output != null)
            {
                this.output.Close();
            }
            if (this.input != null)
            {
                this.input.Close();
            }
            if (this.simulator != null)
            {
                this.simulator.Close();
            }
        }
    }
}
