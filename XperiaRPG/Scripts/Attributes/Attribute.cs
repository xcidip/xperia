using System;

namespace XperiaRPG.Scripts.Attributes
{
    public abstract class Attribute
    {
        public string Name { get; }
        public double Value { get; set; }
        public int Level { get; }

        protected Attribute(string name, double value)
        {
            Name = name;
            Value = value;
        }
    }
    
    public class AttributeBonus
    {
        public string Skill { get; set; }
        public int Amount { get; set; }
        public string Unit { get; set; }

        public AttributeBonus(string skill, int amount,string unit)
        {
            Unit = unit;   
            Skill = skill;
            Amount = amount;
        }

        public string Bonus()
        {
            var symbol = "+";
            if (Amount < 0) symbol = "";
            var text = symbol + Amount + " " + Unit + " to " + Skill;
            //Console.Write($"{symbol + Amount + " " + Unit + " to " + Skill,-27}");
            return text;
        }
    }
}