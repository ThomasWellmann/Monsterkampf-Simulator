using System.Drawing;
namespace Monsterkampf_Simulator
{
    internal class Lobby
    {
        public static ConsoleColor defaultBColor = ConsoleColor.Black;
        public static ConsoleColor defaultFColor = ConsoleColor.White;
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
        private static string[] getStarted = { "Press any key to get started!" };
        public static int[] windowSize = {Console.LargestWindowWidth, Console.LargestWindowHeight};

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
            PrintText(getStarted[0], defaultFColor, CenterTextX(getStarted[0]), CenterTextY(7));

            Console.ReadKey(true);

            MonsterSettings.PrintMonsterSelection();
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
            int offSet = -7;
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
                Console.ReadKey();
            }
        }
    }
}
