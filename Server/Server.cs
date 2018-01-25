using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class Server
    {
        public static Client client;
        TcpListener server;
        public int counter = 0;
        IEntry Logger;
        Dictionary<int, Client> users = new Dictionary<int, Client>();
        Queue<string> messages = new Queue<string>();
        public Server(IEntry Entry)
        {
            users = new Dictionary<int, Client>();
            messages = new Queue<string>();
            this.Logger = Entry;
            server = new TcpListener(IPAddress.Parse("127.0.0.1"), 9999);
            server.Start();
        }
        public void Run()
        {
            AcceptClient();
        }
        private void ClientTalk(Client client)
        {
            string startMessage;
            while (client.isConnected)
            {
                string message = client.Recieve();
                lock (message)
                {
                    messages.Enqueue(/*client.userName + */message);
                }
                if (messages.Count > 0)
                {
                    lock (messages)
                    {
                        startMessage = messages.Dequeue();
                    }
                    Logger.Logger(startMessage);
                    Respond(startMessage);
                }
            }
        }
        private void AcceptClient()
        {
            while (true)
            {
                TcpClient clientSocket = default(TcpClient);
                clientSocket = server.AcceptTcpClient();
                Console.WriteLine("Connected");
                NetworkStream stream = clientSocket.GetStream();
                client = new Client(stream, clientSocket);
                client.userName = client.Recieve();
                string messageString = client.userName + "has joined the chatroom";
                lock (messages)
                {
                    messages.Enqueue(messageString);
                }
                users.Add(counter, client);
                counter++;
                Task.Run(() => ClientTalk(client));
            }
        }
        private void Respond(string body)
        {
            foreach (KeyValuePair<int, Client> entry in users)
            {
                if (entry.Value.isConnected)
                {
                    entry.Value.Send(body);
                }
            }
        }
    }
}