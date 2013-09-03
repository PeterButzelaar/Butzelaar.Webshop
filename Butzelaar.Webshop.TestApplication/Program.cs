using System;
using Butzelaar.Webshop.Database;
using Butzelaar.Webshop.Database.Entities.Webshop;

namespace Butzelaar.Webshop.TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new WebshopContext("datbenik!"))
            {
                var menus = context.Menus;

                var menu = new Menu { Name = "hallo! " };

                //context.Menus.Add(menu);
                context.SaveChanges();
            }

            Console.WriteLine("Klaar!");
            Console.ReadKey();
        }
    }
}
