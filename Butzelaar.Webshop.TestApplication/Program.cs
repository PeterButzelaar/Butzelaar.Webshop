using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Transactions;
using Butzelaar.Generic.Logging;
using Butzelaar.Generic.Logging.Enumeration;
using Butzelaar.Webshop.Database;
using Butzelaar.Webshop.Database.Entities.Webshop;
using System.Threading;

namespace Butzelaar.Webshop.TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            /*using (var context = new LoggingContext())
            {
                var logs = from log in context.Logs
                           where log.Level == "DEBUG"
                           orderby log.Date descending
                           select log;

                foreach (var log in logs)
                {
                    Console.WriteLine(log.StackTrace);
                }
            }*/

            var list = new List<Thread>();

            using (var scope = new TransactionScope())
            {
                for (int i = 0; i < 10; i++)
                {
                    Logger.Log(Level.Fatal, "meh");
                    //list.Add(new Thread(new MyThread(i).Run));
                }

                scope.Complete();
            }
            //list.ForEach(t => t.Start());
        }
    }

    class MyThread
    {
        private int _number;

        public MyThread(int number)
        {
            _number = number;
        }

        public void Run()
        {
            Logger.Log(Level.Debug, _number.ToString(CultureInfo.InvariantCulture), _number.ToString(CultureInfo.InvariantCulture));
        }
    }
}
