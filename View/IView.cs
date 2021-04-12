using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiatorEpicDuels
{
    public interface IView
    {
        public void Display<T>(T arg);
    }
}
