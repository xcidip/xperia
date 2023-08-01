using System;
using System.Collections.Generic;
using System.Linq;
using XperiaRPG.Scripts.Attributes;
using XperiaRPG.Scripts.Characters.Inventory;

namespace XperiaRPG.Scripts.Items
{
    public class Armor : Item
{
    public string ArmorType { get; set; } // Plate, Cloth, Leather

    public Armor(int quantity,int requiredLevel, GearSlot gearSlot, string armorType, string name,int price, string description, List<AttributeBonus> attributeBonusList) 
        :base(quantity,name,description, price)
    {
        RequiredLevel = requiredLevel;
        GearSlot = gearSlot;
        ArmorType = armorType;
        AttributeBonusList = attributeBonusList;
    }

    public override void Use()
    {
        //equip
    }
}

    public class ArmorDatabase : Database
{
    private List<Armor> List { get; set; }

    public ArmorDatabase()
    {
        List = new List<Armor>
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
                })
        };
    }

    public Armor Lookup(string name)
    {
        if (name == null) throw new ArgumentNullException(nameof(name));
        return List.FirstOrDefault(a => a?.Name == name);
            
    }
}
}