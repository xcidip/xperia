using System;
using System.Collections.Generic;
using System.Linq;
using XperiaRPG.Scripts.Attributes;
using XperiaRPG.Scripts.Items;
using XperiaRPG.Scripts.UI;

namespace XperiaRPG.Scripts.Characters.Inventory
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
            Utility.PrintInventory(List, columns, 41, " {0,-36}");
        }
    }
}