using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XperiaRPG.Scripts.Character;
using XperiaRPG.Scripts.Character.Attributes;
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
        public List<Requirement> Requirements { get; set; } // skill requirements for selecting that option
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
            // start new conversation or again start the same
            while (true)
            {
                Console.Clear();
                var dialog = DialogTree;

                // one conversation
                while (true)
                {

                    Console.WriteLine($"{Name}:\n{dialog.Text}");

                    var numOfOptions = 0;

                    var ListOfDialogResponses = new List<int>();
                    var ListOfActionResponses = new List<int>();

                    // if DialogResponses exists show dialog options
                    if (dialog.DialogResponses != null)
                    {
                        foreach (var option in dialog.DialogResponses)
                        {
                            Console.WriteLine($"({numOfOptions + 1}) {option.Item1}");
                            numOfOptions++;
                            ListOfDialogResponses.Add(numOfOptions);
                        }
                    }

                    // if ActionResponses exists show action options
                    if (dialog.ActionResponses != null)
                    {
                        foreach (var option in dialog.ActionResponses)
                        {
                            Console.WriteLine($"({numOfOptions + 1}) {option.Item1}");
                            numOfOptions++;
                            ListOfActionResponses.Add(numOfOptions);
                        }
                    }

                    if (numOfOptions == 0)
                    {
                        break;
                    }

                    // choose what option
                    var choice = Choice.NumberRangeValidation(1, numOfOptions);

                    // Execute the associated action when an action response is selected
                    if (ListOfActionResponses.Contains(choice))
                    {
                        dialog?.ActionResponses?[choice - 1 - ListOfDialogResponses.Count].Item2.Invoke(player); //invoke the delegate
                        break;
                    }

                    // Move to the next dialog node when a dialogue response is selected
                    if (ListOfDialogResponses.Contains(choice))
                    {
                        dialog = dialog?.DialogResponses?[choice - 1].Item2;                       
                    }
                }
                Console.WriteLine("\nTalk again?");
                if (Choice.YesNoValidation() == 'n')
                {
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
                new Npc("Norwyn", new DialogNode
                    {
                        Text = "Hey there, I am Norwyn and i will guide you through the basics of how to survive here!",
                        DialogResponses = new List<(string, DialogNode)>
                        {
                            ("Tell me about this place.",new DialogNode
                            {
                                Text = "Well, this place is just an ordinary island with few things going on. You can learn skills to start your journey on the planet xperia and learn basic things like killing enemies and crafting your first weapon and armor",
                            }),

                            ("What am I doing here?",new DialogNode
                            {
                                Text = "Looks like you just spawned in, well welcome to the planet xperia it is an RPG world filled with creatures, quests and most of all grind. jk",
                            }),
                        },
                        ActionResponses = new List<(string, ActionDelegate)>
                        {
                            ("Lets start!", (Player.Player player) =>
                            {
                                Console.WriteLine("delagate test is working");
                            }),
                            ("Goodbye!",(Player.Player player) => {})
                        }

                        
                    }
                ),
            };
    
        }

        public Npc Lookup(string name)
        {
            return List.FirstOrDefault(x => x.Name == name);
        }
    }
    
}