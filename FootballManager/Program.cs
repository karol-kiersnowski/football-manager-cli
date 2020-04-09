namespace FootballManager
{
    class Program
    {
        public static bool isRunning;

        static void Main(string[] args)
        {
            //Console.CursorVisible = false;
            //Console.OutputEncoding = System.Text.Encoding.UTF8;
            isRunning = true;
            Window.setTitle("Football Manager");
            Window.setDimensions(80, 25);
            new WindowLanguage().run();
            new WindowLoading().run();
            new WindowMain().run();
            Window.clear();
        }
    }
}
