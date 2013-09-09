using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
            //using (var context = new WebshopContext("datbenik!"))
            //{
                //var menus = context.Menus.ToList();

                //var menu = new Menu { Name = "hallo! " };

                //context.Menus.Add(menu);
                //context.SaveChanges();
            //}

            var list = new List<Thread>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(new Thread(new MyThread(i).Run));
            }
            list.ForEach(t => t.Start());
            Console.WriteLine("Klaar!");
            Console.ReadKey();
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
