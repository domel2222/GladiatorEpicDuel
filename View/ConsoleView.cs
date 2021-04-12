using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GladiatorEpicDuels
{
    public class ConsoleView : IView 
    {
        //private Colosseum _coloseum = new Colosseum();
        public void Display<T>(T arg)
        {
            if (arg is List<string>)
            {
                var list = arg as List<string>;
                foreach (var item in list)
                {
                    Thread.Sleep(400);
                    Console.WriteLine(item);
                    Console.WriteLine("----------------------");
                }
            }
            else if (arg is StringBuilder || arg is String)
            {
                Console.WriteLine(arg);
            }
            else
            {
                Console.WriteLine($"did not recognize {arg.GetType()}");
            }
        }
        public void GetNumberBetween(int numberOfGladiators)
        {
            var factory = new GladiatorFactory(); // na zewnatrz 
            var colossemu = new Colosseum(numberOfGladiators, factory); // tylko lista z gladiatorami 
            colossemu.SetView(this);
            colossemu.IsAGameThereAreVictims();
            colossemu.LetsGetReadyToRumble();
        }
    }
}
