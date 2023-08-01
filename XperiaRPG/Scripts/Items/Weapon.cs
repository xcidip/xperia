using System;
using System.Collections.Generic;
using System.Linq;
using XperiaRPG.Scripts.Attributes;
using XperiaRPG.Scripts.Characters.Inventory;

namespace XperiaRPG.Scripts.Items
{
    public class Weapon : Item
    {
        public string WeaponType { get; set; } // Plate, Cloth, Leather

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
        private List<Weapon> List { get; set; }

        public WeaponDatabase()
        {
            List = new List<Weapon>
            {
                new Weapon(1, 0, GearSlot.MainHand, "Sword", "Arnold's Sword",150, "Best of the swords",
                    new List<AttributeBonus>()
                    {
                        new AttributeBonus("Strength", 3, "points"),
                        new AttributeBonus("", 2, "points"),
                        new AttributeBonus("Agility", 1, "points")
                    }),
                new Weapon(1, 0, GearSlot.OffHand, "Shield", "Arnold's test",150, "Best of the helms",
                    new List<AttributeBonus>()
                    {
                        new AttributeBonus("Defense", 3, "points"),
                        new AttributeBonus("Agility", 4, "points")
                    }),
                new Weapon(1, 0, GearSlot.MainHand, "Staff", "Arnold's Legplates",150, "Best of the legs",
                    new List<AttributeBonus>()
                    {
                        new AttributeBonus("Strength", 2, "points"),
                        new AttributeBonus("Defense", 4, "points"),
                        new AttributeBonus("Agility", 2, "points")
                    }),
                new Weapon(1, 0, GearSlot.MainHand, "Bow", "Arnold's Helmut",150, "Best of the helms",
                    new List<AttributeBonus>()
                    {
                        new AttributeBonus("Defense", 3, "points"),
                        new AttributeBonus("Agility", 4, "points")
                    }),
                new Weapon(1, 0, GearSlot.OffHand, "Pickaxe", "Arnold's test",150, "Best of the helms",
                    new List<AttributeBonus>()
                    {
                        new AttributeBonus("Defense", 3, "points"),
                        new AttributeBonus("Agility", 4, "points")
                    }),
                new Weapon(1, 0, GearSlot.MainHand, "Fishing Rod", "Arnold's test",100, "Best of the helms",
                    new List<AttributeBonus>()
                    {
                        new AttributeBonus("Defense", 3, "points"),
                        new AttributeBonus("Agility", 4, "points")
                    }),
            };
        }

        public Weapon Lookup(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            return List.FirstOrDefault(a => a?.Name == name);

        }
    }
}