using System;
using System.Collections.Generic;
using XperiaRPG.Scripts.Items;

namespace XperiaRPG.Scripts.Items
{
    public abstract class Potion : Item
    {
        public int Potency { get; set; }
        public string Effect { get; set; }

        protected Potion(int quantity, string name, int price, string description, int potency) 
            : base(quantity,name, description, price)
        {
            Potency = potency;
        }

        public abstract override void Use();

        public override void Examine()
        {
            Console.Write($"Name: {Name}\n" +
                          $"Description: {Description}\n" +
                          $"Quantity: {Quantity}x\n" +
                          $"Required level to equip: {RequiredLevel}\n" +
                          $"Effect: {Effect}\n" +
                          $"Potency: {Potency}" +
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

    public class PotionItemList : ItemList
    {
        public PotionItemList()
        {
            List = new List<Item>
            {
                new HealingPotion(1,"Small HP potion","Heals for a small amount of health",20,10),
                new HealingPotion(1,"Medium HP potion","Medium health potion for medium health pool",40,50),
                new HealingPotion(1,"Large HP potion","Big boy healing",100,200),
            };
        }
    }
}

public class HealingPotion : Potion
{
    public HealingPotion(int quantity, string name, string description, int potency, int price)
        : base(quantity, name, price, description,  potency)
    {
        Effect = "healing";
    }

    public override void Use()
    {
        // Heal the user 
    }
}
/*

public class DamagingPotion : Potion
{
    public DamagingPotion(int id, int quantity, string name, string description, int potency, string effect) : base(id,
        quantity, name, description, potency, effect)
    {
        Name = name;
        Description = description;
        Effect = "Damaging";
    }

    public override void Use()
    {
        // Damage the enemy
    }
}

public class TeleportPotion : Potion
{

    public TeleportPotion(int id, int quantity, string name, string description, int potency, string effect) : base(id,
        quantity, name, description, potency, effect)
    {
        Name = name;
        Description = description;
        Effect = "Teleport";
    }

    public override void Use()
    {
        // Teleports the player to their base / city
    }
}

// template for resistance potions
public class ResistPotion : Potion
{
    public string ResistanceType { get; set; }
    public int Duration { get; set; }

    public ResistPotion(int id, int quantity, string name, string description, string resistanceType, int potency,
        int duration, string effect) : base(id, quantity, name, description, potency, effect)
    {
        Effect = "Resistance";
        Name = name;
        Description = description;
        ResistanceType = resistanceType;
        Duration = duration;
    }

    public override void Use()
    {
    }
}
*/