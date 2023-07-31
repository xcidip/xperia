using System;
using System.Collections.Generic;
using XperiaRPG.Scripts.Attributes;
using XperiaRPG.Scripts.Character.Player;
using XperiaRPG.Scripts.CharacterCreation;
using XperiaRPG.Scripts.Characters;

namespace XperiaRPG
{
    internal static class Game
    {
        public static void Main()
        {
            var skillList = new SkillList();

            Console.Read();
            skillList.Print(5);

            var statList = new StatList(5, 5, 0, 0, 0, 5, 5, 5, 1);
            statList.Print(5);



            var characterInfo = Player.WhatToChange();

            //var player = Player(characterInfo);

        }
    }
}