using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Timers;
using XperiaRPG.Assets.Sprites;
using XperiaRPG.Scripts.Character.Player.Inventory;
using XperiaRPG.Scripts.Items;
using XperiaRPG.Scripts.UI;
using Timer = System.Threading.Timer;

namespace XperiaRPG.Scripts.Skills
{
    public static class Fishing
    {


        public static void Start(Pond pond, Inventory inventory)
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
                if (random.Next(1,3) == 1) // 33% chance to catch a fish
                {
                    var caughtFish = pond.List[random.Next(pond.List.Count)];
                    Console.WriteLine($"Good job, you caught {caughtFish.Name}");
                    inventory.AddItemStack(new ItemStack(1,caughtFish));
                }
                else
                {
                    Console.WriteLine("Fish escaped :(");
                }
                Console.Write("Continue?: ");
                if (Choice.YesNoValidation() == 'n') return;

            }
            

           





            // if done correctly 33% chance to catch and add to inventory
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

    public class Fish : Item
    {
        public Fish(string name,string description, int price, (ConsoleColor Foreground, ConsoleColor Background) colors) 
            : base(name, description, price, colors)
        {
        }

        public override void Use()
        {
            // useless
        }

        public override void Examine()
        {

        }
    }

    public class FishItemList : ItemList
    {
        public FishItemList()
        {
            List = new List<Item>
            {
                new Fish("Shrimp", "Little shrimp, so easy to catch.", 15, Rarity.Common),
                new Fish("Trout", "Trout, so easy to catch.", 20, Rarity.Common),
                new Fish("Salmon", "Could be delicious if cooked.", 30, Rarity.Uncommon),
                new Fish("Tuna", "Tuna, so tasty.",40, Rarity.Uncommon),
                new Fish("Crayfish", $"Crusty Crayfish, not so easy to catch.", 45, Rarity.Rare),
            };
        }

    }


}