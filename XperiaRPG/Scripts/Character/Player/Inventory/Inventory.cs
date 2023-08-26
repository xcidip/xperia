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
        public void AddItem(ItemStack itemStack)
        {
            if (List.Count != 0)
            {
                if (List.Count >= GlobalVariables.InvWarning) // if 90% full say almost full
                {
                    if (List.Count >= GlobalVariables.InvSize) // if full dont add more
                    {
                        Console.WriteLine("Inventory full!");
                        Choice.PressEnter();
                        return;
                    }
                    Console.WriteLine("Inventory almost full");
                    Console.WriteLine($"You have {GlobalVariables.InvSize - List.Count} slots empty");
                    Choice.PressEnter();
                }
            }
            for (int i = 0; i < itemStack.Quantity; i++) List.Add(itemStack.Item);
            Console.WriteLine($"{itemStack.Quantity}x {itemStack.Name} added to inventory");
        }

        public void PickDrop(ItemStack itemStack)
        {
            Console.Write("Pickup?");
            var choice = Choice.YesNoValidation();
            switch (choice)
            {
                case 'y':
                    AddItem(itemStack);
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
            InventoryUtils.PrintInventory(List, 42, " {0,-36}");
        }

        public Item Lookup(string name)
        {
            return List.FirstOrDefault(a => a?.Name == name);
        }
    }


}