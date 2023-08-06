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
            Console.Clear();
        }


        public static string InventoryActionInput(int invLength)
        {

            // list of possible actions
            var actionList = new ActionList(invLength);
            var actionsList = actionList.List;
            var length = actionsList.Count;

            

            // What do you want to do here? (attributes/crafting/gear/items)
            Console.Write("\nWhat do you want to do here? (");
            while (true)
            {
                var i = 1;
                foreach (var option in actionsList)
                {
                    Console.Write($"{option.Value}");
                    if (i >= length) continue;
                    i++;
                    Console.Write("/");
                }


                Console.WriteLine(")");

                // Please enter (a/c/g/i/0-9):
                i = 1;
                Console.Write("Please enter (0) EXIT (");
                foreach (var option in actionsList)
                {
                    Console.Write($"{option.Key}");
                    if (i >= length) continue;
                    i++;
                    Console.Write("/");
                }
                Console.Write("): ");


                var choice = Console.ReadLine();

                if (int.TryParse(choice, out var number))
                {
                    if (number >= 0 && number <= length) return number.ToString();
                }

                if (actionList.Lookup(choice) != null) return choice;
                Console.WriteLine("Wrong input");
                
            }
        }

    }

}