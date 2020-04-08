using System;

namespace FootballManager
{
    class WindowGenerator : Window
    {
        public WindowGenerator(string menu)
        {
            this.menu = menu + " >> Generator";
        }

        protected override void draw()
        {
            displayHeader();
            Console.WriteLine(Text.question + "\n");
        }

        protected override void selectOption()
        {
            Console.Write(Text.selectionYesNo);
            selectedOption = Console.ReadLine();
            Console.WriteLine();
            switch (selectedOption)
            {
                case "q": Program.isRunning = false; break;
                case "0": isRunning = false; break;
                case "y":
                case "t":
                    Generator generator = new Generator();
                    if (generator.generuj() == 0)
                    {
                        new Database();
                        Console.WriteLine(Text.confirmation);
                    }
                    else
                       Console.WriteLine(Text.error);
                    Console.ReadKey();
                    isRunning = false;
                    break;
                case "n":
                   Console.WriteLine(Text.failure);
                    Console.ReadKey();
                    isRunning = false;
                    break;
            }
        }

        protected override void update()
        {
            
        }
    }
}
