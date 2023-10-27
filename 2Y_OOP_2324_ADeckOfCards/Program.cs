using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Y_OOP_2324_ADeckOfCards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Startup();

            Console.ReadKey();
        }

        static void Startup()
        {
            _21Game game = new _21Game();
        }
    }
}
