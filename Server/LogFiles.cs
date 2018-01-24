using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class LogFiles : IEntry
    {
        private string message;

        public LogFiles(string message)
        {
            this.message = message;
        }

        public void Logger(string message)
        {
            throw new NotImplementedException();
        }
    }
}
