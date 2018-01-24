using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    interface IEntry
    {
        void Logger(string message);
        //calling a message to be logged, will be used to log messages. 
    }
}
