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
        public static void ItemExamine(Item item)
        {
            Console.Clear();
            item.Examine();
            Choice.PressEnter();
        }

        public static bool FullCheck(int itemCount)
        {
            if (itemCount == 0) return false;
            if (itemCount < GlobalVariables.InvWarning) return false; // if 90% full say almost full
            if (itemCount >= GlobalVariables.InvSize) // if full dont add more
            {
                Console.WriteLine("Inventory full!");
                Choice.PressEnter();
                return true;
            }
            Console.WriteLine("Inventory almost full");
            Console.WriteLine($"You have {GlobalVariables.InvSize - itemCount} slots empty");
            Choice.PressEnter();
            return false;
        }

        public static void PrintInventoryHeader(int lengthOfColumn, int numOfItems, int inventorySize)
        {
            Utility.PrintBorder(GlobalVariables.Columns, lengthOfColumn);
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
                    "+-INVENTORY---------------------+\n" +
                    "|      Empty like my soul       |\n" +
                    "+-------------------------------+"
                );
                return;
            }

            PrintInventoryHeader(lengthOfColumn, numOfItems, 30);

            var i = 0;

            foreach (var item in itemList)
            {
                Console.Write($"{"| (" + (i + 1) + ")",-6}");

                // Set foreground and background colors
                Console.ForegroundColor = item.ForeColor;
                Console.BackgroundColor = item.BackColor;

                Console.Write(format, item.Name); //0

                // Reset console colors to default
                Console.ResetColor();

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

            Utility.PrintBorder(GlobalVariables.Columns, lengthOfColumn);
        }

    }
}
