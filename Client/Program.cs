using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client("127.0.0.1", 9999);

            client.ShowClient(client.userName);

            //parallel invoke creates the threads.
            Parallel.Invoke(() =>
            {
                //while loop keeps the servers open to send and receive messages
                while (true)
                {
                    client.Send();
                }
            },
            () =>
            {
                while (true)
                {
                    client.Recieve();

                }
                //might need readline here
            });
        }
    }
}
