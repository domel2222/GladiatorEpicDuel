using System;
using System.ComponentModel;



namespace GladiatorEpicDuels
{
    public class Brutal : BaseGladiator
    {
        public Brutal(int hp, int lv, int sp, int dex) : base(hp, lv, sp, dex)
        {
        }
        public override string FullName { get; protected set; } = Utilities.GetRandomName();
        public override string SpecialTechniqueName { get; protected set; } = Utilities.GetRandomTechniqueName();
        public override double HpFactor { get; protected set; } = Convert.ToDouble(Utilities.GetAttributeOfType<DescriptionAttribute>(StatisticMultiplier.High).Description);
        public override double SpeedFactor { get; protected set; } = Convert.ToDouble(Utilities.GetAttributeOfType<DescriptionAttribute>(StatisticMultiplier.High).Description);
        public override double DexterityFactor { get; protected set; } = Convert.ToDouble(Utilities.GetAttributeOfType<DescriptionAttribute>(StatisticMultiplier.Low).Description);
        public override double TechniqueProbability { get; protected set; } = 0;


        public override void SpecialTechniqie()
        {
            
        }
    }
}
