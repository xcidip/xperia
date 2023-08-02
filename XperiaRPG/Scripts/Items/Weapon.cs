﻿using System;
using System.Collections.Generic;
using System.Linq;
using XperiaRPG.Scripts.Attributes;
using XperiaRPG.Scripts.Character.Player.Inventory;
using XperiaRPG.Scripts.Characters.Inventory;

namespace XperiaRPG.Scripts.Items
{
    public class Weapon : Item
    {
        public string WeaponType { get; set; } // Melee,Ranged,Magic,Tool

        public Weapon(int quantity, int requiredLevel, GearSlot gearSlot, string weaponType, string name,int price,
            string description, List<AttributeBonus> attributeBonusList)
            : base(quantity, name, description, price)
        {
            RequiredLevel = requiredLevel;
            GearSlot = gearSlot;
            WeaponType = weaponType;
            AttributeBonusList = attributeBonusList;
        }

        public override void Use()
        {
            // armor special effect
        }
    }
    
    public class WeaponDatabase : Database
    {


        public WeaponDatabase()
        {
            List = new List<Item>
            {
                new Weapon(1, 0, GearSlot.MainHand, "Melee", "Arnold's Sword",150, "Best of the swords",
                    new List<AttributeBonus>()
                    {
                        new AttributeBonus("Strength", 4, "points"),
                        new AttributeBonus("Defense", 2, "points"),
                    }),
                new Weapon(1, 0, GearSlot.OffHand, "Melee", "Arnold's Iron Shield",150, "Best of the iron shields",
                    new List<AttributeBonus>()
                    {
                        new AttributeBonus("Defense", 4, "points"),
                        new AttributeBonus("NatureRes", 3, "points"),
                    }),
                new Weapon(1, 0, GearSlot.MainHand, "Magic", "Arnold's Staff",150, "Best of the staffs",
                    new List<AttributeBonus>()
                    {
                        new AttributeBonus("Intellect", 4, "points"),
                        new AttributeBonus("Defense", 2, "points"),
                    }),
                new Weapon(1, 0, GearSlot.OffHand, "Magic", "Arnold's Tome",150, "Best of the Tomes",
                    new List<AttributeBonus>()
                    {
                        new AttributeBonus("Intellect", 5, "points"),
                    }),
                new Weapon(1, 0, GearSlot.Pickaxe, "Tool", "Arnold's Pickaxe",150, "Best of the Pickaxes",
                    new List<AttributeBonus>()
                    {
                        new AttributeBonus("Mining", 5, "%"),
                    }),
                new Weapon(1, 0, GearSlot.FishingRod, "Tool", "Arnold's FishingRod",100, "Best of the FishingRods",
                    new List<AttributeBonus>()
                    {
                        new AttributeBonus("Fishing", 5, "%"),
                    }),
            };
        }

    }
}