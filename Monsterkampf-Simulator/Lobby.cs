using System.Drawing;
using System.Runtime.InteropServices;
namespace Monsterkampf_Simulator
{
    internal class Lobby
    {
        public Lobby lobby;
        public MonsterSettings monsterSettings;
        public HowToPlay howToPlay;
        public Credits credits;
        public Simulation simulation = new Simulation();
        public ConsoleColor defaultBColor = ConsoleColor.Black;
        public ConsoleColor defaultFColor = ConsoleColor.White;
        public ConsoleColor selectedBColor = ConsoleColor.White;
        public ConsoleColor selectedFColor = ConsoleColor.Black;
        public ConsoleColor titelColor = ConsoleColor.Red;
        private readonly string[] gameTitel = {
        "   _____                             __                   __                              _____ ",
        "  /     \\    ____    ____    _______/  |_   ____ _______ |  | _______     _____  ______ _/ ____\\",
        " /  \\ /  \\  /  _ \\  /    \\  /  ___/\\   __\\_/ __ \\\\_  __ \\|  |/ /\\__  \\   /     \\ \\____ \\\\   __\\ ",
        "/    Y    \\(  <_> )|   |  \\ \\___ \\  |  |  \\  ___/ |  | \\/|    <  / __ \\_|  Y Y  \\|  |_> >|  |   ",
        "\\____|__  / \\____/ |___|  //____  > |__|   \\___  >|__|   |__|_ \\(____  /|__|_|  /|   __/ |__|   ",
        "        \\/              \\/      \\/             \\/             \\/     \\/       \\/ |__|           ",
        "                 _________ __                  __            __                                 ",
        "                /   _____/|__|  _____   __ __ |  |  _____  _/  |_  ____ _______                 ",
        "                \\_____  \\ |  | /     \\ |  |  \\|  |  \\__  \\ \\   __\\/  _ \\\\_  __ \\                ",
        "                /        \\|  ||  Y Y  \\|  |  /|  |__ / __ \\_|  | (  <_> )|  | \\/                ",
        "               /_______  /|__||__|_|  /|____/ |____/(____  /|__|  \\____/ |__|                   ",
        "                       \\/           \\/                   \\/                                     "};
        private string[] lobbyText = { "START", "HOW TO PLAY", "CREDITS" };
        public int[] windowSize = { Console.LargestWindowWidth, Console.LargestWindowHeight };
        private int offSet;
        private ConsoleKeyInfo key;
        private int selected = 0;
        public Random rnd = new Random();
        public Monster Orc;
        public Monster Troll;
        public Monster Goblin;

        static void Main(string[] args)
        {
            Lobby lobby = new Lobby();
            lobby.PrintLobby();
        }
        //█▀▄
        private void PrintLobby()
        {
            ResizeWindow(windowSize[0], windowSize[1]);
            SetColors();
            Console.Clear();
            Console.CursorVisible = true;

            PrintGameTitel();
            GetLobbyInput();

            if (selected == 0)
                monsterSettings.PrintMonsterSettings();
            else if (selected == 1)
                howToPlay.PrintHowToPlay();
            else if (selected == 2)
                credits.PrintCredits();
        }

        private void GetLobbyInput()
        {
            offSet = 7;
            selected = 0;
            for (int i = 0; i < 3; i++)
            {
                PrintText(lobbyText[i], defaultFColor, CenterTextX(lobbyText[i]), CenterTextY(offSet));
                offSet++;
            }
            offSet = 7;
            while (true)
            {
                SetColors(true);
                string toPrint = "<" + lobbyText[selected] + ">";
                PrintText(toPrint, selectedFColor, CenterTextX(toPrint), CenterTextY(offSet + selected));

                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.UpArrow && selected > 0)
                {
                    PrintUnselected(" " + lobbyText[selected] + " ");
                    selected--;
                }
                else if (key.Key == ConsoleKey.DownArrow && selected < 2)
                {
                    PrintUnselected(" " + lobbyText[selected] + " ");
                    selected++;
                }
                else if (key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.Spacebar)
                {
                    break;
                }
            }
        }

        private void PrintUnselected(string _text)
        {
            SetColors();
            PrintText(_text, defaultFColor, CenterTextX(_text), CenterTextY(offSet + selected));
        }

        public void PrintText(string _toPrint, ConsoleColor _color, int _x, int _y)
        {
            ConsoleColor currentTextColor = Console.ForegroundColor;
            Console.ForegroundColor = _color;
            Console.SetCursorPosition(_x, _y);
            Console.Write(_toPrint);
            Console.ForegroundColor = currentTextColor;
        }

        private void PrintGameTitel()
        {
            offSet = -7;
            for (int i = 0; i < 12; i++)
            {
                PrintText(gameTitel[i], ConsoleColor.Red, CenterTextX(gameTitel[i]), CenterTextY(offSet));
                offSet++;
            }
        }

        public int CenterTextX(string _text)
        {
            return windowSize[0] / 2 - _text.Length / 2;
        }
        public int CenterTextY(int _offSet)
        {
            return windowSize[1] / 2 + _offSet;
        }

        public void DrawMiddleLine()
        {
            for (int y = 0; y < windowSize[1]; y++)
            {
                PrintText("█", ConsoleColor.DarkGray, windowSize[0] / 2, y);
            }
            for (int x = 0; x < windowSize[0]; x++)
            {
                PrintText("█", ConsoleColor.DarkGray, x, windowSize[1] / 2);
            }
        }
        public void Loop()
        {
            while (true)
            {
                Console.ReadKey(true);
            }
        }

        public void SetColors(bool _selected = false)
        {
            if (_selected)
            {
                Console.BackgroundColor = selectedBColor;
                Console.ForegroundColor = selectedFColor;
            }
            else
            {
                Console.BackgroundColor = defaultBColor;
                Console.ForegroundColor = defaultFColor;
            }
        }

        public void Return(string _to)
        {
            if (_to == "Lobby")
            {
                PrintLobby();
            }
            else if (_to == "MonsterSelection")
            {
                monsterSettings.PrintMonsterSettings();
            }
        }

        public void ResizeWindow(int _width, int _height)
        {
            Console.SetWindowPosition(0, 0);
            Console.SetBufferSize(_width, 1000);
            Console.SetWindowSize(_width, _height);
        }
    }
}
