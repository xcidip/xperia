using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XperiaRPG.Scripts.Character.Player;
using XperiaRPG.Scripts.Items;

namespace XperiaRPG.Scripts.UI
{
    public static class InventoryUtils
    {
        public static void PrintInventoryHeader(int lengthOfColumn, int numOfItems, int inventorySize)
        {
            Utility.PrintBorder(lengthOfColumn);
            Console.SetCursorPosition(5, Console.CursorTop - 1);
            Console.WriteLine($"INVENTORY {numOfItems + "/" + inventorySize}");
        }

        public static void PrintInventory(IEnumerable<Item> list, int lengthOfColumn, string format)
        {
            var itemList = list.ToList();
            var numOfItems = itemList.Count();

            if (numOfItems == 0)
            {
                Console.WriteLine(
                    "+-------------------------------+\n" +
                    "|      Empty like my soul       |\n" +
                    "+-----------INVENTORY-----------+"
                );
                return;
            }

            PrintInventoryHeader(lengthOfColumn, numOfItems, 30);

            var i = 0;

            foreach (var item in itemList)
            {
                Console.Write($"{"| (" + (i + 1) + ")",-6}");
                Console.Write(format,
                    item.Name + " " + item.Quantity + "x"); //0

                i++;
                if (i % GlobalVariables.Columns != 0 && i != numOfItems) continue;

                var remainingItemsInRow = i % GlobalVariables.Columns;
                var blankSpaces = remainingItemsInRow == 0 ? 0 : GlobalVariables.Columns - remainingItemsInRow;

                // Print the blank spaces for the remaining items in the row
                for (var j = 0; j < blankSpaces; j++)
                {
                    Console.Write($"|{new string(' ', lengthOfColumn)}");
                }

                Console.WriteLine("|");
            }

            Utility.PrintBorder(lengthOfColumn);
        }

        public static void ItemExamine(Item item)
        {
            Console.Clear();
            item.Examine();
            Choice.PressEnter();
        }
        
    }
}
