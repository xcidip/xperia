using System;
using System.Collections.Generic;
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
            Console.WriteLine($"Hey, {Environment.UserName}");
            Console.WriteLine("Make the game fullscreen please");
            Console.WriteLine("US keyboard layout recommended");
            // ask for columns
            var columns = 4;

            Choice.PressEnter();

            //var characterInfo = Player.WhatToChange();

            #region DemoCharacter
            //*
            var characterInfo = new PlayerSetting[6];
            characterInfo[0] = new RaceList().Lookup("Human");
            characterInfo[1] = new ProfessionList().Lookup("Warrior");
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
            var droppedArmor = armorDatabase.Lookup("Arnold's Helmut");
            var droppedArmor1 = armorDatabase.Lookup("Arnold's test");
            player.Inventory.AddItem(droppedArmor);
            player.Inventory.AddItem(droppedArmor1);
            player.Inventory.AddItem(droppedArmor1);


            var weaponDatabase = new WeaponItemList();
            var toolDatabase = new ToolItemList();
            var droppedItem = weaponDatabase.Lookup("Arnold's Sword");
            var droppedItem1 = weaponDatabase.Lookup("Arnold's Iron Shield");
            var droppedItem2 = weaponDatabase.Lookup("Arnold's Staff");
            var droppedItem3 = weaponDatabase.Lookup("Arnold's Tome");
            var droppedItem4 = toolDatabase.Lookup("Arnold's Pickaxe");
            var droppedItem5 = toolDatabase.Lookup("Arnold's FishingRod");
            var droppedItem6 = toolDatabase.Lookup("Arnold's Horse");

            player.Inventory.AddItem(droppedItem);
            player.Inventory.AddItem(droppedItem1);
            player.Inventory.AddItem(droppedItem2);
            player.Inventory.AddItem(droppedItem3);
            player.Inventory.AddItem(droppedItem4);
            player.Inventory.AddItem(droppedItem5);
            player.Inventory.AddItem(droppedItem6);

            #endregion


            // Inventory menu

            Utility.Action(columns, player);

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

            Console.ReadLine();

        }
    }
} 