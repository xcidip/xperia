using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XperiaRPG.Scripts.Character.NPC;
using XperiaRPG.Scripts.Character.Player;
using XperiaRPG.Scripts.Items;
using XperiaRPG.Scripts.UI;

namespace XperiaRPG.Scripts.Character.NPC
{
    public delegate void ActionDelegate(Player.Player player); // interesting thing that lets you make methods inside objects

    public class DialogNode
    {
        public string Text { get; set; }
        public List<(string, ActionDelegate)> ActionResponses { get; set; } // Text + Quest giving for example
        public List<(string, DialogNode)> DialogResponses { get; set; } // Text + new dialog
    }

    public class Npc
    {
        public string Name { get; set; }
        public DialogNode DialogTree { get; set; }

        public Npc(string name, DialogNode dialogTree)
        {
            Name = name;
            DialogTree = dialogTree;
        }

        public void Talk(Player.Player player)
        {
            var currentNode = DialogTree; // Start with the initial dialog node

            while (true)
            {
                Console.Clear(); // Clear the console for a clean display

                Console.WriteLine($"{currentNode?.Text}\n"); // Display the current dialog text


                // Display action responses if they exist
                if (currentNode?.ActionResponses != null)
                {
                    for (var i = 0; i < currentNode.ActionResponses.Count; i++)
                    {
                        Console.WriteLine($"({i+1}) {currentNode.ActionResponses[i].Item1}"); // Display action response options
                    }
                }
                // Display dialogue responses if they exist
                if (currentNode?.DialogResponses != null)
                {
                    for (var i = 0; i < currentNode.DialogResponses.Count; i++)
                    {
                        Console.WriteLine($"({i + 1}) {currentNode.DialogResponses[i].Item1}"); // Display dialogue response options
                    }
                }


                // Calculate the total number of available responses
                var totalResponses = (currentNode?.ActionResponses?.Count ?? 0) + (currentNode?.DialogResponses?.Count ?? 0);
                if (totalResponses == 0)
                {
                    Console.WriteLine("\nEnd of conversation."); // If there are no responses, end the conversation
                    return;
                }

                var choice = Choice.NumberRangeValidation(1, totalResponses); // Get the user's choice

                if (choice <= (currentNode?.ActionResponses?.Count ?? 0))
                {
                    // Execute the associated action when an action response is selected
                    currentNode?.ActionResponses?[choice - 1].Item2.Invoke(player);
                }
                else
                {
                    // Move to the next dialog node when a dialogue response is selected
                    currentNode = currentNode?.DialogResponses?[choice - currentNode.ActionResponses.Count - 1].Item2;
                }

                Console.WriteLine("talk more?"); //todo
                Console.ReadLine();
                return;
            }
        }
    }
}
public class NpcList
{
    public readonly List<Npc> List;
    public NpcList()
    {
        List = new List<Npc>
            {
                /*
                new Npc("Norwyn", new DialogNode
                {
                    Text = "Hey there, I am Norwyn and i will guide you through the tutorial",
                    Responses = new List<DialogNode>
                    {
                        new DialogNode
                        { 
                            Text = "Tell me about this place",
                            Responses = new List<DialogNode>
                            {
                                new DialogNode
                                {
                                    Text = "\tWell, this place is just an ordinary island with few things going on\n" +
                                    "\tyou can learn skills to start your journey on the planet xperia and basic things\n" +
                                    "\tlike killing enemies and crafting your first weapon and armor",
                                }
                            }
                        },
                        new DialogNode
                        {
                            Text = "What am I doing here?",
                            Responses = new List<DialogNode>
                            {
                                new DialogNode
                                {
                                    Text = "Looks like you just spawned in, well welcome to the planet xperia" +
                                    "it is an RPG world filled with creatures, quests and most of all grind. jk",
                                }
                            }
                        },
                        new DialogNode
                        {
                            Text = "Goodbye!"
                        },
                    },
                }),
                */
                new Npc("QuestTestNpc", new DialogNode
                {
                    Text = "Welcome to the adventure!",
                    ActionResponses = new List<(string, ActionDelegate)>
                    {
                        ("First Quest", (Player player) =>
                        {
                            var questName = "First Quest";
                            if (player.QuestLog.IsQuestFinished("First Quest"))
                            {

                            }
                            else
                            {
                                player.QuestLog.StartQuest("First Quest");
                            }

                            Choice.PressEnter();
                        }),
                        // Add more action responses
                    },
                    DialogResponses = new List<(string, DialogNode)>
                    {
                        ("Tell me more about combat", new DialogNode
                        {
                            Text = "Combat in this world is...",
                            ActionResponses = new List<(string, ActionDelegate)>
                            {
                                ("Ask about combat skills", (Player player) =>
                                {
                                    Console.WriteLine("You can improve your combat skills by...");
                                }),
                                // Add more action responses within the nested dialog
                            },
                            DialogResponses = new List<(string, DialogNode)>
                            {
                                // Add more responses or end the conversation
                            }
                        }),
                        // Add more dialog responses
                    }
                }),







    };
    }
    public Npc Lookup(string name)
    {
        if (name == null) throw new ArgumentNullException(nameof(name));
        return List.FirstOrDefault(a => a?.Name == name);
    }
}

