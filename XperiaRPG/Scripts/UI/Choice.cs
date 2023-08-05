using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using XperiaRPG.Scripts.Character.Player.Inventory;
using XperiaRPG.Scripts.Skills;

namespace XperiaRPG.Scripts.UI
{
    public static class Choice
    {
        public static int NumberRangeValidation(int bottom, int top)
        {
            Console.Write("\n");

            while (true)
            {
                Console.Write($"Please enter a number between {bottom} and {top}: ");
                var input = Console.ReadLine();

                if (int.TryParse(input, out var userInput))
                {
                    if (userInput >= bottom && userInput <= top)
                    {
                        return userInput;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }

        public static string NameValidation()
        {
            Console.Write("\n");

            while (true)
            {
                Console.Write($"Please enter your character's name: ");
                var input = Console.ReadLine();

                var tooLong = input?.Length > 40;
                var hasNumbers = ContainsNumbers(input);

                if (tooLong)
                {
                    Console.WriteLine("Dont troll the length of your name xD");
                }
                else if (hasNumbers)
                {
                    Console.WriteLine("Your name can't contain any numbers!");
                }
                else
                {
                    return input;
                }


            }
            
        }

        private static bool ContainsNumbers(string input)
        {
            // Regular expression pattern to match any digit (0-9) in the input string.
            const string pattern = @"\d";
            // Use Regex.IsMatch to check if the pattern is found in the input string.
            return Regex.IsMatch(input, pattern);
        }

        public static char YesNoValidation()
        {
            char userInput;
            Console.Write("\n");

            while (true)
            {
                Console.Write("Please enter (y/n) or ENTER:");
                var input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))  // Check if the input is empty (Enter was pressed)
                {
                    userInput = 'y';  // Treat Enter as "yes"
                    break;
                }

                if (char.TryParse(input, out userInput))
                {
                    if (userInput == 'y' || userInput == 'n')
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
            return userInput;
        }

        public static void PressEnter()
        {
            Console.Write("\nPress ENTER to continue:");
            Console.ReadLine();
        }


        public static char InventoryActionInput()
        {
            var inventoryActionList = new InventoryActionList();
            var list = inventoryActionList.List;
            var length = list.Count;

            // What do you want to do here? (attributes/crafting/gear/items)
            Console.Write("\nWhat do you want to do here? (");
            while (true)
            {
                foreach (var option in list)
                {
                    Console.Write($"{option.Value}");
                    Console.Write("/");
                }
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                Console.WriteLine(")");

                // Please enter (a/c/g/i):
                Console.Write("Please enter (");
                foreach (var option in list)
                {
                    Console.Write($"{option.Key}");
                    Console.Write("/");
                }
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                Console.Write("): ");


                var myChar = Console.ReadLine();

                if (myChar != null && inventoryActionList.Lookup(myChar[0]) != null)
                {
                    return myChar[0];
                }
                
                Console.WriteLine("The is not in the list.");
                
            }
        }

    }

}