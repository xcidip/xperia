using System.Collections.Generic;
using System.Linq;
using XperiaRPG.Scripts.UI;

namespace XperiaRPG.Scripts.Attributes
{
    public class Stat : Attribute
    {
        
        public Stat(string name, string shortName, int points, int percentBonus) : base(name, shortName, percentBonus)
        {
            
            Points = points;
        }
    }
    
    public class StatList
    {
        private List<Stat> List { get; }

        public StatList(int stamina, int defense, int natureRes, int frostRes, int fireRes, int strength,int intellect, int agility, int luck)
        {
            List = new List<Stat>
            {
                new Stat("Stamina","Stm", stamina, 0),
                new Stat("Defense","Def", defense, 0),
                new Stat("Strength","Str", strength, 0),
                new Stat("Intellect","Int", intellect, 0),
                new Stat("Agility","Agi", agility, 0),
                new Stat("NatureRes","NaR", natureRes, 0),
                new Stat("FrostRes","FrR", frostRes, 0),
                new Stat("FireRes","FiR", fireRes, 0),
                new Stat("Luck","Lck", luck, 0),
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

        public void AddPoints(string name, int amount)
        {
            Lookup(name).Points += amount;
        }

        public void Print(int columns)
        {
            var attributeList = List.Cast<Attribute>().ToList();

            Utility.PrintAttributes(attributeList, columns,16,"| {0,-9}: {3,-4}");
        }
    }
}