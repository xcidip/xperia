using System;
using System.Collections.Generic;
using XperiaRPG.Scripts.Character.NPC;
using XperiaRPG.Scripts.Character.Player;
using XperiaRPG.Scripts.Character.Player.CharacterCreation;
using XperiaRPG.Scripts.CharacterCreation;
using XperiaRPG.Scripts.Items;
using XperiaRPG.Scripts.Skills;
using XperiaRPG.Scripts.UI;
using System.Runtime.InteropServices;

namespace XperiaRPG
{
    internal static class Game
    {
        public static void Main()
        {
            Console.WriteLine($"Hey, {Environment.UserName}");
            Console.WriteLine("Make the game fullscreen please");
            Console.WriteLine("US keyboard layout recommended");
            // ask for columns
            Console.WriteLine("how many columns? 4-1080p 7-2160p");
            GlobalVariables.Columns = Choice.NumberRangeValidation(1, 7);

            /* for final build
            MainMenu.Welcome(200); // Welcoming animation
            var choice = Choice.NumberRangeValidation(1, 3);
            switch (choice)
            {
                case 1: // make new character
                    var characterInfo = Player.WhatToChange();
                    break;
                case 2: // load character, location
                    break;
                default:
                    break;
            }
            */

            #region Demo Character (not creating it everytime XD)
            var characterInfo = new PlayerSetting[6];
            characterInfo[0] = new RaceList().Lookup("Human");
            characterInfo[1] = new ProfessionList().Lookup("Mage");
            characterInfo[2] = new DifficultyList().Lookup("Hard");
            characterInfo[3] = new Name("TestMan");
            characterInfo[4] = new SuffixList().Lookup("the Tough guy");
            characterInfo[5] = new SexualityList().Lookup("Celibacy");
            #endregion

            // create player
            var player = new Player(characterInfo);

            #region Inventory item management test
            var armorDatabase = new ArmorItemList();
            var droppedArmor = armorDatabase.Lookup("Wizard's Coat");
            var droppedArmor1 = armorDatabase.Lookup("Wizard's Skirt");
            var droppedArmor2 = armorDatabase.Lookup("Wizard's Hat");
            //player.Inventory.AddItem(droppedArmor);
            //player.Inventory.AddItem(droppedArmor1);
            //player.Inventory.AddItem(droppedArmor2);


            var weaponDatabase = new WeaponItemList();
            var toolDatabase = new ToolItemList();
            var droppedItem = weaponDatabase.Lookup("Arnold's Sword");
            var droppedItem1 = weaponDatabase.Lookup("Arnold's Iron Shield");
            var droppedItem2 = weaponDatabase.Lookup("Arnold's Staff");
            var droppedItem3 = weaponDatabase.Lookup("Arnold's Tome");
            var droppedItem4 = toolDatabase.Lookup("Arnold's Pickaxe");
            var droppedItem5 = toolDatabase.Lookup("Arnold's FishingRod");
            var droppedItem6 = toolDatabase.Lookup("Arnold's Horse");

            //player.Inventory.AddItem(droppedItem);
            //player.Inventory.AddItem(droppedItem1);
            //player.Inventory.AddItem(droppedItem2);
            //player.Inventory.AddItem(droppedItem3);
            //player.Inventory.AddItem(droppedItem4);
            //player.Inventory.AddItem(droppedItem5);
            //player.Inventory.AddItem(droppedItem6);

            #endregion


            // tailoring crafting test
            var materialItemList = new MaterialItemList();



            var npcList = new NpcList();
            var npc = npcList.Lookup("Norwyn");


            player.Action();

           

            #region Fishing
            /*
            var fishItemList = new FishItemList();

            var pond = new Pond(0, new List<Fish>
            {
                (Fish)fishItemList.Lookup("Shrimp"),
                (Fish)fishItemList.Lookup("Trout")
            });

            Fishing.Start(pond, player.Inventory);
            */
            #endregion  

            //Console.ReadLine();

        }
    }
} 