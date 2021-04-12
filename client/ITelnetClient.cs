namespace Client
{
    /*
        The ITelnetClient interface
        The interface of the TelnetClient class
     */
    interface ITelnetClient
    {
        // Connects to the server on the given IP address and port number
        void connect(string ip, int port);
        // Sends commands to the server
        void write(string operation);
        // Return answer from the server
        string read();
        // Close any open socket or stream
        void disconnect();
    }
}
