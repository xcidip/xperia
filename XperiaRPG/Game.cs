using System;
using System.Collections.Generic;
using System.Threading;
using XperiaRPG.Assets.Sprites;
using XperiaRPG.Scripts.Character.NPC;
using XperiaRPG.Scripts.Character.Player;
using XperiaRPG.Scripts.Character.Player.CharacterCreation;
using XperiaRPG.Scripts.Characters;
using XperiaRPG.Scripts.Fighting;
using XperiaRPG.Scripts.Items;
using XperiaRPG.Scripts.Misc;
using XperiaRPG.Scripts.Skills;
using XperiaRPG.Scripts.Skills.Gathering;
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
            Console.WriteLine("\n\nhow many columns? (2-minimized window) (4-1080p fulscreen) (7-2160p fulscreen)");
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
            
            characterInfo = new PlayerSetting[6];
            characterInfo[0] = new RaceList().Lookup("Human");
            characterInfo[1] = new ProfessionList().Lookup("Mage");
            characterInfo[2] = new DifficultyList().Lookup("Hard");
            characterInfo[3] = new Name("TestMan");
            characterInfo[4] = new SuffixList().Lookup("the Tough guy");
            characterInfo[5] = new SexualityList().Lookup("Celibacy");
            
            #endregion

            // create player
            var player = new Player(characterInfo);


            #region Tutorial

            var npcList = new NpcList();
            Tutorial.Start(npcList, player);




            #endregion


            /* skill level scaling
             * lvl 1 - any xp
             * lvl 2 - 83 xp
             * 
             */





            var world = new World(new Zone("World: Xperia", "world")
            {
                ZoneTeleports = new List<Zone>
                {
                    new Zone("Turorial island", "Area")
                    {
                        Description = "Tutorial zone to learn how the game works",
                        ZoneTeleports = new List<Zone>
                        {
                            new Zone("Village", "Village")
                            {
                                Distance = 2,
                                Description = "The only village on the island",
                            }
                        }
                    }
                },
                Actions = new List<(string, MoveDelegate)>
                {
                    ("Some action!?!", (Player person) => Console.Write("nějaká akce"))

                }
            });

            //world.Move(player);

            Console.WriteLine("End of program!");
            Console.ReadLine();

        }
    }
} 