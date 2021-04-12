using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading;

namespace GladiatorEpicDuels
{
    class Program
    {
        static void Main(string[] args)
        {
            int userValue;
            Utilities.LoadData();
            var view = new ConsoleView();
            Console.WriteLine("Welcome to Epic duel.");
            Console.WriteLine("Choose how many gladiators do you want create");
            Console.WriteLine("Remember that is amout must be power 2  eg.  2, 4, 8.....");
            Console.WriteLine("Your number .. : ");
            userValue = Convert.ToInt32(Console.ReadLine());
            while (!Utilities.powerOf2(userValue))
            {
                Console.WriteLine("Your value isn't power 2 ");
                Console.WriteLine("Your number .. : ");
                userValue = (Convert.ToInt32(Console.ReadLine()));
                
            }
            view.GetNumberBetween(userValue);

            Console.ReadKey();
        }
    }
}
