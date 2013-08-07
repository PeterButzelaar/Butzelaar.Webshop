using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Butzelaar.Webshop.Database;
using Butzelaar.Webshop.Database.Entities;

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
