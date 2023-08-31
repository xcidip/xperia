using System;
using System.Collections.Generic;
using System.Linq;
using XperiaRPG.Scripts.Attributes;
using XperiaRPG.Scripts.Character.Attributes;
using XperiaRPG.Scripts.Character.Player;
using XperiaRPG.Scripts.Character.Player.Inventory;

namespace XperiaRPG.Scripts.Items
{
    public class Weapon : Equipable
    {
        public string WeaponType { get; set; } // Melee,Ranged,Magic,Tool

        public Weapon(int requiredLevel, GearSlot gearSlot, string weaponType, string name,int price,
            string description, List<AttBonus> attributeBonusList, (ConsoleColor Foreground, ConsoleColor Background) colors)
            : base(requiredLevel, gearSlot, name, price,description, attributeBonusList, colors)
        {
            WeaponType = weaponType;
            switch (weaponType)
            {
                case "Melee":
                    Profession = "Warrior";
                    break;
                case "Magic":
                    Profession = "Mage";
                    break;
                case "Ranged":
                    Profession = "Hunter";
                    break;
            }
        }

        public override void Use(Player player)
        {
            // armor special effect
        }
        public new void Examine()
        {
            Console.Write($"Name: {Name}\n" +
                          $"Description: {Description}\n" +
                          $"Required level to equip: {RequiredLevel}\n" +
                          $"Weapon Type: {WeaponType}\n" +
                          $"It goes in {GearSlot} slot and only {Profession} profession can equip it\n" +
                          $"It sells for: {Price}gp\n" +
                          $"Bonuses: ");
            foreach (var attributeBonus in AttributeBonusList)
            {
                Console.Write($"{attributeBonus.Bonus()}, ");
            }

            Console.WriteLine();

        }
    }
}