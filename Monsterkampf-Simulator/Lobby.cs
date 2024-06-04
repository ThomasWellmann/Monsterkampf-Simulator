using System.Drawing;
namespace Monsterkampf_Simulator
{
    internal class Lobby
    {
        public static ConsoleColor defaultBColor = ConsoleColor.Black;
        public static ConsoleColor defaultFColor = ConsoleColor.White;
        public static ConsoleColor selectedBColor = ConsoleColor.White;
        public static ConsoleColor selectedFColor = ConsoleColor.Black;
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
        private static string[] lobbyText = { "START", "HOW TO PLAY", "CREDITS" , ">", "<" };
        public static int[] windowSize = {Console.LargestWindowWidth, Console.LargestWindowHeight};
        private static int offSet;
        private static ConsoleKeyInfo key;

        static void Main(string[] args)
        {
            PrintLobby();
            
        }
        //█▀▄
        private static void PrintLobby()
        {
            ResizeWindow();
            SetColorsToDefault();
            Console.Clear();

            PrintGameTitel();
            GetLobbyInput();

            MonsterSettings.PrintMonsterSelection();
        }

        private static void GetLobbyInput()
        {
            offSet = 7;
            int selected = 0;
            for (int i = 0; i < 3; i++)
            {
                PrintText(lobbyText[i], defaultFColor, CenterTextX(lobbyText[0]), CenterTextY(offSet));
                offSet++;
            }
            while (true)
            {
                SetColors(true);
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.UpArrow && selected > 0)
                {
                    PrintText(lobbyText[selected]);
                    selected++;
                }
                else if (key.Key == ConsoleKey.DownArrow && selected < 2)
                {
                    selected--;
                }
            }
        }

        public static void ResizeWindow()
        {
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(windowSize[0], windowSize[1]);
        }

        public static void SetColorsToDefault()
        {
            Console.ForegroundColor = defaultFColor;
            Console.BackgroundColor = defaultBColor;
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
    }
}
