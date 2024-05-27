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

        private static string[] monsterDrawn = { 
            "  ██  ", 
            "█▀██▀█", 
            "█▄██▄█", 
            " █  █ " };

        public Monster(int _type, int _hp, int _ap, int _dp, int _s)
        {
            type = _type; 
            HP = _hp; 
            AP = _ap; 
            DP = _dp; 
            S = _s;
        }

        public static void DrawMonster(int _monster, int _x, int _y)
        {
            ConsoleColor monsterColor = Lobby.defaultBColor;

            if (_monster == 1)
                monsterColor = ConsoleColor.DarkGray;
            else if (_monster == 2)
                monsterColor = ConsoleColor.DarkGreen;
            else if (_monster == 3)
                monsterColor = ConsoleColor.DarkYellow;

            for (int i = 0; i < 4; i++)
            {
                Lobby.PrintText(monsterDrawn[i], monsterColor, _x, _y + i);
            }
        }

        public static int[] Attack(Monster _attacker, Monster _defender)
        {
            int dmgDelt = _attacker.AP - _defender.DP;
            _defender.HP -= dmgDelt;
            int[] attackLog = {dmgDelt, _defender.HP};
            return attackLog;
        }
    }
}
