using System.Collections.Generic;
using System.Linq;
using XperiaRPG.Scripts.UI;

namespace XperiaRPG.Scripts.Attributes
{
    public class Stat : Attribute
    {
        
        public Stat(string name, string shortName, int points) : base(name, shortName)
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
                //offense
                new Stat("Strength","Str", strength),
                new Stat("Intellect","Int", intellect),
                new Stat("Agility","Agi", agility),

                //defense
                new Stat("Stamina","Stm", stamina),
                new Stat("Defense","Def", defense),
                new Stat("NatureRes","NaR", natureRes),
                new Stat("FrostRes","FrR", frostRes),
                new Stat("FireRes","FiR", fireRes),
                
                //both
                new Stat("Luck","Lck", luck),
            };
        }

        public Stat Lookup(string name)
        {
            return List.Find(a => a?.Name == name);
        }
        
        public void AddPoints(string name, int amount)
        {
            Lookup(name).Points += amount;
        }

        public void Print(int columns)
        {
            var attributeList = List.Cast<Attribute>().ToList();

            Utility.PrintAttributes(attributeList, columns,16,"STATS","| {0,-9}: {3,-4}");
        }
    }
}
