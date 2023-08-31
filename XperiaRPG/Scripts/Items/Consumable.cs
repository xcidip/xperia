using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XperiaRPG.Scripts.Character.Player;

namespace XperiaRPG.Scripts.Items
{
    public class Food : Item
    {
        public Food(string name, int healValue, string description, int price, (ConsoleColor Foreground, ConsoleColor Background) colors)
            : base(name, description, price, colors)
        {
            HealValue = healValue;
        }


        public override void Use(Player player)
        {
            Console.WriteLine($"{Name} was eaten");
            //var maxHeal = (player.Stats.Lookup("Stamina") *2 ) - player.BattleAttributes.Lookup("Health)
            //player.BattleAttributes.Heal(HealValue);
            var healed = HealValue;
            //if (maxHealed > HealValue) healed = maxHeal 
            Console.WriteLine($"Player healed by {healed}");
            //todo consume item + heal

        }

        public override void Examine()
        {
            //todo heal value
            Console.Write($"Name: {Name}\n" +
                          $"Description: {Description}\n" +
                          $"It sells for: {Price}gp\n" +
                          $"It heals for {HealValue}");
            Console.WriteLine();
        }
    }

    public abstract class Potion : Item
    {
        public int Potency { get; set; }
        public string Effect { get; set; }

        protected Potion(string name, int price, string description, int potency, (ConsoleColor Foreground, ConsoleColor Background) colors)
            : base(name, description, price, colors)
        {
            Potency = potency;
        }

        public abstract override void Use(Player player);
        
        // todo examine()
    }

    public class HealingPotion : Potion
    {
        public HealingPotion(string name, string description, int potency, int price, (ConsoleColor Foreground, ConsoleColor Background) colors)
            : base(name, price, description, potency, colors)
        {
            Effect = "healing";
        }

        public override void Use(Player player)
        {
            // todo Heal the user 
        }
    }


    //public class DamagingPotion : Potion
    //public class TeleportPotion : Potion
    //public class ResistPotion : Potion

}
