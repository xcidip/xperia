using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using XperiaRPG.Scripts.Character.Player;
using XperiaRPG.Scripts.Characters;
using XperiaRPG.Scripts.UI;

namespace XperiaRPG.Scripts.Fighting
{
    public static class Fight
    {
        public static void Start(Player player, Enemy enemy)
        {
            if (WonOrNot(player, enemy))
            {
                Cutscenes.FightWon();
                GiveLoot(player, enemy);
                return;
            }

            Cutscenes.FightLost();
            player.Die();

        }
        public static void GiveLoot(Player player, Enemy enemy)
        {
            var rand = new Random();

            foreach (var drop in enemy.DropTable)
            {
                var randNum = rand.Next(1, 101); // roll 100
                if (randNum <= drop.DropChance) // if rolled number is lower than drop chance, give item to player
                {
                    Console.WriteLine($"You recieved: {drop.ItemStack.Quantity}x {drop.ItemStack.Name}");
                    Console.WriteLine("Add to inventory?");
                    var choice = Choice.YesNoValidation();
                    if (choice == 'y')
                    {
                        player.Inventory.AddItemStack(drop.ItemStack);
                    }
                    else
                    {
                        Console.WriteLine($"{drop.ItemStack.Quantity}x {drop.ItemStack.Name} dropped on ground");
                    }
                }
            }
        }

        public static bool WonOrNot(Player player, Enemy enemy)
        {
            player.CombatStats.Update(player.Stats, enemy.Stats);
            enemy.CombatStats.Update(enemy.Stats,player.Stats);
            var random = new Random();

            // choose fighting style by enemy preffered
            var fightingStyle = enemy.PrefferedFightingStyle;

           
            while (true) 
            {
                Console.Clear();
                // print stats
                //player.Stats.Print();
                //enemy.Stats.Print();
                player.CombatStats.Print();
                enemy.CombatStats.Print();




                // player attack first
                var hit = false;
                switch (fightingStyle)
                {
                    case "Slider":
                        hit = FightingStyles.SliderAttack(100);
                        break;
                    case "Memory":
                        hit = FightingStyles.MemoryAttack(3, 5000);
                        break;
                    case "Typing":
                        hit = FightingStyles.TypingAttack();
                        break;
                    default: // (dice)
                        hit = FightingStyles.DiceAttack();
                        break;
                }

                // decrease hp to enemy if hit
                if (hit == true)
                {
                    var damage = random.Next(
                        (int)player.CombatStats.Lookup("MinDmg").Value,
                        (int)player.CombatStats.Lookup("MaxDmg").Value
                        );
                    Console.WriteLine($"You dealt: {damage} points of damage");
                    enemy.DecreaseHP(damage);
                    if (enemy.CombatStats.Lookup("Health").Value <= 0) return true;
                }

                // pause
                Console.ReadLine();

                var willEnemyHit = random.Next(1, 2);
                if (willEnemyHit == 1)
                {
                    var damage = random.Next(
                        (int)enemy.CombatStats.Lookup("MinDmg").Value,
                        (int)enemy.CombatStats.Lookup("MaxDmg").Value
                    );
                    player.CombatStats.DecreaseHP(damage);
                    Console.WriteLine($"Enemy dealt: {damage} points of damage");
                    if (player.CombatStats.Lookup("Health").Value <= 0) return false;
                    Choice.PressEnter();
                }
            } 
            




        }
    }
}
