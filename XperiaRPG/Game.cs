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
            Console.WriteLine("how many columns? 4-1080p 7-2160p");
            //GlobalVariables.Columns = Choice.NumberRangeValidation(1, 7);
            GlobalVariables.Columns = 4;
            Choice.PressEnter();

            GlobalVariables.InvSize = 30;
            PlayerSetting[] characterInfo = null;

            /* for final build
            MainMenu.Welcome(200); // Welcoming animation
            var choice = Choice.NumberRangeValidation(1, 3);

            

            switch (choice)
            {
                case 1: // make new character
                    characterInfo = Player.WhatToChange();
                    break;
                case 2: // load character, location
                    break;
                default:
                    break;
            }
            */

            #region Demo Character (not creating it everytime XD)
            ///*
            characterInfo = new PlayerSetting[6];
            characterInfo[0] = new RaceList().Lookup("Human");
            characterInfo[1] = new ProfessionList().Lookup("Mage");
            characterInfo[2] = new DifficultyList().Lookup("Hard");
            characterInfo[3] = new Name("TestMan");
            characterInfo[4] = new SuffixList().Lookup("the Tough guy");
            characterInfo[5] = new SexualityList().Lookup("Celibacy");
            //*/
            #endregion

            // create player
            var player = new Player(characterInfo);

            #region Inventory item management test
            var armorDatabase = new ArmorItemList();
            player.Inventory.AddItem(armorDatabase.Lookup("Wizard's Coat"));

            var weaponDatabase = new WeaponItemList();
            var toolDatabase = new ToolItemList();
            player.Inventory.AddItem(weaponDatabase.Lookup("Arnold's Sword"));
            player.Inventory.AddItem(weaponDatabase.Lookup("Arnold's Iron Shield"));
            player.Inventory.AddItem(weaponDatabase.Lookup("Arnold's Staff"));
            player.Inventory.AddItem(weaponDatabase.Lookup("Arnold's Tome"));
            player.Inventory.AddItem(toolDatabase.Lookup("Arnold's Pickaxe"));
            player.Inventory.AddItem(toolDatabase.Lookup("Arnold's FishingRod"));
            player.Inventory.AddItem(toolDatabase.Lookup("Arnold's Horse"));

            #endregion


            // tailoring crafting test
            var materialItemList = new MaterialItemList();
            player.Inventory.AddItemStack(new ItemStack(4, materialItemList.Lookup("Linen cloth")));


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