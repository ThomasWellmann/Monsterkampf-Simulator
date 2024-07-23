namespace Monsterkampf_Simulator
{//█▀▄
    public class Monster
    {
        #region Variables
        public int type;
        public int HP;
        public int AP;
        public int DP;
        public int AS;
        public string name;
        private int crited;
        public Random rnd = new Random(DateTime.Now.Millisecond);
        private string[] monsterDrawn = [
                "  ██  ",
                "█▀██▀█",
                "█▄██▄█",
                " █  █ " ];
        private ConsoleColor monsterColor;
        #endregion

        public Monster(string _name = "null", ConsoleColor _color = default, int _type = 0, int _hp = 0, int _ap = 0, int _dp = 0, int _as = 0)
        {
            name = _name;
            monsterColor = _color;
            type = _type;
            HP = _hp;
            AP = _ap;
            DP = _dp;
            AS = _as;
        }

        public int[] Attack(Monster _defender)
        {
            int dmgDelt = 0;
            if (type == 1)
            {
                dmgDelt = AP - _defender.DP;
                dmgDelt += (GetCrit(10)) ? AP * 2 : 0;
            }
            else if (type == 2)
            {
                dmgDelt = AP - _defender.DP;
                dmgDelt += (GetCrit(0)) ? AP * 2 : 0;
            }
            else if (type == 3)
            {
                dmgDelt = AP - _defender.DP;
                dmgDelt += (GetCrit(20)) ? AP * 2 : 0;
            }
            _defender.HP -= dmgDelt;
            if (_defender.HP < 0) _defender.HP = 0;
            int[] attackLog = { dmgDelt, _defender.HP, crited };
            return attackLog;
        }

        private bool GetCrit(int _criticalChance)
        {
            int crit = rnd.Next(0, 100);
            if (crit < _criticalChance)
            {
                crited = 1;
                return true;
            }
            else
            {
                crited = 0;
                return false;
            }
        }

        public string[] GetMonsterStats()
        {
            string[] stats = { $" HP: {HP}    ", $" AP: {AP}    ", $" DP: {DP}    ", $" AS: {AS}    ", $" {name}" };
            return stats;
        }

        public void DrawMonster(int _x, int _y)
        {
            for (int i = 0; i < 4; i++)
            {
                Screen.PrintText(monsterDrawn[i], monsterColor, _x, _y + i);
            }
        }
    }
}
