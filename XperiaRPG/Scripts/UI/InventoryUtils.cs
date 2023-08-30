using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XperiaRPG.Scripts.Character.Player;
using XperiaRPG.Scripts.Items;
using XperiaRPG.Scripts.Misc;

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
            BorderUtility.PrintBorder(GlobalVariables.Columns, lengthOfColumn);
            Console.SetCursorPosition(5, Console.CursorTop - 1);
            Console.WriteLine($"INVENTORY {numOfItems + "/" + inventorySize}");
        }

        public static void PrintColored(string format, Item item)
        {
            // Set foreground and background colors
            Console.ForegroundColor = item.ForeColor;
            Console.BackgroundColor = item.BackColor;

            Console.Write(format, item.Name); //0

            // Reset console colors to default
            Console.ResetColor();
        }

        public static void PrintInventory(IEnumerable<Item> list, int lengthOfColumn)
        {
            var itemNameList = list.ToList();
            var numOfItems = itemNameList.Count();

            if (numOfItems == 0)
            {
                Console.WriteLine(
                    "+-INVENTORY---------------------+\n" +
                    "|      Empty like my soul       |\n" +
                    "+-------------------------------+");
                return;
            }

            PrintInventoryHeader(lengthOfColumn, numOfItems, 30);


            var i = 0;
            var h = 0;
            var stringPrinted = new HashSet<string>(); // Use HashSet to store the names of printed items (Hashset list of uniques)

            foreach (var item in itemNameList)
            {
                if (stringPrinted.Contains(item.Name)) // if printed, skip one cycle
                {
                    continue;
                }

                var range = itemNameList.Count(s => s.Name == item.Name);

                // Mark the item as printed
                stringPrinted.Add(item.Name);

                if (range > 1)
                {
                    if (i + range > 9)
                    {
                        if (i + range > 9 && i < 10)
                        {
                            Console.Write($"{"| (" + (i + 1) + "-" + (i + range) + ")",-8}");
                            PrintColored(" {0,-34}", item);
                        }
                        else
                        {
                            Console.Write($"{"| (" + (i + 1) + "-" + (i + range) + ")",-9}");
                            PrintColored(" {0,-33}", item);
                        }
                    }
                    else
                    {
                        Console.Write($"{"| (" + (i + 1) + "-" + (i + range) + ")",-7}");
                        PrintColored(" {0,-35}", item);
                    }

                    
                    i += range -1;
                }
                else if (i > 9)
                {
                    Console.Write($"{"| (" + (i + 1) + ")",-6}");
                    PrintColored(" {0,-36}", item);
                }
                else
                {
                    Console.Write($"{"| (" + (i + 1) + ")",-5}");
                    PrintColored(" {0,-37}", item);
                }
                i++;
                h++;


                if (h % GlobalVariables.Columns == 0)
                {
                    Console.Write("|\n");
                }
            }


            do
            {
                Console.Write($"|{new string(' ', lengthOfColumn)}");
                h++;
            } while (h % GlobalVariables.Columns != 0);

            Console.WriteLine("|");

            BorderUtility.PrintBorder(GlobalVariables.Columns, lengthOfColumn);
            }

    }
}
