using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XperiaRPG.Scripts.Character.NPC;
using XperiaRPG.Scripts.Character.Player;
using XperiaRPG.Scripts.Character.Player.Inventory;
using XperiaRPG.Scripts.Items;
using XperiaRPG.Scripts.Skills.Crafting;
using XperiaRPG.Scripts.Skills.Gathering;
using XperiaRPG.Scripts.UI;

namespace XperiaRPG.Scripts.Misc
{
    public static class Tutorial
    {
        public static void Start(NpcList npcList, Player player)
        {
            Cutscenes.Intro();

            Console.WriteLine("Do you want a tutorial? (Recommended for first time players)");
            switch (Choice.YesNoValidation())
            {
                case 'y':
                    break;
                default:
                    return;
            }

            var norwyn = npcList.Lookup("Norwyn");

            // basic info WIP
            norwyn.Talk(player);

            Console.Clear();
            Console.WriteLine("First, you are gonna catch a fish and then cook it.\nAfter you caught one you can return.");
            Choice.PressEnter();

            // fishing
            var fishItemList = new FishItemList();
            var pond = new Pond(0, new List<Fish>
            {
                (Fish)fishItemList.Lookup("Shrimp"),
            });
            Fishing.Start(pond,1, player.Inventory, player.Skills);


            // cooking
            Console.Clear();
            Console.WriteLine("Now that you caught a fish, you have to cook it!");
            Choice.PressEnter();

            var cooking = new Cooking();
            while (true)
            {
                cooking.Print();
                player.Inventory.Print();
                cooking.WhatToCraft(player.Inventory, player.Skills);
                if (player.Inventory.Lookup("Cooked Shrimp") != null) break;
            }
            Console.WriteLine("Cool now you a got a cooked shrimp in your inventory, that you can eat to restore health when needed");
            player.Inventory.Print();

        }
    }
}
