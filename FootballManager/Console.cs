namespace FootballManager
{
    public static class Console
    {
        public static int Width { get; private set; }
        public static int Height { get; private set; }

        public static System.ConsoleColor BackgroundColor
        {
            get
            {
                return System.Console.BackgroundColor;
            }
            set
            {
                System.Console.BackgroundColor = value;
            }
        }

        public static System.ConsoleColor ForegroundColor
        {
            get
            {
                return System.Console.ForegroundColor;
            }
            set
            {
                System.Console.ForegroundColor = value;
            }
        }

        public static System.ConsoleKeyInfo ReadKey()
        {
            return System.Console.ReadKey();
        }

        public static string ReadLine()
        {
            return System.Console.ReadLine();
        }

        public static void Write(string value)
        {
            System.Console.Write(value);
        }

        public static void Write(char value)
        {
            System.Console.Write(value);
        }

        public static void Write(int value)
        {
            System.Console.Write(value);
        }

        public static void WriteLine()
        {
            System.Console.WriteLine();
        }

        public static void WriteLine(string value)
        {
            System.Console.WriteLine(value);
        }

        public static void Clear()
        {
            System.Console.Clear();
        }

        public static void ResetColor()
        {
            System.Console.ResetColor();
        }

        public static void SetCursorPosition(int left, int top)
        {
            try
            {
                System.Console.SetCursorPosition(left, top);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void SetTitle(string title)
        {
            System.Console.Title = title;
        }

        public static void SetDimensions(int width, int height)
        {
            try
            {
                if (Width <= System.Console.LargestWindowWidth && Height <= System.Console.LargestWindowHeight)
                {
                    System.Console.WindowWidth = width;
                    System.Console.WindowHeight = height;
                    System.Console.BufferWidth = width;
                    Width = width;
                    Height = height;
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
