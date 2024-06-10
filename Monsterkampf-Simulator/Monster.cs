using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Monsterkampf_Simulator
{//█▀▄
    public class Monster
    {
        #region
        public int type;
        public int HP;
        public int AP;
        public int DP;
        public int AS;
        public string name;
        private static string crited;
        static Random rnd = new Random();
        #endregion
        

        private static string[] monsterDrawn = {
            "  ██  ",
            "█▀██▀█",
            "█▄██▄█",
            " █  █ " };

        public Monster(int _type, int _hp, int _ap, int _dp, int _as, string _name)
        {
            type = _type;
            HP = _hp;
            AP = _ap;
            DP = _dp;
            AS = _as;
            name = _name;
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

        public static string[] Attack(Monster _attacker, Monster _defender)
        {
            int dmgDelt = 0;
            if (_attacker.type == 1)
            {
                dmgDelt = _attacker.AP - _defender.DP;
                dmgDelt += GetCrit(20);
            }
            else if (_attacker.type == 2)
            {
                dmgDelt = _attacker.AP - _defender.DP;
                dmgDelt += GetCrit(0);
            }
            else if (_attacker.type == 3)
            {
                dmgDelt = _attacker.AP - _defender.DP;
                dmgDelt += GetCrit(30);
            }
            _defender.HP -= dmgDelt;
            if (_defender.HP < 0) _defender.HP = 0;
            string[] attackLog = {$"{dmgDelt}", $"{_defender.HP}", crited};
            return attackLog;
        }

        private static int GetCrit(int _criticalChance)
        {
            int crit = rnd.Next(0, 100);
            if (crit < _criticalChance)
            {
                crited = "criticaly ";
                return 5;
            }
            else
            {
                crited = "";
                return 0;
            }
        }
    }
}
