using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XperiaRPG.Scripts.Character.Player;
using XperiaRPG.Scripts.Characters;

namespace XperiaRPG.Scripts.Fighting
{
    public static class FightingStyles
    {
        public static bool TypingAttack()
        {
            
            var List = new List<string>
            {
                "Elephant",
                "Sunshine",
                "Keyboard",
                "Butterfly",
                "Happiness",
                "Mountain",
                "Computer",
                "Adventure",
                "Universe",
                "Chocolate",
            };

            Console.WriteLine("Type this word quickly: ");
            var random = new Random();
            var randIndex = random.Next(List.Count);
            var randWord = List[randIndex];

            Console.WriteLine(randWord);

            var stopwatch = Stopwatch.StartNew();

            // Allowing the user to type the word
            string userInput = Console.ReadLine();

            // Stopping the stopwatch
            stopwatch.Stop();

            // Checking if the user's input matches the target word
            if (userInput != randWord)
            {
                Console.WriteLine("You did not type the word correctly.");
                return false;
            }

            // Displaying the time taken
            Console.WriteLine("Nice!");
            Console.WriteLine("Time taken: " + stopwatch.Elapsed.TotalSeconds + " seconds");
            return true;
        }

        public static bool SliderAttack(int speed)
        {
            var hit = false;
            var field = new[]
            {
                "[ * - | - - | - - ]",
                "[ - * | - - | - - ]",
                "[ - - * - - | - - ]",
                "[ - - | * - | - - ]",
                "[ - - | - * | - - ]",
                "[ - - | - - * - - ]",
                "[ - - | - - | * - ]",
                "[ - - | - - | - * ]",
                "[ - - | - - | * - ]",
                "[ - - | - - * - - ]",
                "[ - - | - * | - - ]",
                "[ - - | * - | - - ]",
                "[ - - * - - | - - ]",
                "[ - * | - - | - - ]",
                "[ * - | - - | - - ]"
            };

            var index = 0;

            // do until something is clicked
            do
            {
                // for looping the animation
                if (index == field.Length) index = 0;

                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(field[index]);
                Thread.Sleep(speed);
                index++;


            } while (!Console.KeyAvailable); // vrátí false při stisknutí klávesy
            Console.ReadKey();  // sežrání znaku

            Console.Clear();

            // if last frame's position is the star's position now
            index--;
            var hitCounter = 0;

            for (var i = 0; i < field[index].Length; i++)
            {
                if (field[index][i] == '|')
                {
                    hitCounter++;
                }
            }

            if (hitCounter == 2)
            {
                hit = true;
            }
            return hit;
        }

        public static bool MemoryAttack(int numOfWords, int timeLimit)
        {
            var List = new List<string>
            {
                "Elephant",
                "Sunshine",
                "Keyboard",
                "Butterfly",
                "Happiness",
                "Mountain",
                "Computer",
                "Adventure",
                "Universe",
                "Chocolate",
            };

            var rand = new Random();
            var randWords = "";

            for (int i = 0; i < numOfWords; i++)
            {
                var randIndex = rand.Next(List.Count);
                randWords += $"{List[randIndex]} ";
            }
            Console.WriteLine("Remember these words:");
            Console.WriteLine(randWords);
            Thread.Sleep(timeLimit);

            Console.Clear();
            Console.WriteLine("Type you the words you saw (case sensitive): ");
            var input = Console.ReadLine();
            if (input == null || input != randWords.Substring(0, randWords.Length - 1))
            {
                Console.WriteLine("Bad memory!");
                Console.WriteLine($"You typed: {input}");
                Console.WriteLine($"Instead of: {randWords}");
                return false;
            }

            Console.WriteLine("Good job on remembering the words!");
            return true;
        }

        public static bool DiceAttack()
        {
            while (true)
            {
                var rand = new Random();
                var playerRoll = rand.Next(1, 7);
                var enemyRoll = rand.Next(1, 7);

                if (playerRoll < enemyRoll)
                {
                    Console.WriteLine("Enemy has won!");
                    Console.WriteLine($"Enemy: {enemyRoll} Player {playerRoll}");
                    return false;
                }
                if (playerRoll > enemyRoll)
                {
                    Console.WriteLine("Player has won!");
                    Console.WriteLine($"Enemy: {enemyRoll} Player {playerRoll}");
                    return true;
                }
                
                Console.WriteLine("You and the enemy rolled the same.\nNext roll will decide");
            }
        }
    }
}
