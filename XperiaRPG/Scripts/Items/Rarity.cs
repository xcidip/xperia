using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XperiaRPG.Scripts.Items
{
    public class Rarity
    {
        public (ConsoleColor Foreground, ConsoleColor Background) Common { get; } = (ConsoleColor.White, ConsoleColor.Black);
        public (ConsoleColor Foreground, ConsoleColor Background) Uncommon { get; } = (ConsoleColor.Green, ConsoleColor.Black);
        public (ConsoleColor Foreground, ConsoleColor Background) Rare { get; } = (ConsoleColor.Blue, ConsoleColor.Black);
        public (ConsoleColor Foreground, ConsoleColor Background) Epic { get; } = (ConsoleColor.Magenta, ConsoleColor.Black);
        public (ConsoleColor Foreground, ConsoleColor Background) Legendary { get; } = (ConsoleColor.Yellow, ConsoleColor.Black);
    }
}
