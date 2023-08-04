using System;
using System.Collections.Generic;
using System.Linq;
using XperiaRPG.Scripts.Skills;
using XperiaRPG.Scripts.UI;

namespace XperiaRPG.Scripts.Attributes
{
    public class Skill : Attribute
    {
        public double Level { get; set; }
        
        public Skill(string name, string shortName, int xp, int percentBonus, string description) : base(name, shortName, description)
        {
            PercentBonus = percentBonus;
            Xp = xp;
            if (xp >= 40)
            {
                Level = Math.Floor(Math.Sqrt(xp) / 2) - 3;
            }
        }
    } 

    public class Skills
    {
        private List<Skill> List { get; }
        public Cooking Cooking { get; set; }

        public Skills()
        {
            List = new List<Skill>
            {
                new Skill("PLAYER","PLR", 0, 0,"is used for overcoming gear, weapon,... requirements"),
                new Skill("Fishing","Fsh", 0, 0, "is pretty self explanatory, you can also cook the fish"),
                new Skill("Alchemy","Alc", 0, 0, "is about making potions"),
                new Skill("Herbalism","Hrb", 0,0, "is about gathering plants and flowers for alchemy"),
                new Skill("Cooking","Coo", 0, 0, "is for cooking food that could heal you out of combat"),
                new Skill("Mining","Mng", 0, 0, "is used for getting resources"),
                new Skill("Lthrworking","Lth", 0, 0, "is used for creating leather items"),
                new Skill("Skinning","Skn", 0, 0, "is used for getting leather from animals for leatherworking"),
                new Skill("Slayer","Slr", 0, 0, "is about being a mercenary slaying monsters "),
                new Skill("Smithing","Smt",0 , 0, "is used crafting plate gear and weapons"),
                new Skill("Tailoring","Tlr", 0, 0, "is used crafting cloth gear"),
                
                new Skill("Bartering","Brt", 0, 0, "is about trading with money"),
                new Skill("Seduction","Sdc", 0, 0, "is about seducing people for profit"),
                new Skill("Traveling","Trv", 0, 0, "is about increasing travel speed"),
            };
            
            Cooking = new Cooking();
            // todo add more skills
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
        public void Explain()
        {
            foreach (var skill in List)
            {
                Console.WriteLine($"{skill.ShortName} - {skill.Name} - {skill.Description}");
            }
        }
        public void Print(int columns)
        {
            var attributeList = List.Cast<Attribute>().ToList();

            Utility.PrintAttributes(attributeList, columns,42,"skills", "| {0,-12} LVL: {1,-3} {4,-6} XP: {2,-7} ");
        }
    }
}