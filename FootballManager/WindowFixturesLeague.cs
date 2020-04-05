using System;

namespace FootballManager
{
    class WindowFixturesLeague : Window
    {
        public WindowFixturesLeague(string menu)
        {
            this.menu = menu + " >> " + Text.leagueFixtures;
            selectedNumber = 1;
            round = Games.instance.polishLeague1.rounds[0];
        }

        protected override void draw()
        {
            initialY = displayHeader();

            if (selectedNumber > 0 && selectedNumber <= 30)
                Console.Write(round.name);

            int x = 0;
            int y = initialY + 2;

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
            for (int i = 0; i < round.matches.Length; i++)
            {
                x = 0;
                y++;
                Console.SetCursorPosition(x, y);
                Console.Write(i + 1 + ".");
                x += 4;
                Console.SetCursorPosition(x, y);
                Console.Write(round.matches[i].host.fullName);
                x += 23;
                Console.SetCursorPosition(x, y);
                Console.Write(round.matches[i].result);
                x += 6;
                Console.SetCursorPosition(x, y);
                Console.Write(round.matches[i].guest.fullName);
                x += 23;
            }
        }

        protected override void selectOption()
        {
            Console.SetCursorPosition(15, initialY);
            Console.Write(Text.selectRound);
            selectedOption = Console.ReadLine();

            checkBasicOptions();

            int.TryParse(selectedOption, out selectedNumber);
            if (selectedNumber > 0 && selectedNumber <= 30)
                round = Games.instance.polishLeague1.rounds[selectedNumber - 1];
        }

        protected override void update()
        {
            
        }

        Round round;
        int initialY;
    }
}
