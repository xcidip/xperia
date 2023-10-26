using System;
using System.Collections.Generic;
using XperiaRPG.Scripts.Character.Attributes;
using XperiaRPG.Scripts.Character.Player.CharacterCreation;
using XperiaRPG.Scripts.Character.Player.Inventory;
using XperiaRPG.Scripts.UI;

namespace XperiaRPG.Scripts.Character.Player
{
    public class Player : Character
    {
        #region Variables

        public PlayerSetting[] CharacterInfo { get; set; }
        public Attributes.Skills Skills { get; set; }
        public Inventory.Inventory Inventory { get; set; }
        public Gear Gear { get; set; }
        public CurrencyBag CurrencyBag { get; set; }
        public BattleAttributeList BattleAttributes { get; set; }
        public QuestLog QuestLog { get; set; }

        #endregion

        #region CharacterCreationOptions

        private static PlayerSetting ChooseRace()
        {
            var listOfOptions = new RaceList();
            return Utility.PrintCharacterCreationSetting(listOfOptions, " {0,-7} {1,-27} {4}");
        }

        private static PlayerSetting ChooseProfession()
        {
            var listOfOptions = new ProfessionList();
            return Utility.PrintCharacterCreationSetting(listOfOptions, " {0,-7} {1,-27} Wears: {2,-17} Uses: {4}");
        }

        private static PlayerSetting ChooseDifficulty()
        {
            var listOfOptions = new DifficultyList();
            return Utility.PrintCharacterCreationSetting(listOfOptions, " {0,-7} scaling: {3,-6} {4}");
        }

        private static PlayerSetting ChooseName()
        {
            return new Name(Choice.NameValidation());
        }

        private static PlayerSetting ChooseSuffix()
        {
            var listOfOptions = new SuffixList();
            return Utility.PrintCharacterCreationSetting(listOfOptions, " {0,-25} {1,-27} {4}");
        }

        private static PlayerSetting ChooseSexuality()
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
                    ? $"({i + 1}) {option,-15} {characterInfo[i].Name}"
                    : $"({i + 1}) {option,-15} -");
                i++;
            }
        }

        public static PlayerSetting[] WhatToChange()
        {
            var characterInfo = new PlayerSetting[6];

            while (true)
            {
                PrintWhatToChange(characterInfo);

                var choice = Choice.NumberRangeValidation(1, characterInfo.Length);
                switch (choice)
                {
                    case 1:
                        characterInfo[0] = ChooseRace();
                        break;
                    case 2:
                        characterInfo[1] = ChooseProfession();
                        break;
                    case 3:
                        characterInfo[2] = ChooseDifficulty();
                        break;
                    case 4:
                        characterInfo[3] = ChooseName();
                        break;
                    case 5:
                        characterInfo[4] = ChooseSuffix();
                        break;
                    case 6:
                        characterInfo[5] = ChooseSexuality();
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
                if (Choice.YesNoValidation() == 'y')
                {
                    break;
                }
            }

            return characterInfo;

        }

        #endregion

        // Stat, skill bonuses for character creation
        private void CharacterCreationBonuses(PlayerSetting[] characterInfo, Stats stats, Attributes.Skills skills)
        {
            //todo instead use ChangeAttributeValue
            var whatOptionsHaveBonuses = new List<int>
            {
                0, 1, 4, 5
            };

            foreach (var index in whatOptionsHaveBonuses)
            {
                var bonus = characterInfo[index]?.AttBonus;
                if (bonus == null) return;
                ChangeAttributeValue(bonus, true);
            }

        }
        public void ChangeAttributeValue(AttBonus attBonus, bool addOrRemove)
        {
            var multiplier = 1;
            if (!addOrRemove) multiplier = -1;

            switch (attBonus.Unit)
            {
                case "points":
                    Stats.AddPoints(attBonus.Name, attBonus.Amount * multiplier);
                    break;
                case "%":
                    Skills.AddPercentBonus(attBonus.Name, attBonus.Amount * multiplier);
                    break;
                case "xp":
                    Skills.AddXp(attBonus.Name, attBonus.Amount * multiplier);
                    break;
            }
        }

        public Player(PlayerSetting[] characterInfo)
        {
            CharacterInfo = characterInfo;

            // Stats
            Stats = new Stats(50, 5, 0, 0, 0, 5, 5, 5, 1);

            // Skills
            Skills = new Attributes.Skills();

            // creation bonuses
            if (characterInfo[2].Name != "Pure")
            {
                CharacterCreationBonuses(characterInfo, Stats, Skills);
            }
            
            // Battle attributes like health, dmg reduction, etc..
            BattleAttributes = new BattleAttributeList(Stats);

            // QuestLog
            QuestLog = new QuestLog();

            // Inventory
            Inventory = new Inventory.Inventory();

            // Weapons and Armor Inventory
            Gear = new Gear();

            // Currency Bag
            CurrencyBag = new CurrencyBag();
        }

        public void Action()
        {
            ActionUtility.Action(this);
        }


        public bool CheckRequirements(List<Requirement> requirements)
        {
            var notMetRequirements = "";
            var meetingRequirements = true;

            foreach (var item in requirements) 
            {
                if (Stats.Lookup(item.Name) != null)
                {
                    if (item.RequiredValue >= Stats.Lookup(item.Name).Value)
                    {
                        notMetRequirements += $"{item.Name} is too low, you need atleast {item.RequiredValue}\n";
                        meetingRequirements = false;
                    }
                }
                if (Skills.Lookup(item.Name) != null)
                {
                    if (item.RequiredValue <= Skills.Lookup(item.Name).Value)
                    {
                        notMetRequirements += $"{item.Name} is too low, you need atleast {item.RequiredValue}\n";
                        meetingRequirements = false;
                    }
                }
            }

            Console.WriteLine(notMetRequirements);

            return meetingRequirements;
        }


    }
    public class Requirement
    {
        public string Name { get; set; }
        public int RequiredValue { get; set; }

        public Requirement(string name, int value)
        {
            Name = name;
            RequiredValue = value;
        }
    }
    
}