using Schapi;
using Schapi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schapi_Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            var api = new SchoolAPI
            (
                SchoolAPI.Kind.HIGH,
                SchoolAPI.Region.DAEJEON,
                "G100000170"
            );

            Console.WriteLine(api.GetMonthlyMenus(2018, 5)[23].BreakfastString);
            foreach (var menu in api.GetMonthlyMenus(2018, 5)[23].Lunch)
            {
                Console.WriteLine(menu);
            }
        }
    }
}
