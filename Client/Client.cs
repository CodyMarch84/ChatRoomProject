using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Client
    {
        TcpClient clientSocket;
        NetworkStream stream;
        public string userName;

        public Client(string IP, int port)
        {
            TypeName();
            clientSocket = new TcpClient();
            clientSocket.Connect(IPAddress.Parse(IP), port);
            stream = clientSocket.GetStream();
            Send(userName);
        }

        private void Send(string userName)
        {            
            byte[] message = Encoding.ASCII.GetBytes(userName);
            stream.Write(message, 0, message.Count());
        }

        public void Send()
        {
            string messageString = userName + ": " + UI.GetInput();
            byte[] message = Encoding.ASCII.GetBytes(messageString);
            stream.Write(message, 0, message.Count());
        }
        public void TypeName()
        {
            Console.WriteLine("Please type your name: ");
            userName = UI.GetInput();
        }
        public void MeetClient(string user)
        {
            string messageString = userName + " has joined the chatroom.";
            Console.WriteLine(messageString);
            byte[] message = Encoding.ASCII.GetBytes(messageString);
            stream.Write(message, 0, message.Count());
        }

        public void Recieve()
        {
            byte[] recievedMessage = new byte[256];
            stream.Read(recievedMessage, 0, recievedMessage.Length);
            UI.DisplayMessage(Encoding.ASCII.GetString(recievedMessage));
        }
    }
}
