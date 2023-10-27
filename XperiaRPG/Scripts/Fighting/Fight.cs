using System;
using System.Collections.Generic;
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
            enemy.CombatStats.Update(enemy.Stats,player.Stats);
            player.CombatStats.Update(player.Stats, enemy.Stats);
            var random = new Random();

            // choose fighting style by enemy preffered
            var fightingStyle = enemy.PrefferedFightingStyle;

            do      
            {
                Console.Clear();
                // print stats
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
                        hit = FightingStyles.MemoryAttack(5, 10000);
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
                    Console.WriteLine($"Enemy dealt: {damage} points of damage");
                    player.CombatStats.DecreaseHP(damage);
                }
            } 
            while (player.CombatStats.Lookup("Health").Value < 0 || enemy.CombatStats.Lookup("Health").Value < 0) ;




        }
    }
}
