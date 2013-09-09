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
            Menu parent = null;

            using (var context = new WebshopContext())
            {
                parent = context.Menus.FirstOrDefault(m => m.Id == new Guid("A1938473-2CCB-4A24-8E55-C503B1FCD5F6"));
            }
            using (var scope = new TransactionScope())
            {
                using (var context = new WebshopContext())
                {
                    parent = context.Menus.FirstOrDefault(m => m.Id == new Guid("A1938473-2CCB-4A24-8E55-C503B1FCD5F6"));

                    context.Menus.Add(new Menu
                        {
                            Name = "test1",
                            Parent = parent
                        });

                    context.SaveChanges();
                }

                /*using (var context = new WebshopContext())
                {
                context.Menus.Add(new Menu
                        {
                            Name = "test2"
                        });

                    context.SaveChanges();
                }*/
                scope.Complete();
            }

            var list = new List<Thread>();

            using (var scope = new TransactionScope())
            {
                for (int i = 0; i < 10; i++)
                {
                    //Logger.Log(Level.Fatal, "meh");
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
