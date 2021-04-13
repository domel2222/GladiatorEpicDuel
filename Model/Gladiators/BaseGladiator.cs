using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiatorEpicDuels
{
    public abstract class BaseGladiator
    {

        public  bool IsDeath { get; protected set; }

        public  int Level { get; protected set; }
        public abstract string FullName { get; protected set; } 

        public abstract string SpecialTechniqueName { get; protected set; }
        public abstract double HpFactor { get; protected set; }
        public abstract double SpeedFactor { get; protected set; }
        public abstract double DexterityFactor { get; protected set; }
        public  double HP { get; protected set; }
        public  double Speed { get; protected set; }
        public  double BaseHp  { get; protected set; }
        public  double BaseSp  { get; protected set; }
        public  double BaseDex  { get; protected set; }
        public  double Dexterity {get; protected set; }
        public  double CurrentHp { get; protected set; }

        public abstract double TechniqueProbability { get; protected set; } 
        protected BaseGladiator(int hp, int lv, int sp, int dex)
        {
            Level = lv;
            BaseHp = hp;
            BaseSp = sp;
            BaseDex = dex;
            ComputeStat();
        }

        public  void LevelUp()
        {
            Level++;
        }

        public void DecreaseByHp(double hit)
        {
            CurrentHp -= hit;
        }

        public void HealUp()
        {
            CurrentHp = HP;
        }

        public void ComputeStat()
        {
            HP = BaseHp * Level * HpFactor;
            Speed = BaseHp * Level * SpeedFactor;
            Dexterity = BaseDex * Level * HpFactor;
            CurrentHp = HP;
        }
        public string Roar()
        {

            var roar = (Utilities.GetRandomMessage());

            return roar;
        }

        public override string ToString()
        {
            return ($"{this.GetType().Name} : {FullName}");
        }
        public abstract void  SpecialTechniqie();
    }
}
