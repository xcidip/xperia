using System.Collections.Generic;
using XperiaRPG.Scripts.Character.Attributes;

namespace XperiaRPG.Scripts.Character.Player.CharacterCreation
{
    public class Race : PlayerSetting
    {
        public Race(string name, string description, AttBonus attBonus, string lore) 
            :base(name)
        {
            Description = description;
            AttBonus = attBonus;
            Lore = lore;
        }
    }
    public class RaceList : ChoiceList
    {
        public RaceList()
        {

            List = new List<PlayerSetting>
            {
                new Race("Human", "Faithful human", new AttBonus("Agility",2, "points"),
                    "Lore about humans"),
                new Race("Gnome", "Ingenious gnome", new AttBonus("Intellect",2, "points"),
                    "Violets are blue, my friend's mind is ingenious, with gears and circuits, their brilliance continues."),
                new Race("Orc", "Bloodthirsty orc", new AttBonus("Strength",2, "points"),
                    "Lore about orcs"),
                new Race("Troll", "Mystic troll", new AttBonus("NatureRes",4, "points"),
                    "Lore about trolls")
            };
        }
    }
    public class EnemyRaceList : ChoiceList
    {
        public EnemyRaceList()
        {

            List = new List<PlayerSetting>
            {
                new Race("Human", "Faithful human", new AttBonus("Agility",2, "points"),
                    "Lore about humans"),
                new Race("Gnome", "Ingenious gnome", new AttBonus("Intellect",2, "points"),
                    "Violets are blue, my friend's mind is ingenious, with gears and circuits, their brilliance continues."),
                new Race("Orc", "Bloodthirsty orc", new AttBonus("Strength",2, "points"),
                    "Lore about orcs"),
                new Race("Troll", "Mystic troll", new AttBonus("NatureRes",4, "points"),
                    "Lore about trolls"),
                new Race("Rodent", "", new AttBonus("NatureRes",2, "points"),
                    "Lore about rodents"),
                new Race("Goblin", "", new AttBonus("Agility",2, "points"),
                    "Lore about rodents"),
                new Race("Undead", "", new AttBonus("FrostRes",2, "points"),
                    "Lore about rodents"),
            };
        }
    }
}