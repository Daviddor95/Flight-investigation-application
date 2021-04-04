using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player
{
    interface ITelnetClient
    {
        void connect(string ip, int port);
        void write(string operation);
        string read();
        void disconnect();
    }
}
