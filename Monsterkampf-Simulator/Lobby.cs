namespace Monsterkampf_Simulator
{
    internal class Lobby
    {
        public static ConsoleColor defaultBColor = ConsoleColor.Black;
        public static ConsoleColor defaultFColor = ConsoleColor.White;
        public static int windowLength;
        public static int windowHight;
        private static string gameTitel = @"

     _____                             __                   __                              _____ 
    /     \    ____    ____    _______/  |_   ____ _______ |  | _______     _____  ______ _/ ____\
   /  \ /  \  /  _ \  /    \  /  ___/\   __\_/ __ \\_  __ \|  |/ /\__  \   /     \ \____ \\   __\ 
  /    Y    \(  <_> )|   |  \ \___ \  |  |  \  ___/ |  | \/|    <  / __ \_|  Y Y  \|  |_> >|  |   
  \____|__  / \____/ |___|  //____  > |__|   \___  >|__|   |__|_ \(____  /|__|_|  /|   __/ |__|   
          \/              \/      \/             \/             \/     \/       \/ |__|           
                   _________ __                  __            __                 
                  /   _____/|__|  _____   __ __ |  |  _____  _/  |_  ____ _______ 
                  \_____  \ |  | /     \ |  |  \|  |  \__  \ \   __\/  _ \\_  __ \
                  /        \|  ||  Y Y  \|  |  /|  |__ / __ \_|  | (  <_> )|  | \/
                 /_______  /|__||__|_|  /|____/ |____/(____  /|__|  \____/ |__|   
                         \/           \/                   \/     "; //97x13
        private static string getStarted = "Press any key to get started!";

        static void Main(string[] args)
        {
            PrintLobby();
        }

        private static void PrintLobby()
        {
            ResizeWindow(100, 29);
            SetColorsToDefault();
            Console.Clear();
            
            PrintText(gameTitel, ConsoleColor.Red, 0, 2);
            PrintText(getStarted, defaultFColor, CenterText(getStarted), 21);//29

            Console.ReadKey(false);

            MonsterSelection.PrintMonsterSelection();
        }
        
        public static void ResizeWindow(int _length, int _height)
        {
            windowLength = _length;
            windowHight = _height;
            Console.SetWindowSize(windowLength, windowHight);
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

        public static int CenterText(string _text)
        {
            return windowLength / 2 - _text.Length / 2;
        }
    }
}
