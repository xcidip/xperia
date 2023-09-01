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
            while (true)
            {
                var currentNode = DialogTree; // Start with the initial dialog node
                while (true)
                {
                    Console.Clear();

                    // Display the current dialog text
                    Console.WriteLine($"{currentNode?.Text}\n");
                    
                    var questionCount = 0; // number of the question

                    // Display action responses if they exist
                    if (currentNode?.ActionResponses != null)
                    {
                        foreach (var response in currentNode.ActionResponses)
                        {
                            Console.WriteLine($"({questionCount+1}) {response.Item1}"); // Display action response options
                            questionCount++;
                        }
                    }
                    // Display dialogue responses if they exist
                    if (currentNode?.DialogResponses != null)
                    {
                        foreach (var response in currentNode.DialogResponses)
                        {
                            Console.WriteLine($"({questionCount+1}) {response.Item1}"); // Display action response options
                            questionCount++;
                        }
                    }

                    // if there were no available questions
                    if (questionCount <= 0)
                    {
                        Console.WriteLine("\nBadly programmed conversation."); // If there are no responses, end the conversation
                        break;
                    }

                    // Depending on choice do the latter
                    var choice = Choice.NumberRangeValidation(1, questionCount); // Get the user's choice
                    if (choice <= (currentNode?.ActionResponses?.Count ?? 0))
                    {
                        // Execute the associated action when an action response is selected
                        currentNode?.ActionResponses?[choice - 1].Item2.Invoke(player);
                        break;
                    }
                    // Move to the next dialog node when a dialogue response is selected
                    if (currentNode?.ActionResponses != null) 
                        currentNode = currentNode?.DialogResponses?[choice - currentNode.ActionResponses.Count - 1].Item2;
                }
                Console.WriteLine("Talk again?");
                if (Choice.YesNoValidation() == 'n') return;
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
                            player.QuestLog.QuestNpc("First Quest",player);
                        }),
                        ("Second Quest", (Player player) =>
                        {
                            player.QuestLog.QuestNpc("Second Quest",player);
                        }),
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

