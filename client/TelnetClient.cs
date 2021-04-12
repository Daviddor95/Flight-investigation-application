using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Windows;

namespace Client
{
    /*
        The TelnetClient class
        The client side code that responsible to the connection with the server
     */
    class TelnetClient : ITelnetClient
    {
        // Declaring fields for the socket, input and output of the stream
        private Socket simulator;
        private StreamReader input;
        private StreamWriter output;
        // Default constructor for the TelnetClient class
        public TelnetClient()
        {
        }
        // Connects to the server on the given IP address and port number
        public void connect(string ip, int port)
        {
            IPAddress addr = IPAddress.Parse(ip);
            simulator = new Socket(addr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            // Try to connect to the server and open input and output stream for the communication
            try
            {
                simulator.Connect(new IPEndPoint(addr, port));
                this.input = new StreamReader(new NetworkStream(this.simulator));
                this.output = new StreamWriter(new NetworkStream(this.simulator));
            }
            // Exits the program in case of connection failure and shows appropriate message
            catch (SocketException)
            {
                MessageBox.Show("Connection to Flight Gear failed, please launch Flight Gear first and then launch" +
                    " the program again.", "Connection Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }
        }
        // Sends commands to the server
        public void write(string operation)
        {
            if (this.simulator.Connected)
            {
                this.output.WriteLine(operation);
            }
        }
        // Return answer from the server
        public string read()
        {
            return this.input.ReadLine();
        }
        // Close any open socket or stream
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
