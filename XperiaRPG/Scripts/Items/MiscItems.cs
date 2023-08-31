using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XperiaRPG.Scripts.Character.Player;

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






}
