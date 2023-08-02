using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XperiaRPG.Scripts.Attributes;
using XperiaRPG.Scripts.Character.Player.Inventory;

namespace XperiaRPG.Scripts.Items
{
    public class Equipable : Item
    {
        public Equipable(int quantity, int requiredLevel, GearSlot gearSlot, string name, int price,
            string description, List<AttributeBonus> attributeBonusList)
            : base(quantity, name, description, price)
        {
            RequiredLevel = requiredLevel;
            GearSlot = gearSlot;
            AttributeBonusList = attributeBonusList;
            Profession = "all";
        }

        public override void Use()
        {
            // special effect
        }
        public override void Examine()
        {
            Console.Write($"Name: {Name}\n" +
                              $"Description: {Description}\n" +
                              $"Quantity: {Quantity}x\n" +
                              $"Required level to equip: {RequiredLevel}\n" +
                              $"It goes in {GearSlot} slot\n" +
                              $"It sells for: {Price}gp\n" +
                              $"Bonuses: ");
            foreach (var attributeBonus in AttributeBonusList)
            {
                Console.Write($"{attributeBonus.Bonus()}, ");
            }

            Console.WriteLine();
            
        }
    }


    public class ToolListOfItems : ListOfItems
    {
        public ToolListOfItems()
        {
            List = new List<Item>
            {
                new Equipable(1, 0, GearSlot.Pickaxe, "Arnold's Pickaxe",150, "Best of the Pickaxes",
                    new List<AttributeBonus>()
                    {
                        new AttributeBonus("Mining", 5, "%"),
                    }),
                new Equipable(1, 0, GearSlot.FishingRod, "Arnold's FishingRod",100, "Best of the FishingRods",
                    new List<AttributeBonus>()
                    {
                        new AttributeBonus("Fishing", 5, "%"),
                    }),
                new Equipable(1, 0, GearSlot.Mount, "Arnold's Horse",500, "Best of the FishingRods",
                    new List<AttributeBonus>()
                    {
                        new AttributeBonus("Traveling", 10, "%"),
                    }),
            };
        }
    }



}
