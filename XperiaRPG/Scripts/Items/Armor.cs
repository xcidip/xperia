using System;
using System.Collections.Generic;
using System.Linq;
using XperiaRPG.Scripts.Attributes;
using XperiaRPG.Scripts.Character.Player.Inventory;

namespace XperiaRPG.Scripts.Items
{
    public class Armor : Equipable
{
    public string ArmorType { get; set; } // Plate, Cloth, Leather

    public Armor(int quantity,int requiredLevel, GearSlot gearSlot, string armorType, string name,int price, string description, List<AttributeBonus> attributeBonusList) 
        :base(quantity,requiredLevel,gearSlot,name,price,description, attributeBonusList)
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

    public override void Use()
    {
        //equip
    }
    public override void Examine()
    {
        Console.Write($"Name: {Name}\n" +
                      $"Description: {Description}\n" +
                      $"Quantity: {Quantity}x\n" +
                      $"Required level to equip: {RequiredLevel}\n" +
                      $"Armor Type: {ArmorType}\n" +
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

    public class ArmorItemList : ItemList
    {

        public ArmorItemList()
        {
            List = new List<Item>
            {
                new Armor(1,0, GearSlot.Chest, "Cloth", "Wizard's Coat",200, "Belonged to an old wizard once", 
                    new List<AttributeBonus>() {
                        new AttributeBonus("Intellect", 3, "points"),
                        new AttributeBonus("Defense", 2, "points"),
                        new AttributeBonus("Agility", 1, "points")
                    }),
                new Armor(1,0, GearSlot.Legs, "Cloth", "Wizard's Skirt",200, "Belonged to an old wizard once",
                    new List<AttributeBonus>() {
                        new AttributeBonus("Intellect", 2, "points"),
                        new AttributeBonus("Defense", 4, "points"),
                        new AttributeBonus("Agility", 2, "points")
                    }),
                new Armor(1,0, GearSlot.Head, "Cloth", "Wizard's Hat",200, "Belonged to an old wizard once",
                    new List<AttributeBonus>() {
                        new AttributeBonus("Defense", 3, "points"),
                        new AttributeBonus("Intellect", 4, "points")
                    }),
            };
        }
    }
}