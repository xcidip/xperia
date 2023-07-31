namespace XperiaRPG.Assets.Sprites
{
    public class WelcomeSprite
    {
        /*
            o   \ o /  _ o         __|    \ /     |__        o _  \ o /
           /|\    |     /\   ___\o   \o    |    o/    o/__   /\     |   
           / \   / \   | \  /)  |    ( \  /o\  / )    |  (\  / |   / \  
        */

        public readonly string[] StickMan;
        
        public WelcomeSprite()
        {
            StickMan = new string[] {
                " o \r\n/|\\\r\n/ \\",
                "\\ o /\r\n  |  \r\n / \\",
                "  _ o\r\n  /\\\r\n | \\",
                "        \r\n   ___\\o\r\n  /)  | " ,
                "   __|  \r\n     \\o \r\n     ( \\",
                "     \\ /  \r\n      | \r\n     /o\\",
                "         |__\r\n       o/   \r\n      / )",
                "              \r\n         o/__ \r\n         |  (\\",
                "             o _\r\n             /\\ \r\n             / |",
                "             \\ o /\r\n               |  \r\n              / \\",
            };
        }
    }
}