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
        public Race(string name, string description, AttributeBonus attributeBonus, string lore) 
            :base(name)
        {
            Description = description;
            AttributeBonus = attributeBonus;
            Lore = lore;
        }
    }
    public class RaceList : ChoiceList
    {
        public RaceList()
        {

            List = new List<PlayerSetting>
            {
                new Race("Human", "Faithful human", new AttributeBonus("Agility",2, "points"),
                    "Lore about humans"),
                new Race("Gnome", "Ingenious gnome", new AttributeBonus("Intellect",2, "points"),
                    "Violets are blue, my friend's mind is ingenious, with gears and circuits, their brilliance continues."),
                new Race("Orc", "Bloodthirsty orc", new AttributeBonus("Strength",2, "points"),
                    "Lore about orcs"),
                new Race("Troll", "Mystic troll", new AttributeBonus("NatureRes",4, "points"),
                    "Lore about trolls")
            };
        }
    }
}