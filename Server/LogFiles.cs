using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class LogFiles : IEntry
    {
        private string message;

        public LogFiles(string logLocation)
        {

        }

        public void Logger(string message)
        {
            string track = @"ChatRoomLog.txt";
            if (!File.Exists(track))
            {
                using (StreamWriter sw = File.CreateText(track))
                {
                    sw.WriteLine(message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(track))
                {
                    sw.WriteLine(message);
                }
            }
        }
    }
}

