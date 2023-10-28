using XperiaRPG.Scripts.UI;

namespace XperiaRPG.Scripts.Character.Attributes
{
    public abstract class Attribute
    {
        public string ShortName { get; }
        public string Name { get; }
        public int Points { get; set; }
        public int Level { get; set; }
        private int PreviousLevel { get; set; } = 0;

        private double _xp;
        public double Xp
        {
            get => _xp;
            set
            {
                if (value > 13034431) // if you reach this get a life. jk
                {
                    value = 13034431; // if someone reaches this legit way, I will lick their foot
                }
                _xp = value;
                Level = MathUtility.ConvertXpToLevel(_xp);

                if (Level > PreviousLevel)
                {
                    Cutscenes.NewLevel(Name, Level);
                    PreviousLevel = Level;
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
    
    public class AttBonus
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Unit { get; set; }

        public AttBonus(string name, int amount,string unit)
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