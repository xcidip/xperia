using System;
using System.Collections.Generic;
using System.Linq;
using XperiaRPG.Scripts.Attributes;
using XperiaRPG.Scripts.Character.Attributes;
using XperiaRPG.Scripts.Character.Player.CharacterCreation;
using XperiaRPG.Scripts.Characters;

namespace XperiaRPG.Scripts.CharacterCreation
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
}