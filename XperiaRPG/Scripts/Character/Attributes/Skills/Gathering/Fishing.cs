using System;
using System.Collections.Generic;
using System.Threading;
using XperiaRPG.Assets.Sprites;
using XperiaRPG.Scripts.Character.Player;
using XperiaRPG.Scripts.Character.Player.Inventory;
using XperiaRPG.Scripts.Items;
using XperiaRPG.Scripts.UI;

namespace XperiaRPG.Scripts.Skills.Gathering
{
    public static class Fishing
    {
        public static void Start(Pond pond,int chanceToCatchOneIn, Inventory inventory, Character.Attributes.Skills skillList)
        {
            while (true)
            {
                Console.Clear();
                var random = new Random();
                var i = 0;

                // i < 25 under the boat, 41 end
                do
                {
                    if (i > 41)
                    {
                        i = 0;
                    }
                    Console.WriteLine("To catch a fish press key when the tip of the fish is under the hook\n");
                    Print();
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.SetCursorPosition(Console.CursorLeft + i, Console.CursorTop);
                    Console.Write("}(>");
                    Thread.Sleep(100);
                    Console.Clear();
                    i++;

                } while (!Console.KeyAvailable); // false when pressed
                Console.ReadKey();  // eat the key

                // if the fish was under the hook
                if (i <= 24 || i >= 27) continue;


                if (random.Next(0,chanceToCatchOneIn) == 0) // chance to catch a fish
                {
                    var caughtFish = pond.List[random.Next(pond.List.Count)];
                    Console.WriteLine($"Good job, you caught {caughtFish.Name}");
                    Console.WriteLine($"You gained {caughtFish.XpGain}xp + bonus xp if you have a % bonus");
                    skillList.AddXp("Fishing",caughtFish.XpGain);
                    inventory.AddItemStack(new ItemStack(1,caughtFish));
                }
                else
                {
                    Console.WriteLine("Fish escaped :(");
                }
                Console.Write("Again?: ");
                if (Choice.YesNoValidation() == 'n') return;

            }
        }

        public static void Print()
        {
            var fishingSprite = new SkillSprites();
            Console.WriteLine(fishingSprite.FishingManOnBoat);
        }
    }

    public class Pond
    {
        public int Level { get; set; }
        public List<Fish> List { get; set; } // list of fish located in that pool
        public Pond(int level, List<Fish> list)
        {
            Level = level;
            List = list;
        }   
    }
}