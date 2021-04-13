using System;
using System.ComponentModel;
namespace GladiatorEpicDuels
{
    public class Elf : BaseGladiator
    {
        public Elf(int hp, int lv, int sp, int dex) : base(hp, lv, sp, dex)
        {
        }

        public override string FullName { get; protected set; } = "Legolas";
        public override string SpecialTechniqueName { get; protected set; } = "Sniper Rifle : Head shot";
        public override double HpFactor { get; protected set; } = Convert.ToDouble(Utilities.GetAttributeOfType<DescriptionAttribute>(Utilities.RandomEnum<StatisticMultiplier>()).Description);
        public override double SpeedFactor { get; protected set; } = Convert.ToDouble(Utilities.GetAttributeOfType<DescriptionAttribute>(Utilities.RandomEnum<StatisticMultiplier>()).Description);
        public override double DexterityFactor { get; protected set; } = Convert.ToDouble(Utilities.GetAttributeOfType<DescriptionAttribute>(Utilities.RandomEnum<StatisticMultiplier>()).Description);

        public override double TechniqueProbability { get; protected set; } = 50;


        public override void SpecialTechniqie()
        {
            if (Utilities.GetRandomValue() < TechniqueProbability)
            {


                Console.WriteLine("technique activate");
                Speed += 1000;
                Console.WriteLine(SpecialTechniqueName);
                
                //need decrease after shot
            }
            else
            {
                
            }

        }
        

    }
}
