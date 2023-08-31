using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XperiaRPG.Scripts.Character.Attributes;
using XperiaRPG.Scripts.Character.Player;
using XperiaRPG.Scripts.Character.Player.Inventory;

namespace XperiaRPG.Scripts.Items
{
    public class Fish : Item
    {
        public int XpGain { get; set; }
        public Fish(string name, string description, int xpGain, int price, (ConsoleColor Foreground, ConsoleColor Background) colors)
            : base(name, description, price, colors)
        {
            XpGain = xpGain;
        }

        public override void Use(Player player)
        {
            // useless
        }
    }

    public class Herb : Item
    {
        public Herb(string name, string description, int price, (ConsoleColor Foreground, ConsoleColor Background) colors)
            : base(name, description, price, colors)
        {

        }
        public override void Use(Player player)
        {

        }
    }

    public class Book : Item // development diary, lore about game
    {
        public string InsideOfBook { get; set; }
        public Book(string name, string description, int price,
            (ConsoleColor Foreground, ConsoleColor Background) colors, string insideOfBook)
            : base(name, description, price, colors)
        {
            InsideOfBook = insideOfBook;
        }

        public override void Use(Player player)
        {

        }
        public new void Examine()
        {
            Console.Clear();
            Console.Write($"Name: {Name}\n" +
                          $"Description: {Description}\n" +
                          $"It sells for: {Price}gp\n" +
                          $"{InsideOfBook}");
        }
    }
    
    public class Material : Item // basic materials for all professions
    {
        public Material(string name, string description, int price, (ConsoleColor Foreground, ConsoleColor Background) colors)
            : base(name, description, price, colors)
        {

        }


        public override void Use(Player player)
        {

        }

    }

    public class ProfessionTool : Item
    {

        public ProfessionTool(string name, string description, int price, (ConsoleColor Foreground, ConsoleColor Background) colors)
            : base(name, description, price, colors)
        {

        }

        public override void Use(Player player)
        {

        }

    }

    public class ToolItemList : ItemList
    {
        public ToolItemList()
        {
            List = new List<Item>
            {
                new Equipable(0, GearSlot.Pickaxe, "Arnold's Pickaxe",150, "Best of the Pickaxes",
                    new List<AttBonus>()
                    {
                        new AttBonus("Mining", 5, "%"),
                    }, Rarity.Common),
                new Equipable(0, GearSlot.FishingRod, "Arnold's FishingRod",100, "Best of the FishingRods",
                    new List<AttBonus>()
                    {
                        new AttBonus("Fishing", 5, "%"),
                    }, Rarity.Common),
                new Equipable(0, GearSlot.Mount, "Arnold's Horse",500, "Best of the FishingRods",
                    new List<AttBonus>()
                    {
                        new AttBonus("Traveling", 10, "%"),
                    }, Rarity.Common),
            };
        }
    }




}
