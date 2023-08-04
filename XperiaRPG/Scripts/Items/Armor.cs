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
            new Armor(1,0, GearSlot.Chest, "Plate", "Arnold's Chestplate",200, "Best of the chests", 
                new List<AttributeBonus>() {
                    new AttributeBonus("Strength", 3, "points"),
                    new AttributeBonus("Defense", 2, "points"),
                    new AttributeBonus("Agility", 1, "points")
                }),
            new Armor(1,0, GearSlot.Legs, "Leather", "Arnold's Legplates",200, "Best of the legs",
                new List<AttributeBonus>() {
                    new AttributeBonus("Strength", 2, "points"),
                    new AttributeBonus("Defense", 4, "points"),
                    new AttributeBonus("Agility", 2, "points")
                }),
            new Armor(1,0, GearSlot.Head, "Cloth", "Arnold's Helmut",200, "Best of the helms",
                new List<AttributeBonus>() {
                    new AttributeBonus("Defense", 3, "points"),
                    new AttributeBonus("Agility", 4, "points")
                }),
            new Armor(1,0, GearSlot.Head, "Cloth", "Arnold's test",9999, "Best of the helms",
                new List<AttributeBonus>() {
                    new AttributeBonus("Defense", 1000, "points"),
                    new AttributeBonus("Mining", 5000, "xp")
                }),
        };
    }

    }
}