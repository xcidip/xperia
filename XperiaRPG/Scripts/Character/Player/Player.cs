using System;
using System.Collections.Generic;
using XperiaRPG.Scripts.Attributes;
using XperiaRPG.Scripts.Character.Player.CharacterCreation;
using XperiaRPG.Scripts.Character.Player.Inventory;
using XperiaRPG.Scripts.CharacterCreation;
using XperiaRPG.Scripts.Characters.Inventory;
using XperiaRPG.Scripts.UI;

namespace XperiaRPG.Scripts.Character.Player
{
    public class Player : Character
    {
        #region Variables

        public int LevelXp { get; set; }
        public int Level { get; set; }
        public PlayerSetting[] CharacterInfo { get; set; }
        public SkillList SkillList { get; set; }
        public Characters.Inventory.Inventory Inventory { get; set; }
        public Gear Gear { get; set; }
        

        
        #endregion
        
        #region CharacterCreationOptions

        private static PlayerSetting _ChooseRace()
        {
            var listOfOptions = new RaceList();
            return Utility.PrintCharacterCreationSetting(listOfOptions," {0,-7} {1,-27} {4}");
        }
        private static PlayerSetting _ChooseProfession()
        {
            var listOfOptions = new ProfessionList();
            return Utility.PrintCharacterCreationSetting(listOfOptions," {0,-7} {1,-27} Wears: {2,-17} Uses: {4}");
        }
        private static PlayerSetting ChooseDifficulty()
        {
            var listOfOptions = new DifficultyList();
            return Utility.PrintCharacterCreationSetting(listOfOptions," {0,-7} scaling: {3,-6} {4}");
        }
        private static PlayerSetting _ChooseName()
        {
            return new Name(Choice.NameValidation());
        }
        private static PlayerSetting _ChooseSuffix()
        {
            var listOfOptions = new SuffixList();
            return Utility.PrintCharacterCreationSetting(listOfOptions, " {0,-25} {1,-27} {4}");
        }
        private static PlayerSetting _ChooseSexuality()
        {
            var listOfOptions = new SexualityList();
            return Utility.PrintCharacterCreationSetting(listOfOptions, " {0,-12} {1,-27} {4}");
        }
        
        private static void PrintWhatToChange(IList<PlayerSetting> characterInfo)
        {
            Console.Clear();
            string[] options = { "Race", "Profession", "Difficulty", "Name", "Suffix", "Sexuality" };
            var i = 0;
            foreach (var option in options)
            {
                Console.WriteLine(characterInfo[i] != null
                    ? $"({i+1}) {option,-15} {characterInfo[i].Name}"
                    : $"({i+1}) {option,-15} -");
                i++;
            }
        }
        public static IEnumerable<PlayerSetting> WhatToChange()
        {
            var characterInfo = new PlayerSetting[6];
            
            while (true)
            {
                PrintWhatToChange(characterInfo);
                
                var choice = Choice.NumberRangeValidation(1, characterInfo.Length);
                switch (choice)
                {
                    case 1:
                        characterInfo[0] = _ChooseRace();
                        break;
                    case 2:
                        characterInfo[1] = _ChooseProfession();
                        break;
                    case 3:
                        characterInfo[2] = ChooseDifficulty();
                        break;
                    case 4:
                        characterInfo[3] = _ChooseName();
                        break;
                    case 5:
                        characterInfo[4] = _ChooseSuffix();
                        break;
                    case 6:
                        characterInfo[5] = _ChooseSexuality();
                        break;
                }

                if (characterInfo[0] == null ||
                    characterInfo[1] == null ||
                    characterInfo[2] == null ||
                    characterInfo[3] == null ||
                    characterInfo[4] == null ||
                    characterInfo[5] == null) continue;
                PrintWhatToChange(characterInfo);
                Console.WriteLine("Is everything ok?");
                if (Choice.YesNoValidation() == 'y') { break; }
            }
    
            return characterInfo;
            
        }

        #endregion

        private static void CharacterCreationBonuses(PlayerSetting[] characterInfo, StatList statList, SkillList skillList)
        {
            var whatOptionsHaveBonuses = new List<int>
        {
            0,1,4,5
        };

            foreach (var i in whatOptionsHaveBonuses)
            {
                var bonus = characterInfo[i]?.AttributeBonus;
                
                if (bonus == null) return;
                var name = bonus.Name;
                var amount = bonus.Amount;
                var unit = bonus.Unit;

                if (skillList.Lookup(name) != null)
                {
                    if (unit == "%")
                    {
                        skillList.AddPercentBonus(name, amount);
                        return;
                    }
                    skillList.AddXp(name, amount);
                    return;
                }

                if (statList.Lookup(name) == null) return;
                statList.AddPoints(name, amount);

            }

        }

        public Player(PlayerSetting[] characterInfo)
        {
            CharacterInfo = characterInfo;

            // Stats
            StatList = new StatList(50, 5, 0, 0, 0, 5, 5, 5, 1);

            // Skills
            SkillList = new SkillList();

            // creation bonuses
            if (characterInfo[2].Name != "Pure")
            {
                CharacterCreationBonuses(characterInfo, StatList, SkillList);
            }
            
            // Inventory
            Inventory = new Characters.Inventory.Inventory();

            // Weapons and Armor Inventory
            Gear = new Gear();
        }
    }
    
    
}