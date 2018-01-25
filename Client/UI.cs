using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public static class UI
    {
        public static void DisplayMessage(string message)
        {
            while (message.EndsWith("\0"))
            {
                string placeHolder = message.Substring(0, message.Length - 1);
                message = placeHolder;
            }
            Console.WriteLine();
            Console.WriteLine(message);
            
        }
        public static string GetInput()
        {
            return Console.ReadLine();
        }
    }
}
