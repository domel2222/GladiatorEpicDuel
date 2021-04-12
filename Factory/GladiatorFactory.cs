using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiatorEpicDuels
{
    public class GladiatorFactory
    {


        private List<BaseGladiator> ListOfGladiators { get; set; } =  new List<BaseGladiator>();

        private const int _minRangeLv = 1;
        private const int _maxRangeLv = 5;
        private const int _minRangeAbility = 25;
        private const int _maxRangeAbility = 100;

        public List<BaseGladiator> CreateGladiatrosWhatAmountYouWant(int numberOfgladiators)
        {
            for (int i = 0; i < numberOfgladiators; i++)
            {
                GenerateRandomGladiator();
            }
            return GetListOfGladiators();
        }

        private void GenerateRandomGladiator()
        {
            var gladiator = Utilities.RandomEnum<GladiatorsEnumList>();
            var  level = Utilities.GetRandomValue(_minRangeLv, _maxRangeLv);
            var hp  = Utilities.GetRandomValue(_minRangeAbility, _maxRangeAbility);
            var sp  = Utilities.GetRandomValue(_minRangeAbility, _maxRangeAbility);
            var dex = Utilities.GetRandomValue(_minRangeAbility, _maxRangeAbility);

            switch ((int)gladiator)
            {
                case 0:
                    ListOfGladiators.Add(new Archer(hp, level, sp, dex));
                    break;
                case 1:
                    ListOfGladiators.Add(new Assassin(hp, level, sp, dex));
                    break;
                case 2:
                    ListOfGladiators.Add(new Brutal(hp, level, sp, dex));
                    break;
                case 3:
                    ListOfGladiators.Add(new Elf(hp, level, sp, dex));
                    break;
                case 4:
                    ListOfGladiators.Add(new Geo(hp, level, sp, dex));
                    break;
                case 5:
                    ListOfGladiators.Add(new GLord(hp, level, sp, dex));
                    break;
                case 6:
                    ListOfGladiators.Add(new JednoU(hp, level, sp, dex));
                    break;
                case 7:
                    ListOfGladiators.Add(new Destroyer(hp, level, sp, dex));
                    break;
                case 8:
                    ListOfGladiators.Add(new Geo(hp, level, sp, dex));
                    break;
            }

        }
        private List<BaseGladiator> GetListOfGladiators()
        {
            return ListOfGladiators;
        }
    }
}
