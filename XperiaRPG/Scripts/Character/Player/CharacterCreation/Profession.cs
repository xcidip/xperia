using System;
using System.Collections.Generic;
using System.Linq;
using XperiaRPG.Scripts.Attributes;
using XperiaRPG.Scripts.Character.Attributes;
using XperiaRPG.Scripts.CharacterCreation;

namespace XperiaRPG.Scripts.Character.Player.CharacterCreation
{
    public class Profession : PlayerSetting
{ 
    public Profession(string name, string description, string armorType, AttBonus attBonus, string howToPlay) 
        : base(name)
    {
        Description = description;
        ArmorType = armorType;
        AttBonus = attBonus;
        ArmorType = armorType;
        HowToPlay = howToPlay;
    }
}
public class ProfessionList : ChoiceList
{
    public ProfessionList()
    {

        List = new List<PlayerSetting>
        {
            new Profession("Warrior", "Slam, Block, Execute", "Plate", new AttBonus("Strength",10, "points"),
                "Warriors goal is to outlive the opponent." +
                "\nYou are not doing much damage but you can survive a lot of it" +
                "\nOnly thing you can equip is a one handed SWORD and a SHIELD" +
                "\nTo do more damage, your best bet is to have a lot of STRENGTH stat." +
                "\nYour primary stats are STRENGTH and STAMINA which increases your health pool."+
                "\nYou are now a true warrior, and you have to represent them in a good way so"+
                "\nyou can only wear PLATE armor from now on"),
            new Profession("Mage", "Fireball, Frost bolt", "Cloth", new AttBonus("Intellect",10, "points"),
                "The Mage's goal is to swiftly eliminate enemies before they can cause harm." +
                "\nUnlike warriors, Mages prioritize dealing significant damage over survivability." +
                "\nAs a Mage, you wield a powerful STAFF to unleash devastating spells" +
                "\nYour primary stat is INTELLIGENCE, which enhances your magical prowess" +
                "\nLike every mage you are equipped with CLOTH armor, which is not very defensive"+
                "\nbut focuses more on mobility and better magical energy flow"),
            new Profession("Hunter", "Guns, Bows, Crossbows", "Leather", new AttBonus("Agility",10, "points"),
                "The Hunter's goal is to swiftly eliminate enemies while evading their attacks." +
                "\nUnlike warriors, Hunters prioritize AGILITY and damage over pure survivability." +
                "\nAs a Hunter, you are equipped with LEATHER armor and have a variety of RANGED weapons" +
                "\nat your disposal, including guns, bows, and crossbows." +
                "\nYour primary stat is Agility, which enhances your damage, and ability to dodge")
        };
        }
    }
}