using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monsterkampf_Simulator
{
    internal class MonsterSettings
    {
        public static int[] orc = { 1, 200, 20, 5, 1 };
        public static int[] troll = { 2, 175, 15, 10, 2 };
        public static int[] goblin = { 3, 150, 20, 0, 3 };
        public static int currentPlayer = 1;
        public static int[] monsterPlayer = { 0, 0, 0 };
        public static ConsoleColor[] colorPlayer = { Lobby.defaultBColor, ConsoleColor.Blue, ConsoleColor.Red };
        private static string[] selectionText = {"",//0
        $"Choose your Monster by pressing the respective monster class number in your keyboard.",//1
        "You can not choose the same moster for both players",//2
        $"(1): Orc       (2): Troll     (3): Goblin",//3
        $"HP: {orc[1]}        HP: {troll[1]}        HP: {goblin[1]}",//4
        $"AP: {orc[2]}         AP: {troll[2]}         AP: {goblin[2]}",//5
        $"DP: {orc[3]}          DP: {troll[3]}         DP: {goblin[3]}",//6
        $"AS: {orc[4]}          AS: {troll[4]}          AS: {goblin[4]}"};//7
        private static string[][] VSText = {
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
            " (_) "//5
        ]};
        private static int x1 = Lobby.CenterTextX(VSText[0][0] + VSText[0][1] + VSText[1][0] + "    ");
        private static int x2 = x1 + VSText[0][0].Length + VSText[0][1].Length + 8;
        private static int offSet;
        private static ConsoleKeyInfo key;

        public static Monster Orc = new Monster(orc[0], orc[1], orc[2], orc[3], orc[4], "Orc");
        public static Monster Troll = new Monster(troll[0], troll[1], troll[2], troll[3], troll[4], "Troll");
        public static Monster Goblin = new Monster(goblin[0], goblin[1], goblin[2], goblin[3], goblin[4], "Goblin");

        public static void PrintMonsterSettings()
        {
            Lobby.SetColors(false);
            Console.Clear();

            SetDefaultValues();
            MonsterSelection();

            AskForChanges();

            Simulation.PrintSimulation();
        }

        private static void SetDefaultValues()
        {
            monsterPlayer[1] = 0;
            monsterPlayer[2] = 0;
            currentPlayer = 1;
            VSText[0][0] = "Player 1:";
            VSText[0][1] = "Player 2:";
            orc[1] = 200;
            orc[2] = 20;
            orc[3] = 5;
            orc[4] = 3;
            troll[1] = 175;
            troll[2] = 15;
            troll[3] = 10;
            troll[4] = 5;
            goblin[1] = 150;
            goblin[2] = 20;
            goblin[3] = 0;
            goblin[4] = 10;
        }

        private static void MonsterSelection()
        {
            PrintSelectionText();

            SelectMonster();
            currentPlayer++;

            PrintSelectionText();

            SelectMonster();

            VSText[0][0] = GetMonsterStats(monsterPlayer[1])[4];
            VSText[0][1] = GetMonsterStats(monsterPlayer[2])[4];
        }

        private static void AskForChanges()
        {
            PrintMChangesText();
            while (true)
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    GetMValueInput();
                else if (key.Key == ConsoleKey.Spacebar)
                    break;
                else if (key.Key == ConsoleKey.Escape)
                    Lobby.GoBack("ChangeMonsterValues");
            }
            Simulation.PrintSimulation();
        }

        private static void PrintSelectionText()
        {
            DisplayVS(false);

            offSet = -1;
            Lobby.PrintText($"Player {currentPlayer}:", Lobby.defaultFColor, Lobby.CenterTextX($"Player {currentPlayer}:"), Lobby.CenterTextY(offSet - 2));
            for (int i = 1; i < 4; i++)
            {
                Lobby.PrintText(selectionText[i], Lobby.defaultFColor, Lobby.CenterTextX(selectionText[i]), Lobby.CenterTextY(offSet));
                offSet += 2;
            }
            for (int i = 0; i < 3; i++)
                Monster.DrawMonster(i + 1, Lobby.CenterTextX(selectionText[3]) + 3 + i * 15, Lobby.CenterTextY(offSet));

            offSet = 10;
            for (int i = 4; i < 8; i++)
            {
                Lobby.PrintText(selectionText[i], Lobby.defaultFColor, Lobby.CenterTextX(selectionText[4]), Lobby.CenterTextY(offSet));
                offSet++;
            }
        }

        private static void PrintMChangesText()
        {
            string[] mChangesText = { "If you want to play as it is, press \"SpaceBar\" to start the simulation.",
            "But if you first want to change your monster's values, press \"Enter\" to enter one of your liking.",
            "Note: Do not choose a DP grater than the oponent's AP. More about that in the 'How To Play' menu.",
            "Press \"ESC\" to exit the value input." };
            Console.Clear();
            DisplayVS(true);

            offSet = 3;
            for (int i = 0; i < 3; i++)
            {
                Lobby.PrintText(mChangesText[i], Lobby.defaultFColor, Lobby.CenterTextX(mChangesText[i]), Lobby.CenterTextY(offSet));
                offSet += 2;
            }
        }

        public static void DisplayVS(bool _stats)
        {
            Lobby.SetColors(false);
            int VSOffset = 0;
            if (_stats)
            {
                VSOffset = 2;
                for (int i = 1; i < 3; i++)
                {
                    offSet = -2;
                    int x = (i == 1) ? x1 - 1 : x2 - 1;
                    for (int j = 0; j < 4; j++)
                    {
                        Lobby.PrintText(GetMonsterStats(monsterPlayer[i])[j], Lobby.defaultFColor, x, Lobby.CenterTextY(offSet));
                        offSet++;
                    }
                }
            }
            offSet = (!_stats) ? -11 : -9;
            DisplayPlayer(1, _stats, x1, Lobby.CenterTextY(offSet));
            DisplayPlayer(2, _stats, x2, Lobby.CenterTextY(offSet));
            offSet++;
            for (int i = 0; i < VSText[1].GetLength(0); i++)
            {
                Lobby.PrintText(VSText[1][i], Lobby.defaultFColor, Lobby.CenterTextX(VSText[1][0]), Lobby.CenterTextY(offSet + VSOffset));
                offSet++;
            }
        }

        private static void SelectMonster()
        {
            while (true)
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.D1)
                {
                    if (currentPlayer == 1)
                    {
                        monsterPlayer[1] = orc[0];
                        Simulation.monsterPlayer[1] = Orc;
                    }
                    else if (currentPlayer == 2 && monsterPlayer[1] != orc[0])
                    {
                        monsterPlayer[2] = orc[0];
                        Simulation.monsterPlayer[2] = Orc;
                    }
                    else
                        continue;
                    
                    break;
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    if (currentPlayer == 1)
                    {
                        monsterPlayer[1] = troll[0];
                        Simulation.monsterPlayer[1] = Troll;
                    }
                    else if (currentPlayer == 2 && monsterPlayer[1] != troll[0])
                    {
                        monsterPlayer[2] = troll[0];
                        Simulation.monsterPlayer[2] = Troll;
                    }
                    else
                        continue;
                    
                    break;
                }
                else if (key.Key == ConsoleKey.D3)
                {
                    if (currentPlayer == 1)
                    {
                        monsterPlayer[1] = goblin[0];
                        Simulation.monsterPlayer[1] = Goblin;
                    }
                    else if (currentPlayer == 2 && monsterPlayer[1] != goblin[0])
                    {
                        monsterPlayer[2] = goblin[0];
                        Simulation.monsterPlayer[2] = Goblin;
                    }
                    else
                        continue;
                    
                    break;
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    Lobby.GoBack("MonsterSettings");
                }
            }
        }

        public static void DisplayPlayer(int _player, bool _stats, int _x, int _y)
        {
            Lobby.PrintText(VSText[0][_player - 1], colorPlayer[_player], _x, _y);
            _y++;
            if (monsterPlayer[_player] == 0)
            {
                for (int i = 0; i < VSText[2].GetLength(0); i++)
                {
                    Lobby.PrintText(VSText[2][i], colorPlayer[_player], _x + 2, _y + i);
                }
            }
            else
            {
                for (int i = 0; i < VSText[2].GetLength(0); i++)
                {
                    Lobby.PrintText(VSText[2][i], Lobby.defaultBColor, _x + 2, _y + i);
                }
                _x++;
                _y++;
                if (monsterPlayer[_player] == orc[0])
                {
                    Monster.DrawMonster(orc[0], _x, _y);
                }
                else if (monsterPlayer[_player] == troll[0])
                {
                    Monster.DrawMonster(troll[0], _x, _y);
                }
                else if (monsterPlayer[_player] == goblin[0])
                {
                    Monster.DrawMonster(goblin[0], _x, _y);
                }
            }
        }

        private static void GetMValueInput() // Texteingabe für Monster Werten
        {
            string[] values = { "     ", " HP: ", " AP: ", " DP: ", " AS: " };
            int x = 0;
            bool end = false;

            for (int p = 1; p < 3; p++)
            {
                if (end) break;
                x = (p == 1) ? x1 + 4 : x2 + 4;
                int valueOffSet = Lobby.CenterTextY(-2);

                for (int i = 1; i < 5; i++)
                {
                    if (end) break;
                    string input = "";

                    Lobby.SetColors(true);
                    Lobby.PrintText(values[i] + values[0], Lobby.selectedFColor, x - 5, valueOffSet);

                    while (true)
                    {
                        Console.SetCursorPosition(x + input.Length, valueOffSet);
                        Console.CursorVisible = true;
                        key = Console.ReadKey(true);
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

                            Console.SetCursorPosition(x + input.Length, valueOffSet);
                            Console.Write(' ');
                            Console.SetCursorPosition(x + input.Length, valueOffSet);
                        }
                        else if (key.Key == ConsoleKey.Enter) // Eingabe bestätigen
                        {
                            Console.CursorVisible = false;
                            if (input == "0") input = "1";
                            if (input == "") break;

                            if (int.TryParse(input, out int mValue))
                            {
                                if (monsterPlayer[p] == orc[0])
                                    orc[i] = mValue;
                                else if (monsterPlayer[p] == troll[0])
                                    troll[i] = mValue;
                                else if (monsterPlayer[p] == goblin[0])
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

        private static void SetMValues()
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

        public static string[] GetMonsterStats(int _monsterType)
        {
            if (_monsterType == 1)
            {
                string[] orcStats = { $" HP: {orc[1]}    ", $" AP: {orc[2]}    ", $" DP: {orc[3]}    ", $" AS: {orc[4]}    ", "   Orc   " };
                return orcStats;
            }
            else if (_monsterType == 2)
            {
                string[] trollStats = { $" HP: {troll[1]}    ", $" AP: {troll[2]}    ", $" DP: {troll[3]}    ", $" AS: {troll[4]}    ", "  Troll  " };
                return trollStats;
            }
            else if (_monsterType == 3)
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
    }
}
