using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XperiaRPG.Scripts.Items;

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
            DialogTree = dialogTree;
        }

        public void Talk()
        {
            Console.WriteLine(DialogTree.Text);
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
                                    Text = "Well, this place is just an ordinary island with few things going on\n" +
                                    "you can learn skills to start your journey on the planet xperia and basic things" +
                                    "like killing enemies and crafting your first weapon and armor",
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
                }),


                




            };
        }
        public Npc Lookup(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            return List.FirstOrDefault(a => a?.Name == name);
        }
    }
}
