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
        private static string getStarted = "Press any key to get started!";

        static void Main(string[] args)
        {
            PrintLobby();
        }
        //█▀▄
        private static void PrintLobby()
        {
            SetFullSizedWindow();
            SetColorsToDefault();
            Console.Clear();

            PrintGameTitel();
            PrintText(getStarted, defaultFColor, CenterTextX(getStarted), CenterTextY(7));

            Console.ReadKey(true);

            MonsterSelection.PrintMonsterSelection();
        }

        private static void SetFullSizedWindow()
        {
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
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
            return Console.LargestWindowWidth / 2 - _text.Length / 2;
        }
        public static int CenterTextY(int _offSet)
        {
            return Console.LargestWindowHeight / 2 + _offSet;
        }
    }
}
