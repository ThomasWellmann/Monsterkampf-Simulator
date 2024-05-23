using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Monsterkampf_Simulator
{//█▀▄
    class Monster
    {
        public int type { get; set; }
        public int HP { get; set; }
        public int AP { get; set; }
        public int DP { get; set; }
        public int S { get; set; }

        public Monster(int _type, int _hp, int _ap, int _dp, int _s)
        {
            type = _type; 
            HP = _hp; 
            AP = _ap; 
            DP = _dp; 
            S = _s;
        }

        public static void DrawOrc(int _x, int _y)
        {
            Lobby.PrintText("  ██  ", ConsoleColor.Gray, _x, _y);
            Lobby.PrintText("█▀██▀█", ConsoleColor.Gray, _x, _y + 1);
            Lobby.PrintText("█▄██▄█", ConsoleColor.Gray, _x, _y + 2);
            Lobby.PrintText(" █  █ ", ConsoleColor.Gray, _x, _y + 3);
        }
        public static void DrawTroll(int _x, int _y)
        {
            Lobby.PrintText("  ██  ", ConsoleColor.DarkYellow, _x, _y);
            Lobby.PrintText("█▀██▀█", ConsoleColor.DarkYellow, _x, _y + 1);
            Lobby.PrintText("█▄██▄█", ConsoleColor.DarkYellow, _x, _y + 2);
            Lobby.PrintText(" █  █ ", ConsoleColor.DarkYellow, _x, _y + 3);
        }
        public static void DrawGoblin(int _x, int _y)
        {
            Lobby.PrintText("  ██  ", ConsoleColor.DarkGreen, _x, _y);
            Lobby.PrintText("█▀██▀█", ConsoleColor.DarkGreen, _x, _y + 1);
            Lobby.PrintText("█▄██▄█", ConsoleColor.DarkGreen, _x, _y + 2);
            Lobby.PrintText(" █  █ ", ConsoleColor.DarkGreen, _x, _y + 3);
        }
    }
}
