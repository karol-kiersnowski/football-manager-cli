namespace FootballManager
{
    class Program
    {
        public static bool isRunning;

        static void Main(string[] args)
        {
            //Console.OutputEncoding = System.Text.Encoding.UTF8;
            isRunning = true;
            Console.SetTitle("Football Manager");
            Console.SetDimensions(80, 24);
            new WindowLanguage().run();
            new WindowLoading().run();
            new WindowMain().run();
            Console.Clear();
        }
    }
}
