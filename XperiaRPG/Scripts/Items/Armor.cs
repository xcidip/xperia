using System;
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
            List<AttBonus> attributeBonusList, (ConsoleColor Foreground, ConsoleColor Background) colors)
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
    }
}