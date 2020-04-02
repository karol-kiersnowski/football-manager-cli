using System;

namespace FootballManager
{
    class WindowLanguage : Window
    {
        public WindowLanguage()
        {
            options = new string[2];
            options[0] = "English";
            options[1] = "Polski";
        }

        protected override void draw()
        {
			Console.Clear();
            Console.WriteLine(logo);
            Console.WriteLine("Select your language / Wybierz swój język\n");
            for (int i = 0; i < options.Length; i++)
                Console.WriteLine((i+1) + ". " + options[i]);
            Console.WriteLine();
        }

        protected override void selectOption()
        {
            Console.Write(">> ");
            selectedOption = Console.ReadLine();

            switch (selectedOption)
            {
                case "exit": Program.isRunning = false; break;
                case "q": Program.isRunning = false; break;
                case "1": new Text("English"); isRunning = false; break;
                case "2": new Text("Polish"); isRunning = false; break;
            }
        }

        protected override void update()
        {
            
        }
    }
}
