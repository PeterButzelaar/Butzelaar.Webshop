using System;
using Butzelaar.Generic.Logging;
using Butzelaar.Generic.Logging.Enumeration;
using Butzelaar.Webshop.Service.Logging;

namespace Butzelaar.Webshop.TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ILoggingService logService = new LoggingService())
            {
                var logs = logService.GetLogsOrderedByDateDescending();
            }
        }
    }
}
