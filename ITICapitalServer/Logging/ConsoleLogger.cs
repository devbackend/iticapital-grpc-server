using System;
using Microsoft.VisualBasic;

namespace ITICapitalServer.Logging
{
    public class ConsoleLogger: ILogger
    {
        public void Write(params string[] messages)
        {
            Console.WriteLine($"[{DateTime.Now}] {Strings.Join(messages, " ")}");
        }

        public void Error(string error)
        {
            Console.WriteLine($"[{DateTime.Now}] ERROR: {error}");
        }
    }
}