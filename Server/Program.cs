using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            LogFiles fl = new LogFiles("file.txt");
            //Server server = new Server(fl);
            new Server(fl).Run();
            Console.ReadLine();
        }
    }
}
