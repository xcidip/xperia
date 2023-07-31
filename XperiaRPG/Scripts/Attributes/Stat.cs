using System.Collections.Generic;
using System.Linq;
using XperiaRPG.Scripts.UI;

namespace XperiaRPG.Scripts.Attributes
{
    public class Stat : Attribute
    {
        public int PercentBonus { get; set; }
        
        public Stat(string name, double value) : base(name, value)
        {
            PercentBonus = PercentBonus;
        }
    }
    
    public class StatList
    {
        private List<Stat> List { get; }

        public StatList(int stamina, int defense, int natureRes, int frostRes, int fireRes, int strength,int intellect, int agility, double luck)
        {
            List = new List<Stat>
            {
                new Stat("Stamina", stamina),
                new Stat("Defense", defense),
                new Stat("NatureRes", natureRes),
                new Stat("FrostRes", frostRes),
                new Stat("FireRes", fireRes),
                new Stat("Strength", strength),
                new Stat("Intellect", intellect),
                new Stat("Agility", agility),
                new Stat("Luck", luck),
            };
        }

        public Stat Lookup(string name)
        {
            return List.Find(a => a?.Name == name);
        }
        
        public void AddPercentBonus(string name, int amount)
        {
            Lookup(name).PercentBonus += amount;
        }

        public void Print(int columns)
        {
            var attributeList = List.Cast<Attribute>().ToList();

            Utility.PrintAttributes(attributeList, columns,16,"| {0,-9}: {2,-4}");
        }
    }
}