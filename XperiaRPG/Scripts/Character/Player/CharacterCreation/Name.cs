using System.Collections.Generic;
using XperiaRPG.Scripts.Attributes;
using XperiaRPG.Scripts.Character.Attributes;
using XperiaRPG.Scripts.CharacterCreation;

namespace XperiaRPG.Scripts.Character.Player.CharacterCreation
{
    public class Name : PlayerSetting
    {
        public Name(string name) : base(name){}
    }
    
    public class Suffix : PlayerSetting
    {

        public Suffix(string name, string description, AttBonus attBonus): base(name)
        {
            Description = description;
            AttBonus = attBonus;
        }
    }
    
    public class SuffixList : ChoiceList
    {
        public SuffixList()
        {
            List = new List<PlayerSetting>
            {

                // bad suffixes
                new Suffix("the Computer Guy", "sudo rm -rf / --no-preserve-root", new AttBonus("Strength", -2,"points")),
                new Suffix("the Turek", "Always has to sleep", new AttBonus("Intellect", -1,"points")),
                
                // stats bonuses
                new Suffix("the Hated", "Nobody likes you!", new AttBonus("Defense", 3, "points")),
                new Suffix("the Luffy", "I ate the Gum-Gum fruit", new AttBonus("Agility", 5, "points")),
                new Suffix("the Pyromancer", "You like looking at fire. You Arsonist!", new AttBonus("FireRes", 10,"points")),
                new Suffix("of the Earth", "groot, GROOT, gROoT", new AttBonus("FireRes", 10,"points")),
                new Suffix("the Frozone", "Honey, where's my super suit?", new AttBonus("NatureRes", 10,"points")),
                new Suffix("the Lich", "Master of dark and forbidden", new AttBonus("Intellect", 3,"points")),
                new Suffix("the Swords-master", "Chop chop, cut cut", new AttBonus("Strength", 4,"points")),
                new Suffix("the Tough guy", "Hulk Smash!", new AttBonus("Stamina", 3,"points")),

                // skill bonuses
                new Suffix("the Cook", "You know how to make your belly full", new AttBonus("Cooking", 30,"%")),
                new Suffix("the Brutal", "Crush skulls!!!", new AttBonus("Slayer", 30,"%")),
                new Suffix("the Havířov Miner", "Banik py*o", new AttBonus("Mining", 30,"%")),
                new Suffix("the Elite of TOS", "Master of the Industrial craft", new AttBonus("Smithing", 31,"%")),
                new Suffix("the Herbalist", "You know nature too good", new AttBonus("Herbalism", 30,"%")),
                
                // utility skill bonus`
                new Suffix("the Femboy", "Seductive as hell!", new AttBonus("Seduction", 30,"percent")), // seduction
                new Suffix("the Hoarder", "You know to talk with people", new AttBonus("Bartering", 30,"percent")), // bartering
                new Suffix("the Forest Gump", "Run, Forrest, run!", new AttBonus("Traveling", 50,"percent")), // traveling
            };
            
        }
    }
}