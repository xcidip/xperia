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
        public static void PrintInventoryHeader(int columns, int lengthOfColumn, int numOfItems, int inventorySize)
        {
            Utility.PrintBorder(columns, lengthOfColumn);
            Console.SetCursorPosition(5, Console.CursorTop - 1);
            Console.WriteLine($"INVENTORY {numOfItems + "/" + inventorySize}");
        }

        public static void PrintInventory(IEnumerable<Item> list, int columns, int lengthOfColumn, string format)
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

            PrintInventoryHeader(columns, lengthOfColumn, numOfItems, 30);

            var i = 0;

            foreach (var item in itemList)
            {
                Console.Write($"{"| (" + (i + 1) + ")",-6}");
                Console.Write(format,
                    item.Name + " " + item.Quantity + "x"); //0

                i++;
                if (i % columns != 0 && i != numOfItems) continue;

                var remainingItemsInRow = i % columns;
                var blankSpaces = remainingItemsInRow == 0 ? 0 : columns - remainingItemsInRow;

                // Print the blank spaces for the remaining items in the row
                for (var j = 0; j < blankSpaces; j++)
                {
                    Console.Write($"|{new string(' ', lengthOfColumn)}");
                }

                Console.WriteLine("|");
            }

            Utility.PrintBorder(columns, lengthOfColumn);
        }

        
    }
}
