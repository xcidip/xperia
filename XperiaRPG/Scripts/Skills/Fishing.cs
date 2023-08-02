using System;
using System.Collections.Generic;
using XperiaRPG.Scripts.Items;

namespace XperiaRPG.Scripts.Skills
{
    public static class Fishing
    {




        public static void Print()
        {
            Console.WriteLine("          /\\             \r\n       o /  \\           \r\n   []__|/___ \\      \r\n~~~|(_______)~\\~~~\r\n  %            <){");
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
        public Fish(int quantity, string name,string description, int price) : base(quantity, name, description, price)
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

    public class FishList : ListOfItems
    {
        public FishList()
        {
            List = new List<Item>
            {
                new Fish(1,"Shrimp", "Little shrimp, so easy to catch.", 15),
            };
        }

    }


}