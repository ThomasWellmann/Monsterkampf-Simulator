using System.Drawing;
using System.Runtime.InteropServices;
namespace Monsterkampf_Simulator
{
    internal class Lobby
    {
        public static ConsoleColor defaultBColor = ConsoleColor.Black;
        public static ConsoleColor defaultFColor = ConsoleColor.White;
        public static ConsoleColor selectedBColor = ConsoleColor.White;
        public static ConsoleColor selectedFColor = ConsoleColor.Black;
        public static ConsoleColor titelColor = ConsoleColor.Red;
        private static readonly string[] gameTitel = {
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
        private static string[] lobbyText = { "START", "HOW TO PLAY", "CREDITS" };
        public static int[] windowSize = {Console.LargestWindowWidth, Console.LargestWindowHeight};
        private static int offSet;
        private static ConsoleKeyInfo key;
        private static int selected = 0;

        static void Main(string[] args)
        {
            PrintLobby();
        }
        //█▀▄
        private static void PrintLobby()
        {
            ResizeWindow(windowSize[0], windowSize[1]);
            SetColors(false);
            Console.Clear();

            PrintGameTitel();
            GetLobbyInput();

            if (selected == 0)
                MonsterSettings.PrintMonsterSettings();
            else if (selected == 1)
                HowToPlay.PrintHowToPlay();
            else if (selected == 2)
                Credits.PrintCredits();
        }

        private static void GetLobbyInput()
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

        private static void PrintUnselected(string _text)
        {
            SetColors(false);
            PrintText(_text, defaultFColor, CenterTextX(_text), CenterTextY(offSet + selected));
        }

        public static void PrintText(string _toPrint, ConsoleColor _color, int _x, int _y)
        {
            ConsoleColor currentTextColor = Console.ForegroundColor;
            Console.ForegroundColor = _color;
            Console.SetCursorPosition(_x, _y);
            Console.Write(_toPrint);
            Console.ForegroundColor = currentTextColor;
        }

        private static void PrintGameTitel()
        {
            offSet = -7;
            for (int i = 0; i < 12; i++) 
            {
                PrintText(gameTitel[i], ConsoleColor.Red, CenterTextX(gameTitel[i]), CenterTextY(offSet));
                offSet++;
            }
        }

        public static int CenterTextX(string _text)
        {
            return windowSize[0] / 2 - _text.Length / 2;
        }
        public static int CenterTextY(int _offSet)
        {
            return windowSize[1] / 2 + _offSet;
        }

        public static void DrawMiddleLine()
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
        public static void Loop()
        {
            while (true)
            {
                Console.ReadKey(true);
            }
        }

        public static void SetColors(bool _selected)
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

        public static void GoBack(string _currentPage) 
        {
            if (_currentPage == "MonsterSettings" || _currentPage == "HowToPlay" || _currentPage == "Credits")
                PrintLobby();
            else if (_currentPage == "ChangeMonsterValues")
                MonsterSettings.PrintMonsterSettings();
        }

        public static void ResizeWindow(int _width, int _height)
        {
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(_width, _height);
        }
    }
}
