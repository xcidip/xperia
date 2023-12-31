﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XperiaRPG.Scripts.Character.Player;
using XperiaRPG.Scripts.Character.Player.Inventory;
using XperiaRPG.Scripts.Items;
using XperiaRPG.Scripts.Skills;
using XperiaRPG.Scripts.Skills.Crafting;

namespace XperiaRPG.Scripts.UI
{
    public class Action
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public Action(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
    public class ActionList
    {
        public List<Action> List { get; set; }

        public ActionList(int invLength)
        {
            List = new List<Action>
            {
                new Action($"0-{invLength}", "Item"),
                new Action("a", "Attributes"),
                new Action("c", "Crafting"),
                new Action("g", "Gear"),
                new Action("q", "Quest Log"),
            };
        }
        public Action Lookup(string key)
        {
            return List.FirstOrDefault(a => a?.Key == key);
        }
    }

    public static class ActionUtility
    {
        public static void Action(Player player)
        {
            var inventory = player.Inventory;
            var invLength = inventory.List.Count;
            var gear = player.Gear;
            var statList = player.Stats;
            var skillList = player.Skills;
            var combatStatList = player.CombatStats;
            var questLog = player.QuestLog;

            while (true)
            {


                gear.Print(skillList, statList);
                statList.Print();
                combatStatList.ResetAfterCombat();
                combatStatList.Print();
                skillList.Print();
                inventory.Print();


                var choice = Choice.InventoryActionInput(invLength);
                switch (choice)
                {
                    // tell more about what stats & skills does
                    case "a":
                        Console.Clear();
                        statList.Print();
                        statList.Explain();

                        Choice.PressEnter();

                        skillList.Print();
                        skillList.Explain();

                        Choice.PressEnter();
                        break;
                    // 1) what skill 2) show recipes 3) craft
                    case "c":
                        var craftingSkillList = skillList.QueryByTypeList("Crafting");
                        var i = 1;
                        Console.Clear();
                        foreach (var skill in craftingSkillList)
                        {
                            Console.WriteLine($"({i}) {skill.Name}");
                            i++;
                        }
                        var whatSkill = craftingSkillList[Choice.NumberRangeValidation(1, craftingSkillList.Count) - 1].Name;
                        switch (whatSkill)
                        {
                            case "Cooking":
                                var cooking = new Cooking();
                                cooking.Print();
                                inventory.Print();
                                cooking.WhatToCraft(inventory,skillList);
                                break;
                            case "Smithing":
                                var smithing = new Smithing();
                                smithing.Print();
                                inventory.Print();
                                smithing.WhatToCraft(inventory,skillList);
                                break;
                            case "Lthrworking":
                                var lthrworking = new Lthrworking();
                                lthrworking.Print();
                                inventory.Print();
                                lthrworking.WhatToCraft(inventory,skillList);
                                break;
                            case "Alchemy":
                                var alchemy = new Alchemy();
                                alchemy.Print();
                                inventory.Print();
                                alchemy.WhatToCraft(inventory, skillList);
                                break;
                            case "Tailoring":
                                var tailoring = new Tailoring();
                                tailoring.Print();
                                inventory.Print();
                                tailoring.WhatToCraft(inventory, skillList);
                                break;
                        }
                        break;
                    // show gear menu (unequip, examine gear)
                    case "g":
                        Console.Clear();
                        gear.GearMenu(player);
                        Console.Clear();
                        break;
                    // quest log
                    case "q":
                        Console.Clear();
                        player.QuestLog.Print(); // todo quest interaction

                        // (1) see all started quest / finished and not delivered
                        // (2) see all unstarted quests
                        // (3) see all hidden quests (completed quests)
                        Choice.PressEnter();
                        break;
                    // Interact with items
                    default:
                        if (int.TryParse(choice, out var number))
                        {
                            if (number == 0) return;
                            var item = inventory.List[number - 1];
                            Console.WriteLine($"\nItem Selected: {item.Name}");

                            ItemInteraction.ItemInteract(item, player, number);
                            break;
                        }

                        Console.WriteLine("You found the easter egg. Type just one number not whole option next time");
                        Choice.PressEnter();
                        continue;

                }


            }
        }
    }
}
