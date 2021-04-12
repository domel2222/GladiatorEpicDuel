using System;
using System.ComponentModel;


namespace GladiatorEpicDuels
{
    public class Assassin : BaseGladiator
    {
        public Assassin(int hp, int lv, int sp, int dex) : base(hp, lv, sp, dex)
        {
        }

        public override bool IsDeath { get; protected set; }
        public override int Level { get; protected set; }
        public override string FullName { get; protected set; } = Utilities.GetRandomName();
        public override string SpecialTechniqueName { get; protected set; } = Utilities.GetRandomTechniqueName();
        public override double HpFactor { get; protected set; } = Convert.ToDouble(Utilities.GetAttributeOfType<DescriptionAttribute>(StatisticMultiplier.Low).Description);
        public override double SpeedFactor { get; protected set; } = Convert.ToDouble(Utilities.GetAttributeOfType<DescriptionAttribute>(StatisticMultiplier.High).Description);
        public override double DexterityFactor { get; protected set; } = Convert.ToDouble(Utilities.GetAttributeOfType<DescriptionAttribute>(StatisticMultiplier.High).Description);
        public override double HP { get; protected set; }
        public override double Speed { get; protected set; }
        public override double Dexterity { get; protected set; }
        public override double CurrentHp { get; protected set; }
        public override double TechniqueProbability { get; protected set; } = 0;
        public override double BaseHp { get; protected set; }
        public override double BaseSp { get; protected set; }
        public override double BaseDex { get; protected set; }

        public override void SpecialTechniqie()
        {
            
        }
    }
}
