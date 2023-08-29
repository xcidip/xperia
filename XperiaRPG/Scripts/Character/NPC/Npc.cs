using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XperiaRPG.Scripts.Character.NPC;
using XperiaRPG.Scripts.Items;
using XperiaRPG.Scripts.UI;

namespace XperiaRPG.Scripts.Character.NPC
{

    public class DialogNode
    {
        public string Text { get; set; }
        public List<DialogNode> Responses { get; set; }
    }


    public class Npc
    {
        // no stats, skills 
        // for giving quests, talking, selling stuff
        public string Name { get; set; }
        public DialogNode DialogTree { get; set; }

        public Npc(string name,DialogNode dialogTree)
        {
            Name = name;
            DialogTree = dialogTree;
        }

        public void Talk()
        {
            while (true)
            {
                // if DialogTree used instead it would break the npc
                var dialogTree = DialogTree;

                while (true)
                {
                    Console.Clear();

                    // if badly programmed
                    if (dialogTree.Responses == null)
                    {
                        Console.WriteLine("Badly written dialog - bugged");
                        Choice.PressEnter();
                        break;
                    }

                    // display the option you picked
                    Console.WriteLine("{0}\n", dialogTree.Text);

                    //display the responses
                    for (var i = 0; i < dialogTree.Responses.Count; i++) Console.WriteLine($"({i + 1}) {dialogTree.Responses[i].Text}");

                    if (dialogTree.Responses.Count == 1) break;


                    // Get player's choice
                    var choice = Choice.NumberRangeValidation(1, dialogTree.Responses.Count);

                    // Update currentNPC based on player choice
                    dialogTree = dialogTree.Responses[choice - 1];
                }

                Console.WriteLine("\ntalk again?");


                var talkAgain = Choice.YesNoValidation();
                if (talkAgain == 'n') return;


            }
        }
    }
    public class NpcList
    {
        private readonly List<Npc> List;
        public NpcList()
        {
            List = new List<Npc>
            {
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
                                    "it is an RPG world filled with creatures, quests and grind",
                                }
                            }
                        },
                        new DialogNode
                        {
                            Text = "Goodbye!"
                        },
                    },
                }
                ),


                




            };
        }
        public Npc Lookup(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            return List.FirstOrDefault(a => a?.Name == name);
        }
    }
}
