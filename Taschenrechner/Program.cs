using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Das ist mein Taschenrechner, Gebe einen Term ein");
            while (true)
            {
                Calculator.Calculate(Console.ReadLine());
            }
        }
    }

}
