using System;

namespace FootballManager
{
    class WindowFixturesClub : Window
    {
        public WindowFixturesClub(string menu)
        {
            this.menu = menu + " >> " + Text.clubFixtures;
            matches = Games.instance.playerClub.statistics.matches;
        }

        protected override void draw()
        {
            int initialY = displayHeader();

            int x = 0;
            int y = initialY;
            Console.SetCursorPosition(x, y);
            Console.Write(Text.number);
            x += 4;
            Console.SetCursorPosition(x, y);
           Console.Write(Text.host);
            x += 23;
            Console.SetCursorPosition(x, y);
           Console.Write(Text.score);
            x += 6;
            Console.SetCursorPosition(x, y);
            Console.Write(Text.guest);
            for (int i = 0; i < matches.Length; i++)
            {
                x = 0;
                y++;
                Console.SetCursorPosition(x, y);
                Console.Write(matches[i].round + ".");
                x += 4;
                Console.SetCursorPosition(x, y);
                Console.Write(matches[i].host.fullName);
                x += 23;
                Console.SetCursorPosition(x, y);
                Console.Write(matches[i].result);
                x += 6;
                Console.SetCursorPosition(x, y);
                Console.Write(matches[i].guest.fullName);
                x += 23;
            }

            Console.WriteLine("\n");
        }
        protected override void selectOption()
        {
            Console.Write(Text.selectMatch);
            selectedOption = Console.ReadLine();
            if (selectedOption == "q") Program.isRunning = false;
            if (int.TryParse(selectedOption, out selectedNumber))
            {
                if (selectedNumber == 0)
                    isRunning = false;
                if (selectedNumber > 0 && selectedNumber <= 30)
                    new WindowAfterMatch(menu, matches[selectedNumber - 1]).run();
            }
        }

        protected override void update()
        {
            
        }

        Match[] matches;
    }
}
