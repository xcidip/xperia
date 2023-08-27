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

        public void AddItem(Item item)
        {
            if (InventoryUtils.FullCheck(List.Count)) return;
            List.Add(item);
            Console.WriteLine($"{item.Name} added to inventory");
        }
        public void AddItemStack(ItemStack itemStack)
        {
            
            for (var i = 0; i < itemStack.Quantity; i++)
            {
                if (InventoryUtils.FullCheck(List.Count)) return;
                List.Add(itemStack.Item);
            }
            Console.WriteLine($"{itemStack.Quantity}x {itemStack.Name} added to inventory");
        }

        public void PickDrop(ItemStack itemStack)
        {
            Console.Write("Pickup?");
            var choice = Choice.YesNoValidation();
            switch (choice)
            {
                case 'y':
                    AddItemStack(itemStack);
                    break;
                case 'n':
                    Console.WriteLine($"You left {itemStack.Name} on the ground.");
                    break;
            }
        }

        public void RemoveItem(Item item)
        {
            List.Remove(item);
        }

        public void Print()
        {
            List.Sort((obj1, obj2) => string.CompareOrdinal(obj1.Name, obj2.Name));
            InventoryUtils.PrintInventory(List, 42);
        }

        public Item Lookup(string name)
        {
            return List.FirstOrDefault(a => a?.Name == name);
        }
    }


}