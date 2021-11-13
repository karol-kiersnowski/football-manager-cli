namespace FootballManager
{
    public abstract class Window
    {
        public static void displayMessage(string text)
        {
            Console.Clear();
            Console.WriteLine(logo);
            Console.WriteLine(">> Error\n");
            Console.WriteLine(text);
            Console.ReadKey();
        }









        public Window()
        {
            isRunning = true;
        }

        public void run()
        {
            while (isRunning && Program.isRunning)
            {
                update();
                draw();
                selectOption();
            }
        }









        protected static readonly string logo =
              "____ ____ ____ ___ ___  ____ _    _       _  _ ____ _  _ ____ ____ ____ ____ \n" +
              "|___ |  | |  |  |  |__] |__| |    |       |\\/| |__| |\\ | |__| | __ |___ |__/ \n" +
              "|    |__| |__|  |  |__] |  | |___ |___    |  | |  | | \\| |  | |__] |___ |  \\\n" +
              "\t\t\t\t\t\t\t\t    v. 21.11";

        protected bool isRunning;
        protected string menu;
        protected int selectedNumber;
        protected string selectedOption;
        protected string[] options;

        protected abstract void update();
        protected abstract void draw();
        protected abstract void selectOption();

        protected int displayHeader()
        {
            Console.Clear();
            //if (Console.Height > 24)
            //{
                Console.WriteLine(logo);
                Console.WriteLine(menu + "\n");
                return 6;
            //}
            //else
            //{
            //    Console.WriteLine(menu + "\n");
            //    return 2;
            //}
        }

        protected void displayOptionsWithoutNumbers()
        {
            for (int i = 0; i < options.Length; i++)
                Console.WriteLine(options[i]);
            Console.WriteLine();
        }

        protected void displayOptions()
        {
            for (int i = 0; i < options.Length; i++)
                Console.WriteLine(i + 1 + ". " + options[i]);
            Console.WriteLine();
        }

        protected void checkBasicOptions()
        {
            switch (selectedOption)
            {
                case "0":
                case "cd..":
                case "cd ..":
                    isRunning = false;
                    break;
                case "q":
                case "quit":
                case "exit":
                    Program.isRunning = false;
                    break;
                case "ver":
                    new WindowAboutGame(menu).run();
                    break;
                case "settings":
                    new WindowSettings(menu).run();
                    break;
            }
        }

        protected void drawBlocks(int level)
        {
            char sign = '\u25A0';
            if (level < 20)
                System.Console.Write("{0}", sign);
            else if (level < 40)
                System.Console.Write("{0}{1}", sign, sign);
            else if (level < 60)
                System.Console.Write("{0}{1}{2}", sign, sign, sign);
            else if (level < 80)
                System.Console.Write("{0}{1}{2}{3}", sign, sign, sign, sign);
            else if (level < 100)
                System.Console.Write("{0}{1}{2}{3}{4}", sign, sign, sign, sign, sign);
        }

        protected void draw4Blocks(int level)
        {
            char sign = '\u25A0';
            if (level < 25)
                System.Console.Write("{0}", sign);
            else if (level < 50)
                System.Console.Write("{0}{1}", sign, sign);
            else if (level < 75)
                System.Console.Write("{0}{1}{2}", sign, sign, sign);
            else if (level < 100)
                System.Console.Write("{0}{1}{2}{3}", sign, sign, sign, sign);
        }

        protected void setColor(int skills)
        {
            if (skills >= 80)
                System.Console.ForegroundColor = System.ConsoleColor.Cyan;
            if (skills >= 60 && skills < 80)
                System.Console.ForegroundColor = System.ConsoleColor.DarkCyan;
            if (skills >= 40 && skills < 60)
                System.Console.ForegroundColor = System.ConsoleColor.Blue;
            if (skills < 40)
                System.Console.ForegroundColor = System.ConsoleColor.DarkBlue;
        }

        protected void setColorAge(int age)
        {
            if (age < 20)
                System.Console.ForegroundColor = System.ConsoleColor.Cyan;
            if (age >= 20 && age < 27)
                System.Console.ForegroundColor = System.ConsoleColor.DarkCyan;
            if (age >= 27 && age < 35)
                System.Console.ForegroundColor = System.ConsoleColor.Blue;
            if (age >= 35)
                System.Console.ForegroundColor = System.ConsoleColor.DarkBlue;
        }

        public static void setColor(Position position)
        {
            if (position == Position.goalkeeper)
                System.Console.ForegroundColor = System.ConsoleColor.Green;
            if (position == Position.defender)
                System.Console.ForegroundColor = System.ConsoleColor.Magenta;
            if (position == Position.midfielder)
                System.Console.ForegroundColor = System.ConsoleColor.Yellow;
            if (position == Position.forward)
                System.Console.ForegroundColor = System.ConsoleColor.Blue;
        }

        public static void setColorGray()
        {
            System.Console.ForegroundColor = System.ConsoleColor.DarkGray;
        }
    }
}