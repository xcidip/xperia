using System;

namespace XperiaRPG.Scripts.Attributes
{
    public abstract class Attribute
    {
        public string ShortName { get; }
        public string Name { get; }
        public int Points { get; set; }
        public int Xp{ get; set; }
        public int PercentBonus { get; set; }
        public double Value{ get; set; }

        protected Attribute(string name, string shortName, int percentBonus)
        {
            ShortName = shortName;
            PercentBonus = percentBonus;
            Name = name;
        }
    }
    
    public class AttributeBonus
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Unit { get; set; }

        public AttributeBonus(string name, int amount,string unit)
        {
            Unit = unit;   
            Name = name;
            Amount = amount;
        }

        public string Bonus()
        {
            var symbol = "+";
            if (Amount < 0) symbol = "";
            var text = symbol + Amount + " " + Unit + " to " + Name;
            //Console.Write($"{symbol + Amount + " " + Unit + " to " + Skill,-27}");
            return text;
        }
    }
}