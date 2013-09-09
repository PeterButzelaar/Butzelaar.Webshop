using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Transactions;
using Butzelaar.Generic.Logging;
using Butzelaar.Generic.Logging.Enumeration;
using Butzelaar.Webshop.Database;
using Butzelaar.Webshop.Database.Entities.Webshop;
using System.Threading;
using Butzelaar.Webshop.Repository.Webshop;

namespace Butzelaar.Webshop.TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var unitOfWork = new UnitOfWork("Peter");

            try
            {
                var menu = unitOfWork.MenuRepository.Get(m => m.Name.Contains("2"), m2 => m2.OrderBy(m3 => m3.Name),
                                                         "Parent");
            }
            finally
            {
                unitOfWork.Dispose();
            }
        }
    }
}
