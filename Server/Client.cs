using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Client
    {
        NetworkStream stream;
        TcpClient client;
        public string UserId;
        public string userName;
        public bool isConnected = true;
        public Client(NetworkStream Stream, TcpClient Client)
        {
            stream = Stream;
            client = Client;
            UserId = "495933b6-1762-47a1-b655-483510072e73";
        }
        public void Send(string Message)
        {
            try
            {
                byte[] message = Encoding.ASCII.GetBytes(Message);
                stream.Write(message, 0, message.Count());
            }
            catch
            {
                isConnected = false;
            }
            
        }
        public string Recieve()
        {
            try
            {
                byte[] recievedMessage = new byte[256];
                stream.Read(recievedMessage, 0, recievedMessage.Length);
                string recievedMessageString = Encoding.ASCII.GetString(recievedMessage);
                //get rid of the extra space in a message here
                while (recievedMessageString.EndsWith("\0"))
                {
                    string placeHolder = recievedMessageString.Substring(0, recievedMessageString.Length - 2);
                    recievedMessageString = placeHolder;
                }
                Console.WriteLine(recievedMessageString);
                return recievedMessageString;
            }
            catch
            {
                string disconnected = userName + ": left the chat room!";
                Console.WriteLine(disconnected);
                return disconnected;
            }
            
        }

    }
}
