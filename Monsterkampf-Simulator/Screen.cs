namespace Monsterkampf_Simulator
{
    internal abstract class Screen
    {
        public static ConsoleColor defaultBColor = ConsoleColor.Black;
        public static ConsoleColor defaultFColor = ConsoleColor.White;
        public static ConsoleColor selectedBColor = ConsoleColor.White;
        public static ConsoleColor selectedFColor = ConsoleColor.Black;
        public static ConsoleColor[] colorPlayer = [ConsoleColor.Black, ConsoleColor.Blue, ConsoleColor.Red];
        public static ConsoleColor titelColor = ConsoleColor.Red;
        public static int[] windowSize = { Console.LargestWindowWidth, Console.LargestWindowHeight };

        public abstract Screen Start();

        public static void PrintText(string _toPrint, ConsoleColor _color, int _x, int _y)
        {
            ConsoleColor currentTextColor = Console.ForegroundColor;
            Console.ForegroundColor = _color;
            Console.SetCursorPosition(_x, _y);
            Console.Write(_toPrint);
            Console.ForegroundColor = currentTextColor;
        }

        protected static void SetColors(bool _selected = false)
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

        protected static int CenterTextX(string _text = "") { return windowSize[0] / 2 - _text.Length / 2; }

        protected static int CenterTextY(int _offSet = 0) { return windowSize[1] / 2 + _offSet; }

        protected static void DrawMiddleLine()
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

        protected void ResizeWindow(int _width, int _height)
        {
            Console.SetWindowPosition(0, 0);
            Console.SetBufferSize(_width, 1000);
            Console.SetWindowSize(_width, _height);
        }
    }
}
