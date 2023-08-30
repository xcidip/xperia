using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XperiaRPG.Scripts.Character.Player;

namespace XperiaRPG.Scripts.Items
{
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

    public class BookItemList : ItemList
    {
        BookItemList()
        {
            List = new List<Item>
            {
                new Book("Dev book 1","this book is about the books in this game",0,Rarity.Uncommon,
                    "The game\nWell hello, I see you can open books now, congratulations.\nYou know" +
                    " this is the first book I am writing in this game.\nToday is 30/8/23 and this project has 3.8k lines" +
                    " and I think I am about half way done with the game :) ...\nBye Bye, see you in the next book scattered across the game"),
            };
        }
    }
}
