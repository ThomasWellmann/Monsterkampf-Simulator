using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monsterkampf_Simulator
{
    internal class MonsterSettings : Screen
    {
        #region Variables
        public int[] orc;
        public int[] troll;
        public int[] goblin;
        public int currentPlayer;
        private ConsoleColor monsterColor;
        private string[] monsterDrawn;
        private string[] selectionText;
        private string[][] VSText;
        private int[] x;
        private int offSet;
        private static Monster[] monsterPlayer = new Monster[3];
        public Monster Orc;
        public Monster Troll;
        public Monster Goblin;
        private void SetValues()
        {
            x[0] = CenterTextX(VSText[0][0] + VSText[0][1] + VSText[1][0] + "    ");
            x[1] = x[0] + VSText[0][0].Length + VSText[0][1].Length + 8;
            monsterPlayer = [ 0, 0 ];
            currentPlayer = 1;
            monsterColor = ConsoleColor.White;
            VSText[0] = [ "Player 1:", "Player 2:" ];
            orc = [1, 200, 20, 5, 1];
            troll = [2, 175, 15, 10, 2];
            goblin = [3, 150, 20, 0, 3];
            monsterDrawn = [
                "  ██  ",
                "█▀██▀█",
                "█▄██▄█",
                " █  █ " ];
            selectionText = [ "",//0
                $"Choose your Monster by pressing the respective Monster class number in your keyboard.",//1
                "You can not choose the same moster for both players",//2
                $"(1): Orc       (2): Troll     (3): Goblin",//3
                $"HP: 200        HP: 175        HP: 150",//4
                $"AP: 20         AP: 15         AP: 15",//5
                $"DP: 5          DP: 10         DP: 10",//6
                $"AS: 5          AS: 10         AS: 15" ];//7
            VSText = [
                [//z0
                    "Player 1:",//0 
                    "Player 2:"//1
                ],[//z1
                    " _    _______",//0
                    "| |  / / ___/",//1
                    "| | / /\\__ \\ ",//2
                    "| |/ /___/ / ",//3
                    "|___//____/  "//4
                ],[//z2
                    " ___ ",//0
                    "(_, )",//1
                    "  // ",//2
                    " (_) ",//3
                    "  _  ",//4
                    " (_) "]];//5
            SetMValues();
        }
        #endregion


        public override Screen Start()
        {
            SetColors();
            Console.Clear();

            SetValues();
            Screen next = MonsterSelection();
            if (next != null) { return next; }

            return AskForChanges();
        }

        private Screen MonsterSelection()
        {
            PrintSelectionText();

            Screen next = SelectMonster();
            if (next != null ) { return next; }
            currentPlayer++;

            PrintSelectionText();

            next = SelectMonster();
            if (next != null) { return next; }

            VSText[0][0] = GetMonsterStats(monsterPlayer[1])[4];
            VSText[0][1] = GetMonsterStats(monsterPlayer[2])[4];
            return null;
        }

        private Screen AskForChanges()
        {
            PrintMChangesText();
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    GetMValueInput();
                else if (key.Key == ConsoleKey.Spacebar)
                    break;
                else if (key.Key == ConsoleKey.Escape)
                    return new MonsterSettings();
            }
            return new Simulation(monsterPlayer);
        }

        private void PrintSelectionText()
        {
            DisplayVS(false);

            offSet = -1;
            PrintText($"Player {currentPlayer}:", defaultFColor, CenterTextX($"Player {currentPlayer}:"), CenterTextY(offSet - 2));
            for (int i = 1; i < 4; i++)
            {
                PrintText(selectionText[i], defaultFColor, CenterTextX(selectionText[i]), CenterTextY(offSet));
                offSet += 2;
            }
            for (int i = 0; i < 3; i++)
                DrawMonster(i + 1, CenterTextX(selectionText[3]) + 3 + i * 15, CenterTextY(offSet));

            offSet = 10;
            for (int i = 4; i < 8; i++)
            {
                PrintText(selectionText[i], defaultFColor, CenterTextX(selectionText[4]), CenterTextY(offSet));
                offSet++;
            }
        }

        private void PrintMChangesText()
        {
            string[] mChangesText = { "If you want to play as it is, press \"SpaceBar\" to start the simulation.",
            "But if you first want to change your Monster's values, press \"Enter\" to enter one of your liking.",
            "Note: Do not choose a DP grater than the oponent's AP. More about that in the 'How To Play' menu.",
            "Press \"ESC\" to exit the value input." };
            Console.Clear();
            DisplayVS(true);

            offSet = 3;
            for (int i = 0; i < 3; i++)
            {
                PrintText(mChangesText[i], defaultFColor, CenterTextX(mChangesText[i]), CenterTextY(offSet));
                offSet += 2;
            }
        }

        private void DisplayVS(bool _stats)
        {
            SetColors();
            int VSOffset = 0;
            if (_stats)
            {
                VSOffset = 2;
                for (int i = 1; i < 3; i++)
                {
                    offSet = -2;
                    int _x = (i == 1) ? x[0] - 1 : x[1] - 1;
                    for (int j = 0; j < 4; j++)
                    {
                        PrintText(GetMonsterStats(monsterPlayer[i])[j], defaultFColor, _x, CenterTextY(offSet));
                        offSet++;
                    }
                }
            }
            offSet = (!_stats) ? -11 : -9;
            DisplayPlayer(1, _stats, x[0], CenterTextY(offSet));
            DisplayPlayer(2, _stats, x[1], CenterTextY(offSet));
            offSet++;
            for (int i = 0; i < VSText[1].GetLength(0); i++)
            {
                PrintText(VSText[1][i], defaultFColor, CenterTextX(VSText[1][0]), CenterTextY(offSet + VSOffset));
                offSet++;
            }
        }

        private Screen SelectMonster()
        {
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.D1)
                {
                    if (currentPlayer == 1)
                    {
                        Orc = new Monster(orc[0], orc[1], orc[2], orc[3], orc[4], "Orc");
                        monsterPlayer[1] = Orc;
                    }
                    else if (currentPlayer == 2 && monsterPlayer[1] != Orc)
                    {
                        Orc = new Monster(orc[0], orc[1], orc[2], orc[3], orc[4], "Orc");
                        monsterPlayer[2] = Orc;
                    }
                    else
                        continue;
                    
                    break;
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    if (currentPlayer == 1)
                    {
                        Troll= new Monster(troll[0], troll[1], troll[2], troll[3], troll[4], "Troll");
                        monsterPlayer[1] = Troll;
                    }
                    else if (currentPlayer == 2 && monsterPlayer[1] != Troll)
                    {
                        Troll = new Monster(troll[0], troll[1], troll[2], troll[3], troll[4], "Troll");
                        monsterPlayer[2] = Troll;
                    }
                    else
                        continue;
                    
                    break;
                }
                else if (key.Key == ConsoleKey.D3)
                {
                    if (currentPlayer == 1)
                    {
                        Goblin = new Monster(goblin[0], goblin[1], goblin[2], goblin[3], goblin[4], "Goblin");
                        monsterPlayer[1] = Goblin;
                    }
                    else if (currentPlayer == 2 && monsterPlayer[1] != Goblin)
                    {
                        Goblin = new Monster(goblin[0], goblin[1], goblin[2], goblin[3], goblin[4], "Goblin");
                        monsterPlayer[2] = Goblin;
                    }
                    else
                        continue;
                    
                    break;
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    return new Lobby();
                }
            }
            return null;
        }

        public void DisplayPlayer(int _player, bool _stats, int _x, int _y)
        {
            PrintText(VSText[0][_player - 1], colorPlayer[_player], _x, _y);
            _y++;
            if (monsterPlayer[_player].type == 0)
            {
                for (int i = 0; i < VSText[2].GetLength(0); i++)
                {
                    PrintText(VSText[2][i], colorPlayer[_player], _x + 2, _y + i);
                }
            }
            else
            {
                for (int i = 0; i < VSText[2].GetLength(0); i++)
                {
                    PrintText(VSText[2][i], defaultBColor, _x + 2, _y + i);
                }
                _x++;
                _y++;
                if (monsterPlayer[_player].type == Orc.type)
                {
                    DrawMonster(orc[0], _x, _y);
                }
                else if (monsterPlayer[_player].type == Troll.type)
                {
                    DrawMonster(troll[0], _x, _y);
                }
                else if (monsterPlayer[_player].type == Goblin.type)
                {
                    DrawMonster(goblin[0], _x, _y);
                }
            }
        }
        private void GetMValueInput() // Texteingabe für Monster Werten
        {
            string[] values = { "     ", " HP: ", " AP: ", " DP: ", " AS: " };
            int _x = 0;
            bool end = false;

            for (int p = 1; p < 3; p++)
            {
                if (end) break;
                _x = (p == 1) ? x[0] + 4 : x[1] + 4;
                int valueOffSet = CenterTextY(-2);

                for (int i = 1; i < 5; i++)
                {
                    if (end) break;
                    string input = "";

                    SetColors(true);
                    PrintText(values[i] + values[0], selectedFColor, _x - 5, valueOffSet);

                    while (true)
                    {
                        Console.SetCursorPosition(_x + input.Length, valueOffSet);
                        Console.CursorVisible = true;
                        ConsoleKeyInfo key = Console.ReadKey(true);
                        if (key.Key == ConsoleKey.Escape) // Eingabe ohne änderung beenden
                        {
                            Console.CursorVisible = false;
                            end = true;
                            SetMValues();
                            DisplayVS(true);
                            break;
                        }
                        else if (Char.IsDigit(key.KeyChar) == true && input.Length < 3) // Input muss Zahl sein
                        {
                            input += key.KeyChar;
                            Console.Write(key.KeyChar);
                        }
                        else if (key.Key == ConsoleKey.Backspace && input.Length > 0) // Letzte Input löschen
                        {
                            input = input.Remove(input.Length - 1);

                            Console.SetCursorPosition(_x + input.Length, valueOffSet);
                            Console.Write(' ');
                            Console.SetCursorPosition(_x + input.Length, valueOffSet);
                        }
                        else if (key.Key == ConsoleKey.Enter) // Eingabe bestätigen
                        {
                            Console.CursorVisible = false;
                            if (input == "0") input = "1";
                            if (input == "") break;

                            if (int.TryParse(input, out int mValue))
                            {
                                if (monsterPlayer[p].type == orc[0])
                                    orc[i] = mValue;
                                else if (monsterPlayer[p].type == troll[0])
                                    troll[i] = mValue;
                                else if (monsterPlayer[p].type == goblin[0])
                                    goblin[i] = mValue;
                            }
                            SetMValues();
                            break;
                        }
                    }
                    DisplayVS(true);
                    valueOffSet++;
                }
            }
        }

        private void SetMValues()
        {
            Orc.HP = orc[1];
            Orc.AP = orc[2];
            Orc.DP = orc[3];
            Orc.AS = orc[4];
            Troll.HP = troll[1];
            Troll.AP = troll[2];
            Troll.DP = troll[3];
            Troll.AS = troll[4];
            Goblin.HP = goblin[1];
            Goblin.AP = goblin[2];
            Goblin.DP = goblin[3];
            Goblin.AS = goblin[4];
        }

        public string[] GetMonsterStats(Monster _monster)
        {
            if (_monster.type == 1)
            {
                string[] orcStats = { $" HP: {orc[1]}    ", $" AP: {orc[2]}    ", $" DP: {orc[3]}    ", $" AS: {orc[4]}    ", "   Orc   " };
                return orcStats;
            }
            else if (_monster.type == 2)
            {
                string[] trollStats = { $" HP: {troll[1]}    ", $" AP: {troll[2]}    ", $" DP: {troll[3]}    ", $" AS: {troll[4]}    ", "  Troll  " };
                return trollStats;
            }
            else if (_monster.type == 3)
            {
                string[] goblingStats = { $" HP: {goblin[1]}    ", $" AP: {goblin[2]}    ", $" DP: {goblin[3]}    ", $" AS: {goblin[4]}    ", " Goblin  " };
                return goblingStats;
            }
            else
            {
                string[] strings = { "", "", "", "", "" };
                return strings;
            }
        }

        public void DrawMonster(int _monster, int _x, int _y)
        {
            if (_monster == 1)
                monsterColor = ConsoleColor.DarkGray;
            else if (_monster == 2)
                monsterColor = ConsoleColor.DarkGreen;
            else if (_monster == 3)
                monsterColor = ConsoleColor.DarkYellow;

            for (int i = 0; i < 4; i++)
            {
                PrintText(monsterDrawn[i], monsterColor, _x, _y + i);
            }
        }
    }
}
