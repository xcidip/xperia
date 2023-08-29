using System;
using System.Collections.Generic;
using System.Threading;
using XperiaRPG.Assets.Sprites;
using XperiaRPG.Scripts.Character.NPC;
using XperiaRPG.Scripts.Character.Player;
using XperiaRPG.Scripts.Character.Player.CharacterCreation;
using XperiaRPG.Scripts.CharacterCreation;
using XperiaRPG.Scripts.Items;
using XperiaRPG.Scripts.Skills;
using XperiaRPG.Scripts.UI;

namespace XperiaRPG
{
    internal static class Game
    {
        public static void Main()
        {
            #region Disclaimer
            Console.WriteLine($"Hey, {Environment.UserName}");
            Console.WriteLine("Make the game fullscreen please");
            Console.WriteLine("US keyboard layout recommended");
            Console.WriteLine("Windows terminal heavily recommended (less stuttering)");
            Console.WriteLine("\n\nDISCLAIMER:\nALL CHARACTERS AND\r\nEVENTS IN THIS SHOW--\r\nEVEN THOSE BASED ON REAL\r\nPEOPLE--ARE ENTIRELY FICTIONAL.\r\nALL CELEBRITY VOICES ARE\r\nIMPERSONATED…...POORLY. THE\r\nFOLLOWING PROGRAM CONTAINS\r\nCOARSE LANGUAGE AND DUE TO\r\nITS CONTENT IT SHOULD NOT BE\r\nVIEWED BY ANYONE");
            Console.WriteLine("\n\nhow many columns? 4-1080p 7-2160p");
            //GlobalVariables.Columns = Choice.NumberRangeValidation(1, 7);
            GlobalVariables.Columns = 4;
            Choice.PressEnter();
            #endregion

            #region Global variables...
            GlobalVariables.InvSize = 30;
            PlayerSetting[] characterInfo = null;
            #endregion

            #region MainMenu

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

            #endregion

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

            #region crafting test
            // tailoring crafting test
            var materialItemList = new MaterialItemList();
            player.Inventory.AddItemStack(new ItemStack(4, materialItemList.Lookup("Linen cloth")));


            #endregion

            


            Choice.PressEnter();

            var npcList = new NpcList();
            var npc = npcList.Lookup("Norwyn");
            
            npc.Talk();
            /*
            // Display NPC's current dialog text
            Console.WriteLine(npc.DialogTree.Text);

            // Display player response options
            for (int i = 0; i < npc.DialogTree.Responses.Count; i++)
            {
                Console.WriteLine($"({i + 1}) {npc.DialogTree.Responses[i].Text}");
            }

            // Get player's choice
            int choice = Choice.NumberRangeValidation(1, npc.DialogTree.Responses.Count);

            // Update currentNPC based on player choice
            npc.DialogTree = npc.DialogTree.Responses[choice - 1];
            */            

            player.Action();

            #region Fishing
            
            var fishItemList = new FishItemList();

            var pond = new Pond(0, new List<Fish>
            {
                (Fish)fishItemList.Lookup("Shrimp"),
                (Fish)fishItemList.Lookup("Trout")
            });

            //Fishing.Start(pond, player.Inventory);
            
            #endregion  

            Console.ReadLine();

        }
    }
} 