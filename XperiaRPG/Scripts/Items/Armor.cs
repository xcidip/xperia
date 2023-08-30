﻿using System;
using System.Collections.Generic;
using System.Linq;
using XperiaRPG.Scripts.Attributes;
using XperiaRPG.Scripts.Character.Attributes;
using XperiaRPG.Scripts.Character.Player;
using XperiaRPG.Scripts.Character.Player.Inventory;

namespace XperiaRPG.Scripts.Items
{
    public class Armor : Equipable
    {
        public string ArmorType { get; set; } // Plate, Cloth, Leather

        public Armor(int requiredLevel, GearSlot gearSlot, string armorType, string name, int price, string description,
            List<AttributeBonus> attributeBonusList, (ConsoleColor Foreground, ConsoleColor Background) colors)
            : base(requiredLevel, gearSlot, name, price, description, attributeBonusList, colors)
        {
            ArmorType = armorType;
            switch (armorType)
            {
                case "Plate":
                    Profession = "Warrior";
                    break;
                case "Cloth":
                    Profession = "Mage";
                    break;
                case "Leather":
                    Profession = "Hunter";
                    break;
            }
        }

        public override void Use(Player player)
        {
            //equip
        }

        public class ArmorItemList : ItemList
        {

            public ArmorItemList()
            {
                List = new List<Item>
                {
                    new Armor(0, GearSlot.Chest, "Cloth", "Wizard's Coat", 200, "Belonged to an old wizard once",
                        new List<AttributeBonus>()
                        {
                            new AttributeBonus("Intellect", 3, "points"),
                            new AttributeBonus("Defense", 2, "points"),
                            new AttributeBonus("Agility", 1, "points")
                        }, Rarity.Uncommon),
                    new Armor(0, GearSlot.Legs, "Cloth", "Wizard's Skirt", 200, "Belonged to an old wizard once",
                        new List<AttributeBonus>()
                        {
                            new AttributeBonus("Intellect", 2, "points"),
                            new AttributeBonus("Defense", 4, "points"),
                            new AttributeBonus("Agility", 2, "points")
                        }, Rarity.Uncommon),
                    new Armor(0, GearSlot.Head, "Cloth", "Wizard's Hat", 200, "Belonged to an old wizard once",
                        new List<AttributeBonus>()
                        {
                            new AttributeBonus("Defense", 3, "points"),
                            new AttributeBonus("Intellect", 4, "points")
                        }, Rarity.Uncommon),
                    new Armor(0, GearSlot.Head, "Cloth", "Arnold's test", 9999, "Belonged to an old wizard once",
                        new List<AttributeBonus>()
                        {
                            new AttributeBonus("Mining", 13034431, "xp"),
                            new AttributeBonus("Intellect", 4, "points")
                        }, Rarity.Uncommon),
                };
            }
        }
    }
}