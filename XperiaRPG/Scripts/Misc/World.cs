using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XperiaRPG.Scripts.Character.NPC;
using XperiaRPG.Scripts.Character.Player;
using XperiaRPG.Scripts.Character.Player.CharacterCreation;
using XperiaRPG.Scripts.Characters;
using XperiaRPG.Scripts.Skills;
using XperiaRPG.Scripts.UI;

namespace XperiaRPG.Scripts.Misc
{
    // World(xperia) > Zone(Ashenfire Valley) > GatheringSpot (flower forest)
    //                                        > Dungeon (skeleton's den)
    //                                        > City > District(Crafting district) > Location(Blacksmith, Quest giver)
    //                                               > Location(Blacksmith, Quest giver)
    //                                        > Village > Location(Blacksmith, Quest giver)


    public delegate void MoveDelegate(Player person); // interesting thing that lets you make methods inside objects

    public class Zone
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Distance { get; set; }
        public List<(string, MoveDelegate)> Actions { get; set; } // Text + Quest giving for example
        public List<Zone> ZoneTeleports { get; set; } // Text + new dialog

        public Zone(string name, string type)
        {
            Name = name;
            Type = type;
        }
    }

    public class World
    {
        private readonly Stack<Zone> visitedZones = new Stack<Zone>(); // stack to keep track of visited zones

        public Zone ZoneTree { get; set; } // list of zones/biomes/cities/villages

        public World(Zone zoneTree)
        {
            ZoneTree = zoneTree;
        }

        public void Move(Player player)
        {
            while (true)
            {
                Console.Clear();
                var zone = ZoneTree;

                while (true)
                {
                    Console.WriteLine($"{zone.Name}");

                    var numOfOptions = 0;
                    var ListOfDialogResponses = new List<int>();
                    var ListOfActionResponses = new List<int>();

                    #region Printing choices
                    if (zone.ZoneTeleports != null)
                    {
                        foreach (var option in zone.ZoneTeleports)
                        {
                            Console.WriteLine($"({numOfOptions + 1}) {option.Name}");
                            numOfOptions++;
                            ListOfDialogResponses.Add(numOfOptions);
                        }
                    }

                    if (zone.Actions != null)
                    {
                        foreach (var option in zone.Actions)
                        {
                            Console.WriteLine($"({numOfOptions + 1}) {option.Item1}");
                            numOfOptions++;
                            ListOfActionResponses.Add(numOfOptions);
                        }
                    }
                    if (visitedZones.Count > 0)
                    {
                        Console.WriteLine($"({numOfOptions + 1}) Go back!");
                        numOfOptions++;
                    }
                        #endregion


                    if (numOfOptions == 0)
                    {
                        break;
                    }

                    var choice = Choice.NumberRangeValidation(1, numOfOptions);

                    if (ListOfActionResponses.Contains(choice))
                    {
                        zone?.Actions?[choice - 1 - ListOfDialogResponses.Count].Item2.Invoke(player);
                        break;
                    }

                    if (ListOfDialogResponses.Contains(choice))
                    {
                        visitedZones.Push(zone); // push current zone to the stack before moving
                        zone = zone?.ZoneTeleports?[choice - 1];
                        if (zone.Distance > 0) Traveling.Travel(zone.Distance);
                    }

                    if (choice == numOfOptions)
                    {
                        if (zone.Distance > 0) Traveling.Travel(zone.Distance);
                        zone = visitedZones.Pop(); // pop the last visited zone from the stack
                    }

                }

                
            }
        }
    }

}
