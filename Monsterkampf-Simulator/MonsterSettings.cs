namespace Monsterkampf_Simulator
{
    internal class MonsterSettings : Screen
    {
        #region Variables
        public static int[] orc = new int[5];
        public static int[] troll = new int[5];
        public static int[] goblin = new int[5];
        public static int currentPlayer;
        private static string[] selectionText = new string[8];
        public static string[][] VSText = new string[3][];
        public static int[] x = new int[2];
        public static Monster[] monsterPlayer = new Monster[3];
        public Monster _null = new Monster();
        public Monster Orc = new Monster("Orc", ConsoleColor.DarkGreen);
        public Monster Troll = new Monster("Troll", ConsoleColor.DarkYellow);
        public Monster Goblin = new Monster("Goblin", ConsoleColor.DarkMagenta);
        private void SetValues()
        {
            monsterPlayer = [_null, _null, _null];
            currentPlayer = 1;
            orc = [1, 200, 20, 5, 1];
            troll = [2, 175, 15, 10, 2];
            goblin = [3, 150, 20, 0, 3];
            selectionText = [ "",//0
                $"Choose your Monster by pressing the respective Monster class number in your keyboard.",//1
                "You can not choose the same moster for both players",//2
                $"(1): Orc       (2): Troll     (3): Goblin",//3
                $"  HP: 200        HP: 175        HP: 150",//4
                $"  AP: 20         AP: 15         AP: 15",//5
                $"  DP: 5          DP: 10         DP: 10",//6
                $"  AS: 5          AS: 10         AS: 15" ];//7
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
            x[0] = CenterTextX(VSText[0][0] + VSText[0][1] + VSText[1][0] + "    ");
            x[1] = x[0] + VSText[0][0].Length + VSText[0][1].Length + 8;
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

            VSText[0][0] = monsterPlayer[1].GetMonsterStats()[4];
            VSText[0][1] = monsterPlayer[2].GetMonsterStats()[4];
            return null;
        }

        private Screen AskForChanges()
        {
            PrintMChangesText();
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter) GetMValueInput();
                else if (key.Key == ConsoleKey.Spacebar) break;
                else if (key.Key == ConsoleKey.Escape) return new MonsterSettings();
            }
            return new Simulation(monsterPlayer);
        }

        private void PrintSelectionText()
        {
            DisplayVS();

            int offSet = -1;
            PrintText($"Player {currentPlayer}:", defaultFColor, CenterTextX($"Player {currentPlayer}:"), CenterTextY(offSet - 2));
            for (int i = 1; i < 4; i++)
            {
                PrintText(selectionText[i], defaultFColor, CenterTextX(selectionText[i]), CenterTextY(offSet));
                offSet += 2;
            }
            Orc.DrawMonster(CenterTextX(selectionText[3]) + 3, CenterTextY(offSet));
            Troll.DrawMonster(CenterTextX(selectionText[3]) + 3 + 15, CenterTextY(offSet));
            Goblin.DrawMonster(CenterTextX(selectionText[3]) + 3 + 30, CenterTextY(offSet));

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

            int offSet = 3;
            for (int i = 0; i < 3; i++)
            {
                PrintText(mChangesText[i], defaultFColor, CenterTextX(mChangesText[i]), CenterTextY(offSet));
                offSet += 2;
            }
        }

        public static void DisplayVS(bool _stats = false)
        {
            SetColors();
            int VSOffset = 0;
            int offSet;
            if (_stats)
            {
                VSOffset = 2;
                for (int i = 1; i < 3; i++)
                {
                    offSet = -2;
                    int _x = (i == 1) ? x[0] - 1 : x[1] - 1;
                    for (int j = 0; j < 4; j++)
                    {
                        PrintText(monsterPlayer[i].GetMonsterStats()[j], defaultFColor, _x, CenterTextY(offSet));
                        offSet++;
                    }
                }
            }
            offSet = (!_stats) ? -11 : -9;
            DisplayPlayer(monsterPlayer[1], _stats, x[0], CenterTextY(offSet), 1);
            DisplayPlayer(monsterPlayer[2], _stats, x[1], CenterTextY(offSet), 2);
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
                        Orc = new Monster("Orc", ConsoleColor.DarkGreen, orc[0], orc[1], orc[2], orc[3], orc[4]);
                        monsterPlayer[1] = Orc;
                    }
                    else if (currentPlayer == 2 && monsterPlayer[1] != Orc)
                    {
                        Orc = new Monster("Orc", ConsoleColor.DarkGreen, orc[0], orc[1], orc[2], orc[3], orc[4]);
                        monsterPlayer[2] = Orc;
                    }
                    else continue;

                    break;
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    if (currentPlayer == 1)
                    {
                        Troll = new Monster("Troll", ConsoleColor.DarkYellow, troll[0], troll[1], troll[2], troll[3], troll[4]);
                        monsterPlayer[1] = Troll;
                    }
                    else if (currentPlayer == 2 && monsterPlayer[1] != Troll)
                    {
                        Troll = new Monster("Troll", ConsoleColor.DarkYellow, troll[0], troll[1], troll[2], troll[3], troll[4]);
                        monsterPlayer[2] = Troll;
                    }
                    else continue;
                    
                    break;
                }
                else if (key.Key == ConsoleKey.D3)
                {
                    if (currentPlayer == 1)
                    {
                        Goblin = new Monster("Goblin", ConsoleColor.DarkMagenta, goblin[0], goblin[1], goblin[2], goblin[3], goblin[4]);
                        monsterPlayer[1] = Goblin;
                    }
                    else if (currentPlayer == 2 && monsterPlayer[1] != Goblin)
                    {
                        Goblin = new Monster("Goblin", ConsoleColor.DarkMagenta, goblin[0], goblin[1], goblin[2], goblin[3], goblin[4]);
                        monsterPlayer[2] = Goblin;
                    }
                    else continue;

                    break;
                }
                else if (key.Key == ConsoleKey.Escape) return new Lobby();
            }
            return null;
        }

        public static void DisplayPlayer(Monster _monster, bool _stats, int _x, int _y, int _player)
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
                    PrintText(VSText[2][i], defaultBColor, _x + 2, _y + i);

                _x++;
                _y++;
                _monster.DrawMonster(_x, _y);
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
                                if (monsterPlayer[p] == Orc) orc[i] = mValue;
                                else if (monsterPlayer[p] == Troll) troll[i] = mValue;
                                else if (monsterPlayer[p] == Goblin) goblin[i] = mValue;
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
            SetMValues(Orc, orc);
            SetMValues(Troll, troll);
            SetMValues(Goblin, goblin);
        }

        private static void SetMValues(Monster _monster, int[] _arr)
        {
            _monster.HP = _arr[1];
            _monster.AP = _arr[2];
            _monster.DP = _arr[3];
            _monster.AS = _arr[4];
        }
    }
}
