using System;
using System.Collections.Generic;
using System.Linq;
using XperiaRPG.Scripts.UI;

namespace XperiaRPG.Scripts.Attributes
{
    public class Skill : Attribute
    {
        public double Level { get; set; }
        public int PercentBonus { get; set; }
        
        public Skill(string name, double value, int percentBonus) : base(name, value)
        {
            PercentBonus = percentBonus;
            if (value >= 40)
            {
                Level = Math.Floor(Math.Sqrt(value) / 2) - 3;
            }
        }
    } 

    public class SkillList
    {
        private List<Skill> List { get; }

        public SkillList()
        {
            List = new List<Skill>
            {
                new Skill("Fishing", 0, 0),
                new Skill("Alchemy", 0, 0),
                new Skill("Herbalism", 0,0),
                new Skill("Cooking", 0, 0),
                new Skill("Mining", 0, 0),
                new Skill("Lthrworking", 0, 0),
                new Skill("Slayer", 0, 0),
                new Skill("Smithing",0 , 0),
                new Skill("Tailoring", 0, 0),
                
                new Skill("Bartering", 0, 0),
                new Skill("Seduction", 0, 0),
                new Skill("Traveling", 0, 0),
            };
        }

        public Skill Lookup(string name)
        {
            return List.Find(a => a?.Name == name);
        }

        public void AddXp(string name, int amount)
        {
            Lookup(name).Value += amount;
        }
        public void AddPercentBonus(string name, int amount)
        {
            Lookup(name).PercentBonus += amount;
        }

        public void Print(int columns)
        {
            var attributeList = List.Cast<Attribute>().ToList();

            Utility.PrintAttributes(attributeList, columns,33,"| {0,-11} LVL: {1,-2}  XP: {2,-7}");
        }
    }
}