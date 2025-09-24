using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydac
{
    public class Logger
    {
        private List<string> logs = new List<string>();
        public void Log(string message) => logs.Add($"{DateTime.Now}: {message}");

        public void ShowLogs(string message)
        {
            if(logs.Count == 0)
            {
                Console.WriteLine("No logs available.");
                return;
            }
            else
                foreach (var log in logs)
                {
                    Console.WriteLine(log);
                }
        }
    }
}
