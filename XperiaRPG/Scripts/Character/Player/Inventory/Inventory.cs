using System;
using System.Collections.Generic;
using System.Linq;
using XperiaRPG.Scripts.Items;
using XperiaRPG.Scripts.UI;

namespace XperiaRPG.Scripts.Character.Player.Inventory
{
    public class Inventory
    {
        public readonly List<Item> List;

        public Inventory()
        {
            List = new List<Item>();
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public void AddItem(Item newItem)
        {
            var itemExists = false;

            foreach (var item in List.Where(item => item.Name == newItem.Name))
            {
                item.Quantity += newItem.Quantity;
                itemExists = true;
                break;
            }

            if (!itemExists)
            {
                List.Add(newItem);
            }

            Console.WriteLine(newItem.Name + " added to inventory");
        }

        public void PickDrop(Item item)
        {
            Console.Write("Pickup?");
            var choice = Choice.YesNoValidation();
            switch (choice)
            {
                case 'y':
                    AddItem(item);
                    break;
                case 'n':
                    Console.WriteLine($"You left {item.Name} on the ground.");
                    break;
            }
        }

        public void RemoveItem(Item item)
        {
            List.Remove(item);
        }

        public static void ReduceItem(Item item)
        {
            item.Quantity--;
        }

        public void Print(int columns)
        {
            InventoryUtils.PrintInventory(List, columns, 42, " {0,-37}");
        }
    }

    public class InventoryAction
    {
        public char Key { get; set; }
        public string Value { get; set; }

        public InventoryAction(char key, string value)
        {
            Key = key;
            Value = value;
        }
    }
    public class InventoryActionList
    {
        public List<InventoryAction> List { get; set; }

        public InventoryActionList()
        {
            List = new List<InventoryAction>
            {
                new InventoryAction('a', "Attributes"),
                new InventoryAction('c', "Crafting"),
                new InventoryAction('g', "Gear"),
                new InventoryAction('i', "Inventory"),

            };
        }
        public InventoryAction Lookup(char key)
        {
            return List.FirstOrDefault(a => a?.Key == key);
        }
    }
}