using System;
using System.Globalization;
using System.Threading;
using Butzelaar.Webshop.Common.Resources;
using Butzelaar.Webshop.Service;

namespace Butzelaar.Webshop.TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            

            using (var uow = new UnitOfWork())
            {
                var logs = uow.LoggingService.GetLogsOrderedByDateDescending();
                foreach (var log in logs)
                {
                    Console.WriteLine(log.Date);
                }
                Thread.CurrentThread.CurrentCulture = new CultureInfo("nl-NL");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("nl-NL");

                Console.WriteLine(ModelResource.Date);
                Console.ReadKey();
            }
        }
    }
}
