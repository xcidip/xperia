using System;
using System.Collections.Generic;
using System.Linq;
using XperiaRPG.Scripts.UI;

namespace XperiaRPG.Scripts.Attributes
{
    public class Skill : Attribute
    {
        public new double Level { get; set; }
        
        public Skill(string name, string shortName, int xp, int percentBonus) : base(name, shortName, percentBonus)
        {
            Xp = xp;
            if (xp >= 40)
            {
                Level = Math.Floor(Math.Sqrt(xp) / 2) - 3;
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
                new Skill("Fishing","Fsh", 0, 0),
                new Skill("Alchemy","Alc", 0, 0),
                new Skill("Herbalism","Hrb", 0,0),
                new Skill("Cooking","Coo", 0, 0),
                new Skill("Mining","Mng", 0, 0),
                new Skill("Lthrworking","Lth", 0, 0),
                new Skill("Slayer","Slr", 0, 0),
                new Skill("Smithing","Smt",0 , 0),
                new Skill("Tailoring","Tlr", 0, 0),
                
                new Skill("Bartering","Brt", 0, 0),
                new Skill("Seduction","Sdc", 0, 0),
                new Skill("Traveling","Trv", 0, 0),
            };
        }

        public Skill Lookup(string name)
        {
            return List.Find(a => a?.Name == name);
        }

        public void AddXp(string name, int amount)
        {
            Lookup(name).Xp += amount;
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