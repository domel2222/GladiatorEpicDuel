using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiatorEpicDuels
{
    public class Combat 
    {
        private const double _minRange = 0.1;
        private const double _maxRange = 0.5;
        private BaseGladiator _firstGladiator { get; set; }
        private BaseGladiator _secondGladiator { get; set; }

        private double _probabilityHitFirst { get; set; }

        private double _probabilityHitSecond {get; set;}

        private string _stringFirst { get; set; } 

        private string _stringSecond { get; set; }

        private List<string> _listCombatLog = new List<string>();
        public Combat(List<BaseGladiator> gladiators)
        {
            if (Utilities.GetRandomValue() > 50)
            {
                _firstGladiator = gladiators[0];
                _secondGladiator = gladiators[1];
            }
            else
            {
                _firstGladiator = gladiators[1];
                _secondGladiator = gladiators[0];
            }
            _probabilityHitFirst = CalculateProbabilityHit(_firstGladiator.Dexterity, _secondGladiator.Dexterity);
            _probabilityHitSecond = CalculateProbabilityHit(_secondGladiator.Dexterity, _firstGladiator.Dexterity);
        }

        public BaseGladiator SimulationCombat()
        {
            bool fight = true;
            while(fight)
            {
                if (IsHit(_probabilityHitFirst))
                {
                    _firstGladiator.SpecialTechniqie();
                    var damage = GetDamage(_firstGladiator.Speed);
                    var roar = _firstGladiator.Roar();
                    _secondGladiator.DecreaseByHp(damage);

                    _stringFirst = ($"{_firstGladiator.ToString()}  inflicted damage: {damage} to {_secondGladiator.FullName}. {roar} ");
                    _listCombatLog.Add(_stringFirst);
                    
                    if (_secondGladiator.CurrentHp < 0)
                    {
                        _stringFirst = ($"{_secondGladiator.ToString()} died , {_firstGladiator.ToString()} WINS");
                        _listCombatLog.Add(_stringFirst);
                        _firstGladiator.HealUp();
                        _firstGladiator.LevelUp();
                        _firstGladiator.ComputeStat();
                        fight = false;
                        return _firstGladiator;
                    }
                }
                else
                {
                    _stringFirst = ($"{_firstGladiator.ToString()}  missed");
                    _listCombatLog.Add(_stringFirst);
                }
                
                if (IsHit(_probabilityHitSecond))
                {
                    _secondGladiator.SpecialTechniqie();
                    var damage = GetDamage(_secondGladiator.Speed);
                    var roar = _secondGladiator.Roar();
                    _firstGladiator.DecreaseByHp(damage);

                    _stringSecond = ($"{_secondGladiator.ToString()}  inflicted damage: {damage} to {_firstGladiator.FullName}. {roar} ");
                    _listCombatLog.Add(_stringSecond);
                    if (_firstGladiator.CurrentHp < 0) 
                    {
                        _stringSecond = ($"{_firstGladiator.ToString()} died , {_secondGladiator.ToString()} WINS");
                        _listCombatLog.Add(_stringSecond);
                        _secondGladiator.HealUp();
                        _secondGladiator.LevelUp();
                        _secondGladiator.ComputeStat();
                        fight = false;
                        return _secondGladiator;
                    }
                }
                else
                {
                    _stringSecond = ($"{_secondGladiator.ToString()}  missed");
                    _listCombatLog.Add(_stringSecond);
                }
            }
            return default;
        }

        private double CalculateProbabilityHit(double first, double second)
        {
            var distinction = first - second;
            double percent;
            if (distinction < 10)
            {
                percent = 10;
            }
            else if (distinction > 100)
            {
                percent = 100;
            }
            else
                percent = distinction;
            
            return percent;
        }

        private bool IsHit(double probability)
        {
            var hit = Utilities.GetRandomValue() <= probability;

            return hit;
        }

        private double GetDamage(double baseStat)
        {
            var cos = (Utilities.GetRandomDouble(_minRange, _maxRange));
            var damage = baseStat * cos;


            return Math.Round(damage, 1);
        }

        public List<string> GetListOfLogs()
        {
            return _listCombatLog;
        }
    }
}
