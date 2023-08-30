using System;

namespace XperiaRPG.Scripts.Attributes
{
    public abstract class Attribute
    {
        public string ShortName { get; }
        public string Name { get; }
        public int Points { get; set; }
        public double Level { get; set; }

        private int _xp;
        public int Xp
        {
            get => _xp;
            set
            {
                _xp = value;
                if (_xp >= 40)
                {
                    Level = Math.Floor(Math.Sqrt(_xp) / 2) - 3;
                }
                else
                {
                    Level = 1;
                }
            }
        }
        public int PercentBonus { get; set; }
        public double Value{ get; set; }
        public string Description { get; set; }

        protected Attribute(string name, string shortName, string description)
        {
            ShortName = shortName;
            Name = name;
            Description = description;
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
            return text;
        }
    }
}