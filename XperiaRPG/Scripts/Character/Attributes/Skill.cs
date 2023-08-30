using System;
using System.Collections.Generic;
using System.Linq;
using XperiaRPG.Scripts.Skills;
using XperiaRPG.Scripts.UI;
using Attribute = XperiaRPG.Scripts.Character.Attributes.Attribute;

namespace XperiaRPG.Scripts.Character.Attributes
{
    public class Skill : Attribute
    {
        public string Type { get; }

        
        public Skill(string type,string name, string shortName, int xp, int percentBonus, string description) : base(name, shortName, description)
        {
            PercentBonus = percentBonus;
            Type = type;
            Xp = xp;
        }
    }

    public class Skills
    {
        private List<Skill> List { get; } = new List<Skill>
        {
            new Skill("","PLAYER","PLR", 0, 0,"is used for overcoming gear, weapon,... requirements"),
                
            new Skill("Crafting","Cooking","Coo", 0, 0, "is for cooking food that could heal you out of combat"),
            new Skill("Crafting","Alchemy","Alc", 500, 0, "is about making potions"),
            new Skill("Crafting","Lthrworking","Lth", 0, 0, "is used for creating leather items"),
            new Skill("Crafting","Tailoring","Tlr", 0, 0, "is used crafting cloth gear"),
            new Skill("Crafting","Smithing","Smt",0 , 0, "is used crafting plate gear and weapons"),
                
            new Skill("Gathering","Fishing","Fsh", 0, 0, "is pretty self explanatory, you can also cook the fish"),
            new Skill("Gathering","Herbalism","Hrb", 0,0, "is about gathering plants and flowers for alchemy"),
            new Skill("Gathering","Mining","Mng", 0, 0, "is used for getting resources"),
            new Skill("Gathering","Skinning","Skn", 0, 0, "is used for getting leather from animals for leatherworking"),
            new Skill("Gathering","Slayer","Slr", 0, 0, "is about being a mercenary slaying monsters "),
                
            new Skill("Misc","Bartering","Brt", 0, 0, "is about trading with money"),
            new Skill("Misc","Seduction","Sdc", 0, 0, "is about seducing people for profit"),
            new Skill("Misc","Traveling","Trv", 0, 0, "is about increasing travel speed"),
        };

        public Skill Lookup(string name)
        {
            return List.Find(a => a?.Name == name);
        }

        public List<Skill> QueryByTypeList(string type)
        {
            return List.Where(a => a?.Type == type).ToList();
        }

        public void AddXp(string name, int amount)
        {
            var skill = Lookup(name);
            if (skill == null)
            {
                Console.WriteLine("skill doesn't exist");
                Choice.PressEnter();
                return;
            }
            Lookup(name).Xp += amount;
        }
        public void AddPercentBonus(string name, int amount)
        {
            var skill = Lookup(name);
            if (skill == null)
            {
                Console.WriteLine("skill doesn't exist");
                Choice.PressEnter();
                return;
            }
            Lookup(name).PercentBonus += amount;
        }
        public void Explain()
        {
            foreach (var skill in List)
            {
                Console.WriteLine($"{skill.ShortName} - {skill.Name} - {skill.Description}");
            }
        }
        public void Print()
        {
            var attributeList = List.Cast<Attribute>().ToList();

            Utility.PrintAttributes(attributeList,42,GlobalVariables.Columns,"skills", "| {0,-12} LVL: {1,-3} {4,-6} XP: {2,-8}");
        }
    }
}